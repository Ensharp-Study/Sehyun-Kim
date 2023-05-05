
﻿using System;
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
using static Library.Controller.Account;
using MySql.Data.MySqlClient;

namespace Library.Controller
{
    internal class BookReturner
    {

        public void returnBook(string Userid)
        {
            HomeDisplay display = new HomeDisplay();
            BookSearcher searchBookInfo = new BookSearcher();
            UserMenuDisplay viewMenu = new UserMenuDisplay();
            BookLender borrowBook = new BookLender();
            CRUDInDAO mysqlConnecter = new CRUDInDAO();

            borrowBook.borrowhistory(Userid);
            Console.WriteLine("반납할 책 id를 입력하세요.");
            Console.WriteLine("(뒤로 가려면 0을 누르세요.)");
            int inputBookId2 = int.Parse(Console.ReadLine());
            if (inputBookId2 == 0) //0이면 뒤로가기
            {
                Console.Clear();
                viewMenu.ViewUserMenu();
            }
            //0이 아니면
            //DELETE

            DateTime returnTime = DateTime.Now;
            string returnTimeString = returnTime.ToString("yyyy-MM-dd HH:mm:ss"); //현재시각측정


            bool check = mysqlConnecter.InsertUpdateDelete($"INSERT INTO returnlist(id, bookName, author, publisher, quantity, price, publicationDate, isbn, info, rentpossible, borrowtime,returntime, userid) SELECT id, bookName, author, publisher, quantity, 0, publicationDate, isbn, info, rentpossible, borrowtime,'{returnTimeString}',userid FROM borrowlist WHERE id = '{inputBookId2}'");


            check = mysqlConnecter.InsertUpdateDelete($"DELETE FROM borrowlist WHERE id = {inputBookId2}");
            if (check)
            {
                Console.Clear();
                Console.WriteLine("반납 완료하였습니다.");
            }
        }
        public void returnhistory(string Userid)
        {
            BookUpdater bookUpdater = new BookUpdater();
            Console.Clear();

            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            MySqlCommand command = new MySqlCommand($"SELECT * FROM returnlist WHERE userid = '{Userid}'", connection);

            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
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
                    Console.WriteLine("  returntime: " + reader["returntime"]);
                    Console.WriteLine("==================================================");
                }
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


