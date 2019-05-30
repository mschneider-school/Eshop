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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.logInstructLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.FileOptionButton = new System.Windows.Forms.Button();
            this.ConsoleOptionButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.logInstructLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.61111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.38889F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(334, 133);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // logInstructLabel
            // 
            this.logInstructLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logInstructLabel.AutoSize = true;
            this.logInstructLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logInstructLabel.Location = new System.Drawing.Point(69, 22);
            this.logInstructLabel.Name = "logInstructLabel";
            this.logInstructLabel.Size = new System.Drawing.Size(195, 20);
            this.logInstructLabel.TabIndex = 1;
            this.logInstructLabel.Text = "Logy se budou ukládat do:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.86666F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.13334F));
            this.tableLayoutPanel2.Controls.Add(this.FileOptionButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ConsoleOptionButton, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 67);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(328, 63);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // FileOptionButton
            // 
            this.FileOptionButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FileOptionButton.AutoSize = true;
            this.FileOptionButton.Location = new System.Drawing.Point(9, 13);
            this.FileOptionButton.Name = "FileOptionButton";
            this.FileOptionButton.Padding = new System.Windows.Forms.Padding(32, 3, 32, 3);
            this.FileOptionButton.Size = new System.Drawing.Size(144, 36);
            this.FileOptionButton.TabIndex = 0;
            this.FileOptionButton.Text = "Souboru";
            this.FileOptionButton.UseVisualStyleBackColor = true;
            this.FileOptionButton.Click += new System.EventHandler(this.FileOptionButton_Click);
            // 
            // ConsoleOptionButton
            // 
            this.ConsoleOptionButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConsoleOptionButton.AutoSize = true;
            this.ConsoleOptionButton.Location = new System.Drawing.Point(175, 13);
            this.ConsoleOptionButton.Name = "ConsoleOptionButton";
            this.ConsoleOptionButton.Padding = new System.Windows.Forms.Padding(32, 3, 32, 3);
            this.ConsoleOptionButton.Size = new System.Drawing.Size(140, 36);
            this.ConsoleOptionButton.TabIndex = 1;
            this.ConsoleOptionButton.Text = "Konzole";
            this.ConsoleOptionButton.UseVisualStyleBackColor = true;
            this.ConsoleOptionButton.Click += new System.EventHandler(this.ConsoleOptionButton_Click);
            // 
            // SaveLogPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 133);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveLogPrompt";
            this.Text = "Vítejte!";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button ConsoleOptionButton;
        private System.Windows.Forms.Label logInstructLabel;
        private System.Windows.Forms.Button FileOptionButton;
    }
}