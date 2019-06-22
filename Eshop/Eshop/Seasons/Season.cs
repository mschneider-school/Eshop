using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop
{
    abstract class Season
    {
        public int NoDiscount { get; } = 0;

        public abstract List<OrderItem> AssignDiscountsToItem(KeyValuePair<Product,int> basketItem);
        public abstract int GetFixedOrderDiscount();
        public abstract int GetPercentualOrderDiscount();

        /// <summary>
        /// Metoda vraci aktualni sezonu podle aktualniho casu
        /// </summary>
        /// <returns>aktualni objekt sezony</returns>
        public static Season GetCurrentSeason()
        {
            int thisYear = DateTime.Today.Year;
            DateTime springStart = new DateTime(thisYear, 2, 20);
            DateTime summerStart = new DateTime(thisYear, 5, 21);
            DateTime autumnStart = new DateTime(thisYear, 8, 23);
            DateTime winterStart = new DateTime(thisYear, 11, 21);

            DateTime date = DateTime.Now;

            // od jari do zacatku leta
            if (date >= springStart && date < summerStart)
            {
                return new Spring();
            }
            else if (date >= summerStart && date < autumnStart)
            {
                return new Summer();
            }
            else if (date >= autumnStart && date < winterStart)
            {
                return new Autumn();
            }
            else
            {
                return new Winter();
            }
        }

        // v pripade polozky bez aplikaci slev
        public List<OrderItem> BasketToOrderItemNoChange(KeyValuePair<Product, int> basketItem)
        {
            List<OrderItem> orderItemSplit = new List<OrderItem>();

            OrderItem newOrderItem = new OrderItem(basketItem.Key, basketItem.Value);
            newOrderItem.SetFixedDiscount(0);
            newOrderItem.SetPercentualDiscount(0);
            newOrderItem.SetStrategy(10);

            orderItemSplit.Add(newOrderItem);

            return orderItemSplit;
        }
    }
}
