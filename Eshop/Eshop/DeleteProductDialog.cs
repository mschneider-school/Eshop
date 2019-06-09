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
    public partial class DeleteProductDialog : Form
    {
        public DeleteProductDialog(Product selectedProduct = null)
        {
            InitializeComponent();
        }

        private void CancelActionButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfirmActionButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
