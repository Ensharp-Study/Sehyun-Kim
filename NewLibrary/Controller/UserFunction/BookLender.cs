using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLibrary.Controller;
using NewLibrary.Constant;
using NewLibrary.Utility;
using MySql.Data.MySqlClient;
using NewLibrary.Model.DAO;

namespace NewLibrary.Controller.Function
{
    internal class BookLender
    {
        public string RentOutBook(string userId)
        {
            CRUDInDAO mysqlConnecter = new CRUDInDAO();
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            Console.SetWindowSize(56, 50);
            Console.CursorVisible = true;
            string inputBookId="";
            bool fine = true;
            while (fine)
            {
                inputBookId = inputKeyUnlessEnter.SaveInputUnlessEnter(32,6);
                if (inputBookId == null)
                {
                    return userId;
                }
                fine = inputKeyUnlessEnter.CheckRegex(inputBookId, RegexConstant.onlyNumberRegex, 32, 6, 20, 5, "입력이 잘못되었습니다");
            }
            DateTime currentTime = DateTime.Now;
            string currentTimeString = currentTime.ToString("yyyy-MM-dd HH:mm:ss"); //현재시각측정
                                                                                    //만약 대여 가능한 책 수가 1권 이상이면
            int rentPossible = mysqlConnecter.ReadData("rentpossible", $"SELECT rentpossible FROM bookconstructor WHERE id ='{inputBookId}'");
            if (rentPossible >= 1)
            {
                //bookconstructor 테이블에서 대여할 책 정보를 불러와 borrowlist 테이블에 삽입
                bool check = mysqlConnecter.InsertUpdateDelete($"INSERT INTO borrowlist(id, bookName, author, publisher, quantity, price, publicationDate, isbn, info, rentpossible, borrowtime, userid) SELECT id, bookName, author, publisher, quantity, 0, publicationDate, isbn, info, rentpossible, '{currentTimeString}', '{userId}' FROM bookconstructor WHERE id = '{inputBookId}'");

                //bookconstructor 테이블에서 rentpossible 값을 1 감소시킴
                check = mysqlConnecter.InsertUpdateDelete($"UPDATE bookconstructor SET rentpossible = rentpossible - 1 WHERE id = '{inputBookId}'");
                if (check)
                {
                    Console.WriteLine("");
                    Console.WriteLine("                  대여 완료하였습니다.");
                    Console.WriteLine("                  ESC를 눌러 돌아가기");
                    while (true)
                    {
                        ConsoleKeyInfo input = Console.ReadKey(true);
                        if (input.Key == ConsoleKey.Escape) //esc 입력됐을 경우
                        {
                            Console.Clear();
                            return userId;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("대여 가능한 도서가 없습니다.");
                Console.WriteLine("ESC를 눌러 돌아가기");
                while (true)
                {
                    ConsoleKeyInfo input = Console.ReadKey(true);
                    if (input.Key == ConsoleKey.Escape) //esc 입력됐을 경우
                    {
                        Console.Clear();
                        return userId;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return userId;
        }

        public string BorrowHistory(string userId, bool check)
        {
            BookDisplayer bookDisplayer = new BookDisplayer();

            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            MySqlCommand command = new MySqlCommand($"SELECT * FROM borrowlist WHERE userid = '{userId}'", connection);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            bool hasRecords = false; // 레코드가 있는지 여부를 판단하기 위한 변수

            while (reader.Read()) // 모든 레코드를 읽어서 출력
            {
                hasRecords = true;

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
                Console.WriteLine("  rentpossible: " + reader["rentpossible"]);
                Console.WriteLine("  borrowtime: " + reader["borrowtime"]);
                Console.WriteLine("==================================================");
            }

            if (!hasRecords) // 레코드가 없는 경우 메시지 출력
            {
                Console.WriteLine("책 정보가 없습니다.");
            }
            Console.WriteLine("ESC를 눌러 종료");
            while (check)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Escape) //esc 입력됐을 경우
                {
                    Console.Clear();
                    reader.Close();
                    connection.Close();
                    return userId;
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