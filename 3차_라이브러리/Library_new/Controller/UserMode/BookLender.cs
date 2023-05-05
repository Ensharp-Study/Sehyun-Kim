using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;
using Library;
using System.Text.RegularExpressions;
using Library.Model;
using Library.View;
using Library.Controller;
using MySql.Data.MySqlClient;
using static Library.Controller.Account;
namespace Library.Controller
{
    internal class BookLender
    {

        public void RentOutBook(string Userid)
        {
            CRUDInDAO mysqlConnecter = new CRUDInDAO();
            BookUpdater bookUpdater = new BookUpdater();
            UserMenuDisplay viewMenu = new UserMenuDisplay();

            Console.Clear();
            bookUpdater.DisplayAllBook();
            Console.WriteLine("대여할 책 id를 입력하세요.");
            Console.WriteLine("(뒤로 가려면 0을 누르세요.)");
            int inputBookId = int.Parse(Console.ReadLine());
            if (inputBookId == 0) //0이면 뒤로가기
            {
                Console.Clear();
                viewMenu.ViewUserMenu();
            }
            //0이 아니면
            DateTime currentTime = DateTime.Now;
            string currentTimeString = currentTime.ToString("yyyy-MM-dd HH:mm:ss"); //현재시각측정
                                                                                    //만약 대여 가능한 책 수가 1권 이상이면
            int rentPossible = mysqlConnecter.ReadData("rentpossible", $"SELECT rentpossible FROM bookconstructor WHERE id ='{inputBookId}'");
            if (rentPossible >= 1)
            {
                //bookconstructor 테이블에서 대여할 책 정보를 불러와 borrowlist 테이블에 삽입
                bool check = mysqlConnecter.InsertUpdateDelete($"INSERT INTO borrowlist(id, bookName, author, publisher, quantity, price, publicationDate, isbn, info, rentpossible, borrowtime, userid) SELECT id, bookName, author, publisher, quantity, 0, publicationDate, isbn, info, rentpossible, '{currentTimeString}', '{Userid}' FROM bookconstructor WHERE id = '{inputBookId}'");

                //bookconstructor 테이블에서 rentpossible 값을 1 감소시킴
                check = mysqlConnecter.InsertUpdateDelete($"UPDATE bookconstructor SET rentpossible = rentpossible - 1 WHERE id = '{inputBookId}'");
                if (check)
                {
                    Console.WriteLine("대여 완료하였습니다.");
                }
            }
        }



        public void borrowhistory(string Userid)
        {
            BookUpdater bookUpdater = new BookUpdater();
            Console.Clear();

            MySqlConnection connection = DatabaseConnection.Instance.Connection; 
            MySqlCommand command = new MySqlCommand($"SELECT * FROM borrowlist WHERE userid = '{Userid}'", connection);

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
                Console.WriteLine("  rentpossible: " + reader["rentpossible"]);
                Console.WriteLine("  borrowtime: " + reader["borrowtime"]);
                Console.WriteLine("==================================================");
            }
            else
            {
                Console.WriteLine("책 정보가 없습니다.");
            }

            reader.Close();
            connection.Close();
        }
    }
}
