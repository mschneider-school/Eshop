using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop
{
    class Summer : Season
    {
        // pro leto se polozka se vraci bez individualnich slevovych uprav
        public override List<OrderItem> AssignDiscountsToItem(KeyValuePair<Product, int> basketItem)
        {
            List<OrderItem> orderItemSplit = new List<OrderItem>();

            OrderItem newOrderItem = new OrderItem(basketItem.Key, basketItem.Value);
            newOrderItem.SetFixedDiscount(0);
            newOrderItem.SetPercentualDiscount(0);

            orderItemSplit.Add(new OrderItem(basketItem.Key, basketItem.Value));

            return orderItemSplit;
        }

        // pevna sleva neni v lete na objednavku aplikovana
        public override int GetFixedOrderDiscount()
        {
            return 0;
        }

        public override int GetPercentualOrderDiscount()
        {
            // predvolene je sleva na objednavku nulova
            int percentualDiscount = 0;

            Customer customerLoggedIn = Session.CustomerLoggedIn;
            int customersOrders = Database.GetCustomersOrderCount(customerLoggedIn);
            
            // pro zakazniky s 5 a vice exist. objednavkami plati sleva z objednavky 10%
            if (customersOrders >= 5)
            {
                percentualDiscount = 10;
            }
            // pro zakazniky s 10 a vice exist. objednavkami plati sleva z objednavky 20%
            else if (customersOrders >= 10)
            {
                percentualDiscount = 20;
            }

            return percentualDiscount;
        }
    }
}
