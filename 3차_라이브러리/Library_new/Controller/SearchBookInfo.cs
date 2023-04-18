using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;
using Library.Model;
using Library.View;
using Library.Controller;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Library.Controller
{
    internal class SearchBookInfo
    {
        private BookData bookData;
        private UserData userData;

        public SearchBookInfo(BookData bookData, UserData userData)
        {
            this.bookData = bookData;
            this.userData = userData;
        }
        public void searchBookManagerMode()
        {
            ManagerMode managerMode = new ManagerMode(bookData, userData);
            ShowAllBook showAllBook = new ShowAllBook(bookData, userData);
            Console.Clear();
            showAllBook.allBook();
            Console.WriteLine(" < 도서 찾기 >  \n");

            Console.WriteLine(" ⓛ 제목으로 찾기 ");
            Console.WriteLine(" ② 작가명으로 찾기");
            Console.WriteLine(" ③ 출판사명으로 찾기");

            Console.WriteLine(" 0을 입력해 돌아가기");
            int num;
            while (true)
            {
                num = int.Parse(Console.ReadLine());
                Regex regex = new Regex("^[0-3]$");
                string str = Convert.ToString(num);
                if (regex.IsMatch(str))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("0부터 3 사이의 값을 입력해 주세요.");
                }
            }

            int flag = 0;

            switch (num)
            {
                case 0:
                    Console.Clear();
                    managerMode.modOfManager();
                    break;
                case 1:
                    Console.Write("제목을 입력하세요 : ");
                    string title = Console.ReadLine();
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

        public void searchBookUserMode()
        {
            ManagerMode managerMode = new ManagerMode(bookData, userData);
            ShowAllBook showAllBook = new ShowAllBook(bookData, userData);
            Console.Clear();
            showAllBook.allBook();
            Console.WriteLine(" < 도서 찾기 >  \n");

            Console.WriteLine(" ⓛ 제목으로 찾기 ");
            Console.WriteLine(" ② 작가명으로 찾기");
            Console.WriteLine(" ③ 출판사명으로 찾기");

            Console.WriteLine(" 0을 입력해 돌아가기");
            int num;
            while (true)
            {
                num = int.Parse(Console.ReadLine());
                Regex regex = new Regex("^[0-3]$");
                string str = Convert.ToString(num);
                if (regex.IsMatch(str))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("0부터 3 사이의 값을 입력해 주세요.");
                }
            }

            int flag = 0;

            switch (num)
            {
                case 0:
                    Console.Clear();
                    managerMode.modOfManager();
                    break;
                case 1:
                    Console.Write("제목을 입력하세요 : ");
                    string title = Console.ReadLine();
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
