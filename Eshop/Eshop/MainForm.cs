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
        private bool adminLogged = false;

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
            DeleteProductDialog deleteProduct = new DeleteProductDialog
            {
                StartPosition = StartPosition,
            };
            deleteProduct.ShowDialog();
        }

        private void ProductDetailButton_Click(object sender, EventArgs e)
        {
            ProductDetailsForm productDetails = new ProductDetailsForm
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
                && !adminLogged)
            {
                LoginRegisterDialog adminLogin = new LoginRegisterDialog();
                adminLogin.TransformToAdminLogin();
                adminLogin.ShowDialog();
            }
        }
    }
}
