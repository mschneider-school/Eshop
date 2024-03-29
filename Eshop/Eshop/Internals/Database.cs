﻿using Eshop.DatabaseEntites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;

namespace Eshop
{
    /// <summary>
    /// Trida slouzi ke komunikaci s databazi, uchovani cached udaju v pameti a manipulaci s cached udaji
    /// </summary>
    class Database
    {
        /*** Databazove specifikace ***/

        public static string DatabaseFileName { get; private set; } = "../../../AppData/mobileshop.db";
        public static string ConnectionString { get; } = $"Data Source={DatabaseFileName};Version=3;";

        /***  Cache databazovych entit ***/

        public static List<Product> CachedProducts { get; private set; } = new List<Product>();
        public static List<Order> CachedOrders { get; private set; } = new List<Order>();
        public static List<Cathegory> CachedCathegories { get; private set; } = new List<Cathegory>();
        public static List<SpecialOffer> CachedSpecialOffers { get; private set; } = new List<SpecialOffer>();
        public static List<Strategy> CachedStrategies { get; private set; } = new List<Strategy>();
        public static List<OrderState> CachedOrderStates { get; private set; } = new List<OrderState>();

        /*** Manipulace s cached daty ***/

        /// <summary>
        /// Vraceni instance produktu z produktu v pameti podle zadaneho ID
        /// </summary>
        /// <param name="id">hledane ID produktu</param>
        /// <returns>instance nalezeneho produktu</returns>
        public static Product GetCachedProductByID(int id)
        {
            return CachedProducts.Find(product => product.ID == id);
        }

        /// <summary>
        /// Vraceni instance objednavky z objednavek v pameti podle zadaneho ID
        /// </summary>
        /// <param name="id">hledane ID objednavky</param>
        /// <returns>instance nalezene objednavky</returns>
        public static Order GetCachedOrderByID(int id)
        {
            return CachedOrders.Find(order => order.ID == id);
        }

        /// <summary>
        /// Vraceni instance strategie ze strategii v pameti podle zadaneho ID
        /// </summary>
        /// <param name="id">hledane ID strategie</param>
        /// <returns>instance nalezene strategie</returns>
        public static Strategy GetCachedStrategyByID(int id)
        {
            return CachedStrategies.Find(strategy => strategy.StrategyID == id);
        }

        /// <summary>
        /// Vraceni popisu stavu objenavky ze stavu objednavky v pameti podle zadaneho ID
        /// </summary>
        /// <param name="id">hledane ID stavu objednavky</param>
        /// <returns>instance nalezeneho stavu objednavky</returns>
        public static string GetStateNameByID(int id)
        {
            return CachedOrderStates.Find(state => state.ID == id).Description;
        }

        /// <summary>
        /// Vraceni souctu objednavek prihlaseneho zakaznika
        /// Pozn.: pro kalkulaci letni slevy
        /// </summary>
        /// <returns>soucet objednavek zakaznika</returns>
        public static int GetLoggedCustomerOrdersCount()
        {
            int ordersCount = CachedOrders.Where
                (order => order.Customer.ID == Session.CustomerLoggedIn.ID).Count();
            return ordersCount;
        }

        /// <summary>
        /// Vraceni instanci vsech objednavek zakaznika
        /// </summary>
        /// <param name="customer">zakaznik jehoz objednavky jsou hledany</param>
        /// <returns>instance objednavek zakaznika</returns>
        public static List<Order> GetCustomerOrders(Customer customer)
        {
            return CachedOrders.FindAll(order => order.Customer.ID == customer.ID);
        }

