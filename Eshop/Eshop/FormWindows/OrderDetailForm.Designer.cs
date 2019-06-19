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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.WrapperTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.OrdersControlsTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CustomerConfirmOrderButton = new System.Windows.Forms.Button();
            this.ShowProductDetailButton = new System.Windows.Forms.Button();
            this.OrderItemsSeparator = new System.Windows.Forms.TableLayoutPanel();
            this.OrderItemsDataGridView = new System.Windows.Forms.DataGridView();
            this.TotalSumTLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.TotalOrderDiscountsLabel = new System.Windows.Forms.Label();
            this.TotalOrderDiscountsValueLabel = new System.Windows.Forms.Label();
            this.FinalOrderSumLabel = new System.Windows.Forms.Label();
            this.FinalOrderSumValueLabel = new System.Windows.Forms.Label();
            this.PercentualOrderDiscountValueLabel = new System.Windows.Forms.Label();
            this.FixedOrderDiscountValueLabel = new System.Windows.Forms.Label();
            this.FixedOrderDiscountLabel = new System.Windows.Forms.Label();
            this.PercentualOrderDiscountLabel = new System.Windows.Forms.Label();
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
            this.OrderItemsLabel = new System.Windows.Forms.Label();
            this.OrderItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FixedDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PercentualDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WrapperTLPanel.SuspendLayout();
            this.OrdersControlsTLPanel.SuspendLayout();
            this.OrderItemsSeparator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderItemsDataGridView)).BeginInit();
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
            this.WrapperTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.WrapperTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.WrapperTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.WrapperTLPanel.Size = new System.Drawing.Size(749, 653);
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
            this.OrdersControlsTLPanel.Location = new System.Drawing.Point(0, 580);
            this.OrdersControlsTLPanel.Margin = new System.Windows.Forms.Padding(0);
            this.OrdersControlsTLPanel.Name = "OrdersControlsTLPanel";
            this.OrdersControlsTLPanel.RowCount = 1;
            this.OrdersControlsTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.OrdersControlsTLPanel.Size = new System.Drawing.Size(749, 73);
            this.OrdersControlsTLPanel.TabIndex = 2;
            // 
            // CustomerConfirmOrderButton
            // 
            this.CustomerConfirmOrderButton.AutoSize = true;
            this.CustomerConfirmOrderButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerConfirmOrderButton.Location = new System.Drawing.Point(381, 21);
            this.CustomerConfirmOrderButton.Margin = new System.Windows.Forms.Padding(7, 21, 7, 19);
            this.CustomerConfirmOrderButton.Name = "CustomerConfirmOrderButton";
            this.CustomerConfirmOrderButton.Size = new System.Drawing.Size(361, 33);
            this.CustomerConfirmOrderButton.TabIndex = 1;
            this.CustomerConfirmOrderButton.Text = "Potvrdit objednávku";
            this.CustomerConfirmOrderButton.UseVisualStyleBackColor = true;
            this.CustomerConfirmOrderButton.Click += new System.EventHandler(this.CustomerConfirmOrderButton_Click);
            // 
            // ShowProductDetailButton
            // 
            this.ShowProductDetailButton.AutoSize = true;
            this.ShowProductDetailButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShowProductDetailButton.Location = new System.Drawing.Point(7, 21);
            this.ShowProductDetailButton.Margin = new System.Windows.Forms.Padding(7, 21, 7, 19);
            this.ShowProductDetailButton.Name = "ShowProductDetailButton";
            this.ShowProductDetailButton.Size = new System.Drawing.Size(360, 33);
            this.ShowProductDetailButton.TabIndex = 0;
            this.ShowProductDetailButton.Text = "Detail produktu";
            this.ShowProductDetailButton.UseVisualStyleBackColor = true;
            this.ShowProductDetailButton.Click += new System.EventHandler(this.ShowProductDetailButton_Click);
            // 
            // OrderItemsSeparator
            // 
            this.OrderItemsSeparator.AutoSize = true;
            this.OrderItemsSeparator.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.OrderItemsSeparator.ColumnCount = 1;
            this.OrderItemsSeparator.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.OrderItemsSeparator.Controls.Add(this.OrderItemsDataGridView, 0, 1);
            this.OrderItemsSeparator.Controls.Add(this.TotalSumTLPanel, 0, 2);
            this.OrderItemsSeparator.Controls.Add(this.OrderItemsLabel, 0, 0);
            this.OrderItemsSeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrderItemsSeparator.Location = new System.Drawing.Point(0, 232);
            this.OrderItemsSeparator.Margin = new System.Windows.Forms.Padding(0);
            this.OrderItemsSeparator.Name = "OrderItemsSeparator";
            this.OrderItemsSeparator.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.OrderItemsSeparator.RowCount = 3;
            this.OrderItemsSeparator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.OrderItemsSeparator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.OrderItemsSeparator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.OrderItemsSeparator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.OrderItemsSeparator.Size = new System.Drawing.Size(749, 348);
            this.OrderItemsSeparator.TabIndex = 1;
            // 
            // OrderItemsDataGridView
            // 
            this.OrderItemsDataGridView.AllowUserToAddRows = false;
            this.OrderItemsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OrderItemsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.OrderItemsDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.OrderItemsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.OrderItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrderItemsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderItemID,
            this.ProductName,
            this.ProductQuantity,
            this.Price,
            this.FixedDiscount,
            this.PercentualDiscount});
            this.OrderItemsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrderItemsDataGridView.Location = new System.Drawing.Point(10, 67);
            this.OrderItemsDataGridView.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.OrderItemsDataGridView.Name = "OrderItemsDataGridView";
            this.OrderItemsDataGridView.RowHeadersVisible = false;
            this.OrderItemsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OrderItemsDataGridView.Size = new System.Drawing.Size(729, 211);
            this.OrderItemsDataGridView.TabIndex = 2;
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
            this.TotalSumTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TotalSumTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TotalSumTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TotalSumTLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TotalSumTLPanel.Controls.Add(this.TotalOrderDiscountsLabel, 0, 1);
            this.TotalSumTLPanel.Controls.Add(this.TotalOrderDiscountsValueLabel, 0, 1);
            this.TotalSumTLPanel.Controls.Add(this.FinalOrderSumLabel, 0, 1);
            this.TotalSumTLPanel.Controls.Add(this.FinalOrderSumValueLabel, 0, 1);
            this.TotalSumTLPanel.Controls.Add(this.PercentualOrderDiscountValueLabel, 3, 0);
            this.TotalSumTLPanel.Controls.Add(this.FixedOrderDiscountValueLabel, 1, 0);
            this.TotalSumTLPanel.Controls.Add(this.FixedOrderDiscountLabel, 0, 0);
            this.TotalSumTLPanel.Controls.Add(this.PercentualOrderDiscountLabel, 2, 0);
            this.TotalSumTLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TotalSumTLPanel.Location = new System.Drawing.Point(10, 288);
            this.TotalSumTLPanel.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.TotalSumTLPanel.Name = "TotalSumTLPanel";
            this.TotalSumTLPanel.RowCount = 2;
            this.TotalSumTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TotalSumTLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TotalSumTLPanel.Size = new System.Drawing.Size(729, 50);
            this.TotalSumTLPanel.TabIndex = 3;
            // 
            // TotalOrderDiscountsLabel
            // 
            this.TotalOrderDiscountsLabel.AutoSize = true;
            this.TotalOrderDiscountsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TotalOrderDiscountsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalOrderDiscountsLabel.Location = new System.Drawing.Point(0, 25);
            this.TotalOrderDiscountsLabel.Margin = new System.Windows.Forms.Padding(0);
            this.TotalOrderDiscountsLabel.Name = "TotalOrderDiscountsLabel";
            this.TotalOrderDiscountsLabel.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.TotalOrderDiscountsLabel.Size = new System.Drawing.Size(145, 25);
            this.TotalOrderDiscountsLabel.TabIndex = 8;
            this.TotalOrderDiscountsLabel.Text = "Slevněno celkem (Kč):";
            this.TotalOrderDiscountsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TotalOrderDiscountsValueLabel
            // 
            this.TotalOrderDiscountsValueLabel.AutoSize = true;
            this.TotalOrderDiscountsValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TotalOrderDiscountsValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalOrderDiscountsValueLabel.Location = new System.Drawing.Point(145, 25);
            this.TotalOrderDiscountsValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.TotalOrderDiscountsValueLabel.Name = "TotalOrderDiscountsValueLabel";
            this.TotalOrderDiscountsValueLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.TotalOrderDiscountsValueLabel.Size = new System.Drawing.Size(218, 25);
            this.TotalOrderDiscountsValueLabel.TabIndex = 7;
            this.TotalOrderDiscountsValueLabel.Text = "value";
            this.TotalOrderDiscountsValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FinalOrderSumLabel
            // 
            this.FinalOrderSumLabel.AutoSize = true;
            this.FinalOrderSumLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FinalOrderSumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinalOrderSumLabel.Location = new System.Drawing.Point(363, 25);
            this.FinalOrderSumLabel.Margin = new System.Windows.Forms.Padding(0);
            this.FinalOrderSumLabel.Name = "FinalOrderSumLabel";
            this.FinalOrderSumLabel.Padding = new System.Windows.Forms.Padding(17, 0, 0, 0);
            this.FinalOrderSumLabel.Size = new System.Drawing.Size(145, 25);
            this.FinalOrderSumLabel.TabIndex = 6;
            this.FinalOrderSumLabel.Text = "Celková suma (Kč):";
            this.FinalOrderSumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FinalOrderSumValueLabel
            // 
            this.FinalOrderSumValueLabel.AutoSize = true;
            this.FinalOrderSumValueLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.FinalOrderSumValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FinalOrderSumValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinalOrderSumValueLabel.Location = new System.Drawing.Point(508, 25);
            this.FinalOrderSumValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.FinalOrderSumValueLabel.Name = "FinalOrderSumValueLabel";
            this.FinalOrderSumValueLabel.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.FinalOrderSumValueLabel.Size = new System.Drawing.Size(221, 25);
            this.FinalOrderSumValueLabel.TabIndex = 5;
            this.FinalOrderSumValueLabel.Text = "value";
            this.FinalOrderSumValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PercentualOrderDiscountValueLabel
            // 
            this.PercentualOrderDiscountValueLabel.AutoSize = true;
            this.PercentualOrderDiscountValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PercentualOrderDiscountValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PercentualOrderDiscountValueLabel.Location = new System.Drawing.Point(508, 0);
            this.PercentualOrderDiscountValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.PercentualOrderDiscountValueLabel.Name = "PercentualOrderDiscountValueLabel";
            this.PercentualOrderDiscountValueLabel.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.PercentualOrderDiscountValueLabel.Size = new System.Drawing.Size(221, 25);
            this.PercentualOrderDiscountValueLabel.TabIndex = 3;
            this.PercentualOrderDiscountValueLabel.Text = "value";
            this.PercentualOrderDiscountValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FixedOrderDiscountValueLabel
            // 
            this.FixedOrderDiscountValueLabel.AutoSize = true;
            this.FixedOrderDiscountValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FixedOrderDiscountValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FixedOrderDiscountValueLabel.Location = new System.Drawing.Point(145, 0);
            this.FixedOrderDiscountValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.FixedOrderDiscountValueLabel.Name = "FixedOrderDiscountValueLabel";
            this.FixedOrderDiscountValueLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.FixedOrderDiscountValueLabel.Size = new System.Drawing.Size(218, 25);
            this.FixedOrderDiscountValueLabel.TabIndex = 1;
            this.FixedOrderDiscountValueLabel.Text = "value";
            this.FixedOrderDiscountValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FixedOrderDiscountLabel
            // 
            this.FixedOrderDiscountLabel.AutoSize = true;
            this.FixedOrderDiscountLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.FixedOrderDiscountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FixedOrderDiscountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FixedOrderDiscountLabel.Location = new System.Drawing.Point(0, 0);
            this.FixedOrderDiscountLabel.Margin = new System.Windows.Forms.Padding(0);
            this.FixedOrderDiscountLabel.Name = "FixedOrderDiscountLabel";
            this.FixedOrderDiscountLabel.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.FixedOrderDiscountLabel.Size = new System.Drawing.Size(145, 25);
            this.FixedOrderDiscountLabel.TabIndex = 0;
            this.FixedOrderDiscountLabel.Text = "Sleva objednávky (Kč):";
            this.FixedOrderDiscountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PercentualOrderDiscountLabel
            // 
            this.PercentualOrderDiscountLabel.AutoSize = true;
            this.PercentualOrderDiscountLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PercentualOrderDiscountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PercentualOrderDiscountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PercentualOrderDiscountLabel.Location = new System.Drawing.Point(363, 0);
            this.PercentualOrderDiscountLabel.Margin = new System.Windows.Forms.Padding(0);
            this.PercentualOrderDiscountLabel.Name = "PercentualOrderDiscountLabel";
            this.PercentualOrderDiscountLabel.Padding = new System.Windows.Forms.Padding(17, 0, 0, 0);
            this.PercentualOrderDiscountLabel.Size = new System.Drawing.Size(145, 25);
            this.PercentualOrderDiscountLabel.TabIndex = 2;
            this.PercentualOrderDiscountLabel.Text = "Sleva objednávky (%):";
            this.PercentualOrderDiscountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.CustomerDetailsPartTLPanel.Size = new System.Drawing.Size(749, 232);
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
            this.DeliverySeparator.Location = new System.Drawing.Point(374, 10);
            this.DeliverySeparator.Margin = new System.Windows.Forms.Padding(0);
            this.DeliverySeparator.Name = "DeliverySeparator";
            this.DeliverySeparator.RowCount = 2;
            this.DeliverySeparator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.DeliverySeparator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DeliverySeparator.Size = new System.Drawing.Size(365, 222);
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
            this.DeliveryAddressDetailsTableTLPanel.Size = new System.Drawing.Size(365, 164);
            this.DeliveryAddressDetailsTableTLPanel.TabIndex = 2;
            // 
            // PostalCodeValueLabel
            // 
            this.PostalCodeValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PostalCodeValueLabel.AutoSize = true;
            this.PostalCodeValueLabel.Location = new System.Drawing.Point(158, 137);
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
            this.PostalCodeLabel.Location = new System.Drawing.Point(17, 137);
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
            this.HouseNumberValueLabel.Location = new System.Drawing.Point(158, 96);
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
            this.HouseNumberLabel.Location = new System.Drawing.Point(17, 96);
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
            this.StreetValueLabel.Location = new System.Drawing.Point(158, 55);
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
            this.StreetLabel.Location = new System.Drawing.Point(17, 55);
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
            this.CityValueLabel.Location = new System.Drawing.Point(158, 14);
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
            this.CityLabel.Location = new System.Drawing.Point(17, 14);
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
            this.DeliveryAddressLabel.Size = new System.Drawing.Size(358, 58);
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
            this.CustomerSeparator.Size = new System.Drawing.Size(364, 222);
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
            this.CustomerDetailsLabel.Size = new System.Drawing.Size(357, 58);
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
            this.CustomerDetailsTableTLPanel.Size = new System.Drawing.Size(364, 164);
            this.CustomerDetailsTableTLPanel.TabIndex = 1;
            // 
            // PhoneValueLabel
            // 
            this.PhoneValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PhoneValueLabel.AutoSize = true;
            this.PhoneValueLabel.Location = new System.Drawing.Point(155, 137);
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
            this.PhoneLabel.Location = new System.Drawing.Point(10, 137);
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
            this.EmailValueLabel.Location = new System.Drawing.Point(155, 96);
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
            this.EmailLabel.Location = new System.Drawing.Point(10, 96);
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
            this.LastNameValueLabel.Location = new System.Drawing.Point(155, 55);
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
            this.LastNameLabel.Location = new System.Drawing.Point(10, 55);
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
            this.FirstNameValueLabel.Location = new System.Drawing.Point(155, 14);
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
            this.FirstNameLabel.Location = new System.Drawing.Point(10, 14);
            this.FirstNameLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(41, 13);
            this.FirstNameLabel.TabIndex = 0;
            this.FirstNameLabel.Text = "Jméno:";
            // 
            // OrderItemsLabel
            // 
            this.OrderItemsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OrderItemsLabel.AutoSize = true;
            this.OrderItemsLabel.BackColor = System.Drawing.SystemColors.Control;
            this.OrderItemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderItemsLabel.Location = new System.Drawing.Point(10, 0);
            this.OrderItemsLabel.Margin = new System.Windows.Forms.Padding(0);
            this.OrderItemsLabel.Name = "OrderItemsLabel";
            this.OrderItemsLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.OrderItemsLabel.Size = new System.Drawing.Size(729, 57);
            this.OrderItemsLabel.TabIndex = 4;
            this.OrderItemsLabel.Text = "Detail objednávky";
            this.OrderItemsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OrderItemID
            // 
            this.OrderItemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(9, 5, 9, 5);
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.OrderItemID.DefaultCellStyle = dataGridViewCellStyle9;
            this.OrderItemID.HeaderText = "ID";
            this.OrderItemID.Name = "OrderItemID";
            this.OrderItemID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OrderItemID.ToolTipText = "Identifikační číslo produktu";
            this.OrderItemID.Width = 34;
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(9, 5, 9, 5);
            this.ProductName.DefaultCellStyle = dataGridViewCellStyle10;
            this.ProductName.HeaderText = "Název produktu";
            this.ProductName.Name = "ProductName";
            this.ProductName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProductName.ToolTipText = "Prodejný název produktové položky objednávky";
            // 
            // ProductQuantity
            // 
            this.ProductQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Padding = new System.Windows.Forms.Padding(9, 5, 9, 5);
            this.ProductQuantity.DefaultCellStyle = dataGridViewCellStyle11;
            this.ProductQuantity.HeaderText = "Množství";
            this.ProductQuantity.Name = "ProductQuantity";
            this.ProductQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProductQuantity.ToolTipText = "Množství položky je zadané v kusech.";
            this.ProductQuantity.Width = 67;
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N0";
            dataGridViewCellStyle12.NullValue = null;
            dataGridViewCellStyle12.Padding = new System.Windows.Forms.Padding(9, 5, 9, 5);
            this.Price.DefaultCellStyle = dataGridViewCellStyle12;
            this.Price.HeaderText = "Cena (Kč)";
            this.Price.Name = "Price";
            this.Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Price.ToolTipText = "Cena platí pro všechny kusy položky.";
            this.Price.Width = 70;
            // 
            // FixedDiscount
            // 
            this.FixedDiscount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N0";
            dataGridViewCellStyle13.NullValue = null;
            dataGridViewCellStyle13.Padding = new System.Windows.Forms.Padding(9, 5, 9, 5);
            this.FixedDiscount.DefaultCellStyle = dataGridViewCellStyle13;
            this.FixedDiscount.HeaderText = "Sleva (Kč)";
            this.FixedDiscount.Name = "FixedDiscount";
            this.FixedDiscount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FixedDiscount.ToolTipText = "Pevně daná sleva na položku se odečítá nezávisle na ostatních slevách.";
            this.FixedDiscount.Width = 72;
            // 
            // PercentualDiscount
            // 
            this.PercentualDiscount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Padding = new System.Windows.Forms.Padding(9, 5, 9, 5);
            this.PercentualDiscount.DefaultCellStyle = dataGridViewCellStyle14;
            this.PercentualDiscount.HeaderText = "Sleva (%)";
            this.PercentualDiscount.Name = "PercentualDiscount";
            this.PercentualDiscount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PercentualDiscount.ToolTipText = "Procentuálně daná sleva na položku se odečítá nezávisle na ostatních slevách.";
            this.PercentualDiscount.Width = 67;
            // 
            // OrderDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(749, 663);
            this.Controls.Add(this.WrapperTLPanel);
            this.MaximizeBox = false;
            this.Name = "OrderDetailForm";
            this.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.Text = "Detail objednávky";
            this.Load += new System.EventHandler(this.OrderDetailForm_Load);
            this.WrapperTLPanel.ResumeLayout(false);
            this.WrapperTLPanel.PerformLayout();
            this.OrdersControlsTLPanel.ResumeLayout(false);
            this.OrdersControlsTLPanel.PerformLayout();
            this.OrderItemsSeparator.ResumeLayout(false);
            this.OrderItemsSeparator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderItemsDataGridView)).EndInit();
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
        private System.Windows.Forms.DataGridView OrderItemsDataGridView;
        private System.Windows.Forms.TableLayoutPanel TotalSumTLPanel;
        private System.Windows.Forms.Label PercentualOrderDiscountValueLabel;
        private System.Windows.Forms.Label PercentualOrderDiscountLabel;
        private System.Windows.Forms.Label FixedOrderDiscountValueLabel;
        private System.Windows.Forms.Label FixedOrderDiscountLabel;
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
        private System.Windows.Forms.Label TotalOrderDiscountsLabel;
        private System.Windows.Forms.Label TotalOrderDiscountsValueLabel;
        private System.Windows.Forms.Label FinalOrderSumLabel;
        private System.Windows.Forms.Label FinalOrderSumValueLabel;
        private System.Windows.Forms.Label OrderItemsLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn FixedDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PercentualDiscount;
    }
}