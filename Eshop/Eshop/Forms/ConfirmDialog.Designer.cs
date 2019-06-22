namespace Eshop
{
    partial class ConfirmDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmDialog));
            this.ConfirmWrapperTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ConfirmButtonsTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CancelActionButton = new System.Windows.Forms.Button();
            this.ConfirmActionButton = new System.Windows.Forms.Button();
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
            this.ConfirmWrapperTLPanel.Size = new System.Drawing.Size(351, 185);
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
            this.ConfirmButtonsTLPanel.Controls.Add(this.CancelActionButton, 1, 0);
            this.ConfirmButtonsTLPanel.Controls.Add(this.ConfirmActionButton, 0, 0);
            this.ConfirmButtonsTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfirmButtonsTLPanel.Location = new System.Drawing.Point(0, 112);
            this.ConfirmButtonsTLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ConfirmButtonsTLPanel.Name = "ConfirmButtonsTLPanel";
            this.ConfirmButtonsTLPanel.RowCount = 1;
            this.ConfirmButtonsTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConfirmButtonsTLPanel.Size = new System.Drawing.Size(351, 73);
            this.ConfirmButtonsTLPanel.TabIndex = 0;
            this.ConfirmButtonsTLPanel.TabStop = true;
            // 
            // CancelActionButton
            // 
            this.CancelActionButton.AutoSize = true;
            this.CancelActionButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelActionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CancelActionButton.Location = new System.Drawing.Point(182, 21);
            this.CancelActionButton.Margin = new System.Windows.Forms.Padding(7, 21, 10, 19);
            this.CancelActionButton.Name = "CancelActionButton";
            this.CancelActionButton.Size = new System.Drawing.Size(159, 33);
            this.CancelActionButton.TabIndex = 1;
            this.CancelActionButton.Text = "CancelText";
            this.CancelActionButton.UseVisualStyleBackColor = true;
            // 
            // ConfirmActionButton
            // 
            this.ConfirmActionButton.AutoSize = true;
            this.ConfirmActionButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ConfirmActionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfirmActionButton.Location = new System.Drawing.Point(10, 21);
            this.ConfirmActionButton.Margin = new System.Windows.Forms.Padding(10, 21, 7, 19);
            this.ConfirmActionButton.Name = "ConfirmActionButton";
            this.ConfirmActionButton.Size = new System.Drawing.Size(158, 33);
            this.ConfirmActionButton.TabIndex = 0;
            this.ConfirmActionButton.Text = "ConfirmText";
            this.ConfirmActionButton.UseVisualStyleBackColor = true;
            // 
            // ConfirmationLabel
            // 
            this.ConfirmationLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ConfirmationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfirmationLabel.Location = new System.Drawing.Point(0, 0);
            this.ConfirmationLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ConfirmationLabel.Name = "ConfirmationLabel";
            this.ConfirmationLabel.Size = new System.Drawing.Size(351, 112);
            this.ConfirmationLabel.TabIndex = 0;
            this.ConfirmationLabel.Text = "Confirmation message goes here";
            this.ConfirmationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConfirmDialog
            // 
            this.AcceptButton = this.ConfirmActionButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelActionButton;
            this.ClientSize = new System.Drawing.Size(351, 185);
            this.Controls.Add(this.ConfirmWrapperTLPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConfirmDialog";
            this.ShowIcon = false;
            this.Text = "Confirm action";
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
        private System.Windows.Forms.Button CancelActionButton;
        private System.Windows.Forms.Button ConfirmActionButton;
    }
}