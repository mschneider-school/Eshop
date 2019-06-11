namespace Eshop
{
    partial class AddToBasketDialog
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
            this.ConfirmWrapperTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ConfirmButtonsTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CancelActionButton = new System.Windows.Forms.Button();
            this.AddItemButton = new System.Windows.Forms.Button();
            this.QuantityEnterTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.QuantityQuestionLabel = new System.Windows.Forms.Label();
            this.QuantityFieldTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.QuantityTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmWrapperTLPanel.SuspendLayout();
            this.ConfirmButtonsTLPanel.SuspendLayout();
            this.QuantityEnterTLPanel.SuspendLayout();
            this.QuantityFieldTLPanel.SuspendLayout();
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
            this.ConfirmWrapperTLPanel.Controls.Add(this.QuantityEnterTLPanel, 0, 0);
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
            this.ConfirmButtonsTLPanel.Controls.Add(this.CancelActionButton, 1, 0);
            this.ConfirmButtonsTLPanel.Controls.Add(this.AddItemButton, 0, 0);
            this.ConfirmButtonsTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfirmButtonsTLPanel.Location = new System.Drawing.Point(0, 119);
            this.ConfirmButtonsTLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ConfirmButtonsTLPanel.Name = "ConfirmButtonsTLPanel";
            this.ConfirmButtonsTLPanel.RowCount = 1;
            this.ConfirmButtonsTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConfirmButtonsTLPanel.Size = new System.Drawing.Size(351, 73);
            this.ConfirmButtonsTLPanel.TabIndex = 1;
            this.ConfirmButtonsTLPanel.TabStop = true;
            // 
            // CancelActionButton
            // 
            this.CancelActionButton.AutoSize = true;
            this.CancelActionButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelActionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CancelActionButton.Location = new System.Drawing.Point(182, 21);
            this.CancelActionButton.Margin = new System.Windows.Forms.Padding(7, 21, 7, 19);
            this.CancelActionButton.Name = "CancelActionButton";
            this.CancelActionButton.Size = new System.Drawing.Size(162, 33);
            this.CancelActionButton.TabIndex = 1;
            this.CancelActionButton.Text = "Zrušit";
            this.CancelActionButton.UseVisualStyleBackColor = true;
            this.CancelActionButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AddItemButton
            // 
            this.AddItemButton.AutoSize = true;
            this.AddItemButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AddItemButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddItemButton.Location = new System.Drawing.Point(7, 21);
            this.AddItemButton.Margin = new System.Windows.Forms.Padding(7, 21, 7, 19);
            this.AddItemButton.Name = "AddItemButton";
            this.AddItemButton.Size = new System.Drawing.Size(161, 33);
            this.AddItemButton.TabIndex = 0;
            this.AddItemButton.Text = "Přidat";
            this.AddItemButton.UseVisualStyleBackColor = true;
            this.AddItemButton.Click += new System.EventHandler(this.AddItemButton_Click);
            // 
            // QuantityEnterTLPanel
            // 
            this.QuantityEnterTLPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.QuantityEnterTLPanel.ColumnCount = 1;
            this.QuantityEnterTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.QuantityEnterTLPanel.Controls.Add(this.QuantityQuestionLabel, 0, 0);
            this.QuantityEnterTLPanel.Controls.Add(this.QuantityFieldTLPanel, 0, 1);
            this.QuantityEnterTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuantityEnterTLPanel.Location = new System.Drawing.Point(0, 0);
            this.QuantityEnterTLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.QuantityEnterTLPanel.Name = "QuantityEnterTLPanel";
            this.QuantityEnterTLPanel.RowCount = 2;
            this.QuantityEnterTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.QuantityEnterTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.QuantityEnterTLPanel.Size = new System.Drawing.Size(351, 119);
            this.QuantityEnterTLPanel.TabIndex = 0;
            // 
            // QuantityQuestionLabel
            // 
            this.QuantityQuestionLabel.AutoSize = true;
            this.QuantityQuestionLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.QuantityQuestionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuantityQuestionLabel.Location = new System.Drawing.Point(0, 0);
            this.QuantityQuestionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.QuantityQuestionLabel.Name = "QuantityQuestionLabel";
            this.QuantityQuestionLabel.Size = new System.Drawing.Size(351, 59);
            this.QuantityQuestionLabel.TabIndex = 0;
            this.QuantityQuestionLabel.Text = "Kolik kusů si přejete přidat do košíku?";
            this.QuantityQuestionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QuantityFieldTLPanel
            // 
            this.QuantityFieldTLPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.QuantityFieldTLPanel.ColumnCount = 1;
            this.QuantityFieldTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.QuantityFieldTLPanel.Controls.Add(this.QuantityTextBox, 0, 0);
            this.QuantityFieldTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuantityFieldTLPanel.Location = new System.Drawing.Point(8, 59);
            this.QuantityFieldTLPanel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 10);
            this.QuantityFieldTLPanel.Name = "QuantityFieldTLPanel";
            this.QuantityFieldTLPanel.RowCount = 1;
            this.QuantityFieldTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.QuantityFieldTLPanel.Size = new System.Drawing.Size(335, 50);
            this.QuantityFieldTLPanel.TabIndex = 0;
            this.QuantityFieldTLPanel.TabStop = true;
            // 
            // QuantityTextBox
            // 
            this.QuantityTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.QuantityTextBox.Location = new System.Drawing.Point(10, 15);
            this.QuantityTextBox.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.QuantityTextBox.Name = "QuantityTextBox";
            this.QuantityTextBox.Size = new System.Drawing.Size(315, 20);
            this.QuantityTextBox.TabIndex = 0;
            this.QuantityTextBox.Text = "1";
            this.QuantityTextBox.TextChanged += new System.EventHandler(this.QuantityTextBox_TextChanged);
            this.QuantityTextBox.Enter += new System.EventHandler(this.QuantityTextBox_Enter);
            this.QuantityTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QuantityTextBox_KeyDown);
            // 
            // AddToBasketDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelActionButton;
            this.ClientSize = new System.Drawing.Size(351, 192);
            this.Controls.Add(this.ConfirmWrapperTLPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddToBasketDialog";
            this.Text = "Přidat do košíku";
            this.ConfirmWrapperTLPanel.ResumeLayout(false);
            this.ConfirmWrapperTLPanel.PerformLayout();
            this.ConfirmButtonsTLPanel.ResumeLayout(false);
            this.ConfirmButtonsTLPanel.PerformLayout();
            this.QuantityEnterTLPanel.ResumeLayout(false);
            this.QuantityEnterTLPanel.PerformLayout();
            this.QuantityFieldTLPanel.ResumeLayout(false);
            this.QuantityFieldTLPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel ConfirmWrapperTLPanel;
        private System.Windows.Forms.TableLayoutPanel ConfirmButtonsTLPanel;
        private System.Windows.Forms.Button CancelActionButton;
        private System.Windows.Forms.Button AddItemButton;
        private System.Windows.Forms.TableLayoutPanel QuantityEnterTLPanel;
        private System.Windows.Forms.Label QuantityQuestionLabel;
        private System.Windows.Forms.TableLayoutPanel QuantityFieldTLPanel;
        private System.Windows.Forms.TextBox QuantityTextBox;
    }
}