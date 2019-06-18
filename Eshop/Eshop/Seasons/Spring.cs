using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop
{
    class Spring : Season
    {
        public override List<OrderItem> AssignDiscountsToItem(KeyValuePair<Product,int> basketItem)
        {
            List<OrderItem> orderItemSplit = new List<OrderItem>();

            // sleva neni pokud je pocet kusu polozky mensi nez tri, nenastane split polozky na dve casti
            if (basketItem.Value < 3)
            {
                OrderItem newOrderItem = new OrderItem(basketItem.Key, basketItem.Value);
                newOrderItem.SetFixedDiscount(0);
                newOrderItem.SetPercentualDiscount(0);
                orderItemSplit.Add(new OrderItem(basketItem.Key, basketItem.Value));
            }
            // pro tri a vice kusu jsou aplikovany slevy na 3 a dalsi kus podle poctu ks:
            // nastane split polozky na 2 casti
            else if (basketItem.Value < 8)
            {
                // prvni dve polozky jsou beze slevy, dalsi jsou se slevou 20%
                orderItemSplit.AddRange(GetOrderItemSplitRange(basketItem, 20));
            }
            else if (basketItem.Value < 12) 
            {
                // nad 8 ks do max 11 ks sleva na treti a dalsi 30%
                orderItemSplit.AddRange(GetOrderItemSplitRange(basketItem, 30));
            }
            else 
            {
                // pokud je polozek 12 a vice, sleva na treti a dalsi je az 40%
                orderItemSplit.AddRange(GetOrderItemSplitRange(basketItem, 40));
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

            nondiscountedItem.SetFixedDiscount(0);
            nondiscountedItem.SetPercentualDiscount(0);

            discountedItem.SetFixedDiscount(0);
            discountedItem.SetPercentualDiscount(percentualDiscount);

            return new List<OrderItem> { nondiscountedItem, discountedItem };
        }

        // pro jaro neplati pevna sleva z objednavky
        public override int GetFixedOrderDiscount()
        {
            return 0;
        }
        // pro jaro neplati percentualni sleva z objednavky
        public override int GetPercentualOrderDiscount()
        {
            return 0;
        }
    }
}
