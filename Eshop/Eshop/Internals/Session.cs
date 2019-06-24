namespace Eshop
{
    /// <summary>
    /// Abstraktni trida slouzi k uchovani udaju o prihlaseni zakaznika/administratora
    /// a provedeni operaci prihlaseni uzivatelu
    /// </summary>
    abstract class Session
    {
        public static Customer CustomerLoggedIn { get; private set; }
        public static bool AdminLoggedIn { get; private set; }

        /// <summary>
        /// Prihlaseni konkretniho zakaznika
        /// Pozn.: zaroven je prirazeno jeho ID z db
        /// </summary>
        /// <param name="customer">prihlasovany zakaznik</param>
        public static void LoginCustomer(Customer customer)
        {
            customer.LoadThisCustomerID();
            CustomerLoggedIn = customer;
        }

        /// <summary>
        /// Prihlaseni administratora
        /// </summary>
        public static void LoginAdmin() => AdminLoggedIn = true;
    }
}
