using System;
using System.Collections.Generic;

namespace Eshop
{
    /// <summary>
    /// Abstraktni trida ktera je podkladem pro tridy rocnich sezon: Spring, Summer, Autumn, Winter
    /// Podkladem jsou metody:
    /// <see cref="AssignDiscountsToItem"/>, 
    /// <see cref="GetFixedOrderDiscount"/>, 
    /// <see cref="GetPercentualOrderDiscount"/>
    /// </summary>
    abstract class Season
    {
        // JEN PRO TESTOVACI UCELY - datumy 4 rocnich obdobi 
        public const string springDate = "2019-04-01 20:55:24.5344018";
        public const string autumnDate = "2019-10-01 20:55:24.5344018";
        public const string winterDate = "2020-02-01 20:55:24.5344018";

        public int NoDiscount { get; } = 0;

        public abstract List<OrderItem> AssignDiscountsToItem(KeyValuePair<Product,int> basketItem);
        public abstract int GetFixedOrderDiscount();
        public abstract int GetPercentualOrderDiscount();

        /// <summary>
        /// Vraci aktualni sezonu podle aktualniho casu
        /// </summary>
        /// <returns>aktualni objekt sezony</returns>
        public static Season GetCurrentSeason()
        {
            int thisYear = DateTime.Today.Year;
            DateTime springStart = new DateTime(thisYear, 2, 20);
            DateTime summerStart = new DateTime(thisYear, 5, 21);
            DateTime autumnStart = new DateTime(thisYear, 8, 23);
            DateTime winterStart = new DateTime(thisYear, 11, 21);

            // pro testovani jarni slevy zmen: DateTime date = "DateTime.Parse(Order.springDate); misto 'DateTime.Now'"
            DateTime date = DateTime.Now;

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

        /// <summary>
        /// Vraci kolekci s polozkou objednavky na kterou se neaplikuji zadne polozkove slevy
        /// </summary>
        /// <param name="basketItem">polozka kosiku</param>
        /// <param name="strategyID">identifikacni cislo strategie objednavky</param>
        /// <returns>kolekce s polozkou bez slev k dalsimu zpracovani</returns>
        public List<OrderItem> BasketToOrderItemNoChange(KeyValuePair<Product, int> basketItem, int strategyID)
        {
            List<OrderItem> orderItemSplit = new List<OrderItem>();

            OrderItem newOrderItem = new OrderItem(basketItem.Key, basketItem.Value);

            newOrderItem.SetFixedDiscount(0);
            newOrderItem.SetPercentualDiscount(0);
            newOrderItem.SetStrategy(strategyID);

            orderItemSplit.Add(newOrderItem);

            return orderItemSplit;
        }
    }
}
