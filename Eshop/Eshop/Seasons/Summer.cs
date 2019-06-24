using System.Collections.Generic;

namespace Eshop
{
    /// <summary>
    /// Trida dedi od abstraktni tridy metody k aplikaci slev na objednavku a jeji polozky. 
    /// Procentualni sleva objednavky pri nakupu:
    /// <list type="bullet">
    /// <item>
    /// pro zakaznika s 5 a vice existujicimi objednavky, sleva na objednavku 10%
    /// </item>
    /// <item>
    /// pro zakaznika s 10 a vice existujicimi objednavky, sleva na objednavku 20%
    /// </item>
    /// </list>
    /// Pozn.: na polozku nejsou v lete aplikovany slevy
    /// </summary>
    class Summer : Season
    {
        const int smallerOrdersCount = 5;
        const int biggerOrdersCount = 10;

        const int lowerPercentualDiscount = 10;
        const int higherPercentualDiscount = 20;

        public int AssignedStrategyID { get; private set; }

        /// <summary>
        /// Pri vytvareni instance konstruktor tridy zvoli a nastavi vybranou strategii
        /// podle poctu objednavek prave prihlaseneho zakaznika (objednavatele)
        /// </summary>
        public Summer()
        {
            AssignedStrategyID = GetItemStrategy();
        }

        /// <summary>
        /// Vraci kolekci s polozkou bez slev polozky
        /// </summary>
        /// <param name="basketItem"></param>
        /// <returns></returns>
        public override List<OrderItem> AssignDiscountsToItem(KeyValuePair<Product, int> basketItem)
        {
            return BasketToOrderItemNoChange(basketItem, AssignedStrategyID);
        }

        /// <summary>
        /// Vraci pevnou slevu objednavky
        /// </summary>
        /// <returns>nula</returns>
        public override int GetFixedOrderDiscount()
        {
            return NoDiscount;
        }

        /// <summary>
        /// Vraci procentualni slevu objednavky
        /// </summary>
        /// <returns>nula</returns>
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

        /// <summary>
        /// Pri vytvareni instance prideli tride strategii aplikovanou na jeji polozky
        /// podle poctu objednavek zakaznika
        /// </summary>
        /// <returns>identifikacni cislo strategie</returns>
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
