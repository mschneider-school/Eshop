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
    public partial class AddProductDialog : Form
    {
        public AddProductDialog()
        {
            InitializeComponent();
            AddProductSplitContainer.SplitterWidth = 15;
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
        /// <summary>
        /// Vymazani formulare a pridaneho obrazku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearFormButton_Click(object sender, EventArgs e)
        {
            // polozky formulare nastaveny na puvodni hodnotu 
            ProductIDTextBox.Clear();
            ProductNameTextBox.Clear();
            ProductCathegoryCBox.SelectedIndex = -1;
            ProductCathegoryCBox.ResetText();
            ProductPriceTextBox.Clear();
            ProductDescriptionRTBox.Clear();

            // obrazek je smazan
            ProductPictureBox.ImageLocation = string.Empty;
        }
    }
}
