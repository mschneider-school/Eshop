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
            CenterToParent();
        }

        // pokud byl produkt predany pri konstrukci formulare
        // nactou se detaily produktu do odp. casti formulare
        private void LoadProductDetails(Product product)
        {
            if (product != null)
            {
                ProductPictureBox.Image = product.Photo;
                ProductNameLabel.Text = product.Name;
                ProductIDValueLabel.Text = product.ID.ToString();
                ProductCathegoryValueLabel.Text = product.Cathegory;
                ProductPriceValueLabel.Text = product.Price.ToString("N0");
                DescriptionRTBox.Text = product.Description;
            }
        }

        // po zmacknuti Escape se Detail produktu zavre
        private void ProductDetailsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
