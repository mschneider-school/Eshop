namespace Eshop
{
    partial class OrderDetailForm
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
            this.WrapperTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.OrdersControlsTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CustomerConfirmOrderButton = new System.Windows.Forms.Button();
            this.ShowProductDetailButton = new System.Windows.Forms.Button();
            this.OrderItemsSeparator = new System.Windows.Forms.TableLayoutPanel();
            this.OrderedItemsLabel = new System.Windows.Forms.Label();
            this.OrderedItemsDataGridView = new System.Windows.Forms.DataGridView();
            this.TotalSumTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.TotalPriceValueLabel = new System.Windows.Forms.Label();
            this.TotalPriceLabel = new System.Windows.Forms.Label();
            this.DiscountSumValueLabel = new System.Windows.Forms.Label();
            this.DiscountSumLabel = new System.Windows.Forms.Label();
            this.CustomerDetailsPartTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DeliverySeparator = new System.Windows.Forms.TableLayoutPanel();
            this.DeliveryAddressDetailsTableTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PostalCodeValueLabel = new System.Windows.Forms.Label();
            this.PostalCodeLabel = new System.Windows.Forms.Label();
            this.HouseNumberValueLabel = new System.Windows.Forms.Label();
            this.HouseNumberLabel = new System.Windows.Forms.Label();
            this.StreetValueLabel = new System.Windows.Forms.Label();
            this.StreetLabel = new System.Windows.Forms.Label();
            this.CityValueLabel = new System.Windows.Forms.Label();
            this.CityLabel = new System.Windows.Forms.Label();
            this.DeliveryAddressLabel = new System.Windows.Forms.Label();
            this.CustomerSeparator = new System.Windows.Forms.TableLayoutPanel();
            this.CustomerDetailsLabel = new System.Windows.Forms.Label();
            this.CustomerDetailsTableTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PhoneValueLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.EmailValueLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.LastNameValueLabel = new System.Windows.Forms.Label();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.FirstNameValueLabel = new System.Windows.Forms.Label();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.WrapperTLPanel.SuspendLayout();
            this.OrdersControlsTLPanel.SuspendLayout();
            this.OrderItemsSeparator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderedItemsDataGridView)).BeginInit();
            this.TotalSumTLPanel.SuspendLayout();
            this.CustomerDetailsPartTLPanel.SuspendLayout();
            this.DeliverySeparator.SuspendLayout();
            this.DeliveryAddressDetailsTableTLPanel.SuspendLayout();
            this.CustomerSeparator.SuspendLayout();
            this.CustomerDetailsTableTLPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // WrapperTLPanel
            // 
            this.WrapperTLPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.WrapperTLPanel.ColumnCount = 1;
            this.WrapperTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.WrapperTLPanel.Controls.Add(this.OrdersControlsTLPanel, 0, 2);
            this.WrapperTLPanel.Controls.Add(this.OrderItemsSeparator, 0, 1);
            this.WrapperTLPanel.Controls.Add(this.CustomerDetailsPartTLPanel, 0, 0);
            this.WrapperTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WrapperTLPanel.Location = new System.Drawing.Point(0, 10);
            this.WrapperTLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.WrapperTLPanel.Name = "WrapperTLPanel";
            this.WrapperTLPanel.RowCount = 3;
            this.WrapperTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.WrapperTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.WrapperTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.WrapperTLPanel.Size = new System.Drawing.Size(747, 637);
            this.WrapperTLPanel.TabIndex = 0;
            // 
            // OrdersControlsTLPanel
            // 
            this.OrdersControlsTLPanel.BackColor = System.Drawing.SystemColors.Control;
            this.OrdersControlsTLPanel.ColumnCount = 2;
            this.OrdersControlsTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.OrdersControlsTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.OrdersControlsTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.OrdersControlsTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.OrdersControlsTLPanel.Controls.Add(this.CustomerConfirmOrderButton, 0, 0);
            this.OrdersControlsTLPanel.Controls.Add(this.ShowProductDetailButton, 0, 0);
            this.OrdersControlsTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrdersControlsTLPanel.Location = new System.Drawing.Point(0, 563);
            this.OrdersControlsTLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.OrdersControlsTLPanel.Name = "OrdersControlsTLPanel";
            this.OrdersControlsTLPanel.RowCount = 1;
            this.OrdersControlsTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.OrdersControlsTLPanel.Size = new System.Drawing.Size(747, 74);
            this.OrdersControlsTLPanel.TabIndex = 2;
            // 
            // CustomerConfirmOrderButton
            // 
            this.CustomerConfirmOrderButton.AutoSize = true;
            this.CustomerConfirmOrderButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerConfirmOrderButton.Location = new System.Drawing.Point(380, 21);
            this.CustomerConfirmOrderButton.Margin = new System.Windows.Forms.Padding(7, 21, 7, 19);
            this.CustomerConfirmOrderButton.Name = "CustomerConfirmOrderButton";
            this.CustomerConfirmOrderButton.Size = new System.Drawing.Size(360, 34);
            this.CustomerConfirmOrderButton.TabIndex = 1;
            this.CustomerConfirmOrderButton.Text = "Potvrdit objednávku";
            this.CustomerConfirmOrderButton.UseVisualStyleBackColor = true;
            // 
            // ShowProductDetailButton
            // 
            this.ShowProductDetailButton.AutoSize = true;
            this.ShowProductDetailButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShowProductDetailButton.Location = new System.Drawing.Point(7, 21);
            this.ShowProductDetailButton.Margin = new System.Windows.Forms.Padding(7, 21, 7, 19);
            this.ShowProductDetailButton.Name = "ShowProductDetailButton";
            this.ShowProductDetailButton.Size = new System.Drawing.Size(359, 34);
            this.ShowProductDetailButton.TabIndex = 0;
            this.ShowProductDetailButton.Text = "Detail produktu";
            this.ShowProductDetailButton.UseVisualStyleBackColor = true;
            // 
            // OrderItemsSeparator
            // 
            this.OrderItemsSeparator.AutoSize = true;
            this.OrderItemsSeparator.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.OrderItemsSeparator.ColumnCount = 1;
            this.OrderItemsSeparator.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.OrderItemsSeparator.Controls.Add(this.OrderedItemsLabel, 0, 0);
            this.OrderItemsSeparator.Controls.Add(this.OrderedItemsDataGridView, 0, 1);
            this.OrderItemsSeparator.Controls.Add(this.TotalSumTLPanel, 0, 2);
            this.OrderItemsSeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrderItemsSeparator.Location = new System.Drawing.Point(0, 253);
            this.OrderItemsSeparator.Margin = new System.Windows.Forms.Padding(0);
            this.OrderItemsSeparator.Name = "OrderItemsSeparator";
            this.OrderItemsSeparator.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.OrderItemsSeparator.RowCount = 3;
            this.OrderItemsSeparator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.OrderItemsSeparator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.OrderItemsSeparator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.OrderItemsSeparator.Size = new System.Drawing.Size(747, 310);
            this.OrderItemsSeparator.TabIndex = 1;
            // 
            // OrderedItemsLabel
            // 
            this.OrderedItemsLabel.AutoSize = true;
            this.OrderedItemsLabel.BackColor = System.Drawing.SystemColors.Control;
            this.OrderedItemsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrderedItemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderedItemsLabel.Location = new System.Drawing.Point(10, 0);
            this.OrderedItemsLabel.Margin = new System.Windows.Forms.Padding(0);
            this.OrderedItemsLabel.Name = "OrderedItemsLabel";
            this.OrderedItemsLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.OrderedItemsLabel.Size = new System.Drawing.Size(727, 58);
            this.OrderedItemsLabel.TabIndex = 1;
            this.OrderedItemsLabel.Text = "Objednané zboží";
            this.OrderedItemsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OrderedItemsDataGridView
            // 
            this.OrderedItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrderedItemsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrderedItemsDataGridView.Location = new System.Drawing.Point(10, 68);
            this.OrderedItemsDataGridView.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.OrderedItemsDataGridView.Name = "OrderedItemsDataGridView";
            this.OrderedItemsDataGridView.Size = new System.Drawing.Size(727, 186);
            this.OrderedItemsDataGridView.TabIndex = 2;
            // 
            // TotalSumTLPanel
            // 
            this.TotalSumTLPanel.AutoSize = true;
            this.TotalSumTLPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TotalSumTLPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TotalSumTLPanel.ColumnCount = 4;
            this.TotalSumTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TotalSumTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.TotalSumTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TotalSumTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.TotalSumTLPanel.Controls.Add(this.TotalPriceValueLabel, 3, 0);
            this.TotalSumTLPanel.Controls.Add(this.TotalPriceLabel, 2, 0);
            this.TotalSumTLPanel.Controls.Add(this.DiscountSumValueLabel, 1, 0);
            this.TotalSumTLPanel.Controls.Add(this.DiscountSumLabel, 0, 0);
            this.TotalSumTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TotalSumTLPanel.Location = new System.Drawing.Point(10, 254);
            this.TotalSumTLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TotalSumTLPanel.Name = "TotalSumTLPanel";
            this.TotalSumTLPanel.RowCount = 1;
            this.TotalSumTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TotalSumTLPanel.Size = new System.Drawing.Size(727, 46);
            this.TotalSumTLPanel.TabIndex = 3;
            // 
            // TotalPriceValueLabel
            // 
            this.TotalPriceValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TotalPriceValueLabel.AutoSize = true;
            this.TotalPriceValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalPriceValueLabel.Location = new System.Drawing.Point(521, 15);
            this.TotalPriceValueLabel.Margin = new System.Windows.Forms.Padding(13, 0, 3, 0);
            this.TotalPriceValueLabel.Name = "TotalPriceValueLabel";
            this.TotalPriceValueLabel.Size = new System.Drawing.Size(36, 15);
            this.TotalPriceValueLabel.TabIndex = 3;
            this.TotalPriceValueLabel.Text = "value";
            // 
            // TotalPriceLabel
            // 
            this.TotalPriceLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TotalPriceLabel.AutoSize = true;
            this.TotalPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalPriceLabel.Location = new System.Drawing.Point(380, 15);
            this.TotalPriceLabel.Margin = new System.Windows.Forms.Padding(17, 0, 3, 0);
            this.TotalPriceLabel.Name = "TotalPriceLabel";
            this.TotalPriceLabel.Size = new System.Drawing.Size(87, 15);
            this.TotalPriceLabel.TabIndex = 2;
            this.TotalPriceLabel.Text = "Celková suma:";
            // 
            // DiscountSumValueLabel
            // 
            this.DiscountSumValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DiscountSumValueLabel.AutoSize = true;
            this.DiscountSumValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiscountSumValueLabel.Location = new System.Drawing.Point(157, 15);
            this.DiscountSumValueLabel.Margin = new System.Windows.Forms.Padding(12, 0, 3, 0);
            this.DiscountSumValueLabel.Name = "DiscountSumValueLabel";
            this.DiscountSumValueLabel.Size = new System.Drawing.Size(36, 15);
            this.DiscountSumValueLabel.TabIndex = 1;
            this.DiscountSumValueLabel.Text = "value";
            // 
            // DiscountSumLabel
            // 
            this.DiscountSumLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DiscountSumLabel.AutoSize = true;
            this.DiscountSumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiscountSumLabel.Location = new System.Drawing.Point(8, 15);
            this.DiscountSumLabel.Margin = new System.Windows.Forms.Padding(8, 0, 3, 0);
            this.DiscountSumLabel.Name = "DiscountSumLabel";
            this.DiscountSumLabel.Size = new System.Drawing.Size(74, 15);
            this.DiscountSumLabel.TabIndex = 0;
            this.DiscountSumLabel.Text = "Souhrn slev:";
            // 
            // CustomerDetailsPartTLPanel
            // 
            this.CustomerDetailsPartTLPanel.AutoSize = true;
            this.CustomerDetailsPartTLPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CustomerDetailsPartTLPanel.ColumnCount = 2;
            this.CustomerDetailsPartTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CustomerDetailsPartTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CustomerDetailsPartTLPanel.Controls.Add(this.DeliverySeparator, 1, 0);
            this.CustomerDetailsPartTLPanel.Controls.Add(this.CustomerSeparator, 0, 0);
            this.CustomerDetailsPartTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerDetailsPartTLPanel.Location = new System.Drawing.Point(0, 0);
            this.CustomerDetailsPartTLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.CustomerDetailsPartTLPanel.Name = "CustomerDetailsPartTLPanel";
            this.CustomerDetailsPartTLPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.CustomerDetailsPartTLPanel.RowCount = 1;
            this.CustomerDetailsPartTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CustomerDetailsPartTLPanel.Size = new System.Drawing.Size(747, 253);
            this.CustomerDetailsPartTLPanel.TabIndex = 0;
            // 
            // DeliverySeparator
            // 
            this.DeliverySeparator.AutoSize = true;
            this.DeliverySeparator.ColumnCount = 1;
            this.DeliverySeparator.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DeliverySeparator.Controls.Add(this.DeliveryAddressDetailsTableTLPanel, 0, 1);
            this.DeliverySeparator.Controls.Add(this.DeliveryAddressLabel, 0, 0);
            this.DeliverySeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeliverySeparator.Location = new System.Drawing.Point(373, 10);
            this.DeliverySeparator.Margin = new System.Windows.Forms.Padding(0);
            this.DeliverySeparator.Name = "DeliverySeparator";
            this.DeliverySeparator.RowCount = 2;
            this.DeliverySeparator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.DeliverySeparator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DeliverySeparator.Size = new System.Drawing.Size(364, 243);
            this.DeliverySeparator.TabIndex = 1;
            // 
            // DeliveryAddressDetailsTableTLPanel
            // 
            this.DeliveryAddressDetailsTableTLPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DeliveryAddressDetailsTableTLPanel.ColumnCount = 2;
            this.DeliveryAddressDetailsTableTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.DeliveryAddressDetailsTableTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.DeliveryAddressDetailsTableTLPanel.Controls.Add(this.PostalCodeValueLabel, 1, 3);
            this.DeliveryAddressDetailsTableTLPanel.Controls.Add(this.PostalCodeLabel, 0, 3);
            this.DeliveryAddressDetailsTableTLPanel.Controls.Add(this.HouseNumberValueLabel, 1, 2);
            this.DeliveryAddressDetailsTableTLPanel.Controls.Add(this.HouseNumberLabel, 0, 2);
            this.DeliveryAddressDetailsTableTLPanel.Controls.Add(this.StreetValueLabel, 1, 1);
            this.DeliveryAddressDetailsTableTLPanel.Controls.Add(this.StreetLabel, 0, 1);
            this.DeliveryAddressDetailsTableTLPanel.Controls.Add(this.CityValueLabel, 1, 0);
            this.DeliveryAddressDetailsTableTLPanel.Controls.Add(this.CityLabel, 0, 0);
            this.DeliveryAddressDetailsTableTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeliveryAddressDetailsTableTLPanel.Location = new System.Drawing.Point(0, 58);
            this.DeliveryAddressDetailsTableTLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.DeliveryAddressDetailsTableTLPanel.Name = "DeliveryAddressDetailsTableTLPanel";
            this.DeliveryAddressDetailsTableTLPanel.RowCount = 4;
            this.DeliveryAddressDetailsTableTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.DeliveryAddressDetailsTableTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.DeliveryAddressDetailsTableTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.DeliveryAddressDetailsTableTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.DeliveryAddressDetailsTableTLPanel.Size = new System.Drawing.Size(364, 185);
            this.DeliveryAddressDetailsTableTLPanel.TabIndex = 2;
            // 
            // PostalCodeValueLabel
            // 
            this.PostalCodeValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PostalCodeValueLabel.AutoSize = true;
            this.PostalCodeValueLabel.Location = new System.Drawing.Point(157, 155);
            this.PostalCodeValueLabel.Margin = new System.Windows.Forms.Padding(12, 0, 3, 0);
            this.PostalCodeValueLabel.Name = "PostalCodeValueLabel";
            this.PostalCodeValueLabel.Size = new System.Drawing.Size(33, 13);
            this.PostalCodeValueLabel.TabIndex = 7;
            this.PostalCodeValueLabel.Text = "value";
            // 
            // PostalCodeLabel
            // 
            this.PostalCodeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PostalCodeLabel.AutoSize = true;
            this.PostalCodeLabel.Location = new System.Drawing.Point(17, 155);
            this.PostalCodeLabel.Margin = new System.Windows.Forms.Padding(17, 0, 3, 0);
            this.PostalCodeLabel.Name = "PostalCodeLabel";
            this.PostalCodeLabel.Size = new System.Drawing.Size(31, 13);
            this.PostalCodeLabel.TabIndex = 6;
            this.PostalCodeLabel.Text = "PSČ:";
            // 
            // HouseNumberValueLabel
            // 
            this.HouseNumberValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.HouseNumberValueLabel.AutoSize = true;
            this.HouseNumberValueLabel.Location = new System.Drawing.Point(157, 108);
            this.HouseNumberValueLabel.Margin = new System.Windows.Forms.Padding(12, 0, 3, 0);
            this.HouseNumberValueLabel.Name = "HouseNumberValueLabel";
            this.HouseNumberValueLabel.Size = new System.Drawing.Size(33, 13);
            this.HouseNumberValueLabel.TabIndex = 5;
            this.HouseNumberValueLabel.Text = "value";
            // 
            // HouseNumberLabel
            // 
            this.HouseNumberLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.HouseNumberLabel.AutoSize = true;
            this.HouseNumberLabel.Location = new System.Drawing.Point(17, 108);
            this.HouseNumberLabel.Margin = new System.Windows.Forms.Padding(17, 0, 3, 0);
            this.HouseNumberLabel.Name = "HouseNumberLabel";
            this.HouseNumberLabel.Size = new System.Drawing.Size(68, 13);
            this.HouseNumberLabel.TabIndex = 4;
            this.HouseNumberLabel.Text = "Číslo popisu:";
            // 
            // StreetValueLabel
            // 
            this.StreetValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.StreetValueLabel.AutoSize = true;
            this.StreetValueLabel.Location = new System.Drawing.Point(157, 62);
            this.StreetValueLabel.Margin = new System.Windows.Forms.Padding(12, 0, 3, 0);
            this.StreetValueLabel.Name = "StreetValueLabel";
            this.StreetValueLabel.Size = new System.Drawing.Size(33, 13);
            this.StreetValueLabel.TabIndex = 3;
            this.StreetValueLabel.Text = "value";
            // 
            // StreetLabel
            // 
            this.StreetLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.StreetLabel.AutoSize = true;
            this.StreetLabel.Location = new System.Drawing.Point(17, 62);
            this.StreetLabel.Margin = new System.Windows.Forms.Padding(17, 0, 3, 0);
            this.StreetLabel.Name = "StreetLabel";
            this.StreetLabel.Size = new System.Drawing.Size(34, 13);
            this.StreetLabel.TabIndex = 2;
            this.StreetLabel.Text = "Ulice:";
            // 
            // CityValueLabel
            // 
            this.CityValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CityValueLabel.AutoSize = true;
            this.CityValueLabel.Location = new System.Drawing.Point(157, 16);
            this.CityValueLabel.Margin = new System.Windows.Forms.Padding(12, 0, 3, 0);
            this.CityValueLabel.Name = "CityValueLabel";
            this.CityValueLabel.Size = new System.Drawing.Size(33, 13);
            this.CityValueLabel.TabIndex = 1;
            this.CityValueLabel.Text = "value";
            // 
            // CityLabel
            // 
            this.CityLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CityLabel.AutoSize = true;
            this.CityLabel.Location = new System.Drawing.Point(17, 16);
            this.CityLabel.Margin = new System.Windows.Forms.Padding(17, 0, 3, 0);
            this.CityLabel.Name = "CityLabel";
            this.CityLabel.Size = new System.Drawing.Size(36, 13);
            this.CityLabel.TabIndex = 0;
            this.CityLabel.Text = "Obec:";
            // 
            // DeliveryAddressLabel
            // 
            this.DeliveryAddressLabel.AutoSize = true;
            this.DeliveryAddressLabel.BackColor = System.Drawing.SystemColors.Control;
            this.DeliveryAddressLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeliveryAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeliveryAddressLabel.Location = new System.Drawing.Point(7, 0);
            this.DeliveryAddressLabel.Margin = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.DeliveryAddressLabel.Name = "DeliveryAddressLabel";
            this.DeliveryAddressLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.DeliveryAddressLabel.Size = new System.Drawing.Size(357, 58);
            this.DeliveryAddressLabel.TabIndex = 1;
            this.DeliveryAddressLabel.Text = "Fakturační adresa";
            this.DeliveryAddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CustomerSeparator
            // 
            this.CustomerSeparator.AutoSize = true;
            this.CustomerSeparator.ColumnCount = 1;
            this.CustomerSeparator.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CustomerSeparator.Controls.Add(this.CustomerDetailsLabel, 0, 0);
            this.CustomerSeparator.Controls.Add(this.CustomerDetailsTableTLPanel, 0, 1);
            this.CustomerSeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerSeparator.Location = new System.Drawing.Point(10, 10);
            this.CustomerSeparator.Margin = new System.Windows.Forms.Padding(0);
            this.CustomerSeparator.Name = "CustomerSeparator";
            this.CustomerSeparator.RowCount = 2;
            this.CustomerSeparator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.CustomerSeparator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CustomerSeparator.Size = new System.Drawing.Size(363, 243);
            this.CustomerSeparator.TabIndex = 0;
            // 
            // CustomerDetailsLabel
            // 
            this.CustomerDetailsLabel.AutoSize = true;
            this.CustomerDetailsLabel.BackColor = System.Drawing.SystemColors.Control;
            this.CustomerDetailsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerDetailsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerDetailsLabel.Location = new System.Drawing.Point(0, 0);
            this.CustomerDetailsLabel.Margin = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.CustomerDetailsLabel.Name = "CustomerDetailsLabel";
            this.CustomerDetailsLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.CustomerDetailsLabel.Size = new System.Drawing.Size(356, 58);
            this.CustomerDetailsLabel.TabIndex = 0;
            this.CustomerDetailsLabel.Text = "Zákazník";
            this.CustomerDetailsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CustomerDetailsTableTLPanel
            // 
            this.CustomerDetailsTableTLPanel.AutoSize = true;
            this.CustomerDetailsTableTLPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CustomerDetailsTableTLPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CustomerDetailsTableTLPanel.ColumnCount = 2;
            this.CustomerDetailsTableTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.CustomerDetailsTableTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.CustomerDetailsTableTLPanel.Controls.Add(this.PhoneValueLabel, 1, 3);
            this.CustomerDetailsTableTLPanel.Controls.Add(this.PhoneLabel, 0, 3);
            this.CustomerDetailsTableTLPanel.Controls.Add(this.EmailValueLabel, 1, 2);
            this.CustomerDetailsTableTLPanel.Controls.Add(this.EmailLabel, 0, 2);
            this.CustomerDetailsTableTLPanel.Controls.Add(this.LastNameValueLabel, 1, 1);
            this.CustomerDetailsTableTLPanel.Controls.Add(this.LastNameLabel, 0, 1);
            this.CustomerDetailsTableTLPanel.Controls.Add(this.FirstNameValueLabel, 1, 0);
            this.CustomerDetailsTableTLPanel.Controls.Add(this.FirstNameLabel, 0, 0);
            this.CustomerDetailsTableTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerDetailsTableTLPanel.Location = new System.Drawing.Point(0, 58);
            this.CustomerDetailsTableTLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.CustomerDetailsTableTLPanel.Name = "CustomerDetailsTableTLPanel";
            this.CustomerDetailsTableTLPanel.RowCount = 4;
            this.CustomerDetailsTableTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.CustomerDetailsTableTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.CustomerDetailsTableTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.CustomerDetailsTableTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.CustomerDetailsTableTLPanel.Size = new System.Drawing.Size(363, 185);
            this.CustomerDetailsTableTLPanel.TabIndex = 1;
            // 
            // PhoneValueLabel
            // 
            this.PhoneValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PhoneValueLabel.AutoSize = true;
            this.PhoneValueLabel.Location = new System.Drawing.Point(155, 155);
            this.PhoneValueLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.PhoneValueLabel.Name = "PhoneValueLabel";
            this.PhoneValueLabel.Size = new System.Drawing.Size(33, 13);
            this.PhoneValueLabel.TabIndex = 7;
            this.PhoneValueLabel.Text = "value";
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Location = new System.Drawing.Point(10, 155);
            this.PhoneLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(35, 13);
            this.PhoneLabel.TabIndex = 6;
            this.PhoneLabel.Text = "Mobil:";
            // 
            // EmailValueLabel
            // 
            this.EmailValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EmailValueLabel.AutoSize = true;
            this.EmailValueLabel.Location = new System.Drawing.Point(155, 108);
            this.EmailValueLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.EmailValueLabel.Name = "EmailValueLabel";
            this.EmailValueLabel.Size = new System.Drawing.Size(33, 13);
            this.EmailValueLabel.TabIndex = 5;
            this.EmailValueLabel.Text = "value";
            // 
            // EmailLabel
            // 
            this.EmailLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(10, 108);
            this.EmailLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(35, 13);
            this.EmailLabel.TabIndex = 4;
            this.EmailLabel.Text = "Email:";
            // 
            // LastNameValueLabel
            // 
            this.LastNameValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LastNameValueLabel.AutoSize = true;
            this.LastNameValueLabel.Location = new System.Drawing.Point(155, 62);
            this.LastNameValueLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.LastNameValueLabel.Name = "LastNameValueLabel";
            this.LastNameValueLabel.Size = new System.Drawing.Size(33, 13);
            this.LastNameValueLabel.TabIndex = 3;
            this.LastNameValueLabel.Text = "value";
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(10, 62);
            this.LastNameLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(51, 13);
            this.LastNameLabel.TabIndex = 2;
            this.LastNameLabel.Text = "Příjmení:";
            // 
            // FirstNameValueLabel
            // 
            this.FirstNameValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FirstNameValueLabel.AutoSize = true;
            this.FirstNameValueLabel.Location = new System.Drawing.Point(155, 16);
            this.FirstNameValueLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.FirstNameValueLabel.Name = "FirstNameValueLabel";
            this.FirstNameValueLabel.Size = new System.Drawing.Size(33, 13);
            this.FirstNameValueLabel.TabIndex = 1;
            this.FirstNameValueLabel.Text = "value";
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Location = new System.Drawing.Point(10, 16);
            this.FirstNameLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(41, 13);
            this.FirstNameLabel.TabIndex = 0;
            this.FirstNameLabel.Text = "Jméno:";
            // 
            // OrderDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(747, 647);
            this.Controls.Add(this.WrapperTLPanel);
            this.Name = "OrderDetailForm";
            this.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.Text = "Detail objednávky";
            this.WrapperTLPanel.ResumeLayout(false);
            this.WrapperTLPanel.PerformLayout();
            this.OrdersControlsTLPanel.ResumeLayout(false);
            this.OrdersControlsTLPanel.PerformLayout();
            this.OrderItemsSeparator.ResumeLayout(false);
            this.OrderItemsSeparator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderedItemsDataGridView)).EndInit();
            this.TotalSumTLPanel.ResumeLayout(false);
            this.TotalSumTLPanel.PerformLayout();
            this.CustomerDetailsPartTLPanel.ResumeLayout(false);
            this.CustomerDetailsPartTLPanel.PerformLayout();
            this.DeliverySeparator.ResumeLayout(false);
            this.DeliverySeparator.PerformLayout();
            this.DeliveryAddressDetailsTableTLPanel.ResumeLayout(false);
            this.DeliveryAddressDetailsTableTLPanel.PerformLayout();
            this.CustomerSeparator.ResumeLayout(false);
            this.CustomerSeparator.PerformLayout();
            this.CustomerDetailsTableTLPanel.ResumeLayout(false);
            this.CustomerDetailsTableTLPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel WrapperTLPanel;
        private System.Windows.Forms.TableLayoutPanel CustomerDetailsPartTLPanel;
        private System.Windows.Forms.TableLayoutPanel OrderItemsSeparator;
        private System.Windows.Forms.TableLayoutPanel DeliverySeparator;
        private System.Windows.Forms.TableLayoutPanel CustomerSeparator;
        private System.Windows.Forms.Label CustomerDetailsLabel;
        private System.Windows.Forms.Label DeliveryAddressLabel;
        private System.Windows.Forms.Label OrderedItemsLabel;
        private System.Windows.Forms.DataGridView OrderedItemsDataGridView;
        private System.Windows.Forms.TableLayoutPanel TotalSumTLPanel;
        private System.Windows.Forms.Label TotalPriceValueLabel;
        private System.Windows.Forms.Label TotalPriceLabel;
        private System.Windows.Forms.Label DiscountSumValueLabel;
        private System.Windows.Forms.Label DiscountSumLabel;
        private System.Windows.Forms.TableLayoutPanel CustomerDetailsTableTLPanel;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.TableLayoutPanel DeliveryAddressDetailsTableTLPanel;
        private System.Windows.Forms.Label PostalCodeValueLabel;
        private System.Windows.Forms.Label PostalCodeLabel;
        private System.Windows.Forms.Label HouseNumberValueLabel;
        private System.Windows.Forms.Label HouseNumberLabel;
        private System.Windows.Forms.Label StreetValueLabel;
        private System.Windows.Forms.Label StreetLabel;
        private System.Windows.Forms.Label CityValueLabel;
        private System.Windows.Forms.Label CityLabel;
        private System.Windows.Forms.Label PhoneValueLabel;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.Label EmailValueLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label LastNameValueLabel;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.Label FirstNameValueLabel;
        private System.Windows.Forms.TableLayoutPanel OrdersControlsTLPanel;
        private System.Windows.Forms.Button CustomerConfirmOrderButton;
        private System.Windows.Forms.Button ShowProductDetailButton;
    }
}