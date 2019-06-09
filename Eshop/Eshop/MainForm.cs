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
            ProductsDataGridView.DoubleBuffered(true);
            OrdersDataGridView.DoubleBuffered(true);

            // nahraje produktova data z databaze do pameti
            Database.ReadTableData(Database.loadProducts, Database.LoadProductsCommand);

            // nahraje data kategorii z db do pameti
            Database.ReadTableData(Database.loadCathegories, Database.LoadCathegoriesCommand);
            
            // zobrazi data produktu z pameti v produktove table
            Database.DisplayLoadedProducts(ProductsDataGridView);
        }

        private void MainForm_Shown(Object sender, EventArgs e)
        {
            SaveLogDialog logPrompt = new SaveLogDialog
            {
                StartPosition = StartPosition
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

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            ProcessProductDialog addProduct = new ProcessProductDialog(this)
            {
                StartPosition = StartPosition,
            };
            addProduct.ShowDialog();
        }

        private void UpdateProductButton_Click(object sender, EventArgs e)
        {
            ProcessProductDialog updateProduct = new ProcessProductDialog(this, GetSelectedProduct())
            {
                StartPosition = StartPosition,
            };
            DialogResult result = updateProduct.ShowDialog();
            
            // po uprave produktu v databazi i cache
            // aktualizujeme datagridview
            if (result == DialogResult.OK)
            {
                ProductsDataGridView.Rows.Clear();
                Database.DisplayLoadedProducts(ProductsDataGridView);
            }
        }

        private void DeleteProductButton_Click(object sender, EventArgs e)
        {
            DeleteProductDialog deleteProduct = new DeleteProductDialog
            {
                StartPosition = StartPosition,
            };

            // to store a result
            DialogResult result = deleteProduct.ShowDialog();
           
            // when deleting is confirmed, remove the product from the gridview
            if (result == DialogResult.Yes)
            {
                // remove product from cache
                Product selectedProduct = GetSelectedProduct();
                Database.CachedProducts.Remove(selectedProduct);

                // remove product from datagridview
                RemoveSelectedRow(ProductsDataGridView);

                // delete product in database
                Database.DeleteProduct(selectedProduct);
            }
        }

        // zobrazeni formulare s detailem produktu
        private void ProductDetailButton_Click(object sender, EventArgs e)
        {
            Product selectedProduct = GetSelectedProduct();

            ProductDetailsForm productDetails = new ProductDetailsForm(selectedProduct)
            {
                StartPosition = StartPosition,
            };
            
            productDetails.ShowDialog();
        }

        private void LoginToOrderButton_Click(object sender, EventArgs e)
        {
            LoginRegisterDialog customerLogin = new LoginRegisterDialog
            {
                StartPosition = StartPosition,
            };
            customerLogin.Text = "Přihlášení zákazníka";
            customerLogin.ShowDialog();
        }

        private void CustomerOrderDetailButton_Click(object sender, EventArgs e)
        {
            OrderDetailForm customerOrderDetail = new OrderDetailForm
            {
                StartPosition = StartPosition,
            };
            customerOrderDetail.ShowDialog();
        }

        private void AdminOrderDetailButton_Click(object sender, EventArgs e)
        {
            OrderDetailForm adminOrderDetail = new OrderDetailForm
            {
                StartPosition = StartPosition,
            };
            adminOrderDetail.ShowDialog();
        }

        private void LoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginRegisterDialog customerLogin = new LoginRegisterDialog();
            customerLogin.ShowDialog();
        }

        private void UserViewsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UserViewsTabControl.SelectedTab == UserViewsTabControl.TabPages["adminTabPage"]
                && !Session.AdminLoggedIn)
            {
                LoginRegisterDialog adminLogin = new LoginRegisterDialog();
                adminLogin.TransformToAdminLogin();
                adminLogin.ShowDialog();
            }
        }

        /*** POMOCNE METODY HLAVNIHO FORMULARE K PROVEDENI UI UPRAV ***/

        /// <summary>
        /// Vybere a vrati objekt Produkt vybrany 
        /// </summary>
        /// <returns></returns>
        private Product GetSelectedProduct()
        {
            long selectedProductID = Convert.ToInt64(ProductsDataGridView.SelectedRows[0].Cells[0].Value);
            Product selectedProduct = Database.GetCachedProductByID(selectedProductID);

            return selectedProduct;
        }

        // vymaze polozku z GridView
        private void RemoveSelectedRow(DataGridView dataGridView)
        {
            dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);
        }

        // zobrazi novy produkt
        public void DisplayNewProduct(Product product)
        {
             ProductsDataGridView.Rows.Add(product.ID, product.Name, 
                 product.Cathegory, product.Price);
        }
    }
}
