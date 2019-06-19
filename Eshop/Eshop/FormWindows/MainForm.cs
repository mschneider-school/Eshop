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
            
            // zobrazi data produktu z cache do produktoveho prehladu v eshope a admin. sekcii
            Database.DisplayLoadedProducts(ProductsDataGridView);
            Database.DisplayLoadedProducts(ShopDataGridView);
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
                Database.DisplayLoadedProducts(ProductsDataGridView);
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

                ShowLoggedCustomer();
                Validation.LoginSuccessInfo(Session.CustomerLoggedIn);
            }
            else // pokud jiz zakaznik je prihlasen sestavi a zobrazi jeho objednavku
            {
                List<OrderItem> orderItems = OrderItem.GetOrderItemsFromBasket(Basket.Items);
                Order builtOrder = Order.BuildOrder(orderItems);
                OrderDetailForm builtOrderDetail = new OrderDetailForm(builtOrder);
                builtOrderDetail.ShowDialog();
            }
        }

        private void CustomerOrderDetailButton_Click(object sender, EventArgs e)
        {
            // OrderDetailForm customerOrderDetail = new OrderDetailForm();
            // customerOrderDetail.ShowDialog();
        }

        private void AdminOrderDetailButton_Click(object sender, EventArgs e)
        {
            // OrderDetailForm adminOrderDetail = new OrderDetailForm();
            // adminOrderDetail.ShowDialog();
        }

        private void LoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginRegisterDialog customerLogin = new LoginRegisterDialog();
            customerLogin.ShowDialog();
        }

        // pridej polozku do kosiku
        private void AddToBasketButton_Click(object sender, EventArgs e)
        {
            AddToBasketDialog addToBasket =
                new AddToBasketDialog(GetSelectedProduct(ShopDataGridView));
            DialogResult result = addToBasket.ShowDialog();

            // pokud se polozka uspesne pridala do kosiku
            // pridame tablu kosiku a zobrazime obsah kosiku
            if (result == DialogResult.OK)
            {
                DisplayItemsInBasketView();
            }
        }

        private void ShowCustomerLoginForm()
        {
            LoginRegisterDialog customerLogin = new LoginRegisterDialog();
            customerLogin.Text = "Přihlášení zákazníka";
            customerLogin.ShowDialog();
        }

        // prihlasit se jako zakaznik
        private void LoginAsCustomerButton_Click(object sender, EventArgs e)
        {
            // pokud jiz byl zakaznik prihlasen zeptame se jestli chce
            // odhlasit stavajiciho zakaznika prihlasit se jako novy
            if (Session.CustomerLoggedIn != null)
            {
                DialogResult result = Validation.LoginNewCustomerQuestion();
                // prihlasit se jako novy zakaznik
                if (result == DialogResult.Yes)
                {
                    ShowCustomerLoginForm();
                    ShowLoggedCustomer();
                    Validation.LoginSuccessInfo(Session.CustomerLoggedIn);
                }
            }
            else // jinak zobrazi prihlaseni zakaznika
            {
                ShowCustomerLoginForm();
                ShowLoggedCustomer();
                Validation.LoginSuccessInfo(Session.CustomerLoggedIn);
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

        private void UserViewsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UserViewsTabControl.SelectedTab == UserViewsTabControl.TabPages["adminTabPage"]
                && !Session.AdminLoggedIn)
            {
                LoginRegisterDialog adminLogin = new LoginRegisterDialog();
                adminLogin.TransformToAdminLogin();
                adminLogin.ShowDialog();
            }
        }

        /*** POMOCNE METODY HLAVNIHO FORMULARE K PROVEDENI UI UPRAV ***/
        
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
            long selectedProductID = Convert.ToInt64(dataGridView.SelectedRows[0].Cells[0].Value);
            Product selectedProduct = Database.GetCachedProductByID(selectedProductID);

            return selectedProduct;
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
        /// zobrazi novy produkt
        /// </summary>
        /// <param name="product">produkt k zobrazeni</param>
        public void DisplayNewProduct(Product product)
        {
             ProductsDataGridView.Rows.Add(product.ID, product.Name, product.Cathegory, product.Price);
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
            Database.DisplayLoadedProducts(ShopDataGridView);
        }

        // zobraz jen chytre hodinky
        private void SmartWatchesTSMenuItem_Click(object sender, EventArgs e)
        {
            string smWatches = SmartWatchesTSMenuItem.Text;
            Database.DisplayLoadedProducts(ShopDataGridView, smWatches);
        }

        // zobraz jen kryty a pouzdra
        private void CoversTSMenuItem_Click(object sender, EventArgs e)
        {
            string covers = CoversTSMenuItem.Text;
            Database.DisplayLoadedProducts(ShopDataGridView, covers);
        }

        // zobraz jen smartfony
        private void SmartphonesTSMenuItem_Click(object sender, EventArgs e)
        {
            string smphones = SmartphonesTSMenuItem.Text;
            Database.DisplayLoadedProducts(ShopDataGridView, smphones);
        }

        // zobraz jen tablety
        private void TabletsTSMenuItem_Click(object sender, EventArgs e)
        {
            string tablets = TabletsTSMenuItem.Text;
            Database.DisplayLoadedProducts(ShopDataGridView, tablets);
        }

        // zobraz jen tlacitkove telefony
        private void KeypadPhonesTSMenuItem_Click(object sender, EventArgs e)
        {
            string kphones = KeypadPhonesTSMenuItem.Text;
            Database.DisplayLoadedProducts(ShopDataGridView, kphones);
        }

        // zobraz jen ochranna skla
        private void ScreenProtectorsTSMenuItem_Click(object sender, EventArgs e)
        {
            string scprotectors = ScreenProtectorsTSMenuItem.Text;
            Database.DisplayLoadedProducts(ShopDataGridView, scprotectors);
        }

        // zobraz jen kabely a nabijecky
        private void ChargersCablesTSMenuItem_Click(object sender, EventArgs e)
        {
            string cables = ChargersCablesTSMenuItem.Text;
            Database.DisplayLoadedProducts(ShopDataGridView, cables);
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
        
        private void BasketDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            bool availability = BasketDataGridView.Rows.Count > 0;
            List<Button> buttons = new List<Button>()
            {
                RemoveBasketItemButton, ShowDetailBasketItemButton,
                EmptyBasketButton, LoginToOrderButton, MoveToBasketButton
            };
            SetAvailableButtons(sender, buttons, availability);
        }

        private void CustomerOrdersDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            List<Button> buttons = new List<Button>() { CustomerOrderDetailButton };
            SetAvailableButtons(sender, buttons, true);
        }

        private void RegisterAndOrderButton_Click(object sender, EventArgs e)
        {
            bool allValid = Validation.InvalidEntriesCheck(RegDetailsToValidate, Color.MistyRose);
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
                Validation.InvalidEntriesWarning();
            }
            else
            {
                string email = EmailTextBox.Text.Trim();
                // pokud neni email unikatni tak se zobrazi upozorňující hláška
                // a pole emailu se vybarvi chybovou barvou
                if (!Database.IsEmailUnique(email))
                {
                    EmailTLPanel.BackColor = Color.MistyRose;
                    Validation.EmailRegisteredWarning();
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
                    Validation.RegistrationSuccessInfo();
                    ClearRegistrationForm();
                    StoreTabControl.TabPages.Remove(AccountTab);
                    StoreTabControl.SelectedTab = BasketTab;

                    // sestavit objednavku z polozek v kosiku

                }
            }
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
