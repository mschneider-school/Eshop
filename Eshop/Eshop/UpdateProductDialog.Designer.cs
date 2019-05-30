namespace Eshop
{
    partial class UpdateProductDialog
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
            this.AddProducttTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.AddProductSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ProductDetailsTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ProductDetailsFLPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ProductIDTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ProductIDLabel = new System.Windows.Forms.Label();
            this.ProductIDTextBox = new System.Windows.Forms.TextBox();
            this.ProductNameTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ProductNameLabel = new System.Windows.Forms.Label();
            this.ProductNameTextBox = new System.Windows.Forms.TextBox();
            this.ProductCathegoryTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ProductCathegoryLabel = new System.Windows.Forms.Label();
            this.ProductCathegoryCBox = new System.Windows.Forms.ComboBox();
            this.ProductPriceTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ProductPriceLabel = new System.Windows.Forms.Label();
            this.ProductPriceTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.ProductDescriptionRTBox = new System.Windows.Forms.RichTextBox();
            this.ProductPictureTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.LoadPhotoButton = new System.Windows.Forms.Button();
            this.ProductPictureBox = new System.Windows.Forms.PictureBox();
            this.AddPicButtonTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SaveProductButton = new System.Windows.Forms.Button();
            this.ClearFormButton = new System.Windows.Forms.Button();
            this.AddProducttTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddProductSplitContainer)).BeginInit();
            this.AddProductSplitContainer.Panel1.SuspendLayout();
            this.AddProductSplitContainer.Panel2.SuspendLayout();
            this.AddProductSplitContainer.SuspendLayout();
            this.ProductDetailsTLPanel.SuspendLayout();
            this.ProductDetailsFLPanel.SuspendLayout();
            this.ProductIDTLPanel.SuspendLayout();
            this.ProductNameTLPanel.SuspendLayout();
            this.ProductCathegoryTLPanel.SuspendLayout();
            this.ProductPriceTLPanel.SuspendLayout();
            this.DescriptionTLPanel.SuspendLayout();
            this.ProductPictureTLPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductPictureBox)).BeginInit();
            this.AddPicButtonTLPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddProducttTableLayoutPanel
            // 
            this.AddProducttTableLayoutPanel.AutoSize = true;
            this.AddProducttTableLayoutPanel.ColumnCount = 1;
            this.AddProducttTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AddProducttTableLayoutPanel.Controls.Add(this.AddProductSplitContainer, 0, 0);
            this.AddProducttTableLayoutPanel.Controls.Add(this.AddPicButtonTLPanel, 0, 1);
            this.AddProducttTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddProducttTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.AddProducttTableLayoutPanel.Name = "AddProducttTableLayoutPanel";
            this.AddProducttTableLayoutPanel.RowCount = 2;
            this.AddProducttTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AddProducttTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.AddProducttTableLayoutPanel.Size = new System.Drawing.Size(646, 394);
            this.AddProducttTableLayoutPanel.TabIndex = 0;
            // 
            // AddProductSplitContainer
            // 
            this.AddProductSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddProductSplitContainer.Location = new System.Drawing.Point(10, 10);
            this.AddProductSplitContainer.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.AddProductSplitContainer.Name = "AddProductSplitContainer";
            // 
            // AddProductSplitContainer.Panel1
            // 
            this.AddProductSplitContainer.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddProductSplitContainer.Panel1.Controls.Add(this.ProductDetailsTLPanel);
            this.AddProductSplitContainer.Panel1.SizeChanged += new System.EventHandler(this.AddProductSplitContainer_Panel1_SizeChanged);
            // 
            // AddProductSplitContainer.Panel2
            // 
            this.AddProductSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddProductSplitContainer.Panel2.Controls.Add(this.ProductPictureTLPanel);
            this.AddProductSplitContainer.Size = new System.Drawing.Size(626, 314);
            this.AddProductSplitContainer.SplitterDistance = 380;
            this.AddProductSplitContainer.SplitterIncrement = 10;
            this.AddProductSplitContainer.SplitterWidth = 10;
            this.AddProductSplitContainer.TabIndex = 0;
            this.AddProductSplitContainer.TabStop = false;
            // 
            // ProductDetailsTLPanel
            // 
            this.ProductDetailsTLPanel.AutoSize = true;
            this.ProductDetailsTLPanel.ColumnCount = 1;
            this.ProductDetailsTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ProductDetailsTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ProductDetailsTLPanel.Controls.Add(this.ProductDetailsFLPanel, 0, 0);
            this.ProductDetailsTLPanel.Controls.Add(this.DescriptionTLPanel, 0, 1);
            this.ProductDetailsTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductDetailsTLPanel.Location = new System.Drawing.Point(0, 0);
            this.ProductDetailsTLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ProductDetailsTLPanel.Name = "ProductDetailsTLPanel";
            this.ProductDetailsTLPanel.RowCount = 2;
            this.ProductDetailsTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ProductDetailsTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ProductDetailsTLPanel.Size = new System.Drawing.Size(380, 314);
            this.ProductDetailsTLPanel.TabIndex = 0;
            // 
            // ProductDetailsFLPanel
            // 
            this.ProductDetailsFLPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductDetailsFLPanel.AutoScroll = true;
            this.ProductDetailsFLPanel.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.ProductDetailsFLPanel.AutoSize = true;
            this.ProductDetailsFLPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ProductDetailsFLPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ProductDetailsFLPanel.Controls.Add(this.ProductIDTLPanel);
            this.ProductDetailsFLPanel.Controls.Add(this.ProductNameTLPanel);
            this.ProductDetailsFLPanel.Controls.Add(this.ProductCathegoryTLPanel);
            this.ProductDetailsFLPanel.Controls.Add(this.ProductPriceTLPanel);
            this.ProductDetailsFLPanel.Location = new System.Drawing.Point(5, 5);
            this.ProductDetailsFLPanel.Margin = new System.Windows.Forms.Padding(5);
            this.ProductDetailsFLPanel.Name = "ProductDetailsFLPanel";
            this.ProductDetailsFLPanel.Size = new System.Drawing.Size(370, 147);
            this.ProductDetailsFLPanel.TabIndex = 0;
            // 
            // ProductIDTLPanel
            // 
            this.ProductIDTLPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProductIDTLPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ProductIDTLPanel.ColumnCount = 1;
            this.ProductIDTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProductIDTLPanel.Controls.Add(this.ProductIDLabel, 0, 0);
            this.ProductIDTLPanel.Controls.Add(this.ProductIDTextBox, 0, 1);
            this.ProductIDTLPanel.Location = new System.Drawing.Point(5, 5);
            this.ProductIDTLPanel.Margin = new System.Windows.Forms.Padding(5);
            this.ProductIDTLPanel.Name = "ProductIDTLPanel";
            this.ProductIDTLPanel.RowCount = 2;
            this.ProductIDTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.ProductIDTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.ProductIDTLPanel.Size = new System.Drawing.Size(175, 63);
            this.ProductIDTLPanel.TabIndex = 0;
            // 
            // ProductIDLabel
            // 
            this.ProductIDLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ProductIDLabel.AutoSize = true;
            this.ProductIDLabel.Location = new System.Drawing.Point(7, 11);
            this.ProductIDLabel.Margin = new System.Windows.Forms.Padding(7, 11, 3, 0);
            this.ProductIDLabel.Name = "ProductIDLabel";
            this.ProductIDLabel.Size = new System.Drawing.Size(20, 13);
            this.ProductIDLabel.TabIndex = 0;
            this.ProductIDLabel.Text = "lD:";
            // 
            // ProductIDTextBox
            // 
            this.ProductIDTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductIDTextBox.Location = new System.Drawing.Point(10, 30);
            this.ProductIDTextBox.Margin = new System.Windows.Forms.Padding(10, 5, 10, 11);
            this.ProductIDTextBox.Name = "ProductIDTextBox";
            this.ProductIDTextBox.Size = new System.Drawing.Size(155, 20);
            this.ProductIDTextBox.TabIndex = 3;
            // 
            // ProductNameTLPanel
            // 
            this.ProductNameTLPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProductNameTLPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ProductNameTLPanel.ColumnCount = 1;
            this.ProductNameTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProductNameTLPanel.Controls.Add(this.ProductNameLabel, 0, 0);
            this.ProductNameTLPanel.Controls.Add(this.ProductNameTextBox, 0, 1);
            this.ProductNameTLPanel.Location = new System.Drawing.Point(190, 5);
            this.ProductNameTLPanel.Margin = new System.Windows.Forms.Padding(5);
            this.ProductNameTLPanel.Name = "ProductNameTLPanel";
            this.ProductNameTLPanel.RowCount = 2;
            this.ProductNameTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.ProductNameTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.ProductNameTLPanel.Size = new System.Drawing.Size(175, 63);
            this.ProductNameTLPanel.TabIndex = 3;
            // 
            // ProductNameLabel
            // 
            this.ProductNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ProductNameLabel.AutoSize = true;
            this.ProductNameLabel.Location = new System.Drawing.Point(7, 11);
            this.ProductNameLabel.Margin = new System.Windows.Forms.Padding(7, 11, 3, 0);
            this.ProductNameLabel.Name = "ProductNameLabel";
            this.ProductNameLabel.Size = new System.Drawing.Size(41, 13);
            this.ProductNameLabel.TabIndex = 0;
            this.ProductNameLabel.Text = "Název:";
            // 
            // ProductNameTextBox
            // 
            this.ProductNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductNameTextBox.Location = new System.Drawing.Point(10, 30);
            this.ProductNameTextBox.Margin = new System.Windows.Forms.Padding(10, 5, 10, 11);
            this.ProductNameTextBox.Name = "ProductNameTextBox";
            this.ProductNameTextBox.Size = new System.Drawing.Size(155, 20);
            this.ProductNameTextBox.TabIndex = 2;
            // 
            // ProductCathegoryTLPanel
            // 
            this.ProductCathegoryTLPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProductCathegoryTLPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ProductCathegoryTLPanel.ColumnCount = 1;
            this.ProductCathegoryTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProductCathegoryTLPanel.Controls.Add(this.ProductCathegoryLabel, 0, 0);
            this.ProductCathegoryTLPanel.Controls.Add(this.ProductCathegoryCBox, 0, 1);
            this.ProductCathegoryTLPanel.Location = new System.Drawing.Point(5, 78);
            this.ProductCathegoryTLPanel.Margin = new System.Windows.Forms.Padding(5);
            this.ProductCathegoryTLPanel.Name = "ProductCathegoryTLPanel";
            this.ProductCathegoryTLPanel.RowCount = 2;
            this.ProductCathegoryTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.ProductCathegoryTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.ProductCathegoryTLPanel.Size = new System.Drawing.Size(175, 63);
            this.ProductCathegoryTLPanel.TabIndex = 4;
            // 
            // ProductCathegoryLabel
            // 
            this.ProductCathegoryLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ProductCathegoryLabel.AutoSize = true;
            this.ProductCathegoryLabel.Location = new System.Drawing.Point(7, 11);
            this.ProductCathegoryLabel.Margin = new System.Windows.Forms.Padding(7, 11, 3, 0);
            this.ProductCathegoryLabel.Name = "ProductCathegoryLabel";
            this.ProductCathegoryLabel.Size = new System.Drawing.Size(55, 13);
            this.ProductCathegoryLabel.TabIndex = 0;
            this.ProductCathegoryLabel.Text = "Kategorie:";
            // 
            // ProductCathegoryCBox
            // 
            this.ProductCathegoryCBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ProductCathegoryCBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductCathegoryCBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ProductCathegoryCBox.FormattingEnabled = true;
            this.ProductCathegoryCBox.Items.AddRange(new object[] {
            "Chytré hodinky",
            "Nabíječky a kabely",
            "Pouzdra a kryty",
            "Smartfóny",
            "Tablety",
            "Tlačítkové telefony",
            "Tvrzená skla"});
            this.ProductCathegoryCBox.Location = new System.Drawing.Point(10, 30);
            this.ProductCathegoryCBox.Margin = new System.Windows.Forms.Padding(10, 5, 10, 11);
            this.ProductCathegoryCBox.Name = "ProductCathegoryCBox";
            this.ProductCathegoryCBox.Size = new System.Drawing.Size(155, 21);
            this.ProductCathegoryCBox.Sorted = true;
            this.ProductCathegoryCBox.TabIndex = 1;
            // 
            // ProductPriceTLPanel
            // 
            this.ProductPriceTLPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProductPriceTLPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ProductPriceTLPanel.ColumnCount = 1;
            this.ProductPriceTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProductPriceTLPanel.Controls.Add(this.ProductPriceLabel, 0, 0);
            this.ProductPriceTLPanel.Controls.Add(this.ProductPriceTextBox, 0, 1);
            this.ProductPriceTLPanel.Location = new System.Drawing.Point(190, 78);
            this.ProductPriceTLPanel.Margin = new System.Windows.Forms.Padding(5);
            this.ProductPriceTLPanel.Name = "ProductPriceTLPanel";
            this.ProductPriceTLPanel.RowCount = 2;
            this.ProductPriceTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.ProductPriceTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.ProductPriceTLPanel.Size = new System.Drawing.Size(175, 63);
            this.ProductPriceTLPanel.TabIndex = 5;
            // 
            // ProductPriceLabel
            // 
            this.ProductPriceLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ProductPriceLabel.AutoSize = true;
            this.ProductPriceLabel.Location = new System.Drawing.Point(7, 11);
            this.ProductPriceLabel.Margin = new System.Windows.Forms.Padding(7, 11, 3, 0);
            this.ProductPriceLabel.Name = "ProductPriceLabel";
            this.ProductPriceLabel.Size = new System.Drawing.Size(35, 13);
            this.ProductPriceLabel.TabIndex = 0;
            this.ProductPriceLabel.Text = "Cena:";
            // 
            // ProductPriceTextBox
            // 
            this.ProductPriceTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductPriceTextBox.Location = new System.Drawing.Point(10, 30);
            this.ProductPriceTextBox.Margin = new System.Windows.Forms.Padding(10, 5, 10, 11);
            this.ProductPriceTextBox.Name = "ProductPriceTextBox";
            this.ProductPriceTextBox.Size = new System.Drawing.Size(155, 20);
            this.ProductPriceTextBox.TabIndex = 3;
            // 
            // DescriptionTLPanel
            // 
            this.DescriptionTLPanel.AutoSize = true;
            this.DescriptionTLPanel.ColumnCount = 1;
            this.DescriptionTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DescriptionTLPanel.Controls.Add(this.DescriptionLabel, 0, 0);
            this.DescriptionTLPanel.Controls.Add(this.ProductDescriptionRTBox, 0, 1);
            this.DescriptionTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionTLPanel.Location = new System.Drawing.Point(3, 160);
            this.DescriptionTLPanel.Name = "DescriptionTLPanel";
            this.DescriptionTLPanel.RowCount = 2;
            this.DescriptionTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.DescriptionTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.DescriptionTLPanel.Size = new System.Drawing.Size(374, 151);
            this.DescriptionTLPanel.TabIndex = 1;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(4, 4);
            this.DescriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 3, 0);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(36, 13);
            this.DescriptionLabel.TabIndex = 0;
            this.DescriptionLabel.Text = "Popis:";
            this.DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProductDescriptionRTBox
            // 
            this.ProductDescriptionRTBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductDescriptionRTBox.Location = new System.Drawing.Point(7, 25);
            this.ProductDescriptionRTBox.Margin = new System.Windows.Forms.Padding(7, 3, 7, 12);
            this.ProductDescriptionRTBox.Name = "ProductDescriptionRTBox";
            this.ProductDescriptionRTBox.Size = new System.Drawing.Size(360, 114);
            this.ProductDescriptionRTBox.TabIndex = 1;
            this.ProductDescriptionRTBox.Text = "";
            // 
            // ProductPictureTLPanel
            // 
            this.ProductPictureTLPanel.AutoSize = true;
            this.ProductPictureTLPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ProductPictureTLPanel.ColumnCount = 1;
            this.ProductPictureTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProductPictureTLPanel.Controls.Add(this.LoadPhotoButton, 0, 1);
            this.ProductPictureTLPanel.Controls.Add(this.ProductPictureBox, 0, 0);
            this.ProductPictureTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductPictureTLPanel.Location = new System.Drawing.Point(0, 0);
            this.ProductPictureTLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ProductPictureTLPanel.Name = "ProductPictureTLPanel";
            this.ProductPictureTLPanel.RowCount = 2;
            this.ProductPictureTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProductPictureTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.ProductPictureTLPanel.Size = new System.Drawing.Size(236, 314);
            this.ProductPictureTLPanel.TabIndex = 0;
            // 
            // LoadPhotoButton
            // 
            this.LoadPhotoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadPhotoButton.Location = new System.Drawing.Point(10, 269);
            this.LoadPhotoButton.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.LoadPhotoButton.Name = "LoadPhotoButton";
            this.LoadPhotoButton.Size = new System.Drawing.Size(216, 30);
            this.LoadPhotoButton.TabIndex = 0;
            this.LoadPhotoButton.Text = "Nahrát fotografii";
            this.LoadPhotoButton.UseVisualStyleBackColor = true;
            this.LoadPhotoButton.Click += new System.EventHandler(this.LoadPhotoButton_Click);
            // 
            // ProductPictureBox
            // 
            this.ProductPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductPictureBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ProductPictureBox.Location = new System.Drawing.Point(10, 10);
            this.ProductPictureBox.Margin = new System.Windows.Forms.Padding(10);
            this.ProductPictureBox.Name = "ProductPictureBox";
            this.ProductPictureBox.Size = new System.Drawing.Size(216, 234);
            this.ProductPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProductPictureBox.TabIndex = 1;
            this.ProductPictureBox.TabStop = false;
            // 
            // AddPicButtonTLPanel
            // 
            this.AddPicButtonTLPanel.AutoSize = true;
            this.AddPicButtonTLPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddPicButtonTLPanel.BackColor = System.Drawing.SystemColors.Control;
            this.AddPicButtonTLPanel.ColumnCount = 2;
            this.AddPicButtonTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AddPicButtonTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AddPicButtonTLPanel.Controls.Add(this.SaveProductButton, 0, 0);
            this.AddPicButtonTLPanel.Controls.Add(this.ClearFormButton, 1, 0);
            this.AddPicButtonTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddPicButtonTLPanel.Location = new System.Drawing.Point(3, 327);
            this.AddPicButtonTLPanel.Name = "AddPicButtonTLPanel";
            this.AddPicButtonTLPanel.RowCount = 1;
            this.AddPicButtonTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AddPicButtonTLPanel.Size = new System.Drawing.Size(640, 64);
            this.AddPicButtonTLPanel.TabIndex = 1;
            // 
            // SaveProductButton
            // 
            this.SaveProductButton.AutoSize = true;
            this.SaveProductButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveProductButton.Location = new System.Drawing.Point(7, 10);
            this.SaveProductButton.Margin = new System.Windows.Forms.Padding(7, 10, 7, 19);
            this.SaveProductButton.Name = "SaveProductButton";
            this.SaveProductButton.Size = new System.Drawing.Size(306, 35);
            this.SaveProductButton.TabIndex = 2;
            this.SaveProductButton.Text = "Uložit změny";
            this.SaveProductButton.UseVisualStyleBackColor = true;
            // 
            // ClearFormButton
            // 
            this.ClearFormButton.AutoSize = true;
            this.ClearFormButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearFormButton.Location = new System.Drawing.Point(327, 10);
            this.ClearFormButton.Margin = new System.Windows.Forms.Padding(7, 10, 7, 19);
            this.ClearFormButton.Name = "ClearFormButton";
            this.ClearFormButton.Size = new System.Drawing.Size(306, 35);
            this.ClearFormButton.TabIndex = 0;
            this.ClearFormButton.Text = "Vrátit úpravy";
            this.ClearFormButton.UseVisualStyleBackColor = true;
            this.ClearFormButton.Click += new System.EventHandler(this.ClearFormButton_Click);
            // 
            // EditProductDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 394);
            this.Controls.Add(this.AddProducttTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EditProductDialog";
            this.Text = "Úprava produktu";
            this.AddProducttTableLayoutPanel.ResumeLayout(false);
            this.AddProducttTableLayoutPanel.PerformLayout();
            this.AddProductSplitContainer.Panel1.ResumeLayout(false);
            this.AddProductSplitContainer.Panel1.PerformLayout();
            this.AddProductSplitContainer.Panel2.ResumeLayout(false);
            this.AddProductSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddProductSplitContainer)).EndInit();
            this.AddProductSplitContainer.ResumeLayout(false);
            this.ProductDetailsTLPanel.ResumeLayout(false);
            this.ProductDetailsTLPanel.PerformLayout();
            this.ProductDetailsFLPanel.ResumeLayout(false);
            this.ProductIDTLPanel.ResumeLayout(false);
            this.ProductIDTLPanel.PerformLayout();
            this.ProductNameTLPanel.ResumeLayout(false);
            this.ProductNameTLPanel.PerformLayout();
            this.ProductCathegoryTLPanel.ResumeLayout(false);
            this.ProductCathegoryTLPanel.PerformLayout();
            this.ProductPriceTLPanel.ResumeLayout(false);
            this.ProductPriceTLPanel.PerformLayout();
            this.DescriptionTLPanel.ResumeLayout(false);
            this.DescriptionTLPanel.PerformLayout();
            this.ProductPictureTLPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductPictureBox)).EndInit();
            this.AddPicButtonTLPanel.ResumeLayout(false);
            this.AddPicButtonTLPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel AddProducttTableLayoutPanel;
        private System.Windows.Forms.SplitContainer AddProductSplitContainer;
        private System.Windows.Forms.TableLayoutPanel ProductPictureTLPanel;
        private System.Windows.Forms.FlowLayoutPanel ProductDetailsFLPanel;
        private System.Windows.Forms.TableLayoutPanel ProductIDTLPanel;
        private System.Windows.Forms.TableLayoutPanel ProductNameTLPanel;
        private System.Windows.Forms.TableLayoutPanel ProductCathegoryTLPanel;
        private System.Windows.Forms.TableLayoutPanel ProductPriceTLPanel;
        private System.Windows.Forms.Label ProductIDLabel;
        private System.Windows.Forms.Label ProductNameLabel;
        private System.Windows.Forms.Label ProductCathegoryLabel;
        private System.Windows.Forms.TextBox ProductIDTextBox;
        private System.Windows.Forms.TextBox ProductNameTextBox;
        private System.Windows.Forms.Label ProductPriceLabel;
        private System.Windows.Forms.ComboBox ProductCathegoryCBox;
        private System.Windows.Forms.Button LoadPhotoButton;
        private System.Windows.Forms.PictureBox ProductPictureBox;
        private System.Windows.Forms.TableLayoutPanel ProductDetailsTLPanel;
        private System.Windows.Forms.TableLayoutPanel DescriptionTLPanel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.RichTextBox ProductDescriptionRTBox;
        private System.Windows.Forms.TableLayoutPanel AddPicButtonTLPanel;
        private System.Windows.Forms.Button SaveProductButton;
        private System.Windows.Forms.Button ClearFormButton;
        private System.Windows.Forms.TextBox ProductPriceTextBox;
    }
}