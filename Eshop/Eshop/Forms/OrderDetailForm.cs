using System;
using System.Drawing;
using System.Windows.Forms;

namespace Eshop
{
    /// <summary>
    /// Formular zobrazeni detailu objednavky, 
    /// Pozn.: pri zobrazeni detailu existujici objednavky je tlacitko Potvrdit objednavku zakazano
    /// </summary>
    public partial class OrderDetailForm : Form
    {
        public Order Order { get; }
        public MainForm MainForm { get; }
        public bool ConfirmationEnabled { get; private set; }

        public OrderDetailForm(Order order, bool confirmationEnabled = false, MainForm mainForm = null)
        {
            Order = order;
            ConfirmationEnabled = confirmationEnabled;
            InitializeComponent();
            MainForm = mainForm;
            CenterToParent();
        }

        /// <summary>
        /// Udalost nacitani formulare:
        /// Pripraveni formulare k zobrazeni, nacteni informaci o zakaznikovi
        /// pridani polozek do nahledu, nacteni cenove kalkulace objednavky
        /// </summary>
        private void OrderDetailForm_Load(object sender, EventArgs e)
        {
            // zakaz tlacitko povtrzeni pokud form slouzi k zobrazeni detailu existujici objednavky (predvolene)
            CustomerConfirmOrderButton.Enabled = ConfirmationEnabled;

            // nacti informace o zakaznikovi
            FirstNameValueLabel.Text = Order.Customer.Name;
            LastNameValueLabel.Text = Order.Customer.LastName;
            EmailValueLabel.Text = Order.Customer.Email;

            string phone = Order.Customer.MobilePhone.ToString();
            PhoneValueLabel.Text = 
                $"{phone.Substring(0,3)} {phone.Substring(3,3)} {phone.Substring(6,3)}";
            
            // nacti fakturacni adresu
            CityValueLabel.Text = Order.Customer.City;
            StreetValueLabel.Text = Order.Customer.Street;
            HouseNumberValueLabel.Text = Order.Customer.HouseNumber;

            string psc = Order.Customer.PostalCode.ToString();
            PostalCodeValueLabel.Text = $"{psc.Substring(0,3)} {psc.Substring(3)}";

            OrderItemsDataGridView.Columns[6].HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);

            //// nacti kazdou polozku objednavky do nahledu dat
            foreach (var orderItem in Order.OrderItems)
            {
                // celkova cena polozky (pocet kusu * cena za ks)
                int itemPrice = orderItem.GetTotalOrderItemPrice();
                decimal totalItemDiscount = orderItem.GetTotalOrderItemDiscount();

                decimal finalItemPrice = itemPrice - totalItemDiscount;

                OrderItemsDataGridView.Rows.Add
                (
                    orderItem.Item.ID,
                    orderItem.Item.Name,
                    orderItem.Quantity,
                    itemPrice,
                    orderItem.FixedDiscount,
                    orderItem.PercentualDiscount,
                    finalItemPrice,
                    orderItem.StrategyID
                );
            }

            /*** ZOBRAZENI CENOVYCH KALKULACI OBJEDNAVKY ***/

            FixedOrderDiscountValueLabel.Text = Order.FixedDiscount.ToString("N0");
            PercentualOrderDiscountValueLabel.Text = Order.PercentualDiscount.ToString("N0");
            TotalOrderDiscountsValueLabel.Text = 
                Order.TotalOrderDiscount == 0 ? 
                Order.TotalOrderDiscount.ToString("N0") : Order.TotalOrderDiscount.ToString("N2");
            FinalOrderSumValueLabel.Text = Order.FinalOrderPrice.ToString("N0");
        }

        /// <summary>
        /// Udalost kliknuti na tlacitko Detail produktu
        /// Zobrazeni formulare s detailem produktu pro zvyraznenou polozku v nahlede
        /// </summary>
        private void ShowProductDetailButton_Click(object sender, EventArgs e)
        {
            MainForm.ShowSelectedProductDetails(OrderItemsDataGridView);
        }

        /// <summary>
        /// Udalost zmacknuti klavesy: po zmacknuti Escape klavesy se formular detailu objednavky zatvori
        /// </summary>
        private void OrderDetailForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        // po potvrzeni objednavky se zobrazi sprava a zaroven vyprazdni a zavre kosik

        /// <summary>
        /// Udalost stisknuti tlacitka Potvrdit objednavku:
        /// Zobrazeni spravy o uspesnem vytvoreni objednavky, vyprazdneni kosiku
        /// </summary>
        private void CustomerConfirmOrderButton_Click(object sender, EventArgs e)
        {
            Message.CreatedOrderSuccesInfo();
            if (MainForm != null)
            {
                MainForm.EmptyBasketView();
            }
        }

        /// <summary>
        /// Udalost pridani zaznamu do nahledu polozek objednavky v detailu objednavky:
        /// Nacteny popisy slevovych strategii polozek do tooltipu bunek v sloupci Sleva % a Sleva Kc
        /// </summary>
        private void OrderItemsDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int addedRowIndex = e.RowIndex;
            DataGridView thisView = sender as DataGridView;

            int strategyID = (int)thisView.Rows[addedRowIndex].Cells[7].Value;
            string strategyDescription = Database.GetCachedStrategyByID(strategyID).Description;

            // nastav tooltipy pro slevove bunky 
            thisView.Rows[addedRowIndex].Cells[4].ToolTipText = strategyDescription;
            thisView.Rows[addedRowIndex].Cells[5].ToolTipText = strategyDescription;
        }
    }
}
