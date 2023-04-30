using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;
using Library.Model;
using Library.View;
using Library.Controller;
using Library.Constant;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Library.Controller
{
    internal class BookSearcher
    {
        private BookData bookData;
        private UserData userData;

        public BookSearcher(BookData bookData, UserData userData)
        {
            this.bookData = bookData;
            this.userData = userData;
        }
        public void SearchBook(bool check) //check -> 유저모드면 true, 관리자모드면 false
        {
            NumberInputManager managerMode = new NumberInputManager(bookData, userData);
            RegexChecker regexChecker = new RegexChecker();
            AllBookDisplay showAllBook = new AllBookDisplay(bookData, userData);
            Console.Clear();
            showAllBook.DisplayAllBook();
            Console.WriteLine(" < 도서 찾기 >  \n");

            Console.WriteLine(" ⓛ 제목으로 찾기 ");
            Console.WriteLine(" ② 작가명으로 찾기");
            Console.WriteLine(" ③ 출판사명으로 찾기");

            Console.WriteLine(" 0을 입력해 돌아가기");
            int number;
            number = regexChecker.CheckRegexWhenValueIsNumber(0, 3, "^[0-3]$"); //정규식 만족하면 검색하기, 0부터 3
            SearchBookWithNumber(number, check);

        }
        public void SearchBookWithNumber(int number, bool modeChecker)
        {
            UserMenuDisplay userMenuDisplay = new UserMenuDisplay();
            int flag = 0;

            switch (number)
            {
                case 0:
                    Console.Clear();
                    if (modeChecker) {
                        //유저모드면 유저메뉴로 돌아가기
                        userMenuDisplay.ViewUserMenu();
                    } 
                    else
                    { //관리자모드면 관리자메뉴로 돌아가기

                    }
                    break;
                case 1:
                    Console.Write("제목을 입력하세요 : ");
                    string title = Console.ReadLine();
                    Console.Clear();
                    foreach (BookConstructor book in bookData.BookList)
                    {
                        if (book.bookName.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            Console.Clear();
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
                            Console.WriteLine("  대여 가능한 책: " + book.rentpossible + "권");
                            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■");
                            flag = 1;
                        }

                    }
                    if (flag == 0)
                    {
                        Console.WriteLine("해당하는 도서가 없습니다.");

                    }
                    flag = 0;
                    break;
                case 2:
                    Console.Write("작가명을 입력하세요 : ");
                    string authorname = Console.ReadLine();
                    Console.Clear();
                    foreach (var book in bookData.BookList)
                    {
                        if (book.author.IndexOf(authorname, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            Console.Clear();
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
                            Console.WriteLine("  대여 가능한 책: " + book.rentpossible + "권");
                            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■");
                            flag = 1;
                        }
                    }
                    if (flag == 0)
                    {
                        Console.WriteLine("해당하는 도서가 없습니다.");

                    }
                    flag = 0;

                    break;
                case 3:
                    Console.Write("출판사명을 입력하세요 : ");
                    string publishername = Console.ReadLine();
                    Console.Clear();
                    foreach (var book in bookData.BookList)
                    {
                        if (book.publisher.IndexOf(publishername, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            Console.Clear();
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
                            Console.WriteLine("  대여 가능한 책: " + book.rentpossible + "권");
                            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■");
                            flag = 1;
                        }
                    }
                    if (flag == 0)
                    {
                        Console.WriteLine("해당하는 도서가 없습니다.");

                    }
                    flag = 0;

                    break;


            }


        }
    }
        
}