        /// <summary>
        /// Zmen stav objednavky ulozene v pameti
        /// Pozn.: metoda volana pri zmene stavu objednavky administratorem
        /// </summary>
        /// <param name="order">objednavka ktere stav se meni</param>
        /// <param name="state">novy stav objednavky</param>
        private static void ChangeCachedOrderState(Order order, int state)
        {
            GetCachedOrderByID(order.ID).ChangeState(state);
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

        public static string LoadOrdersCommand { get; } =
            $"SELECT * FROM {Order.TableName}";

        public static string LoadSpecialOffersCommand { get; } =
            $"SELECT * FROM {SpecialOffer.TableName}";

        public static string LoadStrategiesCommand { get; } =
            $"SELECT * FROM {Strategy.TableName}";

        public static string LoadOrderStatesCommand { get; } =
            $"SELECT * FROM {OrderState.TableName}";

        /*** Delegaty pro reference nacitavacich funkci ***/

        public static Action<SQLiteDataReader> loadProducts = LoadProducts;
        public static Action<SQLiteDataReader> loadCathegories = LoadCathegories;
        public static Action<SQLiteDataReader> loadOrders = LoadOrders;
        public static Action<SQLiteDataReader> loadSpecialOffers = LoadSpecialOffers;
        public static Action<SQLiteDataReader> loadStrategies = LoadStrategies;
        public static Action<SQLiteDataReader> loadOrderStates = LoadOrderStates;

        /*** Metody k nacteni dat ***/

        /// <summary>
        /// Nacteni produktu z databaze do pameti
        /// </summary>
        /// <param name="reader">precteny sqlite zaznamy k spracovani</param>
        private static void LoadProducts(SQLiteDataReader reader)
        {
            while (reader.Read())
            {
                // obrazek a popis neni povinny, nacte se jen kdyz je ulozen
                System.Drawing.Image productImage = null;
                if (reader[Product.PhotoColumn] != DBNull.Value)
                {
                    productImage = (Bitmap)new ImageConverter().ConvertFrom(reader[Product.PhotoColumn]);
                }

                string productDescription = string.Empty;
                if (reader[Product.DescriptionColumn] != DBNull.Value)
                {
                    productDescription = reader[Product.DescriptionColumn].ToString();
                }

                // nacteni produktu do objektu
                Product loadedProduct = new Product
                (
                    Convert.ToString(reader[Product.NameColumn]),
                    Convert.ToString(reader[Product.CathegoryColumn]),
                    Convert.ToInt32(reader[Product.PriceColumn]),
                    productImage,
                    Convert.ToString(reader[Product.DescriptionColumn]),
                    Convert.ToInt32(reader[Product.IDColumn])
                );
                // pridani produktu do cached produktu
                CachedProducts.Add(loadedProduct);
            }
        }

        /// <summary>
        /// Nacteni kategorii z databaze do pameti
        /// </summary>
        /// <param name="reader">precteny sqlite zaznamy k zpracovani</param>
        public static void LoadCathegories(SQLiteDataReader reader)
        {
            while (reader.Read())
            {
                //  nacteni kategorie do objektu
                Cathegory loadedCathegory = new Cathegory
                (
                    Convert.ToInt32(reader[Cathegory.IDColumn]),
                    Convert.ToString(reader[Cathegory.DescriptionColumn])
                );
                // pridani objektu kategorie do cached kategorii
                CachedCathegories.Add(loadedCathegory);
            }
        }

        /// <summary>
        /// Nacteni objednavek z databaze do pameti
        /// </summary>
        /// <param name="reader">precteny sqlite zaznamy k zpracovani</param>
        public static void LoadOrders(SQLiteDataReader reader)
        {
            while (reader.Read())
            {
                // nacteni objednavky z db
                Order loadedOrder = new Order
                (
                    GetCustomerByID(Convert.ToInt32(reader[Order.CustomerColumn])),
                    new List<OrderItem>(),
                    Convert.ToInt32(reader[Order.FixedDiscountColumn]),
                    Convert.ToInt32(reader[Order.PercentualDiscountColumn]),
                    Convert.ToInt32(reader[Order.StateIDColumn]),
                    Convert.ToDateTime(reader[Order.DateTimeColumn]),
                    Convert.ToInt32(reader[Order.OrderIDColumn])
                );
                // vyhleda priradi k objednavce jeji polozky
                AttachOrderItemsToOrder(loadedOrder);

                // pridani objektu objednavky do cached objednavek
                CachedOrders.Add(loadedOrder);
            }
        }

        /// <summary>
        /// Nacteni specialnich polozek z databaze do pameti
        /// </summary>
        /// <param name="reader">precteny sqlite zaznamy k zpracovani</param>
        public static void LoadSpecialOffers(SQLiteDataReader reader)
        {
            while (reader.Read())
            {
                SpecialOffer loadedSpecialOffer = new SpecialOffer
                (
                    Convert.ToInt32(reader[SpecialOffer.ProductIDColumn]),
                    Convert.ToInt32(reader[SpecialOffer.FixedDiscountColumn])
                );
                CachedSpecialOffers.Add(loadedSpecialOffer);
            }
        }

        /// <summary>
        /// Nacteni strategii z databaze do pameti
        /// </summary>
        /// <param name="reader">precteny sqlite zaznamy k zpracovani</param>
        public static void LoadStrategies(SQLiteDataReader reader)
        {
            while (reader.Read())
            {
                Strategy loadedStrategy = new Strategy
                (
                    Convert.ToInt32(reader[Strategy.StrategyIDCOlumn]),
                    reader[Strategy.DescriptionColumn].ToString()
                );
                CachedStrategies.Add(loadedStrategy);
            }
        }

        /// <summary>
        /// Nacteni stavu objednavek z databaze do pameti
        /// </summary>
        /// <param name="reader">precteny sqlite zaznamy k zpracovani</param>
        public static void LoadOrderStates(SQLiteDataReader reader)
        {
            while (reader.Read())
            {
                OrderState loadedState = new OrderState
                (
                    Convert.ToInt32(reader[OrderState.StateIDColumn]),
                    reader[OrderState.DescriptionColumn].ToString()
                );
                CachedOrderStates.Add(loadedState);
            }
        }

        /// <summary>
        /// Nacteni data z databaze a jejich ulozeni do pameti
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

        /*** METODY MANIPULACE S DOTAZY ***/

        /// <summary>
        /// Vraceni zakaznika se zadanymi prihlasovacimi udaji
        /// Pozn.: pokud zakaznik neexistuje vrati null
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
                                reader[Customer.HouseNumberColumn].ToString(),
                                reader[Customer.PostalCodeColumn].ToString(),
                                reader[Customer.EmailColumn].ToString(),
                                reader[Customer.PasswordColumn].ToString()
                            );
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
        /// Vymazani produktu z databaze
        /// </summary>
        /// <param name="product">produkt k vymazani</param>
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

