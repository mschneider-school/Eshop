using System.Collections.Generic;

namespace Eshop
{
    class Summer : Season
    {
        const int smallerOrdersCount = 5;
        const int biggerOrdersCount = 10;

        const int lowerPercentualDiscount = 10;
        const int higherPercentualDiscount = 20;

        public int AssignedStrategyID { get; private set; }

        public Summer()
        {
            AssignedStrategyID = GetItemStrategy();
        }

        // pro leto se polozka se vraci bez individualnich slevovych uprav
        public override List<OrderItem> AssignDiscountsToItem(KeyValuePair<Product, int> basketItem)
        {
            return BasketToOrderItemNoChange(basketItem, AssignedStrategyID);
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

            switch (AssignedStrategyID)
            {
                case 4:
                    percentualDiscount = lowerPercentualDiscount;
                    break;
                case 5:
                    percentualDiscount = higherPercentualDiscount;
                    break;
            }

            return percentualDiscount;
        }

        private int GetItemStrategy()
        {
            int customerOrders = Database.GetLoggedCustomerOrdersCount();

            if (customerOrders >= smallerOrdersCount && customerOrders < biggerOrdersCount)
            {
                return 4;
            }
            
            if (customerOrders >= 10)
            {
                return 5;
            }

            return 10;
        }
    }
}
