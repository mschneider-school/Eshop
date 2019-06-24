using System;
using System.Drawing;
using System.Windows.Forms;

namespace Eshop
{
    /// <summary>
    /// Formular slouzi k pridani produktu ve zvolenem mnozstvi do kosiku
    /// </summary>
    public partial class AddToBasketDialog : Form
    {
        // ulozen produkt oznacen pro vlozeni do kosiku 
        public static Product SelectedProduct { get; private set; }

        /// <summary>
        /// Konstruktor zobrazi formular s udaji produktu
        /// </summary>
        /// <param name="selectedProduct">vybrany produkt</param>
        public AddToBasketDialog(Product selectedProduct)
        {
            SelectedProduct = selectedProduct;
            InitializeComponent();
            CenterToParent();
        }

        /// <summary>
        /// Udalost kliknuti na tlacitko Pridat overi vstup a prida polozku do kosiku
        /// </summary>
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

        /// <summary>
        /// Udalost zmacknuti klavesy: Enter aktivuje pridavani polozky
        /// </summary>
        private void QuantityTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {   
                AddItemButton.PerformClick();
            }
        }

        /// <summary>
        /// Udalost zmeny textu v poli mnozstvi polozky: vstup se overi pro chybovost
        /// </summary>
        private void QuantityTextBox_TextChanged(object sender, EventArgs e)
        {
            MarkQuantityInput();
        }

        /// <summary>
        /// Udalost vstupu do pole mnozstvi polozky: reset barvy na puvodni
        /// </summary>
        private void QuantityTextBox_Enter(object sender, EventArgs e)
        {
            if (QuantityTextBox.Text.Length == 0)
            {
                QuantityFieldTLPanel.BackColor = SystemColors.GradientInactiveCaption;
            }
        }

        /*** Pomocne metody overeni vstupnich udaju ***/

        /// <summary>
        /// Zvyrazni nekorektne zadany udaj mnozstvi pridavane polozky
        /// </summary>
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

        /// <summary>
        /// Overi spravnost udaju mnozstvi pridavane polozky.
        /// Vstup musi byt ciselny, nesmi byt prazdny ani 0.
        /// </summary>
        /// <returns></returns>
        public bool VerifyQuantityInput()
        {
            string quantityString = QuantityTextBox.Text;
            if (!(int.TryParse(quantityString, out int quantity)
                && quantityString.Length > 0))
            {
                QuantityTextBox.Clear();
                QuantityFieldTLPanel.BackColor = Color.MistyRose;
                Message.QuantityFormatWarning();
                return false;
            }
            else // pokud je cislo zadano spravne
            {
                if (quantityString == "0")
                {
                    QuantityTextBox.Clear();
                    QuantityFieldTLPanel.BackColor = Color.MistyRose;
                    Message.NullQuantityWarning();
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
