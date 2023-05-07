using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using NewLibrary.Model.DAO;

namespace NewLibrary.Controller.DataDisplayer
{
    internal class UserDisplayer
    {
        public string DisplayUserInformation(string userId, bool check)
        {
            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            string selectQuery = $"SELECT * FROM userconstructor WHERE userid = '{userId}'";
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            //이거 따로빼기 dao안에서하는게맞다 controller에 database와 연계되어있느애를생성하면안되고알고있어도안된다
            //dao에 정의되어있으니까 dao안에서 하기

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
    }
}
