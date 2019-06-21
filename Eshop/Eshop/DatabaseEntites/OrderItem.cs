using Eshop.DatabaseEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop
{
    public class OrderItem
    {
        public const string TableName = "OrderItem";
        public const string OrderItemIDColumn = "OrderItemID";
        public const string ProductIDColumn = "ProductID";
        public const string QuantityColumn = "Quantity";
        public const string FixedDiscountColumn = "FixedDiscount";
        public const string PercentualDiscountColumn = "PercentualDiscount";
        public const string StrategyIDColumn = "StrategyID";
        public const string OrderIDColumn = "OrderID";

        public int ID { get; private set; }
        public Product Item { get; private set; }
        public int Quantity { get; private set; }
        public int FixedDiscount { get; private set; }
        public int PercentualDiscount { get; private set; }
        public int StrategyID { get; private set; }

        public OrderItem(Product item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }

        public OrderItem(int id, Product item, int quantity, 
            int fixedDiscount, int percentualDiscount, int strategyID)
        {
            ID = id;
            Item = item;
            Quantity = quantity;
            FixedDiscount = fixedDiscount;
            PercentualDiscount = percentualDiscount;
            StrategyID = strategyID;
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

            // pro kazdou polozku kosiku vytvor rozsah polozek objednavky 
            // a prirad jim slevy podle sezony
            foreach(var basketItem in basketItems)
            {
                List<OrderItem> itemSplit = currentSeason.AssignDiscountsToItem(basketItem);
                orderItems.AddRange(itemSplit);
            }

            return orderItems;
        }

        // metody ke zmene cenovych parametru polozky objednavky
        public void SetFixedDiscount(int fixedDiscount) => FixedDiscount = fixedDiscount;
        public void SetPercentualDiscount(int percentDiscount) => PercentualDiscount = percentDiscount;

        public void SetStrategy(int strategyID)
        {
            StrategyID = strategyID;
        }

        // spocte celkovou cenu polozky (mnozstvi * cena produktu)
        public int GetTotalOrderItemPrice()
        {
            return Quantity * Item.Price;
        }

        // vypocte totalni slevu polozky v korunach
        public double GetTotalOrderItemDiscount()
        {
            int totalItemPrice = Item.Price * Quantity;
            double percentualToFixDiscount = (totalItemPrice / 100) * PercentualDiscount;
            double totalItemDiscount = FixedDiscount + percentualToFixDiscount;

            return totalItemDiscount;
        }
    }
}
