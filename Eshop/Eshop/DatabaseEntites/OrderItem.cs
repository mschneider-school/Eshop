using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop
{
    class OrderItem
    {
        public Product Item { get; private set; }
        public int Quantity { get; private set; }
        public int FixedDiscount { get; private set; }
        public int PercentualDiscount { get; private set; }
        public string Strategy { get; private set; }

        public OrderItem(Product item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }

        /// <summary>
        /// Vytvori nove polozky objednavky z polozek kosiku na zaklade aktualni sezonni strategie 
        /// </summary>
        /// <param name="basketItems"></param>
        /// <returns></returns>
        public static List<OrderItem> GetOrderItemsFromBasket(Dictionary<Product, int> basketItems)
        {
            List<OrderItem> orderItems = new List<OrderItem>();
            Season currentSeason = Season.GetCurrentSeason();

            foreach(var basketItem in basketItems)
            {
            }
        }

        // metody ke zmene cenovych parametru polozky objednavky
        public void SetFixedDiscount(int fixedDiscount) => FixedDiscount = fixedDiscount;
        public void SetPercentualDiscount(int percentDiscount) => PercentualDiscount = percentDiscount;
        public void SetStrategy(string strategy) => Strategy = strategy;
    }
}
