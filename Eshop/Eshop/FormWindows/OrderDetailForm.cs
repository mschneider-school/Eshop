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

        // nacti informace z objednavky do formularoveho okna
        private void OrderDetailForm_Load(object sender, EventArgs e)
        {
            // zakaz tlacitko povtrzeni pokud form slouzi k zobrazeni detailu existujici objednavky (predvolene)
            CustomerConfirmOrderButton.Enabled = ConfirmationEnabled;

            // nacti informace o zakaznikovi
            FirstNameValueLabel.Text = Order.Customer.Name;
            LastNameValueLabel.Text = Order.Customer.LastName;
            EmailValueLabel.Text = Order.Customer.Email;
            PhoneValueLabel.Text = Order.Customer.MobilePhone.ToString();
            
            // nacti fakturacni adresu
            CityValueLabel.Text = Order.Customer.City;
            StreetValueLabel.Text = Order.Customer.Street;
            HouseNumberValueLabel.Text = Order.Customer.HouseNumber;
            PostalCodeValueLabel.Text = Order.Customer.PostalCode.ToString();

            //// nacti kazdou polozku objednavky do nahledu dat
            foreach (var orderItem in Order.OrderItems)
            {
                // celkova cena polozky (pocet kusu * cena za ks)
                int itemPrice = orderItem.Quantity * orderItem.Item.Price;

                OrderItemsDataGridView.Rows.Add
                (
                    orderItem.Item.ID,
                    orderItem.Item.Name,
                    orderItem.Quantity,
                    itemPrice,
                    orderItem.FixedDiscount,
                    orderItem.PercentualDiscount
                );
            }

            /*** ZOBRAZENI CENOVYCH KALKULACI OBJEDNAVKY ***/

            FixedOrderDiscountValueLabel.Text = Order.FixedDiscount.ToString();
            PercentualOrderDiscountValueLabel.Text = Order.PercentualDiscount.ToString();
            TotalOrderDiscountsValueLabel.Text = Order.TotalOrderDiscount.ToString();
            FinalOrderSumValueLabel.Text = Order.FinalOrderPrice.ToString();
        }

        // po kliknuti zobrazi detail produktove polozky
        private void ShowProductDetailButton_Click(object sender, EventArgs e)
        {
            MainForm.ShowSelectedProductDetails(OrderItemsDataGridView);
        }

        private void OrderDetailForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        // po potvrzeni objednavky se zobrazi sprava a zaroven vyprazdni a zavre kosik
        private void CustomerConfirmOrderButton_Click(object sender, EventArgs e)
        {
            Message.CreatedOrderSuccesInfo();
            if (MainForm != null)
            {
                MainForm.EmptyBasketView();
            }
        }
    }
}
