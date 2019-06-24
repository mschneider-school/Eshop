using Eshop.DatabaseEntites;
using System.Collections.Generic;

namespace Eshop
{
    class Autumn : Season
    {
        // zjistuje se individualni sleva pro polozku, jestli je produkt v tabulce specialu
        public override List<OrderItem> AssignDiscountsToItem(KeyValuePair<Product, int> basketItem)
        {
            List<OrderItem> orderItemSplit = new List<OrderItem>();
            OrderItem newOrderItem = new OrderItem(basketItem.Key, basketItem.Value);

            int fixedDiscount = GetSpecialDiscount(newOrderItem.Item) * newOrderItem.Quantity;

            // sleva je nulova pokud neni produkt v tabulce specialu, jinak se nacte fixni sleva z tabulky
            newOrderItem.SetFixedDiscount(fixedDiscount);
            newOrderItem.SetPercentualDiscount(NoDiscount);

            // pokud se uplatnuje specialni fixni sleva, strategie je cislo 6
            AssignItemStrategy(newOrderItem);
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

        // vyber strategii na zaklade pevne dane slevy polozky
        // pokud neni 0, jde o specialni nabidku, strategie je c. 6
        private void AssignItemStrategy(OrderItem orderItem)
        {
            if (orderItem.FixedDiscount != 0)
            {
                orderItem.SetStrategy(6);
            }
            else
            {
                orderItem.SetStrategy(10);
            }
        }
    }
}
