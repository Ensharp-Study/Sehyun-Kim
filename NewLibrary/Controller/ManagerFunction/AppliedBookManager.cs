using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using NewLibrary.Model.DAO;

namespace NewLibrary.Controller.ManagerFunction
{
    internal class AppliedBookManager
    {
        public void ManagerAppliedBook()
        {
            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            string selectQuery = "SELECT * FROM bookconstructor";
            MySqlCommand command = new MySqlCommand(selectQuery, connection);

            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("  title: " + reader["title"].ToString());
                Console.WriteLine("  author: " + reader["author"].ToString());
                Console.WriteLine("  publisher: " + reader["publisher"].ToString());
                Console.WriteLine("  publicationDate: " + reader["pubDate"].ToString());
                Console.WriteLine("  price: " + reader["discount"].ToString());
                Console.WriteLine("  isbn: " + reader["isbn"].ToString());
                Console.WriteLine("  userid: " + reader["userid"].ToString());
                Console.WriteLine("============================================================");
                
            }
            Console.ReadLine();
            reader.Close();
            connection.Close();
        }
    }
}
