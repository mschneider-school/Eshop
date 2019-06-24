using Eshop.DatabaseEntites;
using System;
using System.Collections.Generic;

namespace Eshop
{
    /// <summary>
    /// Trida slouzi k sestaveni objednavky a nacteni objednavek z databaze. 
    /// Mezi parametry tridy patri instance zakaznika a kolekce polozek objednavky 
    /// </summary>
    public class Order
    {
        public const string TableName = "OrderDetail";
        public const string OrderIDColumn = "OrderID";
        public const string CustomerColumn = "CustomerID";
        public const string FixedDiscountColumn = "FixedDiscount";
        public const string PercentualDiscountColumn = "PercentualDiscount";
        public const string StateIDColumn = "StateID";
        public const string DateTimeColumn = "DateTime";

        public int ID { get; private set; }
        public Customer Customer { get; }
        public List<OrderItem> OrderItems { get; private set; }
        public int FixedDiscount { get; private set; }
        public int PercentualDiscount { get; private set; }
        public int State { get; private set; }
        public DateTime CreationDateTime { get; private set; }

        // statisticke cenove polozky objednavky kalkulovane
        public int TotalOrderBeforeDiscountPrice { get; private set; }
        public decimal TotalOrderDiscount { get; private set; }
        public int FinalOrderPrice { get; private set; }

        /// <summary>
        /// Konstruktor objednavky
        /// </summary>
        /// <param name="customer">zakaznik</param>
        /// <param name="orderItems">polozky objednavky</param>
        /// <param name="fixedDiscount">pevna sleva objednavky</param>
        /// <param name="percentualDiscount">percentualni sleva objednavky</param>
        /// <param name="state">stav</param>
        /// <param name="creationDateTime">datum a cas vytvoreni</param>
        /// <param name="id">identifikacni cislo objednavky</param>
        public Order(Customer customer, List<OrderItem> orderItems, int fixedDiscount, 
            int percentualDiscount, int state, DateTime creationDateTime, int id = -1)
        {
            ID = id;
            Customer = customer;
            OrderItems = orderItems;
            FixedDiscount = fixedDiscount;
            PercentualDiscount = percentualDiscount;
            State = state;
            CreationDateTime = creationDateTime;

            // spocti a uloz statisticke cenove polozky objednavky
            CalculateOrderPricing();
        }

        /*** Zmena parametru objednavky ***/
        /// <summary>
        /// Zmen identifikacni cislo objednavky
        /// </summary>
        /// <param name="id">nove identifikacni cislo</param>
        public void ChangeID(int id) => ID = id;

        /// <summary>
        /// Zmen stav objednavky
        /// </summary>
        /// <param name="state">novy stav objednavky</param>
        public void ChangeState(int state) => State = state;

        // 
        /// <summary>
        /// Sestaveni objednavky z pridelenych polozek
        /// </summary>
        /// <param name="orderItems">pridelene polozky objednavky</param>
        /// <returns>objednavka</returns>
        public static Order BuildOrder(List<OrderItem> orderItems)
        {
            Customer customer = Session.CustomerLoggedIn;
            Season currentSeason = Season.GetCurrentSeason();
            Order builtOrder = new Order
            (
                customer,
                orderItems,
                currentSeason.GetFixedOrderDiscount(),
                currentSeason.GetPercentualOrderDiscount(),
                OrderState.Built,
                // pro testovani napr. jarni slevy 
                // vloz "DateTime.Parse(Season.springDate) misto 'DateTime.Now' "
                // + jdi do tridy Season a proved zmeny podle instrukci 
                DateTime.Now
            );

            return builtOrder;
        }

        /*** CENOVA KALKULACE OBJEDNAVKY ***/

        /// <summary>
        /// Spocti ceny: celkova suma pred slevnenim, celkova sleva objednavky, konecna suma objednavky
        /// </summary>
        public void CalculateOrderPricing()
        {
            if (OrderItems.Count != 0)
            {
                TotalOrderBeforeDiscountPrice = GetOrderPricePriorDiscount();
                TotalOrderDiscount = GetTotalOrderDiscount();
                FinalOrderPrice = GetFinalOrderPrice();
            }
        }

        /// <summary>
        /// Spocti a vrat celkovou cenu polozek objednavky pred slevnenim
        /// </summary>
        /// <returns>celkova cela polozek objednavky pred slevnenim</returns>
        private int GetOrderPricePriorDiscount()
        {
            int totalPrice = 0;
            foreach (OrderItem item in OrderItems)
            {
                totalPrice += item.GetTotalOrderItemPrice(); 
            }
            return totalPrice;
        }

        /// <summary>
        /// Vraci souces slev vsech polozek a slev objednavky (pevnych i procentualnich)
        /// </summary>
        /// <returns>celkova sleva objednavky</returns>
        private decimal GetTotalOrderDiscount()
        {
            // nejdrive spocteme celkove slevy u vsech polozek
            decimal itemDiscounts = 0;
            foreach (OrderItem item in OrderItems)
            {
                itemDiscounts += item.GetTotalOrderItemDiscount();
            }

            // pak spocteme celkovou slevu objednavky
            decimal percentageOfOrderPrice = TotalOrderBeforeDiscountPrice / 100m;
            decimal percentualOrderDiscount = percentageOfOrderPrice * PercentualDiscount;
            decimal fixedOrderDiscount = FixedDiscount;

            // objednavkova sleva je souctem procentualni a pevne slevy objednavky
            decimal orderDiscount = percentualOrderDiscount + fixedOrderDiscount;

            // celkova cena objednavky je souctem slev polozek a slev objednavky
            decimal totalDiscount = itemDiscounts + orderDiscount;

            // vratime celkovou slevu objednavky
            return totalDiscount;
        }

        /// <summary>
        /// Vraci konecnou sumu objednavky po aplikaci vsech slev
        /// </summary>
        /// <returns>konecna suma objednavky</returns>
        private int GetFinalOrderPrice()
        {
            decimal finalOrderPrice = TotalOrderBeforeDiscountPrice - TotalOrderDiscount;
            return (int)finalOrderPrice;
        }
    }
}
