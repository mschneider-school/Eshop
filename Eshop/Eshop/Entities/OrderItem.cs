using System.Collections.Generic;

namespace Eshop
{
    /// <summary>
    /// Trida objednavkove polozky slouzi k nacteni kolekce polozek k objednavce a
    /// spocteni pevnych a procentualnich slev polozek.
    /// </summary>
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

        /// <summary>
        /// Jednoduchy konstruktor objednávkové položky
        /// </summary>
        /// <param name="item">produkt položky</param>
        /// <param name="quantity">mnozstvi produktu</param>
        public OrderItem(Product item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }

        /// <summary>
        /// Plny konstruktor objednavkove polozky
        /// </summary>
        /// <param name="id">identifikacni cislo</param>
        /// <param name="item">produkt polozky</param>
        /// <param name="quantity">mnozstvi produktu</param>
        /// <param name="fixedDiscount">pevna sleva položky</param>
        /// <param name="percentualDiscount">procentualni sleva polozky</param>
        /// <param name="strategyID">identifikacni cislo slevove strategie</param>
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

        /*** zmena cenovych parametru polozky objednavky ***/

        /// <summary>
        /// Nastaveni nove pevne slevy polozky
        /// </summary>
        /// <param name="fixedDiscount">nova pevna sleva polozky</param>
        public void SetFixedDiscount(int fixedDiscount) => FixedDiscount = fixedDiscount;

        /// <summary>
        /// Nastaveni nove procentualni slevy polozky
        /// </summary>
        /// <param name="percentDiscount">nova procentualni sleva polozky</param>
        public void SetPercentualDiscount(int percentDiscount) => PercentualDiscount = percentDiscount;

        /// <summary>
        /// Nastaveni identifikatoru slevove strategie polozky
        /// </summary>
        /// <param name="strategyID">identifikacni cislo slevove strategie polozky</param>
        public void SetStrategy(int strategyID) => StrategyID = strategyID;

        /// <summary>
        /// Vypocet celkove cenu polozky (mnozstvi * cena produktu)
        /// </summary>
        /// <returns></returns>
        public int GetTotalOrderItemPrice() => Quantity * Item.Price;

        // vypocte totalni slevu polozky v korunach

        /// <summary>
        /// Vypocet celkove slevy polozky polozky,
        /// prevod procentualni slevy na pevnou a secteni s pevnou slevou polozky
        /// </summary>
        /// <returns>celkova sleva polozky v korunach</returns>
        public decimal GetTotalOrderItemDiscount()
        {
            int totalItemPrice = GetTotalOrderItemPrice();
            decimal percentageOfPrice = totalItemPrice / 100m;
            decimal percentualToFixDiscount = percentageOfPrice * PercentualDiscount;
            decimal totalItemDiscount = FixedDiscount + percentualToFixDiscount;

            return totalItemDiscount;
        }
    }
}
