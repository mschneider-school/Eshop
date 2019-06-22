using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop
{
    class Basket
    {
        public static Dictionary<Product, int> Items { get; private set; } 
            = new Dictionary<Product, int>();

        /// <summary>
        /// Prida produkt a jeho mnozstvi do kosiku
        /// </summary>
        /// <param name="product">produkt k pridani</param>
        /// <param name="quantity">mnozstvi produktu</param>
        public static void AddItem(Product product, int quantity)
        {
            // pokud se jiz produkt nachazi v kosiku, tak pouze pripocteme mnozstvi
            if (Items.ContainsKey(product))
            {
                Items[product] += quantity;
            }
            else // jinak pridame produkt jako novy produkt
            {
                Items.Add(product, quantity);
            }
        }

        /// <summary>
        /// vymaze vsechny polozky z kosiku
        /// </summary>
        public static void Empty()
        {
            Items.Clear();
        }

        /// <summary>
        /// vymaze polozku z kosiku
        /// </summary>
        /// <param name="product">polozka k vymazu</param>
        public static void RemoveItem(Product product)
        {
            Items.Remove(product);
        }
    }
}
