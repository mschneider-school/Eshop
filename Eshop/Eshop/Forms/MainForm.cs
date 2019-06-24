using Eshop.DatabaseEntites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Eshop
{
    public partial class MainForm : Form
    {
        public List<Control> RegDetailsToValidate { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            Shown += MainForm_Shown;
            Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RegDetailsToValidate = new List<Control>()
            {
                FirstNameTextBox, LastNameTextBox,
                CityTextBox, StreetTextBox,
                HouseNumberTextBox
            };

            // skryt predpripravene tably
            StoreTabControl.TabPages.Remove(BasketTab);
            StoreTabControl.TabPages.Remove(AccountTab);
            StoreTabControl.TabPages.Remove(OrdersTab);

            // skryt administratorskou cast pred prihlasenim
            DatabaseTabControl.Visible = false;

            // double buffering povoleno pro datagridviews
            ShopDataGridView.DoubleBuffered(true);
            BasketDataGridView.DoubleBuffered(true);
            ProductsDataGridView.DoubleBuffered(true);
            OrdersDataGridView.DoubleBuffered(true);
            MyOrdersDataGridView.DoubleBuffered(true);

            // nahraje produktova data z databaze do pameti
            Database.ReadTableData(Database.loadProducts, Database.LoadProductsCommand);

            // nahraje data kategorii z db do pameti
            Database.ReadTableData(Database.loadCathegories, Database.LoadCathegoriesCommand);

            // nahraje data objednavek z db do pameti
            Database.ReadTableData(Database.loadOrders, Database.LoadOrdersCommand);

            // nahraje data specialni nabidky do pameti
            Database.ReadTableData(Database.loadSpecialOffers, Database.LoadSpecialOffersCommand);

            // nahraje data strategii do pameti
            Database.ReadTableData(Database.loadStrategies, Database.LoadStrategiesCommand);

            // nahraje data stavu objednavek do pameti
            Database.ReadTableData(Database.LoadOrderStates, Database.LoadOrderStatesCommand);
            
            // zobrazi data produktu z cache do produktoveho prehladu v eshope
            // a vybere ho k manipulaci
            LoadProductsToAdminView(ShopDataGridView);
            SelectActualViewInUserSection();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // nastavime logger
            Logger logger = new Logger();

            SaveLogDialog logPrompt = new SaveLogDialog();
            DialogResult result = logPrompt.ShowDialog();

            // po zmacknuti tlacitka Soubor se nastavi logovani do souboru
            // pri jakekoliv akci se nastavi logovani do konzole 
            if (result == DialogResult.OK)
            {
                Logger.LogToFile(true);
            }
            else
            {
                Logger.LogToFile(false);
            }
            
            Logger.StartLoggingSession();
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            ProcessProductDialog addProduct = new ProcessProductDialog(this);
            addProduct.ShowDialog();
        }

        private void UpdateProductButton_Click(object sender, EventArgs e)
        {
            ProcessProductDialog updateProduct = new ProcessProductDialog(this, GetSelectedProduct(ProductsDataGridView));
            DialogResult result = updateProduct.ShowDialog();
            
            // po uprave produktu v databazi i cache
            // aktualizujeme datagridview
            if (result == DialogResult.OK)
            {
                LoadProductsToAdminView(ProductsDataGridView);
            }
        }

        private void DeleteProductButton_Click(object sender, EventArgs e)
        {
            string deletedProduct = GetSelectedProduct(ProductsDataGridView).Name;
            string formName = "Vymazat produkt";
            string message = $"Opravdu si přejete vymazat produkt:\n{deletedProduct}?";

            ConfirmDialog deleteProduct = new ConfirmDialog(message, formName);
            DialogResult result = deleteProduct.ShowDialog();
           
            // when deleting is confirmed, remove the product from the gridview
            if (result == DialogResult.OK)
            {
                // remove product from cache
                Product selectedProduct = GetSelectedProduct(ProductsDataGridView);
                Database.CachedProducts.Remove(selectedProduct);

                // remove product from datagridview
                RemoveSelectedRow(ProductsDataGridView);

                // delete product in database
                Database.DeleteProduct(selectedProduct);
            }
        }

        // zobrazeni detail vybraneho produktu z produkt view v admin casti
        private void ProductDetailButton_Click(object sender, EventArgs e)
        {
            ShowSelectedProductDetails(ProductsDataGridView);
        }

        private void LoginToOrderButton_Click(object sender, EventArgs e)
        {
            // pokud jeste neni zakaznik prihlasen zobrazi okno prihlaseni nebo registrace
            if (Session.CustomerLoggedIn == null)
            {
                LoginRegisterDialog customerLogin = new LoginRegisterDialog();
                customerLogin.Text = "Přihlášení zákazníka";
                DialogResult result = customerLogin.ShowDialog();

                // pokud se uzivatel chce registrovat (abort prihlaseni)
                if (result == DialogResult.Abort)
                {
                    GoToRegistrationTab();
                }

                // pokud byl zakaznik prihlasen:
                // program zobrazi info o prihlaseni a nacte uzivatelove objednavky
                if (Session.CustomerLoggedIn != null)
                {
                    ShowLoggedCustomer();
                    Message.LoginSuccessInfo(Session.CustomerLoggedIn);
                    LoadCustomerOrders(Session.CustomerLoggedIn);
                    LoginToOrderButton.PerformClick(); // prejde k sestaveni objednavky
                }
            }
            else // pokud jiz zakaznik je prihlasen sestavi a zobrazi jeho objednavku
            {
                List<OrderItem> orderItems = OrderItem.GetOrderItemsFromBasket(Basket.Items);
                Order builtOrder = Order.BuildOrder(orderItems);
                OrderDetailForm builtOrderDetail = new OrderDetailForm(builtOrder, true);
                DialogResult result = builtOrderDetail.ShowDialog();
                
                // pri potvrzeni objednavky ze strany zakaznika
                if (result == DialogResult.Yes)
                {
                    Database.CreateOrder(builtOrder);

                    // ZALOGUJEME akci vytvoreni objednavky
                    Logger.CreateOrderLog(builtOrder);

                    // zobrazi pridanou objednavku v zakaznickem prehledu
                    InsertOrderToMyOrders(builtOrder);

                    if (Session.AdminLoggedIn)
                    {
                        InsertOrderToAdminView(builtOrder);
                        SelectActualViewInAdminSection();
                    }

                    // focus se presune na tablu objednavek
                    StoreTabControl.SelectedTab = OrdersTab;

                    // vymaze obsah kosiku ( spusti event RowRemoved), tym odstrani tablu kosiku
                    EmptyBasketView();
                }
            }
        }

        // pote co uzivatel vybral novou registraci ho presmeruj na tablu s registraci
        private void GoToRegistrationTab()
        {
            if (!StoreTabControl.TabPages.Contains(AccountTab))
            {
                StoreTabControl.TabPages.Add(AccountTab);
            }
            StoreTabControl.SelectTab(AccountTab);
        }

        // vlozi novou objednavku do prehledu zakaznikovych obj. na 1 misto
        private void InsertOrderToMyOrders(Order order)
        {
            DataGridView view = MyOrdersDataGridView;
            view.Rows.Insert
            (
                0,
                order.ID,
                order.CreationDateTime.ToShortDateString(),
                order.CreationDateTime.ToShortTimeString(),
                order.OrderItems.Sum(item => item.Quantity),
                order.PercentualDiscount,
                order.TotalOrderDiscount,
                order.FinalOrderPrice,
                Database.GetStateNameByID(order.State)
            );
        }

        /// <summary>
        /// Prida objednavky prihlaseneho zakaznika do prehledu Moje objednavky
        /// </summary>
        /// <param name="customer">prihlaseny zakaznik</param>
        private void LoadCustomerOrders(Customer customer)
        {
            List<Order> customerOrders = Database.GetCustomerOrders(customer);
            DataGridView ordersView = MyOrdersDataGridView;

            ordersView.Rows.Clear();
            foreach(Order order in customerOrders)
            {
                InsertOrderToMyOrders(order);
            }
        }

        private void CustomerOrderDetailButton_Click(object sender, EventArgs e)
        {
            Order orderToShow = GetSelectedOrder(MyOrdersDataGridView);
            OrderDetailForm customerOrderDetail = new OrderDetailForm(orderToShow);
            customerOrderDetail.ShowDialog();
        }

        private void ReturnToStoreButton_Click(object sender, EventArgs e)
        {
            StoreTabControl.SelectTab(StoreTab);
        }

        private void LoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginRegisterDialog customerLogin = new LoginRegisterDialog();
            customerLogin.ShowDialog();
        }

        // pridej polozku do kosiku
        private void AddToBasketButton_Click(object sender, EventArgs e)
        {
            Product selectedProduct = GetSelectedProduct(ShopDataGridView);
            AddToBasketDialog addToBasket = new AddToBasketDialog(selectedProduct);
            DialogResult result = addToBasket.ShowDialog();

            // pokud se polozka uspesne pridala do kosiku
            // pridame tablu kosiku a zobrazime obsah kosiku
            if (result == DialogResult.OK)
            {
                DisplayItemsInBasketView();
                // polozka posledne pridana do kosiku bude zvyraznena
                SelectRecordInView(selectedProduct.ID, BasketDataGridView);
            }
        }

        // prihlasit se jako zakaznik
        private void LoginAsCustomerButton_Click(object sender, EventArgs e)
        {
            // pokud jiz byl zakaznik prihlasen zeptame se jestli chce
            // odhlasit stavajiciho zakaznika prihlasit se jako novy
            if (Session.CustomerLoggedIn != null)
            {
                DialogResult result = Message.LoginNewCustomerQuestion();

                // prihlasit se jako novy zakaznik
                if (result == DialogResult.Yes)
                {
                    ProcessCustomerLogin();
                }
            }
            else // jinak zobrazi prihlaseni zakaznika
            {
                ProcessCustomerLogin();
            }
        }

        // verifikuje prihlaseni uzivatele a upravi titulek formulare
        private void ProcessCustomerLogin()
        {
            Customer loggedInBefore = Session.CustomerLoggedIn;

            LoginRegisterDialog customerLogin = new LoginRegisterDialog();
            customerLogin.Text = "Přihlášení zákazníka";
            DialogResult result = customerLogin.ShowDialog();

            if (result == DialogResult.Abort)
            {
                GoToRegistrationTab();
            }

            Customer loggedInAfter = Session.CustomerLoggedIn;

            // hlaska o prihlaseni se zobrazi jen kdyz se prihlasi uzivatel prvykrat
            // nebo se prihlasi uplne novy uzivatel
            if (loggedInAfter != null)
            {
                ShowLoggedCustomer();
                if (loggedInBefore != null)
                {
                    if (loggedInBefore.ID != loggedInAfter.ID)
                    {
                        PrepareViewToCustomer(loggedInAfter);
                    }
                }
                else
                {
                    PrepareViewToCustomer(loggedInAfter);
                }
            }
        }

        // nacte zakaznikovy objednavky, vymaze registracni tablu, zobrazi info o prihlaseni
        private void PrepareViewToCustomer(Customer customer)
        {
            // zavre otevrenou registraci po prihlaseni
            if (StoreTabControl.TabPages.Contains(AccountTab))
            {
                CloseRegistration();
            }
            // zavre a vymaze tablu objednavek z predesleho prihlaseni pokud je pritomna
            if (StoreTabControl.TabPages.Contains(OrdersTab))
            {
                MyOrdersDataGridView.Rows.Clear();
                StoreTabControl.TabPages.Remove(OrdersTab);
            }

            LoadCustomerOrders(customer);
            Message.LoginSuccessInfo(customer);
        }

        // serad produkty v shop view od nejlevnejsiho po nejdrazsi
        private void AscendingSortTSMenuItem_Click(object sender, EventArgs e)
        {
            ShopDataGridView.Sort(ShopDataGridView.Columns[3],
                ListSortDirection.Ascending);
        }

        // serad produkty v shop view od nejdrazsiho po nejlevnejsi
        private void DescendingSortTSMenuItem_Click(object sender, EventArgs e)
        {
            ShopDataGridView.Sort(ShopDataGridView.Columns[3],
                ListSortDirection.Descending);
        }

        // po kliknuti zobrazi detail vybraneho produktu z shop view
        private void ShowItemDetailButton_Click(object sender, EventArgs e)
        {
            ShowSelectedProductDetails(ShopDataGridView);
        }

        // prejit do kosik view z shop view po kliknuti na tlacitko
        private void MoveToBasketButton_Click(object sender, EventArgs e)
        {
            StoreTabControl.SelectedTab = BasketTab;
        }

        // odebrat vybranou polozku z kosika v kosik view
        private void RemoveBasketItemButton_Click(object sender, EventArgs e)
        {
            Product selectedItem = GetSelectedProduct(BasketDataGridView);
            string itemName = selectedItem.Name;

            string formName = "Odebrat položku";
            string message = $"Opravdu si přejete odebrat položku:\n{itemName}?";

            ConfirmDialog removeBasketItem = new ConfirmDialog(message, formName);
            DialogResult result = removeBasketItem.ShowDialog();

            // pokud si uzivatel zvolil vymazat vybranou polozku z kosiku vymaze ji
            if (result == DialogResult.OK)
            {
                Basket.RemoveItem(selectedItem);
                DisplayItemsInBasketView();
            }
        }

        // zobraz detail vybraneho produktu z view košíka
        private void ShowDetailBasketItemButton_Click(object sender, EventArgs e)
        {
            ShowSelectedProductDetails(BasketDataGridView);
        }

        // zepta se uzivatele jestli chce vazne smazat vsechny polozky z kosiku
        private void EmptyBasketButton_Click(object sender, EventArgs e)
        {
            string formName = "Vyprázdnit košík";
            string message = "Opravdu si přejete odebrat všechny položky z košíku?";

            ConfirmDialog emptyBasket = new ConfirmDialog(message, formName);
            DialogResult result = emptyBasket.ShowDialog();

            // pokud uzivatel zvolil potvrzeni, vymaze vsechny polozky z kosiku
            // a refreshne view
            if (result == DialogResult.OK)
            {
                EmptyBasketView();
            }
        }

        // vymaze polozky kosiku z pameti i nahledu
        public void EmptyBasketView()
        {
            Basket.Empty();
            DisplayItemsInBasketView();
        }

        // Administratorske prihlaseni
        private void UserViewsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UserViewsTabControl.SelectedTab == UserViewsTabControl.TabPages["adminTabPage"]
                && !Session.AdminLoggedIn)
            {
                LoginRegisterDialog adminLogin = new LoginRegisterDialog();
                adminLogin.TransformToAdminLogin();
                adminLogin.ShowDialog();
                
                // pokud byl administrator uspesne prihlasen event zviditelneni sekce admina
                // spusti nacteni produktu a objednavek a pripraveni administratorskeho nahledu
                if (Session.AdminLoggedIn)
                {
                    DatabaseTabControl.Visible = true;

                    // zobrazi se tably produktu a objednavek
                    // nacte se obsah produktoveho a objednavkoveho prehledu
                    LoadOrdersToAdminView(OrdersDataGridView);
                    LoadProductsToAdminView(ProductsDataGridView);
                    SelectActualViewInAdminSection();
                }
                else
                {   // jinak se presune spatky na zakaznickou cast
                    UserViewsTabControl.SelectTab(CustomerTabPage);
                }
            }
            else
            {
                TabPage selectedTab = UserViewsTabControl.SelectedTab;
                if (selectedTab == AdminTabPage)
                {
                    SelectActualViewInAdminSection();
                }
                else
                {
                    SelectActualViewInUserSection();
                }
            }
        }

        /*** POMOCNE METODY HLAVNIHO FORMULARE K PROVEDENI UI UPRAV ***/

        /// <summary>
        /// Zobrazi vsechny produkty z cache v administratorske casti
        /// </summary>
        /// <param name="cathegory">volitelny parameter k zobrazeni jen produktu jiste kategorie</param>
        private void LoadProductsToAdminView(DataGridView dataGridView, string cathegory = null)
        {
            dataGridView.Rows.Clear();

            foreach (Product product in Database.CachedProducts)
            {
                // pokud chybi parameter kategorie zobraz vse
                if (cathegory == null)
                {
                    dataGridView.Rows.Add(
                        product.ID,
                        product.Name,
                        product.Cathegory,
                        product.Price
                    );
                }
                else // pokud nechybi parameter kategorie zobraz jen produkty kategorie
                {
                    if (product.Cathegory == cathegory)
                    {
                        dataGridView.Rows.Add(
                            product.ID,
                            product.Name,
                            product.Cathegory,
                            product.Price
                        );
                    }
                }
            }
        }

        /// <summary>
        /// Zobrazi nacteny objednavky v administratorskem okne
        /// </summary>
        private void LoadOrdersToAdminView(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();

            // zobrazi kazdou objedavku v pameti
            foreach (Order order in Database.CachedOrders)
            {
                // vlozi zaznam objednavky do view
                InsertOrderToAdminView(order);
            }
        }

        // pomocna metoda k vlozeni zaznamu objednavky do administratorskeho view
        private void InsertOrderToAdminView(Order order)
        {
            DataGridView view = OrdersDataGridView;
            // prida se zaznam s udaji objednavky do prehledu
            view.Rows.Insert
            (
                0,
                order.ID,
                order.Customer.Name,
                order.Customer.LastName,
                order.TotalOrderDiscount,
                order.FinalOrderPrice,
                order.CreationDateTime.ToShortDateString(),
                order.CreationDateTime.ToShortTimeString(),
                Database.GetStateNameByID(order.State)
            );
        }

        /// <summary>
        /// Vycisti registracni formular po uspesne registraci
        /// </summary>
        private void ClearRegistrationForm()
        {
            List<Control> textControls = new List<Control>();

            textControls.AddRange(RegDetailsToValidate);
            textControls.AddRange(new List<TextBoxBase>()
            { EmailTextBox, PasswordTextBox, MobileMaskTextBox, PostalCodeMaskTextBox });

            foreach (Control textControl in textControls)
            {
                textControl.Text = string.Empty;
            }
        }

        /// <summary>
        /// zjistuje jestli je dany datagridview prazdny nebo ne (pripad mazani z prazdneho)
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <returns></returns>
        private bool IsDataGridViewEmpty(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Zobrazi detaily produktu vybraneho v danem dataGridView
        /// </summary>
        public static void ShowSelectedProductDetails(DataGridView dataGridView)
        {
            Product selectedProduct = GetSelectedProduct(dataGridView);
            ProductDetailsForm productDetails = new ProductDetailsForm(selectedProduct);
            productDetails.ShowDialog();
        }

        /// <summary>
        /// Vybere a vrati objekt Produkt vybrany 
        /// </summary>
        /// <returns></returns>
        private static Product GetSelectedProduct(DataGridView dataGridView)
        {
            int selectedProductID = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
            Product selectedProduct = Database.GetCachedProductByID(selectedProductID);
            return selectedProduct;
        }

        /// <summary>
        /// Oznaci zaznam s udaji zvoleneho produktu ve zvolenem datagridview
        /// </summary>
        /// <param name="id">id zvyrazneneho radku</param>
        private static void SelectRecordInView(int id, DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if ((int)row.Cells[0].Value == id)
                {
                    row.Selected = true;
                    dataGridView.FirstDisplayedScrollingRowIndex = row.Index;
                }
            }
        }

        /// <summary>
        /// Vraci oznacenou objednavku z prehledu objednavek jako objekt
        /// </summary>
        /// <param name="dataGridView">prehled objednavek</param>
        /// <returns>objednavka</returns>
        private static Order GetSelectedOrder(DataGridView dataGridView)
        {
            int selectedOrderID = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);

            Order selectedOrder = Database.GetCachedOrderByID(selectedOrderID);
            return selectedOrder;
        }

        /// <summary>
        /// vymaze polozku z GridView
        /// </summary>
        /// <param name="dataGridView">gridview pro vymazani polozky</param>
        private void RemoveSelectedRow(DataGridView dataGridView)
        {
            dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);
        }

        /// <summary>
        /// zobrazi novy produkt v productsDataGridView
        /// </summary>
        /// <param name="product">produkt k zobrazeni</param>
        public void ShowNewProduct(Product product)
        {
             ProductsDataGridView.Rows.Add(product.ID, product.Name, product.Cathegory, product.Price);
             SelectRecordInView(product.ID, ProductsDataGridView);
        }

        /// <summary>
        /// refresh obsahu kosiku
        /// </summary>
        private void DisplayItemsInBasketView()
        {
            BasketDataGridView.Rows.Clear();
            foreach(KeyValuePair<Product,int> item in Basket.Items)
            {
                Product product = item.Key;
                int quantity = item.Value;

                BasketDataGridView.Rows.Add(product.ID, product.Name,
                 product.Cathegory, product.Price, quantity);
            }
        }

        /*** SEKCE PRO SORTOVACI POLOZKY SPLIT MENU ***/

        // zobraz vsechny produkty
        private void LoadEverythingTSMenuItem_Click(object sender, EventArgs e)
        {
            LoadProductsToAdminView(ShopDataGridView);
        }

        // zobraz jen chytre hodinky
        private void SmartWatchesTSMenuItem_Click(object sender, EventArgs e)
        {
            string smWatches = SmartWatchesTSMenuItem.Text;
            LoadProductsToAdminView(ShopDataGridView, smWatches);
        }

        // zobraz jen kryty a pouzdra
        private void CoversTSMenuItem_Click(object sender, EventArgs e)
        {
            string covers = CoversTSMenuItem.Text;
            LoadProductsToAdminView(ShopDataGridView, covers);
        }

        // zobraz jen smartfony
        private void SmartphonesTSMenuItem_Click(object sender, EventArgs e)
        {
            string smphones = SmartphonesTSMenuItem.Text;
            LoadProductsToAdminView(ShopDataGridView, smphones);
        }

        // zobraz jen tablety
        private void TabletsTSMenuItem_Click(object sender, EventArgs e)
        {
            string tablets = TabletsTSMenuItem.Text;
            LoadProductsToAdminView(ShopDataGridView, tablets);
        }

        // zobraz jen tlacitkove telefony
        private void KeypadPhonesTSMenuItem_Click(object sender, EventArgs e)
        {
            string kphones = KeypadPhonesTSMenuItem.Text;
            LoadProductsToAdminView(ShopDataGridView, kphones);
        }

        // zobraz jen ochranna skla
        private void ScreenProtectorsTSMenuItem_Click(object sender, EventArgs e)
        {
            string scprotectors = ScreenProtectorsTSMenuItem.Text;
            LoadProductsToAdminView(ShopDataGridView, scprotectors);
        }

        // zobraz jen kabely a nabijecky
        private void ChargersCablesTSMenuItem_Click(object sender, EventArgs e)
        {
            string cables = ChargersCablesTSMenuItem.Text;
            LoadProductsToAdminView(ShopDataGridView, cables);
        }

        private void BackFromOrderButton_Click(object sender, EventArgs e)
        {
            CloseRegistration();
        }

        /*** Uvedeni registracnich poli do puvodni barvy pri korekci spatnych udaju ***/

        private void EmailTextBox_Enter(object sender, EventArgs e)
        {
            EmailTLPanel.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void PasswordTextBox_Enter(object sender, EventArgs e)
        {
            PasswordTLPanel.BackColor = SystemColors.GradientInactiveCaption;
        }

        private void FirstNameTextBox_Enter(object sender, EventArgs e)
        {
            FirstNameTLPanel.BackColor = SystemColors.Control;
        }

        private void LastNameTextBox_Enter(object sender, EventArgs e)
        {
            LastNameTLPanel.BackColor = SystemColors.Control;
        }

        private void MobileMTextBox_Enter(object sender, EventArgs e)
        {
            MobileTLPanel.BackColor = SystemColors.Control;
        }

        private void CityTextBox_Enter(object sender, EventArgs e)
        {
            CityTLPanel.BackColor = SystemColors.Control;
        }

        private void StreetTextBox_Enter(object sender, EventArgs e)
        {
            StreetTLPanel.BackColor = SystemColors.Control;
        }

        private void HouseNumberTextBox_Enter(object sender, EventArgs e)
        {
            HouseNumberTLPanel.BackColor = SystemColors.Control;
        }

        private void PostalCodeMaskTextBox_Enter(object sender, EventArgs e)
        {
            PostalCodeTLPanel.BackColor = SystemColors.Control;
        }

        /// <summary>
        /// Povol nebo zakaz vice tlacitek (operaci)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="buttons"></param>
        /// <param name="availability"></param>
        private void SetAvailableButtons(object sender, List<Button> buttons, bool availability)
        {
            DataGridView dataGridView = sender as DataGridView;
            foreach(Button btn in buttons) 
                btn.Enabled = availability;
        }
        
        /*** DataGridView - upravy dostupnych operaci podle poctu polozek ve view ***/

        private void OrdersDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView thisView = sender as DataGridView;

            // tlacitka operaci s objednavky se povoli pouze pokud jsou pridany nove objednavky
            List<Button> buttons = new List<Button>()
            {
                ConfirmOrderButton, CancelOrderButton, SendOrderButton, AdminOrderDetailButton
            };
            SetAvailableButtons(sender, buttons, true);
            
            // pri pridane objednavce se vybere tabla objednavek
            if (Session.AdminLoggedIn)
            {
                DatabaseTabControl.SelectTab(OrdersTabPage);
            }
            // pridavany radek je vzdy zvyraznen
            thisView.Rows[e.RowIndex].Selected = true;
        }

        private void ProductsDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            List<Button> buttons = new List<Button>() { UpdateProductButton, DeleteProductButton, ProductDetailButton};
            SetAvailableButtons(sender, buttons, true);
        }

        private void ProductsDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            bool accessibility = ProductsDataGridView.Rows.Count > 0;
            List<Button> buttons = new List<Button>() { UpdateProductButton, DeleteProductButton, ProductDetailButton };
            SetAvailableButtons(sender, buttons, accessibility);
        }

        private void ShopDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            List<Button> buttons = new List<Button>()
            {
                LoginAsCustomerButton, ShowItemDetailButton
            };
            SetAvailableButtons(sender, buttons, true);
        }

        private void BasketDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            List<Button> buttons = new List<Button>()
            {
                RemoveBasketItemButton, ShowDetailBasketItemButton,
                EmptyBasketButton, LoginToOrderButton
            };
            SetAvailableButtons(sender, buttons, true);
            MoveToBasketButton.Enabled = true;
            if (!StoreTabControl.TabPages.Contains(BasketTab))
            {
               StoreTabControl.TabPages.Insert(1, BasketTab);
            }
        }

        private void BasketDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            var thisView = sender as DataGridView;
            if (IsDataGridViewEmpty(thisView))
            {
                StoreTabControl.TabPages.Remove(BasketTab);
                MoveToBasketButton.Enabled = false;
            }
        }

        // po pridani objednavky do zakaznickeho prehledu objednavky se focus presune na tablu objednavek
        // a take se aktualne pridana objednavka vlozi do administratorskeho view pokud je prihlasen
        private void MyOrdersDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var thisView = sender as DataGridView;
            if (!StoreTabControl.TabPages.Contains(OrdersTab))
            {
                StoreTabControl.TabPages.Add(OrdersTab);
            }
            // pridavany radek je vzdy zvyraznen
            thisView.Rows[e.RowIndex].Selected = true;
        }

        private void RegisterAndOrderButton_Click(object sender, EventArgs e)
        {
            bool allValid = Message.InvalidEntriesCheck(RegDetailsToValidate, Color.MistyRose);
            bool phoneValid = IsPhoneValid();
            bool postalCodeValid = IsPostalCodeValid();
            bool emailValid = IsEmailValid();
            bool passwordValid = IsPasswordValid();

            bool invalidInputDetected = 
                !allValid || !phoneValid || !postalCodeValid || !emailValid || !passwordValid;

            // pokud chybi udaje v registraci tak se vypise oznameni, jinak se
            // vytvori novy zakaznik, jeho udaje se ulozi do databaze a zustane prihlaseny
            if (invalidInputDetected)
            {
                Message.InvalidEntriesWarning();
            }
            else
            {
                string email = EmailTextBox.Text.Trim();
                // pokud neni email unikatni tak se zobrazi upozorňující hláška
                // a pole emailu se vybarvi chybovou barvou
                if (!Database.IsEmailUnique(email))
                {
                    EmailTLPanel.BackColor = Color.MistyRose;
                    Message.EmailRegisteredWarning();
                }
                else
                {
                    string name = FirstNameTextBox.Text.Trim();
                    string lastName = LastNameTextBox.Text.Trim();
                    int mobilePhone = Convert.ToInt32(MobileMaskTextBox.Text.Replace(" ", ""));
                    string city = CityTextBox.Text.Trim();
                    string street = StreetTextBox.Text.Trim();
                    string houseNumber = HouseNumberTextBox.Text.Trim();
                    string postalCode = PostalCodeMaskTextBox.Text.Replace(" ", "");
                    string password = PasswordTextBox.Text;

                    Customer registered = new Customer
                    (
                        name, lastName, mobilePhone, city, houseNumber, 
                        street, postalCode, email, password
                    );

                    // ulozi nove zaregistrovaneho zakaznika
                    Database.CreateCustomer(registered);

                    // prihlasi nove zaregistrovaneho zakaznika
                    Session.LoginCustomer(registered);
                    ShowLoggedCustomer();

                    // vycisti a zavre zbylou tablu po predeslem zakaznikovi
                    if (StoreTabControl.Contains(OrdersTab))
                    {
                        MyOrdersDataGridView.Rows.Clear();
                        StoreTabControl.TabPages.Remove(OrdersTab);
                    }

                    // pro registraci z kosiku
                    if (StoreTabControl.TabPages.Contains(BasketTab))
                    {
                        Message.RegistrationToOrderSuccessInfo();
                        CloseRegistration();
                        StoreTabControl.SelectedTab = BasketTab;

                        // automaticky se prejde k objednavce
                        // novemu prihlasenemu uzivateli se zobrazi objednavka k potvrzeni
                        LoginToOrderButton.PerformClick();
                    }
                    else // pro registraci z obchodu
                    {
                        Message.RegistrationSuccessInfo();
                        CloseRegistration();
                        StoreTabControl.SelectedTab = StoreTab;
                    }
                }
            }
        }

        // uzavre registraci a odebere registracni tab
        // po uspesnem prihlaseni, nebo registraci
        private void CloseRegistration()
        {
            ClearRegistrationForm();
            StoreTabControl.TabPages.Remove(AccountTab);
        }

        /*** Akce prehledu objednavek ***/

        // pomocna metoda zmeny stavu
        private void ChangeOrderState(int state)
        {
            int stateID = state;
            string stateName = Database.GetStateNameByID(stateID);

            // vybrana objednavka jako objekt, novy stav ulozen v db aj cache 
            Order selectedOrder = GetSelectedOrder(OrdersDataGridView);
            Database.ChangeOrderState(selectedOrder, stateID);
            
            // zaloguj zmenu stavu objednavky
            LogOrderStateChange(selectedOrder, stateID);

            // zmen stav vybrane objednavky v prehledu objednavek
            OrdersDataGridView.SelectedRows[0].Cells[7].Value = stateName;

            // vyhledej objednavku v mych objednavkach a zmen jeji stav
            UpdateOrderStateInMyOrders(selectedOrder, stateName);

            // zobrazi spravu o proběhle zmene
            Message.OrderStateChangeInfo(stateName.ToLower());
        }

        // zalogovani zmeny stavu objednavky (akce potvrzeni, zruseni objednavky)
        private void LogOrderStateChange(Order order, int stateID)
        {
            switch (stateID)
            {
                case 1:
                    Logger.ConfirmOrderLog(order);
                    break;
                case 2:
                    Logger.CancelOrderLog(order);
                    break;
            }
        }

        // zmen stav objednavky v mych objednavkach (pokud je nalezena)
        private void UpdateOrderStateInMyOrders(Order order, string stateName)
        {
            foreach (DataGridViewRow row in MyOrdersDataGridView.Rows)
            {
                if ((int)row.Cells[0].Value == order.ID)
                {
                    row.Cells[7].Value = stateName;
                }
            }
        }

        /*** Zmeny stavu objednavky (potvrzena, zrusena, odeslana) logovani a zobrazeni detailu ***/

        private void ConfirmOrderButton_Click(object sender, EventArgs e)
        {
            ChangeOrderState(OrderState.Confirmed);
        }

        private void CancelOrderButton_Click(object sender, EventArgs e)
        {
            ChangeOrderState(OrderState.Canceled);
        }

        private void SendOrderButton_Click(object sender, EventArgs e)
        {
            ChangeOrderState(OrderState.Sent);
        }

        private void AdminOrderDetailButton_Click(object sender, EventArgs e)
        {
            Order selectedOrder = GetSelectedOrder(OrdersDataGridView);
            OrderDetailForm adminOrderDetail = new OrderDetailForm(selectedOrder);
            adminOrderDetail.ShowDialog();
        }

        /// <summary>
        /// Zobrazi informaci o prihlaseni zakaznika v titulku okna
        /// </summary>
        private void ShowLoggedCustomer()
        {
            if (Session.CustomerLoggedIn != null)
            {
                string loggedName = Session.CustomerLoggedIn.Name;
                string loggedLastName = Session.CustomerLoggedIn.LastName;
                Text = $"MobileShop - přihlášen: {loggedName} {loggedLastName}";
            }
        }
       
        /*** Validacni pomocni metody k registraci ***/

        private bool IsPhoneValid()
        {
            bool invalidNumber = false;
            if (!MobileMaskTextBox.MaskFull)
            {
                MobileTLPanel.BackColor = Color.MistyRose;
                return invalidNumber;
            }
            return !invalidNumber;
        }

        private bool IsPostalCodeValid()
        {
            bool invalidNumber = false;
            if(!PostalCodeMaskTextBox.MaskFull)
            {
                PostalCodeTLPanel.BackColor = Color.MistyRose;
                return invalidNumber;
            }
            return !invalidNumber;
        }

        /*** Verifikace prihlasovacich udaju ***/
        private bool IsEmailValid()
        {
            bool invalidEMail = false;
            string pattern = @"^.+@.+\.\w+";
            string email = EmailTextBox.Text;

            Match result = Regex.Match(email, pattern);
            if(!result.Success)
            {
                EmailTLPanel.BackColor = Color.MistyRose;
                return invalidEMail;
            }
            return !invalidEMail;
        }

        private bool IsPasswordValid()
        {
            bool invalidPassword = false;
            if(PasswordTextBox.Text.Length == 0)
            {
                PasswordTLPanel.BackColor = Color.MistyRose;
                return invalidPassword;
            }
            return !invalidPassword;
        }

        // po uzavreni aplikace se ukonci session logovani
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logger.StopLoggingSession();
        }

        // fokus na view po zmene tably v zakaznicke sekci
        private void StoreTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectActualViewInUserSection();
        }
        // fokus na aktualni view po zmene tably v administrativni sekci
        private void DatabaseTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectActualViewInAdminSection();
        }

        /***  privatni metody pro selekci aktualne zobrazeneho nahledu ***/

        private void SelectActualViewInAdminSection()
        {
            var selectedTab = DatabaseTabControl.SelectedTab;

            if (selectedTab == OrdersTabPage)
            {
                ActiveControl = OrdersDataGridView;
            }
            else if (selectedTab == ProductsTabPage)
            {
                ActiveControl = ProductsDataGridView;
            }
        }

        private void SelectActualViewInUserSection()
        {
            var selectedTab = StoreTabControl.SelectedTab;

            if (selectedTab == StoreTab)
            {
                ActiveControl = ShopDataGridView;
            }
            else if (selectedTab == BasketTab)
            {
                ActiveControl = BasketDataGridView;
            }
            else if (selectedTab == OrdersTab)
            {
                ActiveControl = MyOrdersDataGridView;
            }
        }
    }
}
