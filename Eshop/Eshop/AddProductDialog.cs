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
            AddProductSplitContainer.SplitterWidth = 10;
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

        private void AddProductSplitContainer_Panel1_SizeChanged(object sender, EventArgs e)
        {
            var splitPanel = AddProductSplitContainer.Panel1;
            var detailsPanel = ProductDetailsFLPanel;
            if (splitPanel.Width < 380 || detailsPanel.Height > 147)
            {
                if (detailsPanel.Bottom > detailsPanel.Height)
                {
                    detailsPanel.AutoScroll = true;
                }
                
                ProductIDTLPanel.Width = splitPanel.Width - 40;
                ProductNameTLPanel.Width = splitPanel.Width - 40;
                ProductCathegoryTLPanel.Width = splitPanel.Width - 40;
                ProductPriceTLPanel.Width = splitPanel.Width - 40;
                ProductDescriptionRTBox.Width = splitPanel.Width - 40;
            }
            else
            {
                ProductDetailsFLPanel.AutoScroll = false;
                ProductIDTLPanel.Width = splitPanel.Width / 2 - 15;
                ProductNameTLPanel.Width = splitPanel.Width / 2 - 15;
                ProductCathegoryTLPanel.Width = splitPanel.Width / 2 - 15;
                ProductPriceTLPanel.Width = splitPanel.Width / 2 - 15;
                ProductDescriptionRTBox.Width = splitPanel.Width / 2 - 15;
            }
        }
    }
}
