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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Shown += MainForm_Shown;
            Load += MainForm_Load;
        }

        private void MainForm_Load(Object sender, EventArgs e)
        {
            
        }

        private void MainForm_Shown(Object sender, EventArgs e)
        {
            SaveLogDialog logPrompt = new SaveLogDialog
            {
                StartPosition = FormStartPosition.CenterParent
            };
            logPrompt.ShowDialog();

            Logger logger = new Logger();
            if (Logger.IsFileLog())
            {
                Logger.Log("Log nenastaveny na file");
            }

            Logger.Log("START");
            Logger.Log("08/11/2019 12:28:13 user created order 256 in total 2500 CZK");
            Logger.Log("08/11/2019 12:38:13 user canceled order 256 in total 4500 CZK");
            Logger.Log("08/11/2019 12:40:15 admin received order 256 in total 700 CZK");
            Logger.Log("END");
        }

        /// <summary>
        /// Deaktivuje ramecek kolem tably, focus nastavi na zadny element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserViewsTabControl_Enter(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            AddProductDialog addProduct = new AddProductDialog
            {
                StartPosition = StartPosition,
            };
            addProduct.ShowDialog();
        }

        private void UpdateProductButton_Click(object sender, EventArgs e)
        {
            UpdateProductDialog updateProduct = new UpdateProductDialog
            {
                StartPosition = StartPosition,
            };
            updateProduct.ShowDialog();
        }

        private void DeleteProductButton_Click(object sender, EventArgs e)
        {
            DeleteConfirmDialog deleteProduct = new DeleteConfirmDialog
            {
                StartPosition = StartPosition,
            };
            deleteProduct.ShowDialog();
        }

        private void ProductDetailButton_Click(object sender, EventArgs e)
        {
            DetailsForm productDetails = new DetailsForm
            {
                StartPosition = StartPosition,
            };
            productDetails.ShowDialog();
        }
    }
}
