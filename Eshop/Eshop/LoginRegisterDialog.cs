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
        public bool adminLogin = false;

        public LoginRegisterDialog()
        {
            InitializeComponent();
            CenterToParent();
        }

        /// <summary>
        /// Transformuje prihlasovaci formular pro prihlaseni administratora.
        /// Email administratora je predvyplnen podle udaju tridy Administrator, nelze menit.
        /// Volba nove registrace pomoci tlacitka je zakazana. Tlacitko prihlasit meni nazev 
        /// na LoginAdminButton pro vyuziti v spracovani prihlaseni administratora.
        /// </summary>
        public void TransformToAdminLogin()
        {
            Text = "Přihlášení administrátora";
            UserNameTextBox.Text = Administrator.Email;
            UserNameTextBox.Enabled = false;
            LoginUserButton.Name = "LoginAdminButton";
            RegisterCustomerButton.Enabled = false;
            adminLogin = true;
        }

        // prihlaseni uzivatele do systemu
        private void LoginUserButton_Click(object sender, EventArgs e)
        {
            // prihlaseni administratora
            if (adminLogin) 
            {
                if (PasswordTextBox.Text == Administrator.Password)
                {
                    Session.LoginAdmin();
                    Close();
                }
                else
                {
                    PasswordTLPanel.BackColor = Color.MistyRose;
                    MessageBox.Show("Zadali jste špatné heslo, zkuste to prosím znovu.", "Nesprávné heslo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    PasswordTextBox.Clear();
                }
            }
            // prihlaseni zakaznika
            else
            {
                string userEmail = UserNameTextBox.Text;
                string userPassword = PasswordTextBox.Text;

                Customer foundCustomer = Database.GetVerifiedCustomer(userEmail, userPassword);

                if (foundCustomer != null)
                {
                    Session.LoginCustomer(foundCustomer);
                    Close();
                }
                else
                {
                    UserNameTextBox.Clear();
                    PasswordTextBox.Clear();
                    UserNameTLPanel.BackColor = Color.MistyRose;
                    PasswordTLPanel.BackColor = Color.MistyRose;
                    MessageBox.Show("Zadali jste špatný email nebo heslo, zkuste to prosím znovu.", "Nesprávné údaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
        }

        /*** Vraceni designu do puvodniho stavu po zmene chybne zadanych poli ***/

        private void UserNameTextBox_Enter(object sender, EventArgs e)
        {
            UserNameTLPanel.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void PasswordTextBox_Enter(object sender, EventArgs e)
        {
            PasswordTLPanel.BackColor = SystemColors.GradientInactiveCaption;
        }
    }
}
