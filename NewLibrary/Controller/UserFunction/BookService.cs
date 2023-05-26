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
    internal class BookService
    {
        public string RentOutBook(string userId) //도서 대여 
        {
            FunctionInDAO mysqlConnecter = new FunctionInDAO();
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            Console.SetWindowSize(56, 50);
            Console.CursorVisible = true;
            string inputBookId="";
            bool fine = true;
            string returnTimeString = "";
            DateTime returnTime;
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
                bool check = mysqlConnecter.InsertUpdateDelete(string.Format(@"INSERT INTO borrowlist(id, bookName, author, publisher, quantity, price, publicationDate, isbn, info, rentpossible, borrowtime, userid) 
                                        SELECT id, bookName, author, publisher, quantity, 0, publicationDate, isbn, info, rentpossible, '{0}', '{1}' 
                                        FROM bookconstructor 
                                        WHERE id = '{2}'", currentTimeString, userId, inputBookId));

                //bookconstructor 테이블에서 rentpossible 값을 1 감소시킴
                check = mysqlConnecter.InsertUpdateDelete(string.Format("UPDATE bookconstructor SET rentpossible = rentpossible - 1 WHERE id = '{0}'", inputBookId));
                if (check)
                {
                    Console.WriteLine("");
                    Console.WriteLine("                  대여 완료하였습니다.");
                    Console.WriteLine("                  ESC를 눌러 돌아가기");
                    returnTime = DateTime.Now;
                    returnTimeString = returnTime.ToString("yyyy-MM-dd HH:mm:ss"); //현재시각측정
                    mysqlConnecter.InsertUpdateDelete(string.Format(ConstantOfQuery.InsertInLogQuery, returnTimeString, "유저", "성공", "도서 대여"));
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
                returnTime = DateTime.Now;
                returnTimeString = returnTime.ToString("yyyy-MM-dd HH:mm:ss"); //현재시각측정
                mysqlConnecter.InsertUpdateDelete(string.Format(ConstantOfQuery.InsertInLogQuery, returnTimeString, "유저", "실패", "도서 대여"));
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

        public string RentalList(string userId, bool check) //대여 목록
        {
            FunctionInDAO mysqlConnecter = new FunctionInDAO();
            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            MySqlCommand command = new MySqlCommand(string.Format("SELECT * FROM borrowlist WHERE userid = '{0}'", userId), connection);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            bool hasRecords = false; // 레코드가 있는지 여부를 판단하기 위한 변수
            string returnTimeString = "";
            DateTime returnTime;

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
            reader.Close();
            connection.Close();
            returnTime = DateTime.Now;
            returnTimeString = returnTime.ToString("yyyy-MM-dd HH:mm:ss"); //현재시각측정
            mysqlConnecter.InsertUpdateDelete(string.Format(ConstantOfQuery.InsertInLogQuery, returnTimeString, "유저", "성공", "도서 대여 확인"));
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

        public string ReturnBook(string userId) //도서 반납
        {
            FunctionInDAO mysqlConnecter = new FunctionInDAO();
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            Console.SetWindowSize(56, 50);
            Console.CursorVisible = true;
            string inputBookId = "";
            bool fine = true;

            while (fine)
            {
                inputBookId = inputKeyUnlessEnter.SaveInputUnlessEnter(32, 5);
                if (inputBookId == null)
                {
                    return userId;
                }
                fine = inputKeyUnlessEnter.CheckRegex(inputBookId, RegexConstant.onlyNumberRegex, 32, 6, 32, 5, "입력이 잘못되었습니다");
            }
            DateTime returnTime = DateTime.Now;
            string returnTimeString = returnTime.ToString("yyyy-MM-dd HH:mm:ss"); //현재시각측정

            bool check = mysqlConnecter.InsertUpdateDelete($@"INSERT INTO returnlist(id, bookName, author, publisher, quantity, price, publicationDate, isbn, info, rentpossible, borrowtime, returntime, userid)
                             SELECT id, bookName, author, publisher, quantity, price, publicationDate, isbn, info, rentpossible, borrowtime, '{returnTimeString}', '{userId}'
                             FROM borrowlist
                             WHERE id = '{inputBookId}' AND userid = '{userId}'
                             ORDER BY borrowtime ASC
                             LIMIT 1");

            if (check)
            {
                bool checker = mysqlConnecter.InsertUpdateDelete(string.Format("DELETE FROM borrowlist WHERE id = {0} AND userid = '{1}'", inputBookId, userId));
                if (checker)
                {
                    bool rentPossibleUpdate = mysqlConnecter.InsertUpdateDelete(string.Format(@"UPDATE bookconstructor SET rentpossible = rentpossible + 1
WHERE id = '{0}'", inputBookId));

                    if (rentPossibleUpdate)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("     반납 완료하였습니다.");
                        Console.WriteLine("     ESC를 눌러 돌아가기");
                        returnTime = DateTime.Now;
                        returnTimeString = returnTime.ToString("yyyy-MM-dd HH:mm:ss"); //현재시각측정
                        mysqlConnecter.InsertUpdateDelete(string.Format(ConstantOfQuery.InsertInLogQuery, returnTimeString, "유저", "성공", "도서 반납"));
                    }
                }
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("     반납 가능한 도서가 없습니다.");
                Console.WriteLine("     ESC를 눌러 돌아가기");
                returnTime = DateTime.Now;
                returnTimeString = returnTime.ToString("yyyy-MM-dd HH:mm:ss"); //현재시각측정
                mysqlConnecter.InsertUpdateDelete(string.Format(ConstantOfQuery.InsertInLogQuery, returnTimeString, "유저", "실패", "도서 반납"));
            }
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

        public string ReturnList(string userId) //반납 목록
        {
            Console.Clear();
            FunctionInDAO mysqlConnecter = new FunctionInDAO();
            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            MySqlCommand command = new MySqlCommand(string.Format("SELECT * FROM returnlist WHERE userid = '{0}'", userId), connection);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            bool hasRecords = false; // 레코드가 있는지 여부를 판단하기 위한 변수
            string returnTimeString = "";
            DateTime returnTime;
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
            reader.Close();
            connection.Close();
            returnTime = DateTime.Now;
            returnTimeString = returnTime.ToString("yyyy-MM-dd HH:mm:ss"); //현재시각측정
            mysqlConnecter.InsertUpdateDelete(string.Format(ConstantOfQuery.InsertInLogQuery, returnTimeString, "유저", "성공", "도서 반납 확인"));
            Console.WriteLine("ESC를 눌러 종료");
            while (true)
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