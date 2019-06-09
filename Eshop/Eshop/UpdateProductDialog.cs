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
    public partial class UpdateProductDialog : Form
    {
        public UpdateProductDialog()
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

        // zakaze editaci pole kategorii
        private void ProductCathegoryCBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
