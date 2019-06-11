using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eshop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            


            InitializeComponent();
            Shown += MainForm_Shown;
            Load += MainForm_Load;
        }

        private void MainForm_Load(Object sender, EventArgs e)
        {
            ShopDataGridView.DoubleBuffered(true);
            BasketDataGridView.DoubleBuffered(true);
            ProductsDataGridView.DoubleBuffered(true);
            OrdersDataGridView.DoubleBuffered(true);

            // nahraje produktova data z databaze do pameti
            Database.ReadTableData(Database.loadProducts, Database.LoadProductsCommand);

            // nahraje data kategorii z db do pameti
            Database.ReadTableData(Database.loadCathegories, Database.LoadCathegoriesCommand);
            
            // zobrazi data produktu z cache do produktoveho prehladu v eshope a admin. sekcii
            Database.DisplayLoadedProducts(ProductsDataGridView);
            Database.DisplayLoadedProducts(ShopDataGridView);
        }

        private void MainForm_Shown(Object sender, EventArgs e)
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
            if (result == DialogResult.Yes)
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
            LoginRegisterDialog customerLogin = new LoginRegisterDialog();
            customerLogin.Text = "Přihlášení zákazníka";
            customerLogin.ShowDialog();
        }

        private void CustomerOrderDetailButton_Click(object sender, EventArgs e)
        {
            OrderDetailForm customerOrderDetail = new OrderDetailForm();
            customerOrderDetail.ShowDialog();
        }

        private void AdminOrderDetailButton_Click(object sender, EventArgs e)
        {
            OrderDetailForm adminOrderDetail = new OrderDetailForm();
            adminOrderDetail.ShowDialog();
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
            // refreshneme zobrazeni kosiku s polozkama
            if (result == DialogResult.OK)
            {
                DisplayItemsInBasketView();
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
                Basket.Empty();
                DisplayItemsInBasketView();
            }
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
        /// Zobrazi detaily produktu vybraneho v danem dataGridView
        /// </summary>
        private void ShowSelectedProductDetails(DataGridView dataGridView)
        {
            Product selectedProduct = GetSelectedProduct(dataGridView);
            ProductDetailsForm productDetails = new ProductDetailsForm(selectedProduct);
            productDetails.ShowDialog();
        }

        /// <summary>
        /// Vybere a vrati objekt Produkt vybrany 
        /// </summary>
        /// <returns></returns>
        private Product GetSelectedProduct(DataGridView dataGridView)
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
            dataGridView.SelectedRows[0].
                DefaultCellStyle.BackColor = SystemColors.GradientActiveCaption;
        }

        /// <summary>
        /// zobrazi novy produkt
        /// </summary>
        /// <param name="product">produkt k zobrazeni</param>
        public void DisplayNewProduct(Product product)
        {
             ProductsDataGridView.Rows.Add(product.ID, product.Name, 
                 product.Cathegory, product.Price);
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

    }
}
