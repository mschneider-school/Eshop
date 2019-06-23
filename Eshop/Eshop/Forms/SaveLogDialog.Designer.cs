namespace Eshop
{
    partial class SaveLogDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveLogDialog));
            this.ConfirmWrapperTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ConfirmButtonsTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ConsoleOptionButton = new System.Windows.Forms.Button();
            this.FileOptionButton = new System.Windows.Forms.Button();
            this.ConfirmationLabel = new System.Windows.Forms.Label();
            this.ConfirmWrapperTLPanel.SuspendLayout();
            this.ConfirmButtonsTLPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfirmWrapperTLPanel
            // 
            this.ConfirmWrapperTLPanel.AutoSize = true;
            this.ConfirmWrapperTLPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ConfirmWrapperTLPanel.BackColor = System.Drawing.SystemColors.Control;
            this.ConfirmWrapperTLPanel.ColumnCount = 1;
            this.ConfirmWrapperTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConfirmWrapperTLPanel.Controls.Add(this.ConfirmButtonsTLPanel, 0, 1);
            this.ConfirmWrapperTLPanel.Controls.Add(this.ConfirmationLabel, 0, 0);
            this.ConfirmWrapperTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfirmWrapperTLPanel.Location = new System.Drawing.Point(0, 0);
            this.ConfirmWrapperTLPanel.Name = "ConfirmWrapperTLPanel";
            this.ConfirmWrapperTLPanel.RowCount = 2;
            this.ConfirmWrapperTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConfirmWrapperTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.ConfirmWrapperTLPanel.Size = new System.Drawing.Size(351, 192);
            this.ConfirmWrapperTLPanel.TabIndex = 0;
            // 
            // ConfirmButtonsTLPanel
            // 
            this.ConfirmButtonsTLPanel.AutoSize = true;
            this.ConfirmButtonsTLPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ConfirmButtonsTLPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ConfirmButtonsTLPanel.ColumnCount = 2;
            this.ConfirmButtonsTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ConfirmButtonsTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ConfirmButtonsTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ConfirmButtonsTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ConfirmButtonsTLPanel.Controls.Add(this.ConsoleOptionButton, 1, 0);
            this.ConfirmButtonsTLPanel.Controls.Add(this.FileOptionButton, 0, 0);
            this.ConfirmButtonsTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfirmButtonsTLPanel.Location = new System.Drawing.Point(0, 119);
            this.ConfirmButtonsTLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ConfirmButtonsTLPanel.Name = "ConfirmButtonsTLPanel";
            this.ConfirmButtonsTLPanel.RowCount = 1;
            this.ConfirmButtonsTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConfirmButtonsTLPanel.Size = new System.Drawing.Size(351, 73);
            this.ConfirmButtonsTLPanel.TabIndex = 1;
            // 
            // ConsoleOptionButton
            // 
            this.ConsoleOptionButton.AutoSize = true;
            this.ConsoleOptionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsoleOptionButton.Location = new System.Drawing.Point(182, 21);
            this.ConsoleOptionButton.Margin = new System.Windows.Forms.Padding(7, 21, 7, 19);
            this.ConsoleOptionButton.Name = "ConsoleOptionButton";
            this.ConsoleOptionButton.Size = new System.Drawing.Size(162, 33);
            this.ConsoleOptionButton.TabIndex = 0;
            this.ConsoleOptionButton.TabStop = false;
            this.ConsoleOptionButton.Text = "Konzole";
            this.ConsoleOptionButton.UseVisualStyleBackColor = true;
            this.ConsoleOptionButton.Click += new System.EventHandler(this.ConsoleOptionButton_Click);
            // 
            // FileOptionButton
            // 
            this.FileOptionButton.AutoSize = true;
            this.FileOptionButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.FileOptionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileOptionButton.Location = new System.Drawing.Point(7, 21);
            this.FileOptionButton.Margin = new System.Windows.Forms.Padding(7, 21, 7, 19);
            this.FileOptionButton.Name = "FileOptionButton";
            this.FileOptionButton.Size = new System.Drawing.Size(161, 33);
            this.FileOptionButton.TabIndex = 0;
            this.FileOptionButton.TabStop = false;
            this.FileOptionButton.Text = "Soubor";
            this.FileOptionButton.UseVisualStyleBackColor = true;
            this.FileOptionButton.Click += new System.EventHandler(this.FileOptionButton_Click);
            // 
            // ConfirmationLabel
            // 
            this.ConfirmationLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ConfirmationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfirmationLabel.Location = new System.Drawing.Point(0, 0);
            this.ConfirmationLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ConfirmationLabel.Name = "ConfirmationLabel";
            this.ConfirmationLabel.Size = new System.Drawing.Size(351, 119);
            this.ConfirmationLabel.TabIndex = 0;
            this.ConfirmationLabel.Text = "Vyberte prosím místo pro záznamy o běhu aplikace";
            this.ConfirmationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SaveLogDialog
            // 
            this.AcceptButton = this.FileOptionButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.FileOptionButton;
            this.ClientSize = new System.Drawing.Size(351, 192);
            this.Controls.Add(this.ConfirmWrapperTLPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveLogDialog";
            this.Text = "Vítejte!";
            this.ConfirmWrapperTLPanel.ResumeLayout(false);
            this.ConfirmWrapperTLPanel.PerformLayout();
            this.ConfirmButtonsTLPanel.ResumeLayout(false);
            this.ConfirmButtonsTLPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel ConfirmWrapperTLPanel;
        private System.Windows.Forms.Label ConfirmationLabel;
        private System.Windows.Forms.TableLayoutPanel ConfirmButtonsTLPanel;
        private System.Windows.Forms.Button ConsoleOptionButton;
        private System.Windows.Forms.Button FileOptionButton;
    }
}