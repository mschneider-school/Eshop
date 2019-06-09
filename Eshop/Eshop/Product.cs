using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop
{
    /// <summary>
    /// Trida obsahuje vlastnosti produktu jako jsou nazvy sloupcu v tabulce, vlastnosti produktu
    /// metody pro praci s objektem. Program vyuziva instanci objektu k nacteni informaci z databáze,
    /// úpravy produktu za běhu a zápis změn do databáze.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// nazvy sloupcu v tabulce Product
        /// </summary>
        public const string TableName = "Product";
        public const string IDColumn = "ProductID";
        public const string NameColumn = "Name";
        public const string CathegoryColumn = "CathegoryID";
        public const string PriceColumn= "Price";
        public const string PhotoColumn = "Photo";
        public const string DescriptionColumn = "Description";

        /// <summary>
        /// vlastnosti produktu
        /// </summary>
        public long ID { get; private set; }
        public string Name { get; private set; }
        public string Cathegory { get; private set; }
        public int Price { get; private set; }
        public Image Photo { get; private set; }
        public string Description { get; private set; }

        /// <summary>
        /// konstruktor objektu Product
        /// </summary>
        /// <param name="ID">identifikacni cislo produktu</param>
        /// <param name="name">nazev produktu</param>
        /// <param name="cathegory">kategorie produktu</param>
        /// <param name="price">cena produktu</param>
        /// <param name="description">popis produktu</param>
        public Product(long id, string name, string cathegory, int price, Image photo, string description)
        {
            ID = id;
            Name = name;
            Cathegory = cathegory;
            Price = price;
            Photo = photo;
            Description = description;
        }

        public void ChangeID(long id) => ID = id;
        public void ChangeName(string name) => Name = name;
        public void ChangeCathegory(string cathegory) => Cathegory = cathegory;
        public void ChangePrice(int price) => Price = price;
        public void ChangeDescription(string description) => Description = description;
    }
}
