using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eshop
{
    public partial class AddToBasketDialog : Form
    {
        // ulozen produkt oznacen pro vlozeni do kosiku 
        public static Product SelectedProduct { get; private set; }

        public AddToBasketDialog(Product selectedProduct)
        {
            SelectedProduct = selectedProduct;
            InitializeComponent();
            CenterToParent();
        }

        // po kliknuti na pridani tlacitka
        private void AddItemButton_Click(object sender, EventArgs e)
        {
            // jestli byl vstup zadan nacte polozka do kolekce tridy Basket
            // za zobrazeni obsahu kosiku odpovida tabla kosik
            if (VerifyQuantityInput())
            {
                int quantity = Convert.ToInt32(QuantityTextBox.Text);
                Basket.AddItem(SelectedProduct, quantity);
            }
            else
            {
                DialogResult = DialogResult.None;
            }
        }

        // po kliknuti na zruseni zavreme dialog pridavani polozky
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        // pokud byl zmacknuty enter pri zadavani mnozstvi, verifikujeme vystup
        // kdyz je vystup platny vyvolame event zmacnknuti tlacitka Pridat
        private void QuantityTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {   
                AddItemButton.PerformClick();
            }
        }

        // kdyz piseme do textboxu verifikujeme jestli barva naznacuje validitu vstupu
        private void QuantityTextBox_TextChanged(object sender, EventArgs e)
        {
            MarkQuantityInput();
        }

        // vraci puvodni barvu fieldu po verifikaci, kdyz je prazdny
        private void QuantityTextBox_Enter(object sender, EventArgs e)
        {
            if (QuantityTextBox.Text.Length == 0)
            {
                QuantityFieldTLPanel.BackColor = SystemColors.GradientInactiveCaption;
            }
        }

        /*** Pomocne metody ***/

        // oznac nekorektni vstup
        public void MarkQuantityInput()
        {
            string quantityString = QuantityTextBox.Text;

            // nekorektni vstup oznacen jinou barvou nez korektni
            if (!int.TryParse(quantityString, out int quantity))
            {
                QuantityFieldTLPanel.BackColor = Color.MistyRose;
            }
            else
            {
                QuantityFieldTLPanel.BackColor = SystemColors.GradientInactiveCaption;
            }
        }

        public bool VerifyQuantityInput()
        {
            string quantityString = QuantityTextBox.Text;
            if (!(int.TryParse(quantityString, out int quantity)
                && quantityString.Length > 0))
            {
                QuantityTextBox.Clear();
                QuantityFieldTLPanel.BackColor = Color.MistyRose;
                MessageBox.Show("Počet kusů musí být zadán celým kladným číslem.", "Chyba formátu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                return false;
            }
            else // pokud je cislo zadano spravne
            {
                if (quantityString == "0")
                {
                    QuantityTextBox.Clear();
                    QuantityFieldTLPanel.BackColor = Color.MistyRose;
                    MessageBox.Show("Přidejte prosím alespoň jeden produkt.", "Špatný počet kusů",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                    return false;
                }
                else
                {
                    QuantityFieldTLPanel.BackColor = SystemColors.GradientInactiveCaption;
                    return true;
                }
            }
        }

    }
}
