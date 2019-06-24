using System.Collections.Generic;

namespace Eshop
{
    /// <summary>
    /// Trida dedi od abstraktni tridy metody k aplikaci slev na objednavku a jeji polozky
    /// Prideleny jsou slevy objednavky:
    /// <list type="bullet">
    /// <item>
    /// pro zakaznika s objednavkou nad 1000 Kc = sleva objednavky 10 % + 100 Kč
    /// </item>
    /// <item>
    /// pro zakaznika s objednavkou nad 5000 Kc = sleva objednavky 20 % + 200 Kč
    /// </item>
    /// <item>
    /// pro zakaznika s objednavkou nad 10000 Kc = sleva objednavky 30 % + 500 Kč
    /// </item>
    /// </list>
    /// Pozn.: slevy polozky nejsou v zime aplikovany
    /// </summary>
    class Winter : Season
    {
        const int lowOrderPrice = 1000;
        const int middleOrderPrice = 5000;
        const int highOrderPrice = 10000;

        const int lowFixDiscount = 100;
        const int middleFixDiscount = 200;
        const int highFixDiscount = 500;

        const int lowPercentualDiscount = 10;
        const int middlePercentualDiscount = 20;
        const int highPercentualDiscount = 30;

        public int AssignedStrategyID { get; private set; }
        public int BasketItemsTotalPrice { get; private set; }

        /// <summary>
        /// Pri vytvareni instance konstruktor tridy spocte celkovou cenu polozek kosiku
        /// a nastavi podle ni slevovou strategii jako podklad pro vypocty slev objednavky
        /// </summary>
        public Winter()
        {
            BasketItemsTotalPrice = GetBasketItemsTotalPrice();
            AssignedStrategyID = GetItemStrategy();
        }

        /// <summary>
        /// Vraci kolekci s polozkou bez slev polozky
        /// </summary>
        public override List<OrderItem> AssignDiscountsToItem(KeyValuePair<Product, int> basketItem)
        {
            return BasketToOrderItemNoChange(basketItem, AssignedStrategyID);
        }

        /// <summary>
        /// Na zaklade vybrane strategie vraci pevnou slevu objednavky
        /// </summary>
        /// <returns>pevna sleva objednavky</returns>
        public override int GetFixedOrderDiscount()
        {
            int fixedOrderDiscount = NoDiscount;
            switch (AssignedStrategyID)
            {
                case 7:
                    return lowFixDiscount;
                case 8:
                    return middleFixDiscount;
                case 9:
                    return highFixDiscount;
                default:
                    return NoDiscount;
            }
        }

        /// <summary>
        /// Na zaklade vybrane strategie vraci procentualni slevu objednavky
        /// </summary>
        /// <returns>procentualni sleva objednavky</returns>
        public override int GetPercentualOrderDiscount()
        {
            switch (AssignedStrategyID)
            {
                case 7:
                    return lowPercentualDiscount;
                case 8:
                    return middlePercentualDiscount;
                case 9:
                    return highPercentualDiscount;
                default:
                    return NoDiscount;
            }
        }

        /// <summary>
        /// Secte katalogove ceny vsech polozek vlozene do kosiku
        /// </summary>
        /// <returns>cena polozek kosiku</returns>
        private int GetBasketItemsTotalPrice()
        {
            int totalPrice = 0; 
            foreach (var item in Basket.Items)
            {
                int itemPrice = item.Key.Price * item.Value;
                totalPrice += itemPrice;
            }
            return totalPrice;
        }

        /// <summary>
        /// Pri vytvareni instance prideli tride strategii aplikovanou na jeji polozky
        /// podle vyse objednavky
        /// </summary>
        /// <returns>identifikacni cislo slevove strategie</returns>
        private int GetItemStrategy()
        {
            if (BasketItemsTotalPrice > highOrderPrice)
            {
                return 9;
            }

            if (BasketItemsTotalPrice > middleOrderPrice)
            {
                return 8;
            }

            if (BasketItemsTotalPrice > lowOrderPrice)
            {
                return 7;
            }
            return 10;
        }
    }
}
