using Eshop.DatabaseEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop
{
    class Autumn : Season
    { 
        // zjistuje se individualni sleva pro polozku, jestli je produkt v tabulce specialu
        public override List<OrderItem> AssignDiscountsToItem(KeyValuePair<Product, int> basketItem)
        {
            List<OrderItem> orderItemSplit = new List<OrderItem>();
            Product product = basketItem.Key;

            int fixedDiscount = GetSpecialDiscount(product);

            // sleva je nulova pokud neni produkt v tabulce specialu, jinak se nacte fixni sleva z tabulky
            OrderItem newOrderItem = new OrderItem(basketItem.Key, basketItem.Value);
            newOrderItem.SetFixedDiscount(fixedDiscount);
            newOrderItem.SetPercentualDiscount(NoDiscount);

            orderItemSplit.Add(newOrderItem);

            return orderItemSplit;
        }

        /// <summary>
        /// Pomocna metoda ke zjisteni specialni nabidky produktu
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        private int GetSpecialDiscount(Product product)
        {
            int discount = NoDiscount;
            int productID = (int)product.ID;
            SpecialOffer offer = Database.CachedSpecialOffers.Find(spo => spo.ProductID == productID);
            
            if (offer != null)
            {
                discount = offer.FixedDiscount;
            }
            return discount;
        }

        // pevna sleva neni na podzim na objednavku aplikovana
        public override int GetFixedOrderDiscount()
        {
            return NoDiscount;
        }

        // procentualni sleva neni na podzim na objednavku aplikovana
        public override int GetPercentualOrderDiscount()
        {
            return NoDiscount;
        }
    }
}
