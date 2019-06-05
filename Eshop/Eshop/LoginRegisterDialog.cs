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
    public partial class LoginRegisterDialog : Form
    {
        public LoginRegisterDialog()
        {
            InitializeComponent();
            CenterToParent();
        }

        public void TransformToAdminLogin()
        {
            Text = "Přihlášení administrátora";
            EmailLabel.Text = "Uživatel";
            UserNameTextBox.Text = "admin";
            UserNameTextBox.Enabled = false;
            RegisterCustomerButton.Enabled = false;
        }
    }
}
