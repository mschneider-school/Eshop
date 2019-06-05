using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop
{
    class OrderItem
    {
        public Product Item { get; set; }
        public int Quantity { get; set; }
        public decimal FixedDiscount { get; set; }
        public double PercentualDiscount { get; set; }

        public OrderItem(Product item, int quantity, decimal fixedDiscount, double percentualDiscount)
        {
            Item = item;
            Quantity = quantity;
            FixedDiscount = fixedDiscount;
            PercentualDiscount = percentualDiscount;
        }
    }
}
