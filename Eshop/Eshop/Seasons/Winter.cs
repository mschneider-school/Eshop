using System.Collections.Generic;

namespace Eshop
{
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

        /*** Slevy objednavky ***/

        // pro zakazniky s objednavkou nad 1000 Kc = sleva objednavky 10 % + 100 Kč
        // pro zakazniky s objednavkou nad 5000 Kc = sleva objednavky 20 % + 200 Kč
        // pro zakazniky s objednavkou nad 10000 Kc = sleva objednavky 30 % + 500 Kč

        public Winter()
        {
            BasketItemsTotalPrice = GetBasketItemsTotalPrice();
            AssignedStrategyID = GetItemStrategy();
        }

        // pro zimu se polozka se vraci bez individualnich slevovych uprav
        public override List<OrderItem> AssignDiscountsToItem(KeyValuePair<Product, int> basketItem)
        {
            return BasketToOrderItemNoChange(basketItem, AssignedStrategyID);
        }

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

        // pomocna metoda k secteni cen vsech polozek v kosiku
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

        public int GetItemStrategy()
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
