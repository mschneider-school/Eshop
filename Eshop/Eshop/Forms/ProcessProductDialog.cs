using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eshop
{
    public partial class ProcessProductDialog : Form
    {
        public MainForm MainForm { get; private set; }
        public Product UpdateProduct { get; private set; }
        public List<Control> EntriesToValidate { get; private set; }

        public ProcessProductDialog(MainForm mainForm = null, Product updateProduct = null)
        {
            MainForm = mainForm;
            UpdateProduct = updateProduct;
            Load += ProcessProductDialog_Load;
            InitializeComponent();
            AddProductSplitContainer.SplitterWidth = 15;
            CenterToParent();
        }

        private void ProcessProductDialog_Load(object sender, EventArgs e)
        {
            EntriesToValidate = new List<Control>()
            {
                ProductNameTextBox, ProductPriceTextBox, ProductCathegoryCBox
            };

            // pokud byl form spusten s produktem uprav charakteristiky
            if (UpdateProduct != null)
            {
                LoadSelectedProductDetails();
                Text = $"Úprava produktu: {UpdateProduct.Name}";
                RevertChangesButton.Text = "Vrátit změny";
            }
        }

        // metoda se spusti pouze kdyz je form spousten s parametrem changeProduct
        private void LoadSelectedProductDetails()
        {
            ProductNameTextBox.Text = UpdateProduct.Name;
            ProductPriceTextBox.Text = UpdateProduct.Price.ToString();
            ProductCathegoryCBox.Text = UpdateProduct.Cathegory;
            ProductDescriptionRTBox.Text = UpdateProduct.Description;
            ProductPictureBox.Image = UpdateProduct.Photo;
        }

        private void LoadPhotoButton_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog loadPicture = new OpenFileDialog())
            {
                loadPicture.Filter = "Image Files(*.JPG;*.PNG;*.BMP)|*.JPG;*.PNG;*.BMP";
                loadPicture.RestoreDirectory = true;

                if (loadPicture.ShowDialog() == DialogResult.OK)
                {
                    // cesta vybraneho souboru
                    filePath = loadPicture.FileName;
                    ProductPictureBox.ImageLocation = filePath;
                }
            }
        }

        private void RevertChangesButton_Click(object sender, EventArgs e)
        {
            // pokud je formular urcen k pridani produktu po zmacknuti revert vycisti form
            if (UpdateProduct == null)
            {
                ClearForm();
            }
            else // jinak vrat upravy a nacti udaje puvodniho produktu
            {
                LoadSelectedProductDetails();
            }
        }

        /// <summary>
        /// Vymazani formulare a pridaneho obrazku
        /// </summary>
        private void ClearForm()
        {
            // polozky formulare nastaveny na puvodni hodnotu 
            ProductNameTextBox.Clear();
            ProductCathegoryCBox.SelectedIndex = -1;
            ProductCathegoryCBox.ResetText();
            ProductPriceTextBox.Clear();
            ProductDescriptionRTBox.Clear();

            // obrazek je smazan
            ProductPictureBox.ImageLocation = string.Empty;
        }

        // zakaze editaci pole kategorii
        private void ProductCathegoryCBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void SaveProductButton_Click(object sender, EventArgs e)
        {
            // kdyz okno slouzi k ukladani noveho produktu
            if (UpdateProduct == null)
            {
                SaveNewProduct();
            }
            else
            {
                UpdateExistingProduct();
            }
        }

        /*** Vraceni designu do puvodniho stavu po zmene chybne zadanych poli ***/

        private void ProductNameTextBox_Enter(object sender, EventArgs e)
        {
            ProductNameTLPanel.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void ProductCathegoryCBox_Enter(object sender, EventArgs e)
        {
            ProductCathegoryTLPanel.BackColor = SystemColors.GradientInactiveCaption;
        }

        // oznacit spatny vstup do pole ceny barevne
        private void ProductPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            string priceString = ProductPriceTextBox.Text;

            if (!int.TryParse(priceString, out int price) 
                && priceString.Length > 0)
            {
                ProductPriceTLPanel.BackColor = Color.MistyRose;
                Message.QuantityFormatWarning();
            }
            else
            {
                ProductPriceTLPanel.BackColor = SystemColors.GradientInactiveCaption;
            }
        }

        /*** Pomocne metody ke zpracovani vstupu ***/

        private bool IsPriceValid()
        {
            if (!int.TryParse(ProductPriceTextBox.Text, out int price))
            {
                return false;
            }
            return true;
        }

        // uloz novy produkt do databaze a zobraz jej v dataGridView
        private void SaveNewProduct()
        {
            
            // zaznamena jestli byli vsechny povinne polozky vyplneny
            bool allValid = Message.InvalidEntriesCheck(EntriesToValidate, Color.MistyRose);

            // pokud nejsou detaily v poradku zobrazi se upozorneni
            if (!allValid || !IsPriceValid())
            {
                Message.InvalidEntriesWarning();
            }
            //  jinak se provede ulozeni produktu do databaze
            else
            {
                // sestav produkt z vlozenych parametru
                Product builtProduct = BuildProductFromDetails();

                // vytvor produkt v databazi
                Database.CreateProduct(builtProduct);

                // zobrazi produkt v productdgview a zavre form 
                MainForm.ShowNewProduct(builtProduct);
                Close();
            }
        }

        private void UpdateExistingProduct()
        {
            // zaznamena jestli byli vsechny povinne polozky vyplneny
            bool allValid = Message.InvalidEntriesCheck(EntriesToValidate, Color.MistyRose);

            // pokud nejsou detaily v poradku zobrazi se upozorneni
            if (!allValid || !IsPriceValid())
            {
                Message.InvalidEntriesWarning();
            }
            else // jinak se produkt aktualizuje
            {
                // sestav produkt z vlozenych parametru
                Product builtProduct = BuildProductFromDetails();

                // uprav produkt v databazi
                Database.UpdateProduct(builtProduct);

                // nacteme upravovany produkt z cache podle ID
                Product cachedToUpdate =
                    Database.CachedProducts.First(p => p.ID == builtProduct.ID);

                // zjistime index upr. produktu a pak na nem ulozime upraveny produkt
                var indexOfUpdated = Database.CachedProducts.IndexOf(cachedToUpdate);
                if (indexOfUpdated != -1)
                {
                    Database.CachedProducts[indexOfUpdated] = builtProduct;
                }

                Close();
            }
        }

        // sestroj produkt podle udaju z formulare
        private Product BuildProductFromDetails()
        {
            int id = -1;
            //  pro aktualizaci produktu se nacte ID soucasneho produktu
            if (UpdateProduct != null)
                id = UpdateProduct.ID;

            string name = ProductNameTextBox.Text.Trim();
            string cathegory = ProductCathegoryCBox.Text.Trim();

            string priceString = ProductPriceTextBox.Text.Trim();
            int price = Convert.ToInt32(priceString);

            Image photo = ProductPictureBox.Image;
            string description = ProductDescriptionRTBox.Text.Trim();

            Product builtProduct = new Product
            (
                name,
                cathegory,
                price,
                photo,
                description,
                id
            );

            return builtProduct;
        }
    }
}
