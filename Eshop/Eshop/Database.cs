using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Eshop
{
    class Database
    {
        /*** Databazove specifikace ***/

        public static string DatabaseFileName { get; private set; } = "mobileshop.db";
        public static string ConnectionString { get; } = $"Data Source={DatabaseFileName};Version=3;";

        /***  Cache produktu a objednavek ***/

        public static List<Product> CachedProducts { get; private set; } = new List<Product>();
        public static List<Order> CachedOrders { get; private set; } = new List<Order>();
        public static List<Cathegory> CachedCathegories { get; private set; } = new List<Cathegory>();

        /*** Manipulace s cached daty ***/
        
        public static Product GetCachedProductByID(long id)
        {
            return CachedProducts.Find(product => product.ID == id);
        }

        /*** Prikazy k selekci dat ***/

        public static string LoadProductsCommand { get; } =
            $"SELECT p.{Product.IDColumn}, p.{Product.NameColumn}, " +
            $"c.Description AS {Product.CathegoryColumn}, " +
            $"p.{Product.PriceColumn}, p.{Product.PhotoColumn}," +
            $"p.{Product.DescriptionColumn} FROM {Product.TableName} AS p " +
            $"JOIN Cathegory AS c WHERE p.{Product.CathegoryColumn} = c.{Product.CathegoryColumn}";

        public static string LoadCathegoriesCommand { get; } =
            $"SELECT * FROM {Cathegory.TableName}";

        /*** Delegaty pro reference nacitavacich funkci ***/

        public static Action<SQLiteDataReader> loadProducts = LoadProducts;
        public static Action<SQLiteDataReader> loadCathegories = LoadCathegories;

        /*** Metody k nacteni  ***/

        /// <summary>
        /// Pomocna funkce nacte produkty z databaze do pameti
        /// </summary>
        /// <param name="reader">precteny sqlite zaznamy k spracovani</param>
        private static void LoadProducts(SQLiteDataReader reader)
        {
            while (reader.Read())
            {
                // obrazek a popis neni povinny, nacte se jen kdyz je ulozen
                Bitmap productImage = null;
                if (reader[Product.PhotoColumn] != DBNull.Value)
                {
                    productImage = (Bitmap)((new ImageConverter()).ConvertFrom(reader[Product.PhotoColumn]));
                }

                string productDescription = string.Empty;
                if (reader[Product.DescriptionColumn] != DBNull.Value)
                {
                    productDescription = reader[Product.DescriptionColumn].ToString();
                }

                // nacteni produktu do objektu
                Product loadedProduct = new Product
                (
                    Convert.ToInt64(reader[Product.IDColumn]),
                    Convert.ToString(reader[Product.NameColumn]),
                    Convert.ToString(reader[Product.CathegoryColumn]),
                    Convert.ToInt32(reader[Product.PriceColumn]),
                    productImage,
                    Convert.ToString(reader[Product.DescriptionColumn])
                );
                // pridani produktu do cached produktu
                CachedProducts.Add(loadedProduct);
            }
        }

        /// <summary>
        /// Pomocna funkce nacte kategorie z databaze do pameti
        /// </summary>
        /// <param name="reader">precteny sqlite zaznamy k spracovani</param>
        public static void LoadCathegories(SQLiteDataReader reader)
        {
            while (reader.Read())
            {
                //  nacteni kategorie do objektu
                Cathegory loadedCathegory = new Cathegory
                (
                    Convert.ToInt64(reader[Cathegory.IDColumn]),
                    Convert.ToString(reader[Cathegory.DescriptionColumn])
                );
                // pridani objektu kategorie do cached kategorii
                CachedCathegories.Add(loadedCathegory);
            }
        }

        /// <summary>
        /// Metoda nacte data z databaze a spusti funkci k jejich ulozeni do pameti
        /// </summary>
        /// <param name="loadRecords">reference na funkci ukladajici prectene zaznamy</param>
        /// <param name="commandText">prikaz pro shromazdeni dat</param>
        public static void ReadTableData(Action<SQLiteDataReader> loadRecords, string commandText)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(commandText, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        loadRecords(reader);
                    }
                }
                connection.Close();
            }
        }

        /*** Metody k zobrazeni dat v DataGridView ***/

        /// <summary>
        /// Zobrazi vsechny produkty z cache ve zvolenem dataGridView
        /// </summary>
        /// <param name="dataGridView">ovladaci prvek k zobrazeni nactenych produktu</param>
        public static void DisplayLoadedProducts(DataGridView dataGridView)
        {
            foreach(Product product in CachedProducts)
            {
                dataGridView.Rows.Add(
                    product.ID,
                    product.Name,
                    product.Cathegory,
                    product.Price
                );
            }
        }

        /// <summary>
        /// Vrati zakaznika se zadanymi prihlasovacimi udaji, pokud neexistuje vrati null
        /// </summary> 
        /// <param name="email">uzivatelsky email</param>
        /// <param name="password">uzivatelske heslo</param>
        /// <returns>vraci objekt typu zakaznika kdyz nalezne zakaznika s udaji, jinak vraci null</returns>
        public static Customer GetVerifiedCustomer(string email, string password)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string commandText = $"SELECT * FROM {Customer.TableName} " +
                    $"WHERE {Customer.EmailColumn} = '{email}' AND {Customer.PasswordColumn} = '{password}'";

                using (SQLiteCommand command = new SQLiteCommand(commandText, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        // pokud byla nalezena shoda vrat zakaznika
                        if (reader.Read())
                        {
                            Customer verifiedCustomer = new Customer(

                                reader[Customer.NameColumn].ToString(),
                                reader[Customer.LastNameColumn].ToString(),

                                Convert.ToInt32(reader[Customer.PhoneColumn]),

                                reader[Customer.CityColumn].ToString(),
                                reader[Customer.StreetColumn].ToString(),

                                Convert.ToInt32(reader[Customer.PostalCodeColumn]),

                                reader[Customer.EmailColumn].ToString(),
                                reader[Customer.PasswordColumn].ToString()
                            );

                            Logger.Log("Customer verified");
                            return verifiedCustomer;
                        }
                    }
                }

                connection.Close();
                return null;
            }
        }

        /*** Spracovani databazovych prikazu ***/

        /// <summary>
        /// Vymaze produkt z databaze
        /// </summary>
        /// <param name="product">objekt typu Product k vymazani</param>
        public static void DeleteProduct(Product product)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string commandText = $"DELETE FROM {Product.TableName} WHERE {Product.IDColumn} = {product.ID}";
                using (SQLiteCommand command = new SQLiteCommand(commandText, connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        // pomocmna metoda ke konverzi obrazku na byte[]
        private static byte[] ImageToBLOB(System.Drawing.Image image)
        {
            byte[] byteImage = null;
            if ( image != null)
            {
                ImageConverter converter = new ImageConverter();
                byteImage = (byte[])converter.ConvertTo(image, typeof(byte[]));
            }
            return byteImage;
        }

        /// <summary>
        /// Uklada novy produkt do databaze
        /// </summary>
        /// <param name="product"></param>
        public static long CreateProduct(Product product)
        {
            long lastInsertedID = -1;
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                Cathegory cathegory = CachedCathegories.Find(c => c.Description == product.Cathegory);
                byte[] productPhoto = ImageToBLOB(product.Photo);

                connection.Open();

                string commandText = $"INSERT INTO {Product.TableName} " +
                    $"({Product.NameColumn}, {Product.CathegoryColumn}, " +
                    $"{Product.PriceColumn}, {Product.PhotoColumn}, {Product.DescriptionColumn}) " +
                    $"VALUES ('{product.Name}', " +
                    $"'{cathegory.ID}'" +
                    $", '{product.Price}', '{productPhoto}', " +
                    $"'{product.Description}')";

                using (SQLiteCommand command = new SQLiteCommand(commandText, connection))
                {
                    command.ExecuteNonQuery();
                }

                lastInsertedID = connection.LastInsertRowId;
                connection.Close();
            }
            return lastInsertedID;
        }

        /// <summary>
        /// Upravuje zmenene parametry produktu
        /// </summary>
        /// <param name="product"></param>
        public static void UpdateProduct(Product product)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                Cathegory cathegory = CachedCathegories.Find(c => c.Description == product.Cathegory);
                byte[] productPhoto = ImageToBLOB(product.Photo);

                connection.Open();

                string commandText = $"UPDATE {Product.TableName} " +
                    $"SET {Product.NameColumn} = '{product.Name}', " +
                    $"{Product.CathegoryColumn} = '{cathegory.ID}', " +
                    $"{Product.PriceColumn} = '{product.Price}', " +
                    $"{Product.PhotoColumn} = '{productPhoto}', " +
                    $"{Product.DescriptionColumn} = '{product.Description}' " +
                    $"WHERE {Product.IDColumn} = {product.ID}"; 

                using (SQLiteCommand command = new SQLiteCommand(commandText, connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}
