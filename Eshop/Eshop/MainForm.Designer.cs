namespace Eshop
{
    partial class MainForm
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
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.UserViewsTabControl = new System.Windows.Forms.TabControl();
            this.AdminTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ItemsManagerFramePanel = new System.Windows.Forms.Panel();
            this.ItemsManagerLabel = new System.Windows.Forms.Label();
            this.ItemsWinFramePanel = new System.Windows.Forms.Panel();
            this.DatabaseTabControl = new System.Windows.Forms.TabControl();
            this.OrdersTabPage = new System.Windows.Forms.TabPage();
            this.OrdersTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.OrderListLabel = new System.Windows.Forms.Label();
            this.OrdersDataGridView = new System.Windows.Forms.DataGridView();
            this.OrdersTableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.DeleteOrderButton = new System.Windows.Forms.Button();
            this.DetailOrderButton = new System.Windows.Forms.Button();
            this.ConfirmOrderButton = new System.Windows.Forms.Button();
            this.ProductsTabPage = new System.Windows.Forms.TabPage();
            this.ProductsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ProductListLabel = new System.Windows.Forms.Label();
            this.ProductsDataGridView = new System.Windows.Forms.DataGridView();
            this.ProductsTableLayoutPanelButton = new System.Windows.Forms.TableLayoutPanel();
            this.UpdateProductButton = new System.Windows.Forms.Button();
            this.DeleteProductButton = new System.Windows.Forms.Button();
            this.ProductDetailButton = new System.Windows.Forms.Button();
            this.AddProductButton = new System.Windows.Forms.Button();
            this.UserTabPage = new System.Windows.Forms.TabPage();
            this.TableLayoutPanel1.SuspendLayout();
            this.UserViewsTabControl.SuspendLayout();
            this.AdminTabPage.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.ItemsManagerFramePanel.SuspendLayout();
            this.ItemsWinFramePanel.SuspendLayout();
            this.DatabaseTabControl.SuspendLayout();
            this.OrdersTabPage.SuspendLayout();
            this.OrdersTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersDataGridView)).BeginInit();
            this.OrdersTableLayoutPanelButtons.SuspendLayout();
            this.ProductsTabPage.SuspendLayout();
            this.ProductsTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsDataGridView)).BeginInit();
            this.ProductsTableLayoutPanelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 1;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Controls.Add(this.UserViewsTabControl, 0, 0);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(737, 537);
            this.TableLayoutPanel1.TabIndex = 0;
            // 
            // UserViewsTabControl
            // 
            this.UserViewsTabControl.Controls.Add(this.AdminTabPage);
            this.UserViewsTabControl.Controls.Add(this.UserTabPage);
            this.UserViewsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserViewsTabControl.Location = new System.Drawing.Point(10, 10);
            this.UserViewsTabControl.Margin = new System.Windows.Forms.Padding(10);
            this.UserViewsTabControl.Name = "UserViewsTabControl";
            this.UserViewsTabControl.Padding = new System.Drawing.Point(15, 6);
            this.UserViewsTabControl.SelectedIndex = 0;
            this.UserViewsTabControl.Size = new System.Drawing.Size(717, 517);
            this.UserViewsTabControl.TabIndex = 0;
            this.UserViewsTabControl.TabStop = false;
            this.UserViewsTabControl.Enter += new System.EventHandler(this.UserViewsTabControl_Enter);
            // 
            // AdminTabPage
            // 
            this.AdminTabPage.Controls.Add(this.tableLayoutPanel2);
            this.AdminTabPage.Location = new System.Drawing.Point(4, 28);
            this.AdminTabPage.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.AdminTabPage.Name = "AdminTabPage";
            this.AdminTabPage.Padding = new System.Windows.Forms.Padding(2);
            this.AdminTabPage.Size = new System.Drawing.Size(709, 485);
            this.AdminTabPage.TabIndex = 0;
            this.AdminTabPage.Text = "Admin";
            this.AdminTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.ItemsManagerFramePanel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ItemsWinFramePanel, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(705, 481);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // ItemsManagerFramePanel
            // 
            this.ItemsManagerFramePanel.AutoSize = true;
            this.ItemsManagerFramePanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ItemsManagerFramePanel.Controls.Add(this.ItemsManagerLabel);
            this.ItemsManagerFramePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsManagerFramePanel.Location = new System.Drawing.Point(3, 3);
            this.ItemsManagerFramePanel.Margin = new System.Windows.Forms.Padding(0);
            this.ItemsManagerFramePanel.Name = "ItemsManagerFramePanel";
            this.ItemsManagerFramePanel.Size = new System.Drawing.Size(699, 23);
            this.ItemsManagerFramePanel.TabIndex = 0;
            // 
            // ItemsManagerLabel
            // 
            this.ItemsManagerLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ItemsManagerLabel.AutoSize = true;
            this.ItemsManagerLabel.Location = new System.Drawing.Point(2, 5);
            this.ItemsManagerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ItemsManagerLabel.Name = "ItemsManagerLabel";
            this.ItemsManagerLabel.Size = new System.Drawing.Size(81, 13);
            this.ItemsManagerLabel.TabIndex = 0;
            this.ItemsManagerLabel.Text = "Správa položek";
            this.ItemsManagerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ItemsWinFramePanel
            // 
            this.ItemsWinFramePanel.AutoSize = true;
            this.ItemsWinFramePanel.BackColor = System.Drawing.Color.Gainsboro;
            this.ItemsWinFramePanel.Controls.Add(this.DatabaseTabControl);
            this.ItemsWinFramePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsWinFramePanel.Location = new System.Drawing.Point(5, 28);
            this.ItemsWinFramePanel.Margin = new System.Windows.Forms.Padding(2);
            this.ItemsWinFramePanel.Name = "ItemsWinFramePanel";
            this.ItemsWinFramePanel.Size = new System.Drawing.Size(695, 448);
            this.ItemsWinFramePanel.TabIndex = 1;
            // 
            // DatabaseTabControl
            // 
            this.DatabaseTabControl.Controls.Add(this.OrdersTabPage);
            this.DatabaseTabControl.Controls.Add(this.ProductsTabPage);
            this.DatabaseTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatabaseTabControl.Location = new System.Drawing.Point(0, 0);
            this.DatabaseTabControl.Margin = new System.Windows.Forms.Padding(2);
            this.DatabaseTabControl.Name = "DatabaseTabControl";
            this.DatabaseTabControl.SelectedIndex = 0;
            this.DatabaseTabControl.Size = new System.Drawing.Size(695, 448);
            this.DatabaseTabControl.TabIndex = 0;
            // 
            // OrdersTabPage
            // 
            this.OrdersTabPage.Controls.Add(this.OrdersTableLayoutPanel);
            this.OrdersTabPage.Location = new System.Drawing.Point(4, 22);
            this.OrdersTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.OrdersTabPage.Name = "OrdersTabPage";
            this.OrdersTabPage.Size = new System.Drawing.Size(687, 422);
            this.OrdersTabPage.TabIndex = 0;
            this.OrdersTabPage.Text = "Objednávky";
            this.OrdersTabPage.UseVisualStyleBackColor = true;
            // 
            // OrdersTableLayoutPanel
            // 
            this.OrdersTableLayoutPanel.AutoSize = true;
            this.OrdersTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OrdersTableLayoutPanel.ColumnCount = 1;
            this.OrdersTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.OrdersTableLayoutPanel.Controls.Add(this.OrderListLabel, 0, 0);
            this.OrdersTableLayoutPanel.Controls.Add(this.OrdersDataGridView, 0, 1);
            this.OrdersTableLayoutPanel.Controls.Add(this.OrdersTableLayoutPanelButtons, 0, 2);
            this.OrdersTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrdersTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.OrdersTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.OrdersTableLayoutPanel.Name = "OrdersTableLayoutPanel";
            this.OrdersTableLayoutPanel.RowCount = 3;
            this.OrdersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.OrdersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.OrdersTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.OrdersTableLayoutPanel.Size = new System.Drawing.Size(687, 422);
            this.OrdersTableLayoutPanel.TabIndex = 0;
            // 
            // OrderListLabel
            // 
            this.OrderListLabel.AutoSize = true;
            this.OrderListLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrderListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderListLabel.Location = new System.Drawing.Point(2, 0);
            this.OrderListLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OrderListLabel.Name = "OrderListLabel";
            this.OrderListLabel.Size = new System.Drawing.Size(683, 58);
            this.OrderListLabel.TabIndex = 0;
            this.OrderListLabel.Text = "Seznam objednávek";
            this.OrderListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OrdersDataGridView
            // 
            this.OrdersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrdersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrdersDataGridView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.OrdersDataGridView.Location = new System.Drawing.Point(7, 64);
            this.OrdersDataGridView.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.OrdersDataGridView.Name = "OrdersDataGridView";
            this.OrdersDataGridView.RowTemplate.Height = 28;
            this.OrdersDataGridView.Size = new System.Drawing.Size(673, 294);
            this.OrdersDataGridView.TabIndex = 1;
            // 
            // OrdersTableLayoutPanelButtons
            // 
            this.OrdersTableLayoutPanelButtons.AutoSize = true;
            this.OrdersTableLayoutPanelButtons.ColumnCount = 4;
            this.OrdersTableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.OrdersTableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.OrdersTableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.OrdersTableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.OrdersTableLayoutPanelButtons.Controls.Add(this.button1, 0, 0);
            this.OrdersTableLayoutPanelButtons.Controls.Add(this.DeleteOrderButton, 1, 0);
            this.OrdersTableLayoutPanelButtons.Controls.Add(this.DetailOrderButton, 2, 0);
            this.OrdersTableLayoutPanelButtons.Controls.Add(this.ConfirmOrderButton, 0, 0);
            this.OrdersTableLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrdersTableLayoutPanelButtons.Location = new System.Drawing.Point(0, 364);
            this.OrdersTableLayoutPanelButtons.Margin = new System.Windows.Forms.Padding(0);
            this.OrdersTableLayoutPanelButtons.Name = "OrdersTableLayoutPanelButtons";
            this.OrdersTableLayoutPanelButtons.RowCount = 1;
            this.OrdersTableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.OrdersTableLayoutPanelButtons.Size = new System.Drawing.Size(687, 58);
            this.OrdersTableLayoutPanelButtons.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(178, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "Zrušit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DeleteOrderButton
            // 
            this.DeleteOrderButton.AutoSize = true;
            this.DeleteOrderButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteOrderButton.Location = new System.Drawing.Point(349, 6);
            this.DeleteOrderButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 19);
            this.DeleteOrderButton.Name = "DeleteOrderButton";
            this.DeleteOrderButton.Size = new System.Drawing.Size(157, 33);
            this.DeleteOrderButton.TabIndex = 0;
            this.DeleteOrderButton.Text = "Odeslat";
            this.DeleteOrderButton.UseVisualStyleBackColor = true;
            // 
            // DetailOrderButton
            // 
            this.DetailOrderButton.AutoSize = true;
            this.DetailOrderButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailOrderButton.Location = new System.Drawing.Point(520, 6);
            this.DetailOrderButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 19);
            this.DetailOrderButton.Name = "DetailOrderButton";
            this.DetailOrderButton.Size = new System.Drawing.Size(160, 33);
            this.DetailOrderButton.TabIndex = 1;
            this.DetailOrderButton.Text = "Zobrazit detail";
            this.DetailOrderButton.UseVisualStyleBackColor = true;
            // 
            // ConfirmOrderButton
            // 
            this.ConfirmOrderButton.AutoSize = true;
            this.ConfirmOrderButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfirmOrderButton.Location = new System.Drawing.Point(7, 6);
            this.ConfirmOrderButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 19);
            this.ConfirmOrderButton.Name = "ConfirmOrderButton";
            this.ConfirmOrderButton.Size = new System.Drawing.Size(157, 33);
            this.ConfirmOrderButton.TabIndex = 2;
            this.ConfirmOrderButton.Text = "Potvrdit";
            this.ConfirmOrderButton.UseVisualStyleBackColor = true;
            // 
            // ProductsTabPage
            // 
            this.ProductsTabPage.Controls.Add(this.ProductsTableLayoutPanel);
            this.ProductsTabPage.Location = new System.Drawing.Point(4, 22);
            this.ProductsTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.ProductsTabPage.Name = "ProductsTabPage";
            this.ProductsTabPage.Size = new System.Drawing.Size(687, 422);
            this.ProductsTabPage.TabIndex = 1;
            this.ProductsTabPage.Text = "Produkty";
            this.ProductsTabPage.UseVisualStyleBackColor = true;
            // 
            // ProductsTableLayoutPanel
            // 
            this.ProductsTableLayoutPanel.AutoSize = true;
            this.ProductsTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ProductsTableLayoutPanel.ColumnCount = 1;
            this.ProductsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProductsTableLayoutPanel.Controls.Add(this.ProductListLabel, 0, 0);
            this.ProductsTableLayoutPanel.Controls.Add(this.ProductsDataGridView, 0, 1);
            this.ProductsTableLayoutPanel.Controls.Add(this.ProductsTableLayoutPanelButton, 0, 2);
            this.ProductsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductsTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.ProductsTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ProductsTableLayoutPanel.Name = "ProductsTableLayoutPanel";
            this.ProductsTableLayoutPanel.RowCount = 3;
            this.ProductsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.ProductsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProductsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.ProductsTableLayoutPanel.Size = new System.Drawing.Size(687, 422);
            this.ProductsTableLayoutPanel.TabIndex = 1;
            // 
            // ProductListLabel
            // 
            this.ProductListLabel.AutoSize = true;
            this.ProductListLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductListLabel.Location = new System.Drawing.Point(2, 0);
            this.ProductListLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProductListLabel.Name = "ProductListLabel";
            this.ProductListLabel.Size = new System.Drawing.Size(683, 58);
            this.ProductListLabel.TabIndex = 0;
            this.ProductListLabel.Text = "Seznam produktů";
            this.ProductListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProductsDataGridView
            // 
            this.ProductsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductsDataGridView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.ProductsDataGridView.Location = new System.Drawing.Point(7, 64);
            this.ProductsDataGridView.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ProductsDataGridView.Name = "ProductsDataGridView";
            this.ProductsDataGridView.RowTemplate.Height = 28;
            this.ProductsDataGridView.Size = new System.Drawing.Size(673, 294);
            this.ProductsDataGridView.TabIndex = 1;
            // 
            // ProductsTableLayoutPanelButton
            // 
            this.ProductsTableLayoutPanelButton.AutoSize = true;
            this.ProductsTableLayoutPanelButton.ColumnCount = 4;
            this.ProductsTableLayoutPanelButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ProductsTableLayoutPanelButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ProductsTableLayoutPanelButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ProductsTableLayoutPanelButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ProductsTableLayoutPanelButton.Controls.Add(this.UpdateProductButton, 0, 0);
            this.ProductsTableLayoutPanelButton.Controls.Add(this.DeleteProductButton, 1, 0);
            this.ProductsTableLayoutPanelButton.Controls.Add(this.ProductDetailButton, 2, 0);
            this.ProductsTableLayoutPanelButton.Controls.Add(this.AddProductButton, 0, 0);
            this.ProductsTableLayoutPanelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductsTableLayoutPanelButton.Location = new System.Drawing.Point(0, 364);
            this.ProductsTableLayoutPanelButton.Margin = new System.Windows.Forms.Padding(0);
            this.ProductsTableLayoutPanelButton.Name = "ProductsTableLayoutPanelButton";
            this.ProductsTableLayoutPanelButton.RowCount = 1;
            this.ProductsTableLayoutPanelButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProductsTableLayoutPanelButton.Size = new System.Drawing.Size(687, 58);
            this.ProductsTableLayoutPanelButton.TabIndex = 2;
            // 
            // UpdateProductButton
            // 
            this.UpdateProductButton.AutoSize = true;
            this.UpdateProductButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UpdateProductButton.Location = new System.Drawing.Point(178, 6);
            this.UpdateProductButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 19);
            this.UpdateProductButton.Name = "UpdateProductButton";
            this.UpdateProductButton.Size = new System.Drawing.Size(157, 33);
            this.UpdateProductButton.TabIndex = 3;
            this.UpdateProductButton.Text = "Upravit";
            this.UpdateProductButton.UseVisualStyleBackColor = true;
            this.UpdateProductButton.Click += new System.EventHandler(this.UpdateProductButton_Click);
            // 
            // DeleteProductButton
            // 
            this.DeleteProductButton.AutoSize = true;
            this.DeleteProductButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeleteProductButton.Location = new System.Drawing.Point(349, 6);
            this.DeleteProductButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 19);
            this.DeleteProductButton.Name = "DeleteProductButton";
            this.DeleteProductButton.Size = new System.Drawing.Size(157, 33);
            this.DeleteProductButton.TabIndex = 0;
            this.DeleteProductButton.Text = "Vymazat";
            this.DeleteProductButton.UseVisualStyleBackColor = true;
            this.DeleteProductButton.Click += new System.EventHandler(this.DeleteProductButton_Click);
            // 
            // ProductDetailButton
            // 
            this.ProductDetailButton.AutoSize = true;
            this.ProductDetailButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductDetailButton.Location = new System.Drawing.Point(520, 6);
            this.ProductDetailButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 19);
            this.ProductDetailButton.Name = "ProductDetailButton";
            this.ProductDetailButton.Size = new System.Drawing.Size(160, 33);
            this.ProductDetailButton.TabIndex = 1;
            this.ProductDetailButton.Text = "Zobrazit detail";
            this.ProductDetailButton.UseVisualStyleBackColor = true;
            this.ProductDetailButton.Click += new System.EventHandler(this.ProductDetailButton_Click);
            // 
            // AddProductButton
            // 
            this.AddProductButton.AutoSize = true;
            this.AddProductButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddProductButton.Location = new System.Drawing.Point(7, 6);
            this.AddProductButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 19);
            this.AddProductButton.Name = "AddProductButton";
            this.AddProductButton.Size = new System.Drawing.Size(157, 33);
            this.AddProductButton.TabIndex = 2;
            this.AddProductButton.Text = "Přidat";
            this.AddProductButton.UseVisualStyleBackColor = true;
            this.AddProductButton.Click += new System.EventHandler(this.AddProductButton_Click);
            // 
            // UserTabPage
            // 
            this.UserTabPage.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.UserTabPage.Location = new System.Drawing.Point(4, 28);
            this.UserTabPage.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.UserTabPage.Name = "UserTabPage";
            this.UserTabPage.Padding = new System.Windows.Forms.Padding(2);
            this.UserTabPage.Size = new System.Drawing.Size(709, 485);
            this.UserTabPage.TabIndex = 1;
            this.UserTabPage.Text = "User";
            this.UserTabPage.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(737, 537);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-shop manager";
            this.TableLayoutPanel1.ResumeLayout(false);
            this.UserViewsTabControl.ResumeLayout(false);
            this.AdminTabPage.ResumeLayout(false);
            this.AdminTabPage.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ItemsManagerFramePanel.ResumeLayout(false);
            this.ItemsManagerFramePanel.PerformLayout();
            this.ItemsWinFramePanel.ResumeLayout(false);
            this.DatabaseTabControl.ResumeLayout(false);
            this.OrdersTabPage.ResumeLayout(false);
            this.OrdersTabPage.PerformLayout();
            this.OrdersTableLayoutPanel.ResumeLayout(false);
            this.OrdersTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersDataGridView)).EndInit();
            this.OrdersTableLayoutPanelButtons.ResumeLayout(false);
            this.OrdersTableLayoutPanelButtons.PerformLayout();
            this.ProductsTabPage.ResumeLayout(false);
            this.ProductsTabPage.PerformLayout();
            this.ProductsTableLayoutPanel.ResumeLayout(false);
            this.ProductsTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsDataGridView)).EndInit();
            this.ProductsTableLayoutPanelButton.ResumeLayout(false);
            this.ProductsTableLayoutPanelButton.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        private System.Windows.Forms.TabControl UserViewsTabControl;
        private System.Windows.Forms.TabPage UserTabPage;
        private System.Windows.Forms.TabPage AdminTabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel ItemsManagerFramePanel;
        private System.Windows.Forms.Panel ItemsWinFramePanel;
        private System.Windows.Forms.TabControl DatabaseTabControl;
        private System.Windows.Forms.TabPage OrdersTabPage;
        private System.Windows.Forms.TabPage ProductsTabPage;
        private System.Windows.Forms.Label ItemsManagerLabel;
        private System.Windows.Forms.TableLayoutPanel OrdersTableLayoutPanel;
        private System.Windows.Forms.Label OrderListLabel;
        private System.Windows.Forms.DataGridView OrdersDataGridView;
        private System.Windows.Forms.TableLayoutPanel OrdersTableLayoutPanelButtons;
        private System.Windows.Forms.Button DeleteOrderButton;
        private System.Windows.Forms.Button DetailOrderButton;
        private System.Windows.Forms.Button ConfirmOrderButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel ProductsTableLayoutPanel;
        private System.Windows.Forms.Label ProductListLabel;
        private System.Windows.Forms.DataGridView ProductsDataGridView;
        private System.Windows.Forms.TableLayoutPanel ProductsTableLayoutPanelButton;
        private System.Windows.Forms.Button UpdateProductButton;
        private System.Windows.Forms.Button DeleteProductButton;
        private System.Windows.Forms.Button ProductDetailButton;
        private System.Windows.Forms.Button AddProductButton;
    }
}

