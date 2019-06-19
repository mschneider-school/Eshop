using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop
{
    class Winter : Season
    {
        public override List<OrderItem> AssignDiscountsToItem(KeyValuePair<Product, int> basketItem)
        {
            throw new NotImplementedException();
        }

        public override int GetFixedOrderDiscount()
        {
            throw new NotImplementedException();
        }

        public override int GetPercentualOrderDiscount()
        {
            throw new NotImplementedException();
        }
    }
}
