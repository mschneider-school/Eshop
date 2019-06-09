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
    public partial class ProductDetailsForm : Form
    {
        public ProductDetailsForm(Product product = null)
        {
            InitializeComponent();
            ProductDetailsSplitContainer.SplitterWidth = 15;
            LoadProductDetails(product);
        }

        // pokud byl produkt predany pri konstrukci formulare
        // nactou se detaily produktu do odp. casti formulare
        private void LoadProductDetails(Product product)
        {
            if (product != null)
            {
                ProductPictureBox.Image = product.Photo;
                ProductIDValueLabel.Text = product.ID.ToString();
                ProductCathegoryValueLabel.Text = product.Cathegory;
                ProductPriceValueLabel.Text = product.Price.ToString();
                DescriptionRTBox.Text = product.Description;
            }
        }
    }
}
