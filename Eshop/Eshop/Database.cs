using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop
{
    class Database
    {
        private readonly string databazeFileName;
        private readonly string connectionString;

        public Database(string databazeFileName)
        {
            this.databazeFileName = databazeFileName;
            connectionString = $"Data Source={databazeFileName};Version=3;";
        }

        // metody k vymazani produktu, pridani produktu, uprave produktu

        /// <summary>
        /// Metoda vymaze produkt z databaze
        /// </summary>
        /// <param name="product">objekt typu Product k vymazani</param>
        public void DeleteProduct(Product product)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string commandText = $"DELETE FROM {Product.TableName} WHERE {Product.IDColumn} = {product.ProductID}";
                using (SQLiteCommand command = new SQLiteCommand(commandText, connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        /// <summary>
        /// Metoda slouzi k vytvoreni noveho produktu a je
        /// </summary>
        /// <param name="product"></param>
        public void CreateProduct(Product product)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string commandText = $"INSERT INTO {Product.TableName} " +
                    $"VALUES ({product.Name}, {product.Cathegory}, {product.Price}," +
                    $"{product.Photo}, {product.Description})";
                using (SQLiteCommand command = new SQLiteCommand(commandText, connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}
