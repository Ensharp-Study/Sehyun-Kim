using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using NewLibrary.Constant;
using NewLibrary.Model.DAO;
using NewLibrary.Utility;

namespace NewLibrary.Controller.ManagerFunction
{
    internal class AppliedBookManager
    {
        public void ManagerAppliedBook(string userId)
        {
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            MySqlConnection connection = DatabaseConnection.Instance.Connection;

            string selectQuery = "SELECT * FROM appliedbooklist";
            MySqlCommand command = new MySqlCommand(selectQuery, connection);

            bool check = true;
            string titleValue = "";
            string idValue = "0";
            string quantityValue = "0";
            string priceValue = "0";
            string infoValue = "";
            string rentpossibleValue = "0";

            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n");

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
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("추가할 책의 제목을 입력하세요.");

            

            while (check)
            {
                titleValue=inputKeyUnlessEnter.SaveInputUnlessEnter(0, 1);
                check = inputKeyUnlessEnter.CheckRegex(titleValue, RegexConstant.englishKoreanNumberRegex, 0, 1, 20, 1, "입력이 잘못되었습니다.");
            }
            check = true;
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("추가할 책의 id를 입력하세요.");
            while (check)
            {
                idValue = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 3);
                check = inputKeyUnlessEnter.CheckRegex(idValue, RegexConstant.onlyNumberRegex, 0, 3, 20, 3, "입력이 잘못되었습니다.");
            }
            check = true;
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("추가할 책의 quantity를 입력하세요.");
            while (check)
            {
                quantityValue = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 5);
                check = inputKeyUnlessEnter.CheckRegex(quantityValue, RegexConstant.quantityRegex, 0, 5, 20, 5, "입력이 잘못되었습니다.");
            }
            int quantity = int.Parse(quantityValue);
            check = true;
            Console.SetCursorPosition(0, 6);
            Console.WriteLine("추가할 책의 price를 입력하세요.");
            while (check)
            {
                priceValue = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 7);
                check = inputKeyUnlessEnter.CheckRegex(priceValue, RegexConstant.priceRegex, 0, 7, 20, 7, "입력이 잘못되었습니다.");
            }
            int price= int.Parse(priceValue);
            check = true;
            Console.SetCursorPosition(0, 8);
            Console.WriteLine("추가할 책의 info를 입력하세요.");
            while (check)
            {
                infoValue = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 9);
                check = inputKeyUnlessEnter.CheckRegex(infoValue, RegexConstant.englishKoreanNumberRegex, 0, 9, 20, 9, "입력이 잘못되었습니다.");
            }
            check = true;
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("추가할 책의 rentPossible를 입력하세요.");
            while (check)
            {
                rentpossibleValue = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 11);
                check = inputKeyUnlessEnter.CheckRegex(rentpossibleValue, RegexConstant.quantityRegex, 0, 11, 20, 11, "입력이 잘못되었습니다.");
            }
            int rentpossible = int.Parse(rentpossibleValue);
            reader.Close();
            connection.Close();
            MoveBookToConstructor(idValue, titleValue, quantity, price, infoValue, rentpossible);
        }
        public void MoveBookToConstructor(string bookId, string title, int quantity, int price, string info, int rentPossible)
        {
            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            string selectQuery = string.Format("SELECT * FROM appliedbooklist WHERE title='{0}'", title);
            MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection);
            FunctionInDAO mysqlConnecter = new FunctionInDAO();
            connection.Open();
            MySqlDataReader reader = selectCommand.ExecuteReader();
            DateTime returnTime;
            string returnTimeString = "";
            bool isExist = false;
            if (reader.Read())
            {
                string author = reader["author"].ToString();
                string publisher = reader["publisher"].ToString();
                string pubDate = reader["pubDate"].ToString();
                string isbn = reader["isbn"].ToString();
                string userId = reader["userid"].ToString();

                reader.Close();

                string insertQuery = string.Format("INSERT INTO bookconstructor(id, bookName, author, publisher, publicationDate, quantity, price, isbn, info, rentpossible) " +
                                   "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', {5}, '{6}', '{7}', '{8}', {9})",
                                   bookId, title, author, publisher, pubDate, quantity, price, isbn, info, rentPossible);
                MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
                int insertResult = insertCommand.ExecuteNonQuery();

                string deleteQuery = string.Format("DELETE FROM appliedbooklist WHERE title='{0}' AND userid='{1}'", title, userId);
                MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection);
                int deleteResult = deleteCommand.ExecuteNonQuery();
                returnTime = DateTime.Now;
                returnTimeString = returnTime.ToString("yyyy-MM-dd HH:mm:ss"); //현재시각측정

                if (insertResult > 0 && deleteResult > 0)
                {
                    Console.WriteLine($"도서가 추가되었습니다.");
                    mysqlConnecter.InsertUpdateDelete(string.Format(ConstantOfQuery.InsertInLogQuery, returnTimeString, "매니저", "성공", "신청 도서 추가"));
                }
                else
                {
                    Console.WriteLine($"도서 추가에 실패했습니다.");
                    mysqlConnecter.InsertUpdateDelete(string.Format(ConstantOfQuery.InsertInLogQuery, returnTimeString, "매니저", "실패", "신청 도서 추가"));
                }
            }
            else
            {
                Console.WriteLine($"도서가 신청 리스트에 존재하지 않습니다.");
            }

            connection.Close();

            Console.WriteLine("ESC를 눌러 종료");
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
