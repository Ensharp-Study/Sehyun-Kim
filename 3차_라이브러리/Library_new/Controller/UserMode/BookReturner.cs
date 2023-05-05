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

namespace Library.Controller
{
    internal class BookReturner
    {
        
        public void returnBook()
        {
            HomeDisplay display = new HomeDisplay();
            BookSearcher searchBookInfo = new BookSearcher();
            UserMenuDisplay viewMenu = new UserMenuDisplay();
            BookLender borrowBook = new BookLender();

            borrowBook.borrowhistory();
            Console.WriteLine("반납할 책 id를 입력하세요.");
            Console.WriteLine("(뒤로 가려면 0을 누르세요.)");
            int inputBookId2 = int.Parse(Console.ReadLine());
            /*
            if (inputBookId2 == 0)
            {
                Console.Clear();
                viewMenu.ViewUserMenu();

            }
            int i = 0;
            int booklistnumber = 0;
            foreach (var book in bookData.BookList)
            {
                i++;
                if (book.id == inputBookId2)
                {
                    booklistnumber = i - 1;

                    bookData.BookList[booklistnumber].rentpossible++;
                    userData.UserList[userlistnumber].rentedbooklist.Remove(book);
                    userData.UserList[userlistnumber].returnedbooklist.Add(book);
                    //BookData.rentimpossibleBook.Add(book);
                    //BookData.rentpossibleBook.Remove(book);
                    Console.WriteLine("반납 완료했습니다.");
                    break;
                }
            }
            */
        }//userlistnumber로 해당회원리스트접근가능 
        //패키징하면데이터x const

        public void returnhistory()
        {/*
            Console.Clear();
            foreach (BookConstructor book in userData.UserList[userlistnumber].returnedbooklist)
            {

                Console.WriteLine("회원님의 반납 이력을 표시합니다.");
                Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■");
                Console.WriteLine("  ID: " + book.id);
                Console.WriteLine("  Title: " + book.bookName);
                Console.WriteLine("  Author: " + book.author);
                Console.WriteLine("  Publisher: " + book.publisher);
                Console.WriteLine("  price: " + book.price);
                Console.WriteLine("  quantity: " + book.quantity);
                Console.WriteLine("  publicationDate: " + book.publicationDate);
                Console.WriteLine("  isbn: " + book.isbn);
                Console.WriteLine("  info: " + book.info);
                Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■");
            }
            */
        }
    }
}
