using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using NewLibrary.Model.DAO;

namespace NewLibrary.Controller.Function
{
    internal class BookDisplayer
    {
        public void DisplayBookInformation(string selectQuery)
        {

            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            //string selectQuery = $"SELECT * FROM bookconstructor WHERE id = '{number}'"; //number 입력받아서 id=number인 행 찾기 
            MySqlCommand command = new MySqlCommand(selectQuery, connection);

            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine("=================================================");
                Console.WriteLine("  id: " + reader["id"]);
                Console.WriteLine("  bookName: " + reader["bookName"]);
                Console.WriteLine("  author: " + reader["author"]);
                Console.WriteLine("  publisher: " + reader["publisher"]);
                Console.WriteLine("  quantity: " + reader["quantity"]);
                Console.WriteLine("  price: " + reader["price"]);
                Console.WriteLine("  publicationDate: " + reader["publicationDate"]);
                Console.WriteLine("  isbn: " + reader["isbn"]);
                Console.WriteLine("  info: " + reader["info"]);
                Console.WriteLine("==================================================");
            }
            else
            {
                Console.WriteLine("            책 정보가 없습니다.");
            }

            reader.Close();
            connection.Close();
        }
        public void DisplayAllBook()
        {
            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            string selectQuery = "SELECT * FROM bookconstructor";
            MySqlCommand command = new MySqlCommand(selectQuery, connection);

            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("  id: " + reader["id"].ToString());
                Console.WriteLine("  bookName: " + reader["bookName"].ToString());
                Console.WriteLine("  author: " + reader["author"].ToString());
                Console.WriteLine("  publisher: " + reader["publisher"].ToString());
                Console.WriteLine("  quantity: " + reader["quantity"].ToString());
                Console.WriteLine("  price: " + reader["price"].ToString());
                Console.WriteLine("  publicationDate: " + reader["publicationDate"].ToString());
                Console.WriteLine("  isbn: " + reader["isbn"].ToString());
                Console.WriteLine("  info: " + reader["info"].ToString());
                Console.WriteLine("  rentpossible: " + reader["rentpossible"].ToString());
                Console.WriteLine("============================================================");
            }
            reader.Close();
            connection.Close();
        }
    }
}
