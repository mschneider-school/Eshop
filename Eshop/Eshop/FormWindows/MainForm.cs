using Eshop.DatabaseEntites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

            // double buffering povoleno pro datagridview
            ShopDataGridView.DoubleBuffered(true);
            BasketDataGridView.DoubleBuffered(true);
            ProductsDataGridView.DoubleBuffered(true);
            OrdersDataGridView.DoubleBuffered(true);

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
            ShowLoadedProducts(ShopDataGridView);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            SaveLogDialog logPrompt = new SaveLogDialog();
            logPrompt.ShowDialog();

            Logger logger = new Logger();
            if (Logger.IsFileLog())
            {
                Logger.Log("Log nenastaveny na file");
            }

            Logger.Log("START");
            Logger.Log("08/11/2019 12:28:13 user created order 256 in total 2500 CZK");
            Logger.Log("08/11/2019 12:38:13 user canceled order 256 in total 4500 CZK");
            Logger.Log("08/11/2019 12:40:15 admin received order 256 in total 700 CZK");
            Logger.Log("END");
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
                ShowLoadedProducts(ProductsDataGridView);
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

                if (result == DialogResult.Abort)
                {
                    StoreTabControl.TabPages.Insert(2, AccountTab);
                    StoreTabControl.SelectTab(AccountTab);
                }

                // pokud byl zakaznik prihlasen, ma historii objednavek a tabla jeste neni viditelna
                // zobrazi se tabla objednavek
                if (Session.CustomerLoggedIn != null
                    && !StoreTabControl.TabPages.Contains(OrdersTab)
                    && CustomerOrdersDataGridView.RowCount > 0)
                {
                    StoreTabControl.TabPages.Insert(3, OrdersTab);
                }
                // pokud byl zakaznik prihlasen zobraz jeho jmeno v titulku okna a informaci o prihlaseni
                // pak klikni programaticky znovu na tlacitko pro zobrazeni detailu objednavky
                if (Session.CustomerLoggedIn != null)
                {
                    ShowLoggedCustomer();
                    Message.LoginSuccessInfo(Session.CustomerLoggedIn);
                    LoginToOrderButton.PerformClick();
                }
            }
            else // pokud jiz zakaznik je prihlasen sestavi a zobrazi jeho objednavku
            {
                List<OrderItem> orderItems = OrderItem.GetOrderItemsFromBasket(Basket.Items);
                Order builtOrder = Order.BuildOrder(orderItems);
                OrderDetailForm builtOrderDetail = new OrderDetailForm(builtOrder);
                DialogResult result = builtOrderDetail.ShowDialog();
                
                // pri potvrzeni objednavky ze strany zakaznika
                if (result == DialogResult.Yes)
                {
                    Database.CreateOrder(builtOrder);

                    // pokud je administrator prihlasen, prida objednavku
                    if (Session.AdminLoggedIn)
                    {
                        ShowNewOrderToAdmin(builtOrder);
                    }
                    Message.CreatedOrderSuccesInfo();
                }
                // VLOZI NOVY ZAZNAM DO PREHLEDU OBJEDNAVEK (InsertOrderToMyOrders(Order order))
                AddOrderToMyOrders(builtOrder);
                
            }
        }

        // pomocna metoda vlozi zaznam objednavky do prehledu objednavek
        private void AddOrderToMyOrders(Order order)
        {

        }

        private void CustomerOrderDetailButton_Click(object sender, EventArgs e)
        {
            // OrderDetailForm customerOrderDetail = new OrderDetailForm();
            // customerOrderDetail.ShowDialog();
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
                FocusOnProductInView(selectedProduct, BasketDataGridView);
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
                    LoginCustomer();
                }
            }
            else // jinak zobrazi prihlaseni zakaznika
            {
                LoginCustomer();
            }
        }

        // privatni metoda verifikuje prihlaseni uzivatele a upravi titulek formulare
        private void LoginCustomer()
        {
            Customer loggedInBefore = Session.CustomerLoggedIn;

            LoginRegisterDialog customerLogin = new LoginRegisterDialog();
            customerLogin.Text = "Přihlášení zákazníka";
            customerLogin.ShowDialog();

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
                        Message.LoginSuccessInfo(loggedInAfter);
                    }
                }
                else
                {
                    Message.LoginSuccessInfo(loggedInAfter);
                }
            }
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
                StoreTabControl.SelectTab(BasketTab);
            }
            RemoveTabWhenViewEmpty(StoreTabControl, BasketDataGridView, BasketTab);
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
                Basket.Empty();
                DisplayItemsInBasketView();
            }
            RemoveTabWhenViewEmpty(StoreTabControl, BasketDataGridView, BasketTab);
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
                
                // pokud byl administrator uspesne prihlasen nactou se produkty a objednavky
                // do views v sekci administratora
                if (Session.AdminLoggedIn)
                {
                    // zobrazi se tably produktu a objednavek
                    DatabaseTabControl.Visible = true;

                    // nacte se obsah produktoveho a objednavkoveho prehledu
                    ShowLoadedProducts(ProductsDataGridView);
                    ShowLoadedOrdersToAdmin();
                }
            }
        }

        /*** POMOCNE METODY HLAVNIHO FORMULARE K PROVEDENI UI UPRAV ***/

        /// <summary>
        /// Zobrazi vsechny produkty z cache v administratorske casti
        /// </summary>
        /// <param name="cathegory">volitelny parameter k zobrazeni jen produktu jiste kategorie</param>
        public void ShowLoadedProducts(DataGridView dataGridView, string cathegory = null)
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
        public void ShowLoadedOrdersToAdmin()
        {
            OrdersDataGridView.Rows.Clear();

            // zobrazi kazdou objedavku v pameti
            foreach (Order order in Database.CachedOrders)
            {
                // objednavce se priradi jeji polozky a zaroven spocita jeji kalkulace
                Database.LoadOrderItemsToOrder(order);
                
                // vlozi zaznam objednavky do view
                AddNewOrderRecordToAdminView(order);
            }
        }

        /// <summary>
        /// Zobrazi nove pridanou skalkulovanou objednavku v administratorskem prehledu objednavek
        /// </summary>
        /// <param name="order">nove pridana objednavka</param>
        public void ShowNewOrderToAdmin(Order order)
        {
            AddNewOrderRecordToAdminView(order);
        }

        // pomocna metoda k vlozeni zaznamu objednavky do administratorskeho view
        private void AddNewOrderRecordToAdminView(Order order)
        {
            // prida se zaznam s udaji objednavky do prehledu
            OrdersDataGridView.Rows.Add
            (
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
        /// Skryje tab kdyz je datagridview prazdny 
        /// </summary>
        /// <param name="tabControl">tabla na ktere se provadi operace</param>
        /// <param name="dataGridView">kontrolovane view</param>
        /// <param name="tabPage">stranka ktera se vymaze pokud je gridview prazdny</param>
        private void RemoveTabWhenViewEmpty(TabControl tabControl, 
            DataGridView dataGridView, TabPage tabPage)
        {
            if (dataGridView.Rows.Count < 1)
            {
                tabControl.TabPages.Remove(tabPage);
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
        public static Product GetSelectedProduct(DataGridView dataGridView)
        {
            int selectedProductID = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
            Product selectedProduct = Database.GetCachedProductByID(selectedProductID);
            return selectedProduct;
        }

        /// <summary>
        /// Oznaci zaznam s udaji zvoleneho produktu v zvolenem datagridview
        /// </summary>
        /// <param name="product"></param>
        public static void FocusOnProductInView(Product product, DataGridView dataGridView)
        {
            foreach(DataGridViewRow row in dataGridView.Rows)
            {
                if ((int)row.Cells[0].Value == product.ID)
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
        public static Order GetSelectedOrder(DataGridView dataGridView)
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

        // oznaci radek jinou barvou po pridani do kosiku
        private void MarkSelectedToBin(DataGridView dataGridView)
        {
            dataGridView.SelectedRows[0].DefaultCellStyle.BackColor = SystemColors.GradientActiveCaption;
        }

        /// <summary>
        /// zobrazi novy produkt v productsDataGridView
        /// </summary>
        /// <param name="product">produkt k zobrazeni</param>
        public void ShowNewProduct(Product product)
        {
             ProductsDataGridView.Rows.Add(product.ID, product.Name, product.Cathegory, product.Price);
             FocusOnProductInView(product, ProductsDataGridView);
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
            ShowLoadedProducts(ShopDataGridView);
        }

        // zobraz jen chytre hodinky
        private void SmartWatchesTSMenuItem_Click(object sender, EventArgs e)
        {
            string smWatches = SmartWatchesTSMenuItem.Text;
            ShowLoadedProducts(ShopDataGridView, smWatches);
        }

        // zobraz jen kryty a pouzdra
        private void CoversTSMenuItem_Click(object sender, EventArgs e)
        {
            string covers = CoversTSMenuItem.Text;
            ShowLoadedProducts(ShopDataGridView, covers);
        }

        // zobraz jen smartfony
        private void SmartphonesTSMenuItem_Click(object sender, EventArgs e)
        {
            string smphones = SmartphonesTSMenuItem.Text;
            ShowLoadedProducts(ShopDataGridView, smphones);
        }

        // zobraz jen tablety
        private void TabletsTSMenuItem_Click(object sender, EventArgs e)
        {
            string tablets = TabletsTSMenuItem.Text;
            ShowLoadedProducts(ShopDataGridView, tablets);
        }

        // zobraz jen tlacitkove telefony
        private void KeypadPhonesTSMenuItem_Click(object sender, EventArgs e)
        {
            string kphones = KeypadPhonesTSMenuItem.Text;
            ShowLoadedProducts(ShopDataGridView, kphones);
        }

        // zobraz jen ochranna skla
        private void ScreenProtectorsTSMenuItem_Click(object sender, EventArgs e)
        {
            string scprotectors = ScreenProtectorsTSMenuItem.Text;
            ShowLoadedProducts(ShopDataGridView, scprotectors);
        }

        // zobraz jen kabely a nabijecky
        private void ChargersCablesTSMenuItem_Click(object sender, EventArgs e)
        {
            string cables = ChargersCablesTSMenuItem.Text;
            ShowLoadedProducts(ShopDataGridView, cables);
        }

        private void BackToBasketButton_Click(object sender, EventArgs e)
        {
            StoreTabControl.SelectTab(BasketTab);
            StoreTabControl.TabPages.Remove(AccountTab);
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
            List<Button> buttons = new List<Button>()
            {
                ConfirmOrderButton, CancelOrderButton,
                SendOrderButton, AdminOrderDetailButton
            };
            SetAvailableButtons(sender, buttons, true);
        }

        private void OrdersDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            bool availability = OrdersDataGridView.Rows.Count > 0;
            List<Button> buttons = new List<Button>()
            {
                ConfirmOrderButton, CancelOrderButton,
                SendOrderButton, AdminOrderDetailButton
            };
            SetAvailableButtons(sender, buttons, availability);
        }

        private void ProductsDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            List<Button> buttons = new List<Button>() { UpdateProductButton, DeleteProductButton, ProductDetailButton};
            SetAvailableButtons(sender, buttons, true);
        }

        private void ProductsDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            bool availability = ProductsDataGridView.Rows.Count > 0;
            List<Button> buttons = new List<Button>() { UpdateProductButton, DeleteProductButton, ProductDetailButton };
            SetAvailableButtons(sender, buttons, availability);
        }

        private void ShopDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            List<Button> buttons = new List<Button>()
            {
                LoginAsCustomerButton, ShowItemDetailButton
            };
            SetAvailableButtons(sender, buttons, true);
        }

        private void ShopDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            bool availability = ShopDataGridView.Rows.Count > 0;
            List<Button> buttons = new List<Button>()
            {
                LoginAsCustomerButton, ShowItemDetailButton, MoveToBasketButton
            };
            SetAvailableButtons(sender, buttons, availability);
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
  

        // po pridani objednavky do zakaznickeho prehledu objednavky se focus presune na tablu objednavek
        private void CustomerOrdersDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            StoreTabControl.SelectedTab = OrdersTab;
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
                    int postalCode = Convert.ToInt32(PostalCodeMaskTextBox.Text.Replace(" ", ""));
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

                    // po uspesne registraci zobrazi informace o registraci
                    // vycisti reg. formular a zavre tabla registrace
                    // uzivatel se presmeruje do kosiku
                    Message.RegistrationSuccessInfo();
                    ClearRegistrationForm();
                    StoreTabControl.TabPages.Remove(AccountTab);
                    StoreTabControl.SelectedTab = BasketTab;

                    // automaticky se prejde k objednavce
                    // novemu prihlasenemu uzivateli se zobrazi objednavka k potvrzeni
                    LoginToOrderButton.PerformClick();
                }
            }
        }

        /*** Akce prehledu objednavek ***/

        // pomocna metoda zmeny stavu
        private void ChangeOrdersState(int state)
        {
            int stateID = state;
            string stateName = Database.GetStateNameByID(stateID);

            // vybrana objednavka jako objekt, novy stav ulozen v db aj cache 
            Order selectedOrder = GetSelectedOrder(OrdersDataGridView);
            Database.ChangeOrderState(selectedOrder, stateID);

            // zmen stav vybrane objednavky v prehledu objedavek
            OrdersDataGridView.SelectedRows[0].Cells[7].Value = stateName;

            // zobrazi spravu o proběhle zmene
            Message.OrderStateChangeInfo(stateName.ToLower());
        }

        /*** Zmeny stavu objednavky (potvrzena, zrusena, odeslana) a zobrazeni detailu ***/

        private void ConfirmOrderButton_Click(object sender, EventArgs e)
        {
            ChangeOrdersState(OrderState.Confirmed);
        }

        private void CancelOrderButton_Click(object sender, EventArgs e)
        {
            ChangeOrdersState(OrderState.Canceled);
        }

        private void SendOrderButton_Click(object sender, EventArgs e)
        {
            ChangeOrdersState(OrderState.Sent);
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
                Text = $"MobileShop - Přihlášen: {loggedName} {loggedLastName}";
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

    }
}
