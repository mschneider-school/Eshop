using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int BasketItemsTotalPrice { get; private set; }

        /*** Slevy objednavky ***/

        // pro zakazniky s objednavkou nad 1000 Kc = sleva objednavky 10 % + 100 Kč
        // pro zakazniky s objednavkou nad 5000 Kc = sleva objednavky 20 % + 200 Kč
        // pro zakazniky s objednavkou nad 10000 Kc = sleva objednavky 30 % + 500 Kč

        public Winter()
        {
            BasketItemsTotalPrice = GetBasketItemsTotalPrice();
        }

        // pro zimu se polozka se vraci bez individualnich slevovych uprav
        public override List<OrderItem> AssignDiscountsToItem(KeyValuePair<Product, int> basketItem)
        {
            return BasketToOrderItemNoChange(basketItem);
        }

        public override int GetFixedOrderDiscount()
        {
            if (BasketItemsTotalPrice > lowOrderPrice)
                return lowFixDiscount;

            if (BasketItemsTotalPrice > middleOrderPrice)
                return middleFixDiscount;

            if (BasketItemsTotalPrice > highOrderPrice)
                return highFixDiscount;

            return NoDiscount;
        }

        public override int GetPercentualOrderDiscount()
        {
            if (BasketItemsTotalPrice > lowOrderPrice)
                return lowPercentualDiscount;

            if (BasketItemsTotalPrice > middleOrderPrice)
                return middlePercentualDiscount;

            if (BasketItemsTotalPrice > highOrderPrice)
                return highPercentualDiscount;

            return NoDiscount;
        }

        // pomocna metoda k secteni cen vsech polozek v kosiku
        private int GetBasketItemsTotalPrice()
        {
            int totalPrice = 0; 
            foreach (var item in Basket.Items)
            {
                totalPrice += item.Key.Price * item.Value;
            }
            return totalPrice;
        }
    }
}
