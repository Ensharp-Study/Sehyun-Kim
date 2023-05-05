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
using static Library.Controller.Account;
using Library.Controller.Form;

namespace Library.Controller
{
    internal class BookDataAdder
    {
        private BookData bookData;
        private UserData userData;

        public BookDataAdder(BookData bookData, UserData userData)
        {
            this.bookData = bookData;
            this.userData = userData;
        }
        public void appendbook()
        {
            InputSaverUnlessEnter inputSaverUnlessEnter = new InputSaverUnlessEnter();
            MysqlConnecter mysqlConnecter = new MysqlConnecter();
            Console.Clear();
            Console.WriteLine("추가할 도서의 정보를 입력하세요.");

            Console.Write(" id : ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("bookName : ");
            string bookName = Console.ReadLine();
            Console.Write("author : ");
            string author = Console.ReadLine();
            Console.Write("publisher : ");
            string publisher = Console.ReadLine();
            Console.Write("quantity : ");
            int quantity = int.Parse(Console.ReadLine());
            Console.Write("price : ");
            int price = int.Parse(Console.ReadLine());
            Console.Write("publicationDate : ");
            string publicationDate = Console.ReadLine();
            Console.Write("isbn : ");
            string isbn = Console.ReadLine();
            Console.Write("info : ");
            string info = Console.ReadLine();

            int rentpossible = quantity;
            bool fine = true;
            fine= mysqlConnecter.InsertData($"INSERT INTO bookconstructor(id, bookName, author, publisher, quantity, price,publicationDate,isbn,info) VALUES('{id}', '{bookName}', '{author}', '{publisher}', '{quantity}', '{price}','{publicationDate}','{isbn}','{info}')");
            Console.Clear();
            if (fine)
            {
                Console.WriteLine("책 정보가 추가되었습니다.");
            }
        }
    }
}
