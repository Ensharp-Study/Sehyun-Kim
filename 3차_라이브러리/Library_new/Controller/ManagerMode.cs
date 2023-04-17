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
    internal class ManagerMode
    {
        static int booklistnumber;
        private BookData bookData;
        private UserData userData;

        public ManagerMode(BookData bookData, UserData userData)
        {
            this.bookData = bookData;
            this.userData = userData;
        }
        public void modOfManager()
        {
            Console.WriteLine("                      □■□■□■□■□■□■□■□■□■□");
            Console.WriteLine("                      ■                                  ■              ");
            Console.WriteLine("                      □                                  □              ");
            Console.WriteLine("                      ■          ① 도서 찾기            ■    ");
            Console.WriteLine("                      □                                  □              ");
            Console.WriteLine("                      ■                                  ■    ");
            Console.WriteLine("                      □                                  □              ");
            Console.WriteLine("                      ■          ② 도서 추가            ■    ");
            Console.WriteLine("                      □                                  □              ");
            Console.WriteLine("                      ■                                  ■    ");
            Console.WriteLine("                      □                                  □              ");
            Console.WriteLine("                      ■          ③ 도서 삭제            ■    ");
            Console.WriteLine("                      □                                  □              ");
            Console.WriteLine("                      ■                                  ■    ");
            Console.WriteLine("                      □                                  □            ");
            Console.WriteLine("                      ■          ④ 도서 수정            ■                    ");
            Console.WriteLine("                      □                                  □               ");
            Console.WriteLine("                      ■        0을 입력해 돌아가기       ■               ");
            Console.WriteLine("                      □■□■□■□■□■□■□■□■□■□");
            HomeDisplay display = new HomeDisplay();
            
            
            Regex regex = new Regex("^[0-4]$"); // 정규식 패턴
            int num;
            while (true)
            {
                num = int.Parse(Console.ReadLine());
                string str = Convert.ToString(num);
                if (!regex.IsMatch(str))
                {
                    Console.WriteLine("0-4 사이의 값을 입력해주세요.");
                }
                else if (regex.IsMatch(str))
                {
                    break;
                }
            }
            
            
            switch (num)
            {
                case 0:
                    Console.Clear();
                    display.InitialDisplay();
                    break;
                case 1:

                    searchBook();
                    modOfManager();
                    break;
                case 2:
                    appendbook();
                    modOfManager();
                    break;
                case 3:
                    deletebookinfo();
                    modOfManager();
                    break;
                case 4:
                    modifyinfo();
                    modOfManager();
                    break;


            }

        }
        public void allBook()
        {

            foreach (BookConstructor book in bookData.BookList)  //전체 도서 표시
            {
                Console.WriteLine("=================================================");
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
                Console.WriteLine("==================================================");
            }
        }



        public void searchBook()
        {
            Console.Clear();
            allBook();
            Console.WriteLine(" < 도서 찾기 >  \n");

            Console.WriteLine(" ⓛ 제목으로 찾기 ");
            Console.WriteLine(" ② 작가명으로 찾기");
            Console.WriteLine(" ③ 출판사명으로 찾기");

            Console.WriteLine(" 0을 입력해 돌아가기");
            int num;
            while (true)
            {
                num= int.Parse(Console.ReadLine());
                Regex regex = new Regex("^[1-3]$");
                string str = Convert.ToString(num);
                if (regex.IsMatch(str))
                {
                    break ;
                }
                else
                {
                    Console.WriteLine("입력한 값이 1, 2, 또는 3이 아닙니다.");
                }
            }

            int flag = 0;

            switch (num)
            {
                case 0:
                    Console.Clear();
                    modOfManager();
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
        public void appendbook()
        {
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

            bookData.BookList.Add(new BookConstructor(id, bookName, author, publisher, quantity, price, publicationDate, isbn, info, rentpossible));

        }

        public void deletebookinfo()
        {
            Console.Clear();
            int i = 0;
            allBook();
            Console.WriteLine("삭제할 책 id를 입력하세요.");
            int inputBookId = int.Parse(Console.ReadLine());

            foreach (BookConstructor book in bookData.BookList)
            {
                i++;
                if (book.id == inputBookId)
                {
                    booklistnumber = i - 1;

                    bookData.BookList.RemoveAt(booklistnumber);
                    i = 0;
                    Console.Clear();
                    Console.WriteLine("도서가 삭제되었습니다.");



                    break;
                }
            }
        }//if (book.id.IndexOf(inputBookID, StringComparison.OrdinalIgnoreCase) >= 0)

        public void modifyinfo()
        {
            Console.Clear();
            allBook();
            ViewRulesForBookData viewRulesForBookData = new ViewRulesForBookData();
            DetermineWithRegularExpression determineWithRegularExpression = new DetermineWithRegularExpression(bookData, userData);
            CheckInputIsEnter checkInputIsEnter = new CheckInputIsEnter(bookData, userData);
            Console.WriteLine("수정할 책 id를 입력하세요.");
            int inputBookId = int.Parse(Console.ReadLine());
            int i = 0;

            foreach (BookConstructor book in bookData.BookList)
            {
                i++;
                if (book.id == inputBookId)
                {
                    Console.Clear();
                    Console.WriteLine("현재 해당 도서의 정보입니다.");
                    booklistnumber = i - 1;

                    Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■");
                    Console.WriteLine("  ID: " + bookData.BookList[booklistnumber].id);
                    Console.WriteLine("  Title: " + bookData.BookList[booklistnumber].bookName);
                    Console.WriteLine("  Author: " + bookData.BookList[booklistnumber].author);
                    Console.WriteLine("  Publisher: " + bookData.BookList[booklistnumber].publisher);
                    Console.WriteLine("  price: " + bookData.BookList[booklistnumber].price);
                    Console.WriteLine("  quantity: " + bookData.BookList[booklistnumber].quantity);
                    Console.WriteLine("  publicationDate: " + bookData.BookList[booklistnumber].publicationDate);
                    Console.WriteLine("  isbn: " + bookData.BookList[booklistnumber].isbn);
                    Console.WriteLine("  info: " + bookData.BookList[booklistnumber].info);
                    Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■");
                    Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■");
                    Console.WriteLine("  ID: ");
                    Console.WriteLine("  Title: ");
                    Console.WriteLine("  Author: ");
                    Console.WriteLine("  Publisher: ");
                    Console.WriteLine("  price: ");
                    Console.WriteLine("  quantity: ");
                    Console.WriteLine("  publicationDate: ");
                    Console.WriteLine("  isbn: ");
                    Console.WriteLine("  info: ");
                    Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■");
                    viewRulesForBookData.RulesForBookData();

                    //ㅡㅡㅡㅡㅡㅡㅡIDㅡㅡㅡㅡㅡㅡㅡㅡㅡ 

                    Console.SetCursorPosition(5, 13);
                    string randomExpression = ""; //임의의 식 변수 
                    int Entercase = 0;
                    int TypeCheck = 0;
                    checkInputIsEnter.SaveIDIfNotEnter(randomExpression, Entercase,booklistnumber);

                    
                    //ㅡㅡㅡㅡㅡㅡㅡTitleㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(8, 14);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    checkInputIsEnter.SaveTitleIfNotEnter(randomExpression, Entercase, booklistnumber);

                    //ㅡㅡㅡㅡㅡㅡㅡauthorㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(9, 15);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    checkInputIsEnter.SaveAuthorIfNotEnter(randomExpression, Entercase, booklistnumber);
                    //ㅡㅡㅡㅡㅡㅡㅡㅡpublisherㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(12, 16);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    checkInputIsEnter.SavePublisherIfNotEnter(randomExpression, Entercase, booklistnumber);
                    //ㅡㅡㅡㅡㅡㅡㅡㅡpriceㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(8, 17);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    checkInputIsEnter.SavePriceIfNotEnter(randomExpression, Entercase, booklistnumber);
                    //ㅡㅡㅡㅡㅡㅡㅡㅡquantityㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(11, 18);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    checkInputIsEnter.SaveQuantityIfNotEnter(randomExpression, Entercase, booklistnumber);
                    //ㅡㅡㅡㅡㅡㅡㅡㅡpublcationㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(18, 19);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    checkInputIsEnter.SavePublicationIfNotEnter(randomExpression, Entercase, booklistnumber);
                    //ㅡㅡㅡㅡㅡㅡㅡㅡisbnㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(7, 20);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    checkInputIsEnter.SaveIsbnIfNotEnter(randomExpression, Entercase, booklistnumber);
                    //ㅡㅡㅡㅡㅡㅡㅡㅡinfoㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(7, 21);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    checkInputIsEnter.SaveInfoIfNotEnter(randomExpression, Entercase, booklistnumber);
                    
                }




            }
            }
        }
    }

