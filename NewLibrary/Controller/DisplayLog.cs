using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using NewLibrary.Model.DAO;

namespace NewLibrary.Controller.Log
{
    internal class DisplayLog
    {
        public void DownloadLog()
        {
            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            string selectQuery = "SELECT * FROM log";
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            MySqlDataReader dataReader = null;

            try
            {
                connection.Open();
                dataReader = command.ExecuteReader();

                using (StreamWriter writer = new StreamWriter("output.txt"))
                {
                    while (dataReader.Read())
                    {
                        string row = string.Format("{0}\t{1}\t{2}\t{3}\t{4}",
                            dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2),
                            dataReader.GetString(3), dataReader.GetString(4));
                        writer.WriteLine(row);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (dataReader != null)
                {
                    Console.WriteLine("로그가 저장되었습니다.");
                    dataReader.Close();
                }
                connection.Close();
            }

            Console.WriteLine("ESC를 눌러 돌아가기");
            while (true)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Escape) //esc 입력됐을 경우
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
