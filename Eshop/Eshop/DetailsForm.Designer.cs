namespace Eshop
{
    partial class DetailsForm
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
            this.ProductDetailsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ProductPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDetailsSplitContainer)).BeginInit();
            this.ProductDetailsSplitContainer.Panel1.SuspendLayout();
            this.ProductDetailsSplitContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductDetailsSplitContainer
            // 
            this.ProductDetailsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductDetailsSplitContainer.Location = new System.Drawing.Point(15, 15);
            this.ProductDetailsSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.ProductDetailsSplitContainer.Name = "ProductDetailsSplitContainer";
            // 
            // ProductDetailsSplitContainer.Panel1
            // 
            this.ProductDetailsSplitContainer.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ProductDetailsSplitContainer.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // ProductDetailsSplitContainer.Panel2
            // 
            this.ProductDetailsSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ProductDetailsSplitContainer.Size = new System.Drawing.Size(581, 372);
            this.ProductDetailsSplitContainer.SplitterDistance = 292;
            this.ProductDetailsSplitContainer.SplitterIncrement = 10;
            this.ProductDetailsSplitContainer.SplitterWidth = 10;
            this.ProductDetailsSplitContainer.TabIndex = 0;
            this.ProductDetailsSplitContainer.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ProductPictureBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(292, 372);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 58);
            this.label1.TabIndex = 0;
            this.label1.Text = "Huawei P20 Lite 4GB/64GB Dual SIM QuadCore Octal 3 DUO sedy ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProductPictureBox
            // 
            this.ProductPictureBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ProductPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductPictureBox.Location = new System.Drawing.Point(3, 61);
            this.ProductPictureBox.Name = "ProductPictureBox";
            this.ProductPictureBox.Size = new System.Drawing.Size(286, 308);
            this.ProductPictureBox.TabIndex = 1;
            this.ProductPictureBox.TabStop = false;
            // 
            // DetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 402);
            this.Controls.Add(this.ProductDetailsSplitContainer);
            this.Name = "DetailsForm";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.Text = "Detail produktu";
            this.ProductDetailsSplitContainer.Panel1.ResumeLayout(false);
            this.ProductDetailsSplitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDetailsSplitContainer)).EndInit();
            this.ProductDetailsSplitContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer ProductDetailsSplitContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ProductPictureBox;
    }
}