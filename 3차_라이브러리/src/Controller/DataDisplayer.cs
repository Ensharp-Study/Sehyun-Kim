using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using NewLibrary.Constant;
using NewLibrary.Model.DAO;

namespace NewLibrary.Controller
{
    internal class DataDisplayer
    {
        public string DisplayUserInformation(string userId, bool check)
        {
            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            string selectQuery = string.Format(ConstantOfQuery.selectUserWithId, userId);
            MySqlCommand command = new MySqlCommand(selectQuery, connection);

            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine("             현재 회원님의 정보를 표시합니다.");
                Console.WriteLine("=============================================================");
                Console.WriteLine("  userid: " + reader["userid"]);
                Console.WriteLine("  Name: " + reader["name"]);
                Console.WriteLine("  Age: " + reader["age"]);
                Console.WriteLine("  PhoneNumber: " + reader["phonenumber"]);
                Console.WriteLine("  Address: " + reader["address"]);
                Console.WriteLine("=============================================================");
            }
            else
            {
                Console.WriteLine("                 회원 정보가 없습니다.");
            }

            Console.WriteLine(    "                   ESC를 눌러 돌아가기");
            while (check)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Escape) //esc 입력됐을 경우
                {
                    Console.Clear();
                    return userId;
                    reader.Close();
                    connection.Close();
                }
                else
                {
                    continue;
                }
            }
            reader.Close();
            connection.Close();
            return userId;
        }

        public void DisplayBookInformation(string selectQuery)
        {

            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            
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
            string selectQuery = ConstantOfQuery.selectBook;
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
