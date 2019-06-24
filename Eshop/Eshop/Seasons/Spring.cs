using System.Collections.Generic;

namespace Eshop
{
    class Spring : Season
    {
        const int littleItemQuantity = 3;
        const int middleItemQuantity = 8;
        const int highItemQuantity = 12;

        const int noDiscount = 0;

        const int lowItemPercentualDiscount = 20;
        const int middleItemPercentualDiscount = 30;
        const int highItemPercentualDiscount = 40;

        public override List<OrderItem> AssignDiscountsToItem(KeyValuePair<Product,int> basketItem)
        {
            List<OrderItem> orderItemSplit = new List<OrderItem>();

            // sleva neni pokud je pocet kusu polozky mensi nez tri, nenastane split polozky na dve casti
            if (basketItem.Value < littleItemQuantity)
            {
                orderItemSplit.AddRange(BasketToOrderItemNoChange(basketItem, 10));
            }
            // pro tri a vice kusu jsou aplikovany slevy na 3 a dalsi kus podle poctu ks:
            // nastane split polozky na 2 casti
            else if (basketItem.Value < middleItemQuantity)
            {
                // prvni dve polozky jsou beze slevy, dalsi jsou se slevou 20%
                orderItemSplit.AddRange(GetOrderItemSplitRange(basketItem, lowItemPercentualDiscount));
            }
            else if (basketItem.Value < highItemQuantity) 
            {
                // nad 8 ks do max 11 ks sleva na treti a dalsi 30%
                orderItemSplit.AddRange(GetOrderItemSplitRange(basketItem, middleItemPercentualDiscount));
            }
            else 
            {
                // pokud je polozek 12 a vice, sleva na treti a dalsi je az 40%
                orderItemSplit.AddRange(GetOrderItemSplitRange(basketItem, highItemPercentualDiscount));
            }
            return orderItemSplit;
        }

        /// <summary>
        /// Pomocna metoda ktera rozdeli polozku kosiku na polozku bez slevy a slevnenou polozku
        /// </summary>
        /// <param name="basketItem">polozka kosiku k rozdeleni</param>
        /// <param name="percentualDiscount">percentualni sleva aplikovana na slevnenou polozku</param>
        /// <returns></returns>
        private List<OrderItem> GetOrderItemSplitRange(KeyValuePair<Product, int> basketItem,
            int percentualDiscount )
        {
            OrderItem nondiscountedItem = new OrderItem(basketItem.Key, 2);
            OrderItem discountedItem = new OrderItem(basketItem.Key, basketItem.Value - 2);

            nondiscountedItem.SetFixedDiscount(noDiscount);
            nondiscountedItem.SetPercentualDiscount(noDiscount);
            nondiscountedItem.SetStrategy(10);

            discountedItem.SetFixedDiscount(noDiscount);
            discountedItem.SetPercentualDiscount(percentualDiscount);

            // nastaveni slevove strategie polozky podle zadane slevy
            switch(percentualDiscount)
            {
                case lowItemPercentualDiscount:
                    discountedItem.SetStrategy(1);
                    break;
                case middleItemPercentualDiscount:
                    discountedItem.SetStrategy(2);
                    break;
                case highItemPercentualDiscount:
                    discountedItem.SetStrategy(3);
                    break;
            }
            return new List<OrderItem> { nondiscountedItem, discountedItem };
        }

        // pro jaro neplati pevna sleva z objednavky
        public override int GetFixedOrderDiscount()
        {
            return noDiscount;
        }
        // pro jaro neplati percentualni sleva z objednavky
        public override int GetPercentualOrderDiscount()
        {
            return noDiscount;
        }
    }
}
