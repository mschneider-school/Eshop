namespace Eshop
{
    partial class ProductDetailsForm
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
            this.DetailsOuterWrapperTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ProductDetailsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ProductIntroTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ProductNameLabel = new System.Windows.Forms.Label();
            this.PictureWrapperPanel = new System.Windows.Forms.Panel();
            this.ProductPictureBox = new System.Windows.Forms.PictureBox();
            this.ParametersSectionTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DescriptionWrapperTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.DescriptionBoxWrapperPanel = new System.Windows.Forms.Panel();
            this.DescriptionRTBox = new System.Windows.Forms.RichTextBox();
            this.ParametersWrapperTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ParemetersLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ProductPriceValueLabel = new System.Windows.Forms.Label();
            this.ProductPriceLabel = new System.Windows.Forms.Label();
            this.ProductCathegoryValueLabel = new System.Windows.Forms.Label();
            this.ProductCathegoryLabel = new System.Windows.Forms.Label();
            this.ProductIDValueLabel = new System.Windows.Forms.Label();
            this.ProductIDLabel = new System.Windows.Forms.Label();
            this.DetailsOuterWrapperTLPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDetailsSplitContainer)).BeginInit();
            this.ProductDetailsSplitContainer.Panel1.SuspendLayout();
            this.ProductDetailsSplitContainer.Panel2.SuspendLayout();
            this.ProductDetailsSplitContainer.SuspendLayout();
            this.ProductIntroTLPanel.SuspendLayout();
            this.PictureWrapperPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductPictureBox)).BeginInit();
            this.ParametersSectionTLPanel.SuspendLayout();
            this.DescriptionWrapperTLPanel.SuspendLayout();
            this.DescriptionBoxWrapperPanel.SuspendLayout();
            this.ParametersWrapperTLPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DetailsOuterWrapperTLPanel
            // 
            this.DetailsOuterWrapperTLPanel.AutoSize = true;
            this.DetailsOuterWrapperTLPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DetailsOuterWrapperTLPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DetailsOuterWrapperTLPanel.ColumnCount = 1;
            this.DetailsOuterWrapperTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DetailsOuterWrapperTLPanel.Controls.Add(this.ProductDetailsSplitContainer, 0, 0);
            this.DetailsOuterWrapperTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailsOuterWrapperTLPanel.Location = new System.Drawing.Point(0, 10);
            this.DetailsOuterWrapperTLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.DetailsOuterWrapperTLPanel.Name = "DetailsOuterWrapperTLPanel";
            this.DetailsOuterWrapperTLPanel.RowCount = 1;
            this.DetailsOuterWrapperTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DetailsOuterWrapperTLPanel.Size = new System.Drawing.Size(656, 416);
            this.DetailsOuterWrapperTLPanel.TabIndex = 1;
            // 
            // ProductDetailsSplitContainer
            // 
            this.ProductDetailsSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductDetailsSplitContainer.Location = new System.Drawing.Point(10, 10);
            this.ProductDetailsSplitContainer.Margin = new System.Windows.Forms.Padding(10);
            this.ProductDetailsSplitContainer.Name = "ProductDetailsSplitContainer";
            // 
            // ProductDetailsSplitContainer.Panel1
            // 
            this.ProductDetailsSplitContainer.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ProductDetailsSplitContainer.Panel1.Controls.Add(this.ProductIntroTLPanel);
            // 
            // ProductDetailsSplitContainer.Panel2
            // 
            this.ProductDetailsSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ProductDetailsSplitContainer.Panel2.Controls.Add(this.ParametersSectionTLPanel);
            this.ProductDetailsSplitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ProductDetailsSplitContainer.Size = new System.Drawing.Size(636, 396);
            this.ProductDetailsSplitContainer.SplitterDistance = 274;
            this.ProductDetailsSplitContainer.SplitterWidth = 15;
            this.ProductDetailsSplitContainer.TabIndex = 0;
            this.ProductDetailsSplitContainer.TabStop = false;
            // 
            // ProductIntroTLPanel
            // 
            this.ProductIntroTLPanel.AutoSize = true;
            this.ProductIntroTLPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ProductIntroTLPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ProductIntroTLPanel.ColumnCount = 1;
            this.ProductIntroTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProductIntroTLPanel.Controls.Add(this.ProductNameLabel, 0, 0);
            this.ProductIntroTLPanel.Controls.Add(this.PictureWrapperPanel, 0, 1);
            this.ProductIntroTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductIntroTLPanel.Location = new System.Drawing.Point(0, 0);
            this.ProductIntroTLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ProductIntroTLPanel.Name = "ProductIntroTLPanel";
            this.ProductIntroTLPanel.RowCount = 2;
            this.ProductIntroTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.ProductIntroTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ProductIntroTLPanel.Size = new System.Drawing.Size(274, 396);
            this.ProductIntroTLPanel.TabIndex = 0;
            // 
            // ProductNameLabel
            // 
            this.ProductNameLabel.AutoSize = true;
            this.ProductNameLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ProductNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductNameLabel.Location = new System.Drawing.Point(0, 0);
            this.ProductNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ProductNameLabel.Name = "ProductNameLabel";
            this.ProductNameLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ProductNameLabel.Size = new System.Drawing.Size(274, 58);
            this.ProductNameLabel.TabIndex = 0;
            this.ProductNameLabel.Text = "Huawei P20 Lite 4GB/64GB Dual SIM QuadCore Octal 3 DUO sedy ";
            this.ProductNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PictureWrapperPanel
            // 
            this.PictureWrapperPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureWrapperPanel.AutoSize = true;
            this.PictureWrapperPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PictureWrapperPanel.Controls.Add(this.ProductPictureBox);
            this.PictureWrapperPanel.Location = new System.Drawing.Point(0, 68);
            this.PictureWrapperPanel.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.PictureWrapperPanel.Name = "PictureWrapperPanel";
            this.PictureWrapperPanel.Padding = new System.Windows.Forms.Padding(15);
            this.PictureWrapperPanel.Size = new System.Drawing.Size(274, 328);
            this.PictureWrapperPanel.TabIndex = 1;
            // 
            // ProductPictureBox
            // 
            this.ProductPictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ProductPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductPictureBox.Location = new System.Drawing.Point(15, 15);
            this.ProductPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.ProductPictureBox.Name = "ProductPictureBox";
            this.ProductPictureBox.Size = new System.Drawing.Size(244, 298);
            this.ProductPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProductPictureBox.TabIndex = 0;
            this.ProductPictureBox.TabStop = false;
            // 
            // ParametersSectionTLPanel
            // 
            this.ParametersSectionTLPanel.AutoSize = true;
            this.ParametersSectionTLPanel.ColumnCount = 1;
            this.ParametersSectionTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ParametersSectionTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ParametersSectionTLPanel.Controls.Add(this.DescriptionWrapperTLPanel, 0, 1);
            this.ParametersSectionTLPanel.Controls.Add(this.ParametersWrapperTLPanel, 0, 0);
            this.ParametersSectionTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParametersSectionTLPanel.Location = new System.Drawing.Point(0, 0);
            this.ParametersSectionTLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ParametersSectionTLPanel.Name = "ParametersSectionTLPanel";
            this.ParametersSectionTLPanel.RowCount = 2;
            this.ParametersSectionTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ParametersSectionTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ParametersSectionTLPanel.Size = new System.Drawing.Size(347, 396);
            this.ParametersSectionTLPanel.TabIndex = 0;
            // 
            // DescriptionWrapperTLPanel
            // 
            this.DescriptionWrapperTLPanel.AutoSize = true;
            this.DescriptionWrapperTLPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DescriptionWrapperTLPanel.ColumnCount = 1;
            this.DescriptionWrapperTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DescriptionWrapperTLPanel.Controls.Add(this.DescriptionLabel, 0, 0);
            this.DescriptionWrapperTLPanel.Controls.Add(this.DescriptionBoxWrapperPanel, 0, 1);
            this.DescriptionWrapperTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionWrapperTLPanel.Location = new System.Drawing.Point(0, 198);
            this.DescriptionWrapperTLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.DescriptionWrapperTLPanel.Name = "DescriptionWrapperTLPanel";
            this.DescriptionWrapperTLPanel.RowCount = 2;
            this.DescriptionWrapperTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.DescriptionWrapperTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DescriptionWrapperTLPanel.Size = new System.Drawing.Size(347, 198);
            this.DescriptionWrapperTLPanel.TabIndex = 1;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.BackColor = System.Drawing.SystemColors.Control;
            this.DescriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionLabel.Location = new System.Drawing.Point(0, 0);
            this.DescriptionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.DescriptionLabel.Size = new System.Drawing.Size(347, 58);
            this.DescriptionLabel.TabIndex = 1;
            this.DescriptionLabel.Text = "Popis produktu";
            this.DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DescriptionBoxWrapperPanel
            // 
            this.DescriptionBoxWrapperPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionBoxWrapperPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DescriptionBoxWrapperPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DescriptionBoxWrapperPanel.Controls.Add(this.DescriptionRTBox);
            this.DescriptionBoxWrapperPanel.Location = new System.Drawing.Point(0, 73);
            this.DescriptionBoxWrapperPanel.Margin = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.DescriptionBoxWrapperPanel.Name = "DescriptionBoxWrapperPanel";
            this.DescriptionBoxWrapperPanel.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.DescriptionBoxWrapperPanel.Size = new System.Drawing.Size(347, 125);
            this.DescriptionBoxWrapperPanel.TabIndex = 2;
            // 
            // DescriptionRTBox
            // 
            this.DescriptionRTBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DescriptionRTBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DescriptionRTBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.DescriptionRTBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionRTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionRTBox.Location = new System.Drawing.Point(12, 0);
            this.DescriptionRTBox.Margin = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.DescriptionRTBox.Name = "DescriptionRTBox";
            this.DescriptionRTBox.ReadOnly = true;
            this.DescriptionRTBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.DescriptionRTBox.Size = new System.Drawing.Size(335, 125);
            this.DescriptionRTBox.TabIndex = 0;
            this.DescriptionRTBox.TabStop = false;
            this.DescriptionRTBox.Text = "";
            // 
            // ParametersWrapperTLPanel
            // 
            this.ParametersWrapperTLPanel.AutoSize = true;
            this.ParametersWrapperTLPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ParametersWrapperTLPanel.ColumnCount = 1;
            this.ParametersWrapperTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ParametersWrapperTLPanel.Controls.Add(this.ParemetersLabel, 0, 0);
            this.ParametersWrapperTLPanel.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.ParametersWrapperTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParametersWrapperTLPanel.Location = new System.Drawing.Point(0, 0);
            this.ParametersWrapperTLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ParametersWrapperTLPanel.Name = "ParametersWrapperTLPanel";
            this.ParametersWrapperTLPanel.RowCount = 2;
            this.ParametersWrapperTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.ParametersWrapperTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ParametersWrapperTLPanel.Size = new System.Drawing.Size(347, 198);
            this.ParametersWrapperTLPanel.TabIndex = 0;
            // 
            // ParemetersLabel
            // 
            this.ParemetersLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ParemetersLabel.AutoSize = true;
            this.ParemetersLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ParemetersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParemetersLabel.Location = new System.Drawing.Point(0, 0);
            this.ParemetersLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ParemetersLabel.Name = "ParemetersLabel";
            this.ParemetersLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ParemetersLabel.Size = new System.Drawing.Size(347, 58);
            this.ParemetersLabel.TabIndex = 1;
            this.ParemetersLabel.Text = "Parametry produktu";
            this.ParemetersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.ProductPriceValueLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ProductPriceLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ProductCathegoryValueLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ProductCathegoryLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ProductIDValueLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ProductIDLabel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 58);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(347, 140);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // ProductPriceValueLabel
            // 
            this.ProductPriceValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ProductPriceValueLabel.AutoSize = true;
            this.ProductPriceValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductPriceValueLabel.Location = new System.Drawing.Point(148, 108);
            this.ProductPriceValueLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.ProductPriceValueLabel.Name = "ProductPriceValueLabel";
            this.ProductPriceValueLabel.Size = new System.Drawing.Size(36, 15);
            this.ProductPriceValueLabel.TabIndex = 9;
            this.ProductPriceValueLabel.Text = "value";
            // 
            // ProductPriceLabel
            // 
            this.ProductPriceLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ProductPriceLabel.AutoSize = true;
            this.ProductPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductPriceLabel.Location = new System.Drawing.Point(10, 108);
            this.ProductPriceLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.ProductPriceLabel.Name = "ProductPriceLabel";
            this.ProductPriceLabel.Size = new System.Drawing.Size(39, 15);
            this.ProductPriceLabel.TabIndex = 8;
            this.ProductPriceLabel.Text = "Cena:";
            // 
            // ProductCathegoryValueLabel
            // 
            this.ProductCathegoryValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ProductCathegoryValueLabel.AutoSize = true;
            this.ProductCathegoryValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductCathegoryValueLabel.Location = new System.Drawing.Point(148, 61);
            this.ProductCathegoryValueLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.ProductCathegoryValueLabel.Name = "ProductCathegoryValueLabel";
            this.ProductCathegoryValueLabel.Size = new System.Drawing.Size(36, 15);
            this.ProductCathegoryValueLabel.TabIndex = 7;
            this.ProductCathegoryValueLabel.Text = "value";
            // 
            // ProductCathegoryLabel
            // 
            this.ProductCathegoryLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ProductCathegoryLabel.AutoSize = true;
            this.ProductCathegoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductCathegoryLabel.Location = new System.Drawing.Point(10, 61);
            this.ProductCathegoryLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.ProductCathegoryLabel.Name = "ProductCathegoryLabel";
            this.ProductCathegoryLabel.Size = new System.Drawing.Size(63, 15);
            this.ProductCathegoryLabel.TabIndex = 6;
            this.ProductCathegoryLabel.Text = "Kategorie:";
            // 
            // ProductIDValueLabel
            // 
            this.ProductIDValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ProductIDValueLabel.AutoSize = true;
            this.ProductIDValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductIDValueLabel.Location = new System.Drawing.Point(148, 15);
            this.ProductIDValueLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.ProductIDValueLabel.Name = "ProductIDValueLabel";
            this.ProductIDValueLabel.Size = new System.Drawing.Size(36, 15);
            this.ProductIDValueLabel.TabIndex = 5;
            this.ProductIDValueLabel.Text = "value";
            // 
            // ProductIDLabel
            // 
            this.ProductIDLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ProductIDLabel.AutoSize = true;
            this.ProductIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductIDLabel.Location = new System.Drawing.Point(10, 15);
            this.ProductIDLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.ProductIDLabel.Name = "ProductIDLabel";
            this.ProductIDLabel.Size = new System.Drawing.Size(22, 15);
            this.ProductIDLabel.TabIndex = 3;
            this.ProductIDLabel.Text = "ID:";
            // 
            // ProductDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(656, 436);
            this.Controls.Add(this.DetailsOuterWrapperTLPanel);
            this.MaximizeBox = false;
            this.Name = "ProductDetailsForm";
            this.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.Text = "Detail produktu";
            this.DetailsOuterWrapperTLPanel.ResumeLayout(false);
            this.ProductDetailsSplitContainer.Panel1.ResumeLayout(false);
            this.ProductDetailsSplitContainer.Panel1.PerformLayout();
            this.ProductDetailsSplitContainer.Panel2.ResumeLayout(false);
            this.ProductDetailsSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDetailsSplitContainer)).EndInit();
            this.ProductDetailsSplitContainer.ResumeLayout(false);
            this.ProductIntroTLPanel.ResumeLayout(false);
            this.ProductIntroTLPanel.PerformLayout();
            this.PictureWrapperPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductPictureBox)).EndInit();
            this.ParametersSectionTLPanel.ResumeLayout(false);
            this.ParametersSectionTLPanel.PerformLayout();
            this.DescriptionWrapperTLPanel.ResumeLayout(false);
            this.DescriptionWrapperTLPanel.PerformLayout();
            this.DescriptionBoxWrapperPanel.ResumeLayout(false);
            this.ParametersWrapperTLPanel.ResumeLayout(false);
            this.ParametersWrapperTLPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel DetailsOuterWrapperTLPanel;
        private System.Windows.Forms.SplitContainer ProductDetailsSplitContainer;
        private System.Windows.Forms.TableLayoutPanel ProductIntroTLPanel;
        private System.Windows.Forms.Label ProductNameLabel;
        private System.Windows.Forms.Panel PictureWrapperPanel;
        private System.Windows.Forms.PictureBox ProductPictureBox;
        private System.Windows.Forms.TableLayoutPanel ParametersSectionTLPanel;
        private System.Windows.Forms.TableLayoutPanel DescriptionWrapperTLPanel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Panel DescriptionBoxWrapperPanel;
        private System.Windows.Forms.RichTextBox DescriptionRTBox;
        private System.Windows.Forms.TableLayoutPanel ParametersWrapperTLPanel;
        private System.Windows.Forms.Label ParemetersLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label ProductPriceValueLabel;
        private System.Windows.Forms.Label ProductPriceLabel;
        private System.Windows.Forms.Label ProductCathegoryValueLabel;
        private System.Windows.Forms.Label ProductCathegoryLabel;
        private System.Windows.Forms.Label ProductIDValueLabel;
        private System.Windows.Forms.Label ProductIDLabel;
    }
}