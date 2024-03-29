﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Eshop
{
    /// <summary>
    /// Formular slouzi k validaci prihlasovacich udaju a prihlaseni uzivatele
    /// </summary>
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

        /// <summary>
        /// Udalost kliknuti na tlacitko Prihlasit: overeni udaju a prihlaseni zakaznika nebo admina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    Message.InvalidPasswordWarning();
                    PasswordTextBox.Clear();
                }
            }
            // prihlaseni zakaznika
            else
            {
                string userEmail = UserNameTextBox.Text;
                string userPassword = PasswordTextBox.Text;

                Customer customer = Database.GetVerifiedCustomer(userEmail, userPassword);

                if (customer != null)
                {
                    Session.LoginCustomer(customer);
                    Close();
                }
                else
                {
                    UserNameTextBox.Clear();
                    PasswordTextBox.Clear();
                    UserNameTLPanel.BackColor = Color.MistyRose;
                    PasswordTLPanel.BackColor = Color.MistyRose;
                    Message.InvalidCredentialsWarning();
                }
            }
        }

        /*** Vraceni designu do puvodniho stavu po zmene chybne zadanych poli ***/

        /// <summary>
        /// Udalost vstupu do pole Email: reset barvy na puvodni
        /// </summary>
        private void UserNameTextBox_Enter(object sender, EventArgs e)
        {
            UserNameTLPanel.BackColor = SystemColors.GradientInactiveCaption;
        }

        /// <summary>
        /// Udalost vstupu do pole Heslo: reset barvy na puvodni
        /// </summary>
        private void PasswordTextBox_Enter(object sender, EventArgs e)
        {
            PasswordTLPanel.BackColor = SystemColors.GradientInactiveCaption;
        }

        /// <summary>
        /// Udalost zmacknuti klavesy: Enter zavre prihlasovaci formular
        /// </summary>
        private void LoginRegisterDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
