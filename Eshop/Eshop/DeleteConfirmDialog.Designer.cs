namespace Eshop
{
    partial class DeleteConfirmDialog
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
            this.ConfirmationLabel = new System.Windows.Forms.Label();
            this.ConfirmButtonsTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CancelActionButton = new System.Windows.Forms.Button();
            this.ConfirmActionButton = new System.Windows.Forms.Button();
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
            this.ConfirmWrapperTLPanel.Controls.Add(this.ConfirmationLabel, 0, 0);
            this.ConfirmWrapperTLPanel.Controls.Add(this.ConfirmButtonsTLPanel, 0, 1);
            this.ConfirmWrapperTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfirmWrapperTLPanel.Location = new System.Drawing.Point(0, 0);
            this.ConfirmWrapperTLPanel.Name = "ConfirmWrapperTLPanel";
            this.ConfirmWrapperTLPanel.RowCount = 2;
            this.ConfirmWrapperTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.ConfirmWrapperTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.ConfirmWrapperTLPanel.Size = new System.Drawing.Size(353, 187);
            this.ConfirmWrapperTLPanel.TabIndex = 0;
            // 
            // ConfirmationLabel
            // 
            this.ConfirmationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmationLabel.AutoSize = true;
            this.ConfirmationLabel.BackColor = System.Drawing.SystemColors.Window;
            this.ConfirmationLabel.Location = new System.Drawing.Point(0, 25);
            this.ConfirmationLabel.Margin = new System.Windows.Forms.Padding(0, 25, 0, 3);
            this.ConfirmationLabel.Name = "ConfirmationLabel";
            this.ConfirmationLabel.Size = new System.Drawing.Size(353, 93);
            this.ConfirmationLabel.TabIndex = 0;
            this.ConfirmationLabel.Text = "Opravdu si přejete vymazat produkt: ";
            this.ConfirmationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.ConfirmButtonsTLPanel.Location = new System.Drawing.Point(3, 124);
            this.ConfirmButtonsTLPanel.Name = "ConfirmButtonsTLPanel";
            this.ConfirmButtonsTLPanel.RowCount = 1;
            this.ConfirmButtonsTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConfirmButtonsTLPanel.Size = new System.Drawing.Size(347, 60);
            this.ConfirmButtonsTLPanel.TabIndex = 1;
            // 
            // CancelActionButton
            // 
            this.CancelActionButton.AutoSize = true;
            this.CancelActionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CancelActionButton.Location = new System.Drawing.Point(180, 7);
            this.CancelActionButton.Margin = new System.Windows.Forms.Padding(7, 7, 10, 20);
            this.CancelActionButton.Name = "CancelActionButton";
            this.CancelActionButton.Size = new System.Drawing.Size(157, 33);
            this.CancelActionButton.TabIndex = 0;
            this.CancelActionButton.Text = "Ne";
            this.CancelActionButton.UseVisualStyleBackColor = true;
            this.CancelActionButton.Click += new System.EventHandler(this.CancelActionButton_Click);
            // 
            // ConfirmActionButton
            // 
            this.ConfirmActionButton.AutoSize = true;
            this.ConfirmActionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfirmActionButton.Location = new System.Drawing.Point(10, 7);
            this.ConfirmActionButton.Margin = new System.Windows.Forms.Padding(10, 7, 7, 20);
            this.ConfirmActionButton.Name = "ConfirmActionButton";
            this.ConfirmActionButton.Size = new System.Drawing.Size(156, 33);
            this.ConfirmActionButton.TabIndex = 1;
            this.ConfirmActionButton.Text = "Ano";
            this.ConfirmActionButton.UseVisualStyleBackColor = true;
            // 
            // DeleteConfirmDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 187);
            this.Controls.Add(this.ConfirmWrapperTLPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DeleteConfirmDialog";
            this.Text = "Vymazání produktu";
            this.Load += new System.EventHandler(this.DeleteConfirmDialog_Load);
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