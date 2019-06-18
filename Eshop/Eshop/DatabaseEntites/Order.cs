using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop
{
    class Order
    {
        public const string TableName = "Order";
        public const string OrderIDColumn = "OrderID";
        public const string CustomerColumn = "CustomerID";
        public const string FixedDiscountColumn = "FixedDiscount";
        public const string PercentualDiscountColumn = "PercentualDiscount";
        public const string StateIDColumn = "StateID";
            
        public int OrderID { get; }
        public Customer Customer { get; }
        public List<OrderItem> OrderItems { get; }
        public int FixedDiscount { get; private set; }
        public int PercentualDiscount { get; private set; }
        public string State { get; private set; }

        public Order(Customer customer, List<OrderItem> orderItems, int fixedDiscount, 
            int percentualDiscount, string state)
        {
            Customer = customer;
            OrderItems = orderItems;
            FixedDiscount = fixedDiscount;
            PercentualDiscount = percentualDiscount;
            State = state;
        }

        // metody pro zmenu detailu objednavky
        public void ChangeFixedDiscount(int fixedDiscount) => FixedDiscount = fixedDiscount;
        public void ChangePercentualDiscount(int percentualDiscount) => PercentualDiscount = percentualDiscount;
        public string ChangeState(string state) => State = state;
    }
}
