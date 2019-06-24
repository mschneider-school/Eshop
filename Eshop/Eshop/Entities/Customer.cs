namespace Eshop
{
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
        public void LoadThisCustomerID()
        {
            ID = Database.GetCustomerID(this);
        }
    }
}
