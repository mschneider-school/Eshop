namespace Eshop
{
    /// <summary>
    /// Trida reprezentuje zakaznika s jeho parametry ulozeneho v databaze. 
    /// Slouzi k abstrakci prihlasovani, vytvareni noveho zakaznika a vyuziti 
    /// udaju zakaznika k sestaveni detailu objednavky
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// nazvy sloupcu v tabulce Customer
        /// </summary>
        public const string TableName = "Customer";
        public const string IDColumn = "CustomerID";
        public const string NameColumn = "Name";
        public const string LastNameColumn = "LastName";
        public const string PhoneColumn = "Phone";
        public const string CityColumn = "City";
        public const string StreetColumn = "Street";
        public const string HouseNumberColumn = "HouseNumber";
        public const string PostalCodeColumn = "PostalCode";
        public const string EmailColumn = "Email";
        public const string PasswordColumn = "Password";

        public int ID { get; private set; }
        public string Name { get; }
        public string LastName { get; }
        public int MobilePhone { get; }
        public string City { get; }
        public string Street { get; }
        public string HouseNumber { get; }
        public string PostalCode { get; }
        public string Email { get; }
        public string Password { get; }

        /// <summary>
        /// Konsruktor zakaznika
        /// </summary>
        /// <param name="name">jmeno</param>
        /// <param name="lastName">prijmeni</param>
        /// <param name="mobilePhone">telefon</param>
        /// <param name="city">mesto</param>
        /// <param name="street">ulica</param>
        /// <param name="houseNumber">cislo domu</param>
        /// <param name="postalCode">postove smerove cislo</param>
        /// <param name="email">email</param>
        /// <param name="password">heslo</param>
        /// <param name="id">identifikacni cislo</param>
        public Customer(string name, string lastName, int mobilePhone,
            string city, string street, string houseNumber,
            string postalCode, string email, string password, int id = -1)
        {
            Name = name;
            LastName = lastName;
            MobilePhone = mobilePhone;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            PostalCode = postalCode;
            Email = email;
            Password = password;
            ID = id;
        }

        /// <summary>
        /// Priradi zakaznikovi jeho ID hodnotu z databaze
        /// </summary>
        public void LoadThisCustomerID() => ID = Database.GetCustomerID(this);
    }
}
