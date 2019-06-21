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

        public OrderDetailForm(Order order)
        {
            Order = order;
            InitializeComponent();
            CenterToParent();
        }

        // nacti informace z objednavky do formularoveho okna
        private void OrderDetailForm_Load(object sender, EventArgs e)
        {
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

            /*** ZOBRAZENI CENOVYCH KALKULACI OBJEDNAVKY V NUMERICKEM FORMATU***/

            FixedOrderDiscountValueLabel.Text = Order.FixedDiscount.ToString("N0");
            PercentualOrderDiscountValueLabel.Text = Order.PercentualDiscount.ToString("N0");
            TotalOrderDiscountsValueLabel.Text = Order.TotalOrderDiscount.ToString("N0");
            FinalOrderSumValueLabel.Text = Order.FinalOrderPrice.ToString("N0");
        }

        // po kliknuti zobrazi detail produktove polozky
        private void ShowProductDetailButton_Click(object sender, EventArgs e)
        {
            MainForm.ShowSelectedProductDetails(OrderItemsDataGridView);
        }
    }
}
