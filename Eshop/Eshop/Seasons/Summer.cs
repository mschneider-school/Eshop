using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop
{
    class Summer : Season
    {
        const int smallerOrdersCount = 5;
        const int biggerOrdersCount = 10;

        const int lowerPercentualDiscount = 10;
        const int higherPercentualDiscount = 20;

        // pro leto se polozka se vraci bez individualnich slevovych uprav
        public override List<OrderItem> AssignDiscountsToItem(KeyValuePair<Product, int> basketItem)
        {
            return BasketToOrderItemNoChange(basketItem);
        }

        // pevna sleva neni v lete na objednavku aplikovana
        public override int GetFixedOrderDiscount()
        {
            return NoDiscount;
        }

        public override int GetPercentualOrderDiscount()
        {
            // predvolene je sleva na objednavku nulova
            int percentualDiscount = NoDiscount;

            int customersOrders = Database.GetLoggedCustomerOrdersCount();
            
            // pro zakazniky s 5 a vice exist. objednavkami plati sleva z objednavky 10%
            if (customersOrders >= smallerOrdersCount && customersOrders < biggerOrdersCount)
            {
                percentualDiscount = lowerPercentualDiscount;
            }

            // pro zakazniky s 10 a vice exist. objednavkami plati sleva z objednavky 20%
            if (customersOrders >= 10)
            {
                percentualDiscount = higherPercentualDiscount;
            }

            return percentualDiscount;
        }
    }
}
