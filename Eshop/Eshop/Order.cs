using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop
{
    class Order
    {
        public int OrderID { get; }
        public Customer Customer { get; }
        public List<OrderItem> OrderItems { get; }
        public decimal FixedDiscount { get; private set; }
        public double PercentualDiscount { get; private set; }
        public string State { get; private set; }

        public Order(int orderID, Customer customer, List<OrderItem> orderItems, decimal fixedDiscount, 
            double percentualDiscount, string state)
        {
            OrderID = orderID;
            Customer = customer;
            OrderItems = orderItems;
            FixedDiscount = fixedDiscount;
            PercentualDiscount = percentualDiscount;
            State = state;
        }

        // metody pro zmenu detailu objednavky
        public void ChangeFixedDiscount(decimal fixedDiscount) => FixedDiscount = fixedDiscount;
        public void ChangePercentualDiscount(double percentualDiscount) => PercentualDiscount = percentualDiscount;
        public string ChangeState(string state) => State = state;
    }
}
