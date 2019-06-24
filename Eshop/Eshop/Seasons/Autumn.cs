using Eshop.DatabaseEntites;
using System.Collections.Generic;

namespace Eshop
{
    /// <summary>
    /// Trida dedi od abstraktni tridy metody k aplikaci slev na objednavku a jeji polozky
    /// Individualni sleva polozky se aplikuje pokud se produkt nachazi v tabulce specialnich produktu v db
    /// Pozn.: slevy objednavky nejsou na podzim aplikovany
    /// </summary>
    class Autumn : Season
    {
        /// <summary>
        /// Aplikace pevne slevy na polozku, pokud se polozka nachazi v tabulce specialnich produktu
        /// </summary>
        /// <param name="basketItem">polozka kosiku transformovana na polozku objednavky</param>
        /// <returns>kolekce s polozkou s pridelenou slevou</returns>
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
            return NoDiscount;
        }

        /// <summary>
        /// Prideleni strategie polozce na zaklade pridelene pevne slevy
        /// Pozn.: pri pridelene nulove sleve je pridelena strategie 10, jinak 6
        /// </summary>
        /// <param name="orderItem"></param>
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
