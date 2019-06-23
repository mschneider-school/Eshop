namespace Eshop
{
    partial class LoginRegisterDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginRegisterDialog));
            this.ConfirmWrapperTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ConfirmButtonsTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RegisterCustomerButton = new System.Windows.Forms.Button();
            this.LoginUserButton = new System.Windows.Forms.Button();
            this.CredentialsWrapperTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PasswordTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.LoginPasswordLabel = new System.Windows.Forms.Label();
            this.UserNameTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.ConfirmWrapperTLPanel.SuspendLayout();
            this.ConfirmButtonsTLPanel.SuspendLayout();
            this.CredentialsWrapperTLPanel.SuspendLayout();
            this.PasswordTLPanel.SuspendLayout();
            this.UserNameTLPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfirmWrapperTLPanel
            // 
            this.ConfirmWrapperTLPanel.AutoSize = true;
            this.ConfirmWrapperTLPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ConfirmWrapperTLPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ConfirmWrapperTLPanel.ColumnCount = 1;
            this.ConfirmWrapperTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConfirmWrapperTLPanel.Controls.Add(this.ConfirmButtonsTLPanel, 0, 1);
            this.ConfirmWrapperTLPanel.Controls.Add(this.CredentialsWrapperTLPanel, 0, 0);
            this.ConfirmWrapperTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfirmWrapperTLPanel.Location = new System.Drawing.Point(0, 0);
            this.ConfirmWrapperTLPanel.Name = "ConfirmWrapperTLPanel";
            this.ConfirmWrapperTLPanel.RowCount = 2;
            this.ConfirmWrapperTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConfirmWrapperTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.ConfirmWrapperTLPanel.Size = new System.Drawing.Size(351, 232);
            this.ConfirmWrapperTLPanel.TabIndex = 0;
            // 
            // ConfirmButtonsTLPanel
            // 
            this.ConfirmButtonsTLPanel.AutoSize = true;
            this.ConfirmButtonsTLPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ConfirmButtonsTLPanel.ColumnCount = 2;
            this.ConfirmButtonsTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ConfirmButtonsTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ConfirmButtonsTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ConfirmButtonsTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ConfirmButtonsTLPanel.Controls.Add(this.RegisterCustomerButton, 1, 0);
            this.ConfirmButtonsTLPanel.Controls.Add(this.LoginUserButton, 0, 0);
            this.ConfirmButtonsTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfirmButtonsTLPanel.Location = new System.Drawing.Point(0, 174);
            this.ConfirmButtonsTLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ConfirmButtonsTLPanel.Name = "ConfirmButtonsTLPanel";
            this.ConfirmButtonsTLPanel.RowCount = 1;
            this.ConfirmButtonsTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConfirmButtonsTLPanel.Size = new System.Drawing.Size(351, 58);
            this.ConfirmButtonsTLPanel.TabIndex = 1;
            // 
            // RegisterCustomerButton
            // 
            this.RegisterCustomerButton.AutoSize = true;
            this.RegisterCustomerButton.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.RegisterCustomerButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegisterCustomerButton.Location = new System.Drawing.Point(182, 13);
            this.RegisterCustomerButton.Margin = new System.Windows.Forms.Padding(7, 13, 10, 15);
            this.RegisterCustomerButton.Name = "RegisterCustomerButton";
            this.RegisterCustomerButton.Size = new System.Drawing.Size(159, 30);
            this.RegisterCustomerButton.TabIndex = 4;
            this.RegisterCustomerButton.Text = "Nová registrace";
            this.RegisterCustomerButton.UseVisualStyleBackColor = true;
            // 
            // LoginUserButton
            // 
            this.LoginUserButton.AutoSize = true;
            this.LoginUserButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginUserButton.Location = new System.Drawing.Point(10, 13);
            this.LoginUserButton.Margin = new System.Windows.Forms.Padding(10, 13, 10, 15);
            this.LoginUserButton.Name = "LoginUserButton";
            this.LoginUserButton.Size = new System.Drawing.Size(155, 30);
            this.LoginUserButton.TabIndex = 3;
            this.LoginUserButton.Text = "Přihlásit se";
            this.LoginUserButton.UseVisualStyleBackColor = true;
            this.LoginUserButton.Click += new System.EventHandler(this.LoginUserButton_Click);
            // 
            // CredentialsWrapperTLPanel
            // 
            this.CredentialsWrapperTLPanel.AutoSize = true;
            this.CredentialsWrapperTLPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CredentialsWrapperTLPanel.ColumnCount = 1;
            this.CredentialsWrapperTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CredentialsWrapperTLPanel.Controls.Add(this.PasswordTLPanel, 0, 1);
            this.CredentialsWrapperTLPanel.Controls.Add(this.UserNameTLPanel, 0, 0);
            this.CredentialsWrapperTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CredentialsWrapperTLPanel.Location = new System.Drawing.Point(0, 10);
            this.CredentialsWrapperTLPanel.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.CredentialsWrapperTLPanel.Name = "CredentialsWrapperTLPanel";
            this.CredentialsWrapperTLPanel.RowCount = 2;
            this.CredentialsWrapperTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CredentialsWrapperTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CredentialsWrapperTLPanel.Size = new System.Drawing.Size(351, 154);
            this.CredentialsWrapperTLPanel.TabIndex = 0;
            this.CredentialsWrapperTLPanel.TabStop = true;
            // 
            // PasswordTLPanel
            // 
            this.PasswordTLPanel.AutoSize = true;
            this.PasswordTLPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PasswordTLPanel.ColumnCount = 1;
            this.PasswordTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PasswordTLPanel.Controls.Add(this.PasswordTextBox, 0, 1);
            this.PasswordTLPanel.Controls.Add(this.LoginPasswordLabel, 0, 0);
            this.PasswordTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PasswordTLPanel.Location = new System.Drawing.Point(11, 82);
            this.PasswordTLPanel.Margin = new System.Windows.Forms.Padding(11, 5, 11, 11);
            this.PasswordTLPanel.Name = "PasswordTLPanel";
            this.PasswordTLPanel.RowCount = 2;
            this.PasswordTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.PasswordTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.PasswordTLPanel.Size = new System.Drawing.Size(329, 61);
            this.PasswordTLPanel.TabIndex = 1;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PasswordTextBox.Location = new System.Drawing.Point(10, 29);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(10, 5, 10, 3);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(309, 20);
            this.PasswordTextBox.TabIndex = 1;
            this.PasswordTextBox.Enter += new System.EventHandler(this.PasswordTextBox_Enter);
            // 
            // LoginPasswordLabel
            // 
            this.LoginPasswordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LoginPasswordLabel.AutoSize = true;
            this.LoginPasswordLabel.Location = new System.Drawing.Point(7, 11);
            this.LoginPasswordLabel.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            this.LoginPasswordLabel.Name = "LoginPasswordLabel";
            this.LoginPasswordLabel.Size = new System.Drawing.Size(56, 13);
            this.LoginPasswordLabel.TabIndex = 0;
            this.LoginPasswordLabel.Text = "Password:";
            this.LoginPasswordLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // UserNameTLPanel
            // 
            this.UserNameTLPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserNameTLPanel.AutoSize = true;
            this.UserNameTLPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.UserNameTLPanel.ColumnCount = 1;
            this.UserNameTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.UserNameTLPanel.Controls.Add(this.UserNameTextBox, 0, 1);
            this.UserNameTLPanel.Controls.Add(this.EmailLabel, 0, 0);
            this.UserNameTLPanel.Location = new System.Drawing.Point(11, 11);
            this.UserNameTLPanel.Margin = new System.Windows.Forms.Padding(11, 11, 11, 5);
            this.UserNameTLPanel.Name = "UserNameTLPanel";
            this.UserNameTLPanel.RowCount = 2;
            this.UserNameTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.UserNameTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.UserNameTLPanel.Size = new System.Drawing.Size(329, 61);
            this.UserNameTLPanel.TabIndex = 0;
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserNameTextBox.Location = new System.Drawing.Point(10, 29);
            this.UserNameTextBox.Margin = new System.Windows.Forms.Padding(10, 5, 10, 3);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(309, 20);
            this.UserNameTextBox.TabIndex = 1;
            this.UserNameTextBox.Enter += new System.EventHandler(this.UserNameTextBox_Enter);
            // 
            // EmailLabel
            // 
            this.EmailLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(7, 11);
            this.EmailLabel.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(35, 13);
            this.EmailLabel.TabIndex = 0;
            this.EmailLabel.Text = "Email:";
            this.EmailLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // LoginRegisterDialog
            // 
            this.AcceptButton = this.LoginUserButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 232);
            this.Controls.Add(this.ConfirmWrapperTLPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "LoginRegisterDialog";
            this.Text = "Přihlášení zákazníka";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginRegisterDialog_KeyDown);
            this.ConfirmWrapperTLPanel.ResumeLayout(false);
            this.ConfirmWrapperTLPanel.PerformLayout();
            this.ConfirmButtonsTLPanel.ResumeLayout(false);
            this.ConfirmButtonsTLPanel.PerformLayout();
            this.CredentialsWrapperTLPanel.ResumeLayout(false);
            this.CredentialsWrapperTLPanel.PerformLayout();
            this.PasswordTLPanel.ResumeLayout(false);
            this.PasswordTLPanel.PerformLayout();
            this.UserNameTLPanel.ResumeLayout(false);
            this.UserNameTLPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel ConfirmWrapperTLPanel;
        private System.Windows.Forms.TableLayoutPanel ConfirmButtonsTLPanel;
        private System.Windows.Forms.Button RegisterCustomerButton;
        private System.Windows.Forms.Button LoginUserButton;
        private System.Windows.Forms.TableLayoutPanel CredentialsWrapperTLPanel;
        private System.Windows.Forms.TableLayoutPanel UserNameTLPanel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.TableLayoutPanel PasswordTLPanel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label LoginPasswordLabel;
    }
}