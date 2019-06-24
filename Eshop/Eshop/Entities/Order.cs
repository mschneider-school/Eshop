using Eshop.DatabaseEntites;
using System;
using System.Collections.Generic;

namespace Eshop
{
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

        // metody pro zmenu detailu objednavky
        public void ChangeID(int id) => ID = id;
        public void ChangeState(int state) => State = state;

        // sestav a vrat objednavku podle zadanych parametru
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
                DateTime.Parse(Season.winterDate)
            );

            return builtOrder;
        }

        /*** SPOCTI CENOVOU KALKULACI OBJEDNAVKY ***/
        public void CalculateOrderPricing()
        {
            if (OrderItems.Count != 0)
            {
                TotalOrderBeforeDiscountPrice = GetOrderPricePriorDiscount();
                TotalOrderDiscount = GetTotalOrderDiscount();
                FinalOrderPrice = GetFinalOrderPrice();
            }
        }

        // spocti a vrat celkovou cenu polozek objednavky pred slevnenim
        private int GetOrderPricePriorDiscount()
        {
            int totalPrice = 0;
            foreach (OrderItem item in OrderItems)
            {
                totalPrice += item.GetTotalOrderItemPrice(); 
            }
            return totalPrice;
        }

        // spocte a vrati celkovou slevu polozek objednavky (fixni a perc. slevu polozek a objednavky)
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

            decimal orderDiscount = percentualOrderDiscount + fixedOrderDiscount;

            decimal totalDiscount = itemDiscounts + orderDiscount;

            // vratime celkovou slevu objednavky jako ceele cislo
            return totalDiscount;
        }

        // vrati konecnou cenu objednavky po aplikovani vsech slev (fixnich i percentualnich)
        private int GetFinalOrderPrice()
        {
            decimal finalOrderPrice = TotalOrderBeforeDiscountPrice - TotalOrderDiscount;
            return (int)finalOrderPrice;
        }
    }
}
