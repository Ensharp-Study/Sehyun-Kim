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
using static Library.Controller.LoginOrNewmember;
namespace Library.Controller
{
    internal class BorrowBook
    {
        private BookData bookData;
        private UserData userData;

        public BorrowBook(BookData bookData, UserData userData)
        {
            this.bookData = bookData;
            this.userData = userData;
        }
        public void RentOutBook()
        {
            
            ShowAllBook showAllBook = new ShowAllBook(bookData, userData);
            ViewMenu viewMenu = new ViewMenu();

            Console.Clear();
            showAllBook.allBook();
            Console.WriteLine("대여할 책 id를 입력하세요.");
            Console.WriteLine("(뒤로 가려면 0을 누르세요.)");
            int inputBookId = int.Parse(Console.ReadLine());
            if (inputBookId == 0)
            {
                Console.Clear();
                viewMenu.ViewUserMenu();

            }
            int i = 0;
            int booklistnumber = 0;
            foreach (var book in bookData.BookList)
            {
                i++;
                if (book.id == inputBookId)
                {
                    booklistnumber = i - 1;

                    if (bookData.BookList[booklistnumber].rentpossible == 0)
                    {
                        Console.WriteLine("대여 가능한 도서가 없습니다.");
                    }
                    if (bookData.BookList[booklistnumber].rentpossible > 0)
                    {

                        bookData.BookList[booklistnumber].rentpossible--;
                        userData.UserList[userlistnumber].rentedbooklist.Add(book);
                        Console.WriteLine("대여 완료했습니다.");
                        //BookData.rentpossibleBook.Add(book);
                    }





                    break;
                }
            }
        }

        public void borrowhistory()
        {
            Console.Clear();
            foreach (BookConstructor book in userData.UserList[userlistnumber].rentedbooklist)
            {
                Console.WriteLine("현재 회원님이 대여 중인 도서를 표시합니다.");
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
        }
    }
}