        /// <summary>
        /// Konverze obrazku na pole bytu
        /// </summary>
        /// <param name="image">obrazek ke konverzi</param>
        /// <returns>pole bytu reprezentujici obrazek</returns>
        private static byte[] ImageToBLOB(System.Drawing.Image image)
        {
            byte[] byteImage = null;
            if (image != null)
            {
                ImageConverter converter = new ImageConverter();
                byteImage = (byte[])converter.ConvertTo(image, typeof(byte[]));
            }
            return byteImage;
        }

        /// <summary>
        /// Ulozeni noveho produktu do databaze
        /// </summary>
        /// <param name="product">produkt k ulozeni</param>
        public static void CreateProduct(Product product)
        {
            int lastInsertedID = -1;
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                Cathegory cathegory = CachedCathegories.Find(c => c.Description == product.Cathegory);
                byte[] productPhoto = ImageToBLOB(product.Photo);

                connection.Open();

                string commandText = $"INSERT INTO {Product.TableName} " +
                    $"({Product.NameColumn}, {Product.CathegoryColumn}, " +
                    $"{Product.PriceColumn}, {Product.PhotoColumn}, {Product.DescriptionColumn}) " +
                    $"VALUES (@{Product.NameColumn}, " +
                    $"@{Product.CathegoryColumn}, " +
                    $"@{Product.PriceColumn}, " +
                    $"@{Product.PhotoColumn}, " +
                    $"@{Product.DescriptionColumn})";

                using (SQLiteCommand command = new SQLiteCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue($"@{Product.NameColumn}", product.Name);
                    command.Parameters.AddWithValue($"@{Product.CathegoryColumn}", cathegory.ID);
                    command.Parameters.AddWithValue($"@{Product.PriceColumn}", product.Price);
                    command.Parameters.AddWithValue($"@{Product.PhotoColumn}", productPhoto);
                    command.Parameters.AddWithValue($"@{Product.DescriptionColumn}", product.Description);
                    command.Parameters.AddWithValue(Product.PhotoColumn, productPhoto);
                    command.ExecuteNonQuery();
                }

                lastInsertedID = Convert.ToInt32(connection.LastInsertRowId);
                connection.Close();
            }
            // passed produktu priradi ID
            product.ChangeID(lastInsertedID);

