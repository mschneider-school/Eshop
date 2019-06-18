using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop
{
    abstract class Session
    {
        public static Customer CustomerLoggedIn { get; private set; }
        public static bool AdminLoggedIn { get; private set; }

        /// <summary>
        /// Prihlaseni konkretniho zakaznika, zaroven mu priradi jeho ID
        /// </summary>
        /// <param name="customer">zakaznik k prihlaseni</param>
        public static void LoginCustomer(Customer customer)
        {
            customer.LoadThisCustomerID();
            CustomerLoggedIn = customer;
        }

        /// <summary>
        ///  Prihlaseni administratora
        /// </summary>
        /// <param name="admininstrator">administrator k prihlaseni</param>
        public static void LoginAdmin()
        {
            AdminLoggedIn = true;
        }
    }
}
