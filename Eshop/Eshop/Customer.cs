using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop
{
    class Customer
    {
        public string Name { get; }
        public string LastName { get; }
        public int MobilePhone { get; }
        public string City { get; }
        public string Street { get; }
        public string HouseNumber { get; }
        public int PostalCode { get; }
        public string Email { get; }
        private string Password { get; }

        public Customer(string name, string lastName, int mobilePhone,
            string city, string street, int postalCode, string email,
            string password)
        {
            Name = name;
            LastName = lastName;
            MobilePhone = mobilePhone;
            City = city;
            Street = street;
            PostalCode = postalCode;
            Email = email;
            Password = password;
        }
    }
}