            // vytvoreny produkt se priradi ku CachedProducts
            CachedProducts.Add(product);
        }

        /// <summary>
        /// Uprava parametru produktu
        /// Pozn.: metoda volana pri uprave produktu administratorem
        /// </summary>
        /// <param name="product">produkt k uprave</param>
        public static void UpdateProduct(Product product)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                Cathegory cathegory = CachedCathegories.Find(c => c.Description == product.Cathegory);
                byte[] productPhoto = ImageToBLOB(product.Photo);

                connection.Open();

                string commandText = $"UPDATE {Product.TableName} " +
                    $"SET {Product.NameColumn} = @{Product.NameColumn}, " +
                    $"{Product.CathegoryColumn} = @{Product.CathegoryColumn}, " +
                    $"{Product.PriceColumn} = @{Product.PriceColumn}, " +
                    $"{Product.PhotoColumn} = @{Product.PhotoColumn}, " +
                    $"{Product.DescriptionColumn} = @{Product.DescriptionColumn} " +
                    $"WHERE {Product.IDColumn} = @{Product.IDColumn}";

                using (SQLiteCommand command = new SQLiteCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue($"@{Product.NameColumn}", product.Name);
                    command.Parameters.AddWithValue($"@{Product.CathegoryColumn}", cathegory.ID);
                    command.Parameters.AddWithValue($"@{Product.PriceColumn}", product.Price);
                    command.Parameters.AddWithValue($"@{Product.PhotoColumn}", productPhoto);
                    command.Parameters.AddWithValue($"@{Product.DescriptionColumn}", product.Description);
                    command.Parameters.AddWithValue($"@{Product.IDColumn}", product.ID);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        /// <summary>
        /// Zmena stavu objednavky v db a pameti
        /// </summary>
        /// <param name="order">objednavka</param>
        /// <param name="state">novy stav</param>
        public static void ChangeOrderState(Order order, int state)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string commandText = $"UPDATE {Order.TableName} " +
                    $"SET {Order.StateIDColumn} = @{Order.StateIDColumn} " +
                    $"WHERE {Order.OrderIDColumn} = @{Order.OrderIDColumn}";

                using (SQLiteCommand command = new SQLiteCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue($"@{Order.StateIDColumn}", state);
                    command.Parameters.AddWithValue($"@{Order.OrderIDColumn}", order.ID);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            // zapis zmeny do CachedOrders
            ChangeCachedOrderState(order, state);
        }

        /// <summary>
        /// Overeni noveho uzivatelskeho emailu 
        /// Pozn.: email nesmi byt jiz registrovan v db
        /// </summary>
        /// <param name="email">novy registracni email</param>
        public static bool IsEmailUnique(string email)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string commandText = $"SELECT * FROM {Customer.TableName} " +
                    $"WHERE {Customer.EmailColumn} = @{Customer.EmailColumn}";

                using (SQLiteCommand command = new SQLiteCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue($"@{Customer.EmailColumn}", email);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        // pokud byly zaznamy s emailem nalezeny, neni unikatni vrat false
                        if (reader.Read())
                        {
                            return false;
                        }
                    }
                }
                connection.Close();
            }
            return true; // jinak vrat true
        }

        /// <summary>
        /// Vytvoreni zakaznika a ulozeni jeho udaju do databaze
        /// </summary>
        /// <param name="customer">zakaznik</param>
        public static void CreateCustomer(Customer customer)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string commandText = $"INSERT INTO {Customer.TableName} " +
                    $"({Customer.NameColumn}, {Customer.LastNameColumn}," +
                    $"{Customer.PhoneColumn}, {Customer.CityColumn}," +
                    $"{Customer.StreetColumn}, {Customer.HouseNumberColumn}," +
                    $"{Customer.PostalCodeColumn}, {Customer.EmailColumn}," +
                    $"{Customer.PasswordColumn}) " +
                    $"VALUES (@{Customer.NameColumn}, @{Customer.LastNameColumn}, " +
                    $"@{Customer.PhoneColumn}, @{Customer.CityColumn}, " +
                    $"@{Customer.StreetColumn}, @{Customer.HouseNumberColumn}, " +
                    $"@{Customer.PostalCodeColumn}, @{Customer.EmailColumn}, " +
                    $"@{Customer.PasswordColumn})";

                using (SQLiteCommand command = new SQLiteCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue($"@{Customer.NameColumn}", customer.Name);
                    command.Parameters.AddWithValue($"@{Customer.LastNameColumn}", customer.LastName);
                    command.Parameters.AddWithValue($"@{Customer.PhoneColumn}", customer.MobilePhone);
                    command.Parameters.AddWithValue($"@{Customer.CityColumn}", customer.City);
                    command.Parameters.AddWithValue($"@{Customer.StreetColumn}", customer.Street);
                    command.Parameters.AddWithValue($"@{Customer.HouseNumberColumn}", customer.HouseNumber);
                    command.Parameters.AddWithValue($"@{Customer.PostalCodeColumn}", customer.PostalCode);
                    command.Parameters.AddWithValue($"@{Customer.EmailColumn}", customer.Email);
                    command.Parameters.AddWithValue($"@{Customer.PasswordColumn}", customer.Password);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        /// <summary>
        /// Vraceni ID prihlaseneho nebo nove vytvoreneho zakaznika
        /// </summary>
        /// <param name="customer">zakaznik jehoz ID se ma vyhledat v db</param>
        /// <returns>id zakaznika v databazi</returns>
        public static int GetCustomerID(Customer customer)
        {
            int customerID = -1;
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string commandText = $"SELECT {Customer.IDColumn} FROM {Customer.TableName} " +
                    $"WHERE {Customer.EmailColumn} = @{Customer.EmailColumn}";

                using (SQLiteCommand command = new SQLiteCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue($"@{Customer.EmailColumn}", customer.Email);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        // pokud byly zaznamy s emailem nalezeny, neni unikatni vrat false
                        if (reader.Read())
                        {
                            customerID = Convert.ToInt32(reader[Customer.IDColumn]);
                        }
                    }
                }
                connection.Close();
            }
            return customerID;
        }

        /// <summary>
        /// Vraceni instance zakaznika se zvolenym ID
        /// </summary>
        /// <param name="id">id hledaneho zakaznika</param>
        /// <returns>instance nalezeneho zakaznika</returns>
        public static Customer GetCustomerByID(int id)
        {
            Customer customerFound = null;
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string commandText = $"SELECT * FROM {Customer.TableName} WHERE " +
                    $"{Customer.IDColumn} = @{Customer.IDColumn}";

                using (SQLiteCommand command = new SQLiteCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue($"@{Customer.IDColumn}", id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customerFound = new Customer
                            (
                                reader[Customer.NameColumn].ToString(),
                                reader[Customer.LastNameColumn].ToString(),
                                Convert.ToInt32(reader[Customer.PhoneColumn]),
                                reader[Customer.CityColumn].ToString(),
                                reader[Customer.StreetColumn].ToString(),
                                reader[Customer.HouseNumberColumn].ToString(),
                                reader[Customer.PostalCodeColumn].ToString(),
                                reader[Customer.EmailColumn].ToString(),
                                reader[Customer.PasswordColumn].ToString()
                            );
                            customerFound.LoadThisCustomerID();
                        }
                    }
                }
                connection.Close();
            }
            return customerFound;
        }

        /// <summary>
        /// Vytvoreni a ulozeni objednavky a jeji polozek do databaze
        /// </summary>
        /// <param name="order">objednavka k ulozeni do db</param>
        public static void CreateOrder(Order order)
        {
            int lastInsertedID = -1;
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string commandText = $"INSERT INTO {Order.TableName} " +
                    $"({Order.CustomerColumn}, {Order.FixedDiscountColumn}, " +
                    $"{Order.PercentualDiscountColumn}, {Order.StateIDColumn}, {Order.DateTimeColumn}) " +
                    $"VALUES (@{Order.CustomerColumn}, @{Order.FixedDiscountColumn}, " +
                    $"@{Order.PercentualDiscountColumn}, @{Order.StateIDColumn}, @{Order.DateTimeColumn})";

                using (SQLiteCommand command = new SQLiteCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue($"@{Order.CustomerColumn}", order.Customer.ID);
                    command.Parameters.AddWithValue($"@{Order.FixedDiscountColumn}", order.FixedDiscount);
                    command.Parameters.AddWithValue($"@{Order.PercentualDiscountColumn}", order.PercentualDiscount);
                    command.Parameters.AddWithValue($"@{Order.StateIDColumn}", order.State);
                    command.Parameters.AddWithValue($"@{Order.DateTimeColumn}", order.CreationDateTime);
                    command.ExecuteNonQuery();
                }

                // posledne pridane ID objednavky
                lastInsertedID = Convert.ToInt32(connection.LastInsertRowId);
                connection.Close();
            }
            // posledne pridane ID se prideli objednavce aby se mohli k nemu priradit polozky objednavky
            order.ChangeID(lastInsertedID);

            // vytvorena objednavka se prida ke CachedOrders
            CachedOrders.Add(order);

            // po ulozeni objednavky zavolame metodu k ulozeni vsech polozek objednavky
            CreateOrderItems(order);
        }

        /// <summary>
        /// Ulozeni polozek objednavky do databaze
        /// </summary>
        /// <param name="order">objednavka jejiz polozky se ukladaji</param>
        private static void CreateOrderItems(Order order)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string commandText = $"INSERT INTO {OrderItem.TableName} " +
                $"({OrderItem.ProductIDColumn}, {OrderItem.QuantityColumn}, " +
                $"{OrderItem.FixedDiscountColumn}, {OrderItem.PercentualDiscountColumn}, " +
                $"{OrderItem.StrategyIDColumn}, {OrderItem.OrderIDColumn}) " +
                $"VALUES (@{OrderItem.ProductIDColumn}, @{OrderItem.QuantityColumn}, " +
                $"@{OrderItem.FixedDiscountColumn}, @{OrderItem.PercentualDiscountColumn}, " +
                $"@{OrderItem.StrategyIDColumn}, @{OrderItem.OrderIDColumn})";

                using (SQLiteCommand command = new SQLiteCommand(commandText, connection))
                {
                    foreach (OrderItem orderItem in order.OrderItems)
                    {
                        command.Parameters.AddWithValue($"@{OrderItem.ProductIDColumn}", orderItem.Item.ID);
                        command.Parameters.AddWithValue($"@{OrderItem.QuantityColumn}", orderItem.Quantity);
                        command.Parameters.AddWithValue($"@{OrderItem.FixedDiscountColumn}", orderItem.FixedDiscount);
                        command.Parameters.AddWithValue($"@{OrderItem.PercentualDiscountColumn}", orderItem.PercentualDiscount);
                        command.Parameters.AddWithValue($"@{OrderItem.StrategyIDColumn}", orderItem.StrategyID);
                        command.Parameters.AddWithValue($"@{OrderItem.OrderIDColumn}", order.ID);
                        command.ExecuteNonQuery();
                    }
                }
                connection.Close();
            }
        }

        /// <summary>
        /// Pripojeni polozek objednavky k objednavce v pameti
        /// </summary>
        /// <param name="order">objednavka ke ktere se pripojuji jeji polozky</param>
        private static void AttachOrderItemsToOrder(Order order)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string commandText = $"SELECT * FROM {OrderItem.TableName} " +
                    $"WHERE {OrderItem.OrderIDColumn} = @{OrderItem.OrderIDColumn}";

                using (SQLiteCommand command = new SQLiteCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue($"@{OrderItem.OrderIDColumn}", order.ID);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            int orderItemPID = Convert.ToInt32(reader[OrderItem.ProductIDColumn]);
                            Product orderItemProduct = GetCachedProductByID(orderItemPID);

                            OrderItem loadedOrderItem = new OrderItem
                            (
                                Convert.ToInt32(reader[OrderItem.OrderIDColumn]),
                                orderItemProduct,
                                Convert.ToInt32(reader[OrderItem.QuantityColumn]),
                                Convert.ToInt32(reader[OrderItem.FixedDiscountColumn]),
                                Convert.ToInt32(reader[OrderItem.PercentualDiscountColumn]),
                                Convert.ToInt32(reader[OrderItem.StrategyIDColumn])
                            );

                            order.OrderItems.Add(loadedOrderItem);
                        }
                    }
                }
                connection.Close();
            }
            // po pridani vsech polozek spocti cenovou kalkulaci pro danou objednavku
            order.CalculateOrderPricing();
        }
    }
}
