using System.Windows.Forms;

namespace Eshop
{
    /// <summary>
    /// Formular detailu produktu
    /// </summary>
    public partial class ProductDetailsForm : Form
    {
        public ProductDetailsForm(Product product = null)
        {
            InitializeComponent();
            ProductDetailsSplitContainer.SplitterWidth = 15;
            LoadProductDetails(product);
            CenterToParent();
        }

        /// <summary>
        /// Nacteni detailu produktu do formulare
        /// </summary>
        /// <param name="product"></param>
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

        /// <summary>
        /// Udalost zmacknuti klavesy: zmacnknuti Escape klavesy zavre formular detailu produktu
        /// </summary>
        private void ProductDetailsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
