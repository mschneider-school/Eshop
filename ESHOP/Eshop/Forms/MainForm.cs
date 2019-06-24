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
    /// <summary>
    /// Hlavni formular aplikace ktery se zobrazi jako prvni. Obsahuje sekci Zakaznika a Administratora.
    /// V sekci Administrator se nachazi podsekce Objednavky a Produkty. V sekci Zakaznik se nachazi podsekce
    /// Obchod, Kosik, Registrace, Moje objednavky, ktere jsou zobrazeny nebo skryty podle aktualni aktivity zakaznika.
    /// </summary>
    public partial class MainForm : Form
    {
        public List<Control> RegDetailsToValidate { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            Shown += MainForm_Shown;
            Load += MainForm_Load;
        }

        /// <summary>
        /// Udalost nacitani hlavniho formulare: upravy komponentu UI
        /// Probehne nacteni dat produktu, kategorii, objednavek, 
        /// specialnich nabidek, strategii a stavu objednavek do pameti.
        /// Produkty se nactou do nahledu Obchod v sekci Zakaznik.
        /// </summary>
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

        /// <summary>
        /// Udalost zobrazeni hlavniho formulare: nastaveni loggeru,
        /// vyvolani dialogoveho okna s otazkou logovani, nastaveni
        /// zpusobu logovani podle vyberu uzivatele (soubor, konzole)
        /// </summary>
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

        /// <summary>
        /// Udalost kliknuti na tlacitko Pridat v sekci Administrator, podsekci Produkty:
        /// Zobrazeni formulare pridavani produktu
        /// </summary>
        private void AddProductButton_Click(object sender, EventArgs e)
        {
            ProcessProductDialog addProduct = new ProcessProductDialog(this);
            addProduct.ShowDialog();
        }

        /// <summary>
        /// Udalost kliknuti na tlacitko Upravit v sekci Administrator, podsekci Produkty:
        /// Zobrazeni formulare s detaily produktu a moznosti uprav, nebo vraceni uprav
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Udalost kliknuti na tlacitko Vymazat v sekci Administrator, podsekci Produkty:
        /// Zobrazeni potvrzujiciho dialogu se spravou o vymazani produktu
        /// </summary>
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

        /// <summary>
        /// Udalost kliknuti na tlacitko Zobrazit detail v sekci Administrator, podsekci Produkty:
        /// Zobrazeni detailu vybraneho produktu z nahledu
        /// </summary>
        private void ProductDetailButton_Click(object sender, EventArgs e)
        {
            ShowSelectedProductDetails(ProductsDataGridView);
        }

        /// <summary>
        /// Udalost kliknuti na tlacitko Prejit k objednavce v sekci Zakaznik, podsekci Kosik:
        /// Spusteni prihlasovaciho formulare pro neprihlaseneho zakaznika,
        /// nebo zobrazeni formulare detailu objednavky prihlasenemu zakaznikovi
        /// </summary>
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

        /// <summary>
        /// Pote co uzivatel zvolil v prihlasovacim formulari novou registraci bude presmerovan na tablu Registrace
        /// </summary>
        private void GoToRegistrationTab()
        {
            if (!StoreTabControl.TabPages.Contains(AccountTab))
            {
                StoreTabControl.TabPages.Add(AccountTab);
            }
            StoreTabControl.SelectTab(AccountTab);
        }

        /// <summary>
        /// Nova objednavka vlozena na 1. misto do prehledu objednavek v sekci Zakaznik, podsekci Moje objednávky
        /// </summary>
        /// <param name="order">objednavka k vlozeni do prehledu</param>
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

        /// <summary>
        /// Udalost kliknuti na tlacitko "Detail objednávky" v sekci Zakaznik, podsekci Moje objednavky:
        /// Zobrazi formular detailu objednavky zvyraznene v prehledu objednavek 
        /// </summary>
        private void CustomerOrderDetailButton_Click(object sender, EventArgs e)
        {
            Order orderToShow = GetSelectedOrder(MyOrdersDataGridView);
            OrderDetailForm customerOrderDetail = new OrderDetailForm(orderToShow);
            customerOrderDetail.ShowDialog();
        }

        /// <summary>
        /// Udalost kliknuti na tlacitko Navrat do obchodu v sekci Zakaznik, podsekci Moje objednavky:
        /// Zobrazeni podsekce Obchod
        /// </summary>
        private void ReturnToStoreButton_Click(object sender, EventArgs e)
        {
            StoreTabControl.SelectTab(StoreTab);
        }

        /// <summary>
        /// Udalost kliknuti na tlacitko Pridat do kosiku v sekci Zakaznik, podsekci Obchod:
        /// Zobrazeni formulare pridani polozky do kosiku
        /// </summary>
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

        /// <summary>
        /// Udalost kliknuti na tlacitko Prihlasit se v sekci Zakaznik, podsekci Obchod:
        /// Zobrazeni prihlasovaciho formulare pro zakaznika
        /// </summary>
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

        /// <summary>
        /// Zobrazeni prihlasovaciho formulare pro zakaznika
        /// </summary>
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

        /// <summary>
        /// Priprava sekce zakaznika pro prihlaseneho uzivatele:
        /// nacteny zakaznikovy objednavky, vymaz registracni tably, info o prihlaseni
        /// </summary>
        /// <param name="customer"></param>
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

        /// <summary>
        /// Udalost kliknuti na polozku Vzestupne od nejlevnejsiho produktu, kontextoveho menu Seradit podle ceny
        /// v sekci Zakaznik, podsekci Obchod:
        /// Serazeni tovaru v nahledu sekce Obchod podle ceny od nejlevnejsiho po nejdrazsi produkt 
        /// </summary>
        private void AscendingSortTSMenuItem_Click(object sender, EventArgs e)
        {
            ShopDataGridView.Sort(ShopDataGridView.Columns[3],
                ListSortDirection.Ascending);
        }

        /// Udalost kliknuti na polozku Sestupne od nejdrazsiho produktu, kontextoveho menu Seradit podle ceny
        /// v sekci Zakaznik, podsekci Obchod:
        /// Serazeni tovaru v nahledu sekce Obchod podle ceny od nejdrazsiho po nejlevnejsi produkt 
        /// </summary>
        private void DescendingSortTSMenuItem_Click(object sender, EventArgs e)
        {
            ShopDataGridView.Sort(ShopDataGridView.Columns[3],
                ListSortDirection.Descending);
        }

        /// <summary>
        /// Udalost kliknuti na tlacitko Zobrazit detail v sekci Zakaznik, podsekci Obchod:
        /// Zobrazi formular detailu produktu zvyrazneneho v nahledu
        /// </summary>
        private void ShowItemDetailButton_Click(object sender, EventArgs e)
        {
            ShowSelectedProductDetails(ShopDataGridView);
        }

        /// <summary>
        /// Udalost kliknuti na tlacitko Prejit do kosiku v sekci Zakaznik, podsekci Obchod:
        /// Zobrazeni podsekce Kosik
        /// </summary>
        private void MoveToBasketButton_Click(object sender, EventArgs e)
        {
            StoreTabControl.SelectedTab = BasketTab;
        }

        /// <summary>
        /// Udalost kliknuti na tlacitko Odstranit polozku v sekci Zakaznik, podsekci Kosik:
        /// Zobrazeni dialogu odebrani polozky z kosiku (eventualne odebrani polozky)
        /// </summary>
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

        /// <summary>
        /// Udalost kliknuti na tlacitko Zobrazit detail v sekci Zakaznik, podsekci Kosik:
        /// Zobrazeni detailu zvyraznene polozky v nahledu
        /// </summary>
        private void ShowDetailBasketItemButton_Click(object sender, EventArgs e)
        {
            ShowSelectedProductDetails(BasketDataGridView);
        }

        /// <summary>
        /// Zobrazeni dialogu smazani vsech polozek nahledu v sekci Zakaznik, podsekci Kosik
        /// Pozn.: po potvrzeni se vymazou polozky nahledu a odstrani tabla Kosik
        /// </summary>
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

        /// <summary>
        /// Smazani polozek kosiku z pameti i nahledu v sekci Zakaznik, podsekci Kosik
        /// </summary>
        public void EmptyBasketView()
        {
            Basket.Empty();
            DisplayItemsInBasketView();
        }

        /// <summary>
        /// Udalost presunu mezi sekci Administrator a Zakaznik
        /// Zobrazi prihlasovaci dialog pro neprihlaseneho administratora
        /// Po prihlaseni administratora zviditelni podsekce Objednavky a Produkty Administratorske sekce a 
        /// nacte zaznamy nahledu z pameti
        /// </summary>
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

                    if (IsDataGridViewEmpty(OrdersDataGridView))
                    {
                        DatabaseTabControl.SelectedTab = ProductsTabPage;
                    }
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

        /// <summary>
        /// Vlozi zaznam objednavky do nahledu v sekci Administrator, podsekci Objednavky
        /// </summary>
        /// <param name="order">vkladana objednavka</param>
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
        /// Vycisteni registracniho formulare v sekci Zakaznik, podsekci Registrace
        /// Pozn.: probehne po uspesne registraci, pred zatvorenim podsekce
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
        /// Vraci informaci o tom zda je nahled prazdny
        /// </summary>
        /// <param name="dataGridView">zkoumany nahled</param>
        /// <returns>true pokud je nahled prazdny, jinak false</returns>
        private bool IsDataGridViewEmpty(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Zobrazeni detailu zvyrazneneho produktu v nahledu
        /// </summary>
        /// <param name="dataGridView">produktovy nahled</param>
        public static void ShowSelectedProductDetails(DataGridView dataGridView)
        {
            Product selectedProduct = GetSelectedProduct(dataGridView);
            ProductDetailsForm productDetails = new ProductDetailsForm(selectedProduct);
            productDetails.ShowDialog();
        }

        /// <summary>
        /// Vraceni instance zvyrazneneho produktu z produktoveho nahledu
        /// </summary>
        /// <param name="dataGridView">produktovy nahled</param>
        /// <returns>instance zvyrazneneho produktu</returns>
        private static Product GetSelectedProduct(DataGridView dataGridView)
        {
            int selectedProductID = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
            Product selectedProduct = Database.GetCachedProductByID(selectedProductID);
            return selectedProduct;
        }

        /// <summary>
        /// Zvyrazneni zaznamu v danem nahledu
        /// </summary>
        /// <param name="id">id zvyrazneneho zaznamu</param>
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
        /// Vraceni instanci objednavky ze zvyrazneneho zaznamu nahledu objednavek
        /// </summary>
        /// <param name="dataGridView">objednavkovy nahled</param>
        /// <returns>instance zvyraznene objednavky</returns>
        private static Order GetSelectedOrder(DataGridView dataGridView)
        {
            int selectedOrderID = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);

            Order selectedOrder = Database.GetCachedOrderByID(selectedOrderID);
            return selectedOrder;
        }

        /// <summary>
        /// Vymazani zaznamu z nahledu
        /// </summary>
        /// <param name="dataGridView">vybrany nahled</param>
        private void RemoveSelectedRow(DataGridView dataGridView)
        {
            dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);
        }

        /// <summary>
        /// Zobrazeni noveho zaznamu produktu v produktovem nahledu sekce Administrator podsekce Produkty
        /// </summary>
        /// <param name="product">produkt pridavany do nahledu</param>
        public void ShowNewProduct(Product product)
        {
             ProductsDataGridView.Rows.Add(product.ID, product.Name, product.Cathegory, product.Price);
             SelectRecordInView(product.ID, ProductsDataGridView);
        }

        /// <summary>
        /// Znovunacteni zaznamu v nahledu v sekci Zakaznik podsekci Kosik
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

        /*** TRIDICI UDALOSTI STRIP MENU ***/

        /// <summary>
        /// Udalost kliknuti na polozku Vsechny kategorie v strip menu Zvolit kategorii
        /// v sekci Zakaznik podsekci obchod:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadEverythingTSMenuItem_Click(object sender, EventArgs e)
        {
            LoadProductsToAdminView(ShopDataGridView);
        }

        /// <summary>
        /// Udalost kliknuti na polozku Chytre hodinky v strip menu Zvolit kategorii
        /// v sekci Zakaznik podsekci obchod:
        /// Zobrazi jen produkty kategorie Chytre hodinky v produktovem nahledu
        /// </summary>
        private void SmartWatchesTSMenuItem_Click(object sender, EventArgs e)
        {
            string smWatches = SmartWatchesTSMenuItem.Text;
            LoadProductsToAdminView(ShopDataGridView, smWatches);
        }

        // zobraz jen kryty a pouzdra

        /// <summary>
        /// Udalost kliknuti na polozku Kryty a pouzdra v strip menu Zvolit kategorii
        /// v sekci Zakaznik podsekci obchod:
        /// Zobrazi jen produkty kategorie Kryty a pouzdra v produktovem nahledu
        /// </summary>
        private void CoversTSMenuItem_Click(object sender, EventArgs e)
        {
            string covers = CoversTSMenuItem.Text;
            LoadProductsToAdminView(ShopDataGridView, covers);
        }

        /// <summary>
        /// Udalost kliknuti na polozku Smartfony v strip menu Zvolit kategorii
        /// v sekci Zakaznik podsekci obchod:
        /// Zobrazi jen produkty kategorie Smartfony v produktovem nahledu
        /// </summary>
        private void SmartphonesTSMenuItem_Click(object sender, EventArgs e)
        {
            string smphones = SmartphonesTSMenuItem.Text;
            LoadProductsToAdminView(ShopDataGridView, smphones);
        }

        /// <summary>
        /// Udalost kliknuti na polozku Tablety v strip menu Zvolit kategorii
        /// v sekci Zakaznik podsekci obchod:
        /// Zobrazi jen produkty kategorie Tablety v produktovem nahledu
        /// </summary>
        private void TabletsTSMenuItem_Click(object sender, EventArgs e)
        {
            string tablets = TabletsTSMenuItem.Text;
            LoadProductsToAdminView(ShopDataGridView, tablets);
        }

        /// <summary>
        /// Udalost kliknuti na polozku Tlacitkove telefony v strip menu Zvolit kategorii
        /// v sekci Zakaznik podsekci obchod:
        /// Zobrazi jen produkty kategorie Tlacitkove telefony v produktovem nahledu
        /// </summary>
        private void KeypadPhonesTSMenuItem_Click(object sender, EventArgs e)
        {
            string kphones = KeypadPhonesTSMenuItem.Text;
            LoadProductsToAdminView(ShopDataGridView, kphones);
        }

        /// <summary>
        /// Udalost kliknuti na polozku Tvrzena skla v strip menu Zvolit kategorii
        /// v sekci Zakaznik podsekci obchod:
        /// Zobrazi jen produkty kategorie Tvrzena skla v produktovem nahledu
        /// </summary>
        private void ScreenProtectorsTSMenuItem_Click(object sender, EventArgs e)
        {
            string scprotectors = ScreenProtectorsTSMenuItem.Text;
            LoadProductsToAdminView(ShopDataGridView, scprotectors);
        }

        /// <summary>
        /// Udalost kliknuti na polozku Nabijecky a kabely v strip menu Zvolit kategorii
        /// v sekci Zakaznik podsekci obchod:
        /// Zobrazi jen produkty kategorie Nabijecky a kabely v produktovem nahledu
        /// </summary>
        private void ChargersCablesTSMenuItem_Click(object sender, EventArgs e)
        {
            string cables = ChargersCablesTSMenuItem.Text;
            LoadProductsToAdminView(ShopDataGridView, cables);
        }

        /// <summary>
        /// Udalost kliknuti na tlacitko Zrusit v sekci Zakaznik, podsekci Registrace:
        /// Zruseni registrace, vycisteni a uzavreni tably Registrace
        /// </summary>
        private void BackFromOrderButton_Click(object sender, EventArgs e)
        {
            CloseRegistration();
        }

        /*** Uvedeni registracnich poli do puvodni barvy pri korekci spatnych udaju ***/

        /// <summary>
        /// Udalost vstupu do pole Email: reset zvyrazneni na puvodni barvu
        /// </summary>
        private void EmailTextBox_Enter(object sender, EventArgs e)
        {
            EmailTLPanel.BackColor = SystemColors.GradientInactiveCaption;
        }

        /// <summary>
        /// Udalost vstupu do pole Heslo: reset zvyrazneni na puvodni barvu
        /// </summary>
        private void PasswordTextBox_Enter(object sender, EventArgs e)
        {
            PasswordTLPanel.BackColor = SystemColors.GradientInactiveCaption;
        }

        /// <summary>
        /// Udalost vstupu do pole Jmeno: reset zvyrazneni na puvodni barvu
        /// </summary>
        private void FirstNameTextBox_Enter(object sender, EventArgs e)
        {
            FirstNameTLPanel.BackColor = SystemColors.Control;
        }

        /// <summary>
        /// Udalost vstupu do pole Prijmeni: reset zvyrazneni na puvodni barvu
        /// </summary>
        private void LastNameTextBox_Enter(object sender, EventArgs e)
        {
            LastNameTLPanel.BackColor = SystemColors.Control;
        }

        /// <summary>
        /// Udalost vstupu do pole Mobil: reset zvyrazneni na puvodni barvu
        /// </summary>
        private void MobileMTextBox_Enter(object sender, EventArgs e)
        {
            MobileTLPanel.BackColor = SystemColors.Control;
        }

        /// <summary>
        /// Udalost vstupu do pole Obec: reset zvyrazneni na puvodni barvu
        /// </summary>
        private void CityTextBox_Enter(object sender, EventArgs e)
        {
            CityTLPanel.BackColor = SystemColors.Control;
        }

        /// <summary>
        /// Udalost vstupu do pole Ulice: reset zvyrazneni na puvodni barvu
        /// </summary>
        private void StreetTextBox_Enter(object sender, EventArgs e)
        {
            StreetTLPanel.BackColor = SystemColors.Control;
        }

        /// <summary>
        /// Udalost vstupu do pole Cislo popisu: reset zvyrazneni na puvodni barvu
        /// </summary>
        private void HouseNumberTextBox_Enter(object sender, EventArgs e)
        {
            HouseNumberTLPanel.BackColor = SystemColors.Control;
        }

        /// <summary>
        /// Udalost vstupu do pole PSC: reset zvyrazneni na puvodni barvu
        /// </summary>
        private void PostalCodeMaskTextBox_Enter(object sender, EventArgs e)
        {
            PostalCodeTLPanel.BackColor = SystemColors.Control;
        }

        /// <summary>
        /// Povoleni nebo zakazani vice tlacitek najednou
        /// </summary>
        /// <param name="buttons">tlacitka k povoleni/zakazani</param>
        /// <param name="availability">povoleni = true, zakazani = false</param>
        private void SetAvailableButtons(List<Button> buttons, bool availability)
        {
            foreach(Button btn in buttons) 
                btn.Enabled = availability;
        }
        
        /*** UDALOSTI ZMENY OBSAHU NAHLEDU ***/

        /// <summary>
        /// Udalost pridani zaznamu do nahledu objednavek v sekci Administrator podsekci Objednavky:
        /// Povoleni tlacitek Potvrdit, Zrusit, Odeslat, Zobrazit detail pro manipulaci s objednavky
        /// Presunuti na tablu Objednavky po pridani noveho zaznamu do nahledu objednavek
        /// </summary>
        private void OrdersDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView thisView = sender as DataGridView;

            // tlacitka operaci s objednavky se povoli pouze pokud jsou pridany nove objednavky
            List<Button> buttons = new List<Button>()
            {
                ConfirmOrderButton, CancelOrderButton, SendOrderButton, AdminOrderDetailButton
            };
            SetAvailableButtons(buttons, true);
            
            // pri pridane objednavce se vybere tabla objednavek
            if (Session.AdminLoggedIn)
            {
                DatabaseTabControl.SelectTab(OrdersTabPage);
            }
            // pridavany radek je vzdy zvyraznen
            thisView.Rows[e.RowIndex].Selected = true;
        }

        /// <summary>
        /// Udalost pridani zaznamu do nahledu produktu v sekci Administrator podsekci Objednavky:
        /// Povoleni tlacitek Upravit, Vymazat Zobrazit detail pro manipulaci s produkty
        /// </summary>
        private void ProductsDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            List<Button> buttons = new List<Button>() { UpdateProductButton, DeleteProductButton, ProductDetailButton};
            SetAvailableButtons(buttons, true);
        }

        /// <summary>
        /// Udalost odstraneni zaznamu z nahledu produktu v sekci Administrator podsekci Objednavky:
        /// Zakazani tlacitek Upravit, Vymazat Zobrazit detail - pokud je nahled produktu prazdny
        /// </summary>
        private void ProductsDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            bool enabledState = !IsDataGridViewEmpty(ProductsDataGridView);
            List<Button> buttons = new List<Button>() { UpdateProductButton, DeleteProductButton, ProductDetailButton };
            SetAvailableButtons(buttons, enabledState);
        }

        /// <summary>
        /// Udalost pridani zaznamu do nahledu produktu v sekci Zakaznik podsekci Obchod:
        /// Pozn.: Pri nacteni aplikace jsou akce obchodu (tlacitka) vypnute, zapnou se po nacteni produktu do nahledu
        /// </summary>
        private void ShopDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            List<Button> buttons = new List<Button>()
            {
                LoginAsCustomerButton, ShowItemDetailButton
            };
            SetAvailableButtons(buttons, true);
        }

        /// <summary>
        /// Udalost pridani zaznamu do nahledu polozek v sekci Zakaznik podsekci Kosik:
        /// Tabla Kosik bude pridana, pokud jiz neni zobrazena v sekci Zakaznik
        /// </summary>
        private void BasketDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            MoveToBasketButton.Enabled = true;
            if (!StoreTabControl.TabPages.Contains(BasketTab))
            {
               StoreTabControl.TabPages.Insert(1, BasketTab);
            }
        }

        /// <summary>
        /// Udalost odstraneni zaznamu z nahledu polozek v sekci Zakaznik, podsekci Kosik:
        /// Tabla Kosik bude odstranena pokud je nahled polozek kosiku prazdny
        /// </summary>
        private void BasketDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            var thisView = sender as DataGridView;
            if (IsDataGridViewEmpty(thisView))
            {
                StoreTabControl.TabPages.Remove(BasketTab);
                MoveToBasketButton.Enabled = false;
            }
        }

        /// <summary>
        /// Udalost pridani zaznamu do nahledu objednavek v sekci Zakaznik, podsekci Moje objednavky:
        /// Zobrazi se tabla Moje objednavky pokud jeste nebyla zobrazena, zvyrazni se pridany zaznam v nahledu
        /// </summary>
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

        /// <summary>
        /// Udalost kliknuti na tlacitko Zaregistrovat v sekci Zakaznik, podsekci Registrace
        /// Verifikace registracnich udaju, zobrazeni chyb/uspesne registrace, prihlaseni registrovaneho zakaznika 
        /// </summary>
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

        /// <summary>
        /// Uzavreni tably Registrace v sekci Zakaznik po uspesne registraci, nebo prihlaseni zakaznika
        /// </summary>
        private void CloseRegistration()
        {
            ClearRegistrationForm();
            StoreTabControl.TabPages.Remove(AccountTab);
        }

        /*** Akce prehledu objednavek ***/

        /// <summary>
        /// Nastaveni stavu objednavky
        /// Pozn.: pri zmene stavu objednavky administratorem
        /// </summary>
        /// <param name="state">novy stav objednavky</param>
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

        /// <summary>
        /// Logovani zmeny stavu objednavky (potvrzeni, zruseni)
        /// </summary>
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

        /// <summary>
        /// Aktualizace stavu objednavky v nahledu objednavek v sekci Zakaznik, podsekci Moje objednavky 
        /// po zmene stavu objednavky administratorem 
        /// </summary>
        /// <param name="order">aktualizovana objednavka</param>
        /// <param name="stateName">novy stav objednavky</param>
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

        /*** ADMINISTRATORSKE AKCE OBJEDNAVKY, LOGOVANI, ZOBRAZENI DETAILU ***/

        /// <summary>
        /// Udalost kliknuti na tlacitko Potvrdit v sekci Administrator, podsekci Objednavky
        /// Potvrdi objednavku zvyraznenou v nahledu objednavek
        /// </summary>
        private void ConfirmOrderButton_Click(object sender, EventArgs e)
        {
            ChangeOrderState(OrderState.Confirmed);
        }

        /// <summary>
        /// Udalost kliknuti na tlacitko Zrušit v sekci Administrator, podsekci Objednavky
        /// Zruší objednavku zvyraznenou v nahledu objednavek
        /// </summary>
        private void CancelOrderButton_Click(object sender, EventArgs e)
        {
            ChangeOrderState(OrderState.Canceled);
        }

        /// <summary>
        /// Udalost kliknuti na tlacitko Odeslat v sekci Administrator, podsekci Objednavky
        /// Odesle objednavku zvyraznenou v nahledu objednavek
        /// </summary>
        private void SendOrderButton_Click(object sender, EventArgs e)
        {
            ChangeOrderState(OrderState.Sent);
        }

        /// <summary>
        /// Udalost kliknuti na tlacitko Zobrazit detail v sekci Administrator, podsekci Objednavky
        /// Zobrazi formular detailu objednavky zvyraznene v nahledu objednavek
        /// </summary>
        private void AdminOrderDetailButton_Click(object sender, EventArgs e)
        {
            Order selectedOrder = GetSelectedOrder(OrdersDataGridView);
            OrderDetailForm adminOrderDetail = new OrderDetailForm(selectedOrder);
            adminOrderDetail.ShowDialog();
        }

        /// <summary>
        /// Zobrazeni jmena prihlaseneho zakaznika v titulku okna
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
       
        /*** VALIDACE REGISTRACE ***/

        /// <summary>
        /// Overi zda je pole Mobil v sekci Zakaznik, podsekci Registrace
        /// vyplneno spravne, zvyrazni chybne vyplneny udaj
        /// </summary>
        /// <returns>true pokud je pole vyplneno spravne, jinak false</returns>
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

        /// <summary>
        /// Overi zda je pole PSC v sekci Zakaznik, podsekci Registrace
        /// vyplneno spravne, zvyrazni chybne vyplneny udaj
        /// </summary>
        /// <returns>true pokud je pole vyplneno spravne, jinak false</returns>
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

        /*** VERIFIKACE PRIHLASOVACICH UDAJU ***/

        /// <summary>
        /// Overi zda je pole Email v sekci Zakaznik, podsekci Registrace
        /// vyplneno spravne, zvyrazni chybne vyplneny udaj
        /// Pozn.: pole Email akceptuje format znaky@znaky.znaky
        /// </summary>
        /// <returns>true pokud je pole vyplneno spravne, jinak false</returns>
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

        /// <summary>
        /// Overi zda je pole Email v sekci Zakaznik, podsekci Registrace
        /// vyplneno spravne, zvyrazni chybne vyplneny udaj
        /// </summary>
        /// <returns>true pokud je pole vyplneno spravne, jinak false</returns>
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

        /// <summary>
        /// Udalost zavreni hlavniho formulare (ukonceni aplikace):
        /// Vyslan signal k ukonceni logovani
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logger.StopLoggingSession();
        }

        /// <summary>
        /// Udalost zmeny zobrazene tably v sekci Zakaznik:
        /// Fokus na aktualny nahled zobrazene podsekce 
        /// </summary>
        private void StoreTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectActualViewInUserSection();
        }

        /// <summary>
        /// Udalost zmeny zobrazene tably v sekci Administrator:
        /// Fokus na aktualny nahled zobrazene podsekce 
        /// </summary>
        private void DatabaseTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectActualViewInAdminSection();
        }

        /// <summary>
        /// Fokus na nahled aktualne zobrazene tably v sekci Administrator
        /// </summary>
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

        /// <summary>
        /// Fokus na nahled aktualne zobrazene tably v sekci Zakaznik
        /// </summary>
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
