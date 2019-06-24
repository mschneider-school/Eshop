namespace Eshop
{
    /// <summary>
    /// Trida obsahuje kategorii a jeji id pridelovane produktu. 
    /// Program vyuziva instanci objektu k nacteni informaci z databáze,
    /// úpravy produktu za běhu a zápis změn do databáze.
    /// </summary>
    class Cathegory
    {
        public const string TableName = "Cathegory";
        public const string IDColumn = "CathegoryID";
        public const string DescriptionColumn = "Description";
        
        public int ID { get; private set; }
        public string Description { get; private set; }

        /// <summary>
        /// Konstruktor Cathegory
        /// </summary>
        /// <param name="id">identifikacni cislo kategorie</param>
        /// <param name="description">popis kategorie</param>
        public Cathegory(int id, string description)
        {
            ID = id;
            Description = description;
        }
    }
}
