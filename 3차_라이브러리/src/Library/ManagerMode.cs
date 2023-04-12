using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;

namespace Library
{
    internal class ManagerMode
    {
        Display display = new Display();
        BookData bookData = new BookData();
        UserMode mode = new UserMode();
        public List<BookConstructor> BookList = new List<BookConstructor>();

        //설계 단계에서 상속 생각하고 설계하기 
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

            int num = int.Parse(Console.ReadLine());
            switch (num)
            {
                case 0:
                    display.InitialDisplay();
                    break;
                case 1:
                    //함수로 빼기 
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
                        Console.WriteLine("==================================================");
                    }
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
        public void searchBook()
        {
            BookData bookData = new BookData();  // BookData 객체 생성

            Console.WriteLine(" < 도서 찾기 >  \n");

            Console.WriteLine(" ⓛ 제목으로 찾기 ");
            Console.WriteLine(" ② 작가명으로 찾기");
            Console.WriteLine(" ③ 출판사명으로 찾기");

            Console.WriteLine(" 0을 입력해 돌아가기");

            int num = int.Parse(Console.ReadLine());

            switch (num)
            {
                case 0:
                    modOfManager();
                    break;
                case 1: //함수로 빼기 매직넘버 mvc 패턴 
                    Console.Write("제목을 입력하세요 : ");
                    string title = Console.ReadLine();
                    foreach (BookConstructor book in bookData.BookList)
                    {
                        if (book.bookName.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
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


                    break;
                case 2:
                    Console.Write("작가명을 입력하세요 : ");
                    string authorname = Console.ReadLine();
                    foreach (var book in bookData.BookList)
                    {
                        if (book.author.IndexOf(authorname, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
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

                    break;
                case 3:
                    Console.Write("출판사명을 입력하세요 : ");
                    string publishername = Console.ReadLine();
                    foreach (var book in bookData.BookList)
                    {
                        if (book.publisher.IndexOf(publishername, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
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

                    break;


            }


        }
        public void appendbook()
        {
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

            bookData.BookList.Add(new BookConstructor(id, bookName, author, publisher, quantity, price, publicationDate, isbn, info));
            
        }

        public void deletebookinfo()
        {
            BookData bookData = new BookData();
            Console.WriteLine("삭제할 책 id를 입력하세요.");
            int inputBookId = int.Parse(Console.ReadLine());
            //(BookConstructor book in bookData.BookList)
            foreach (BookConstructor book in bookData.BookList)
            {
                if (book.id == inputBookId)
                {
                    bookData.BookList.Remove(book);
                    break;
                }
            }
        }//if (book.id.IndexOf(inputBookID, StringComparison.OrdinalIgnoreCase) >= 0)

        public void modifyinfo()
        {
            Console.WriteLine("어떤 정보를 수정하시겠습니까?");
            Console.WriteLine("1. id");
            Console.WriteLine("2. bookName");
            Console.WriteLine("3. author");
            Console.WriteLine("4. publisher");
            Console.WriteLine("5. quantity");
            Console.WriteLine("6. price");
            Console.WriteLine("7. publicationDate");
            Console.WriteLine("8. isbn");
            Console.WriteLine("9. info");
            List<BookConstructor> BookList = new List<BookConstructor>();

            int num = int.Parse(Console.ReadLine());
            switch (num)
            {
                case 1:
                    int idinput = int.Parse(Console.ReadLine());
                    foreach (BookConstructor Book in BookList)
                    {
                        Book.id = idinput;
                    }

                    break;
                case 2:
                    string nameinput = Console.ReadLine();
                    foreach (BookConstructor Book in BookList)
                    {
                        Book.bookName = nameinput;
                    }
                    break;
                case 3:
                    string authorinput =  Console.ReadLine();
                    foreach (BookConstructor Book in BookList)
                    {
                        Book.author = authorinput;
                    }
                    break;
                case 4:
                    string publisherinput = Console.ReadLine();
                    foreach (BookConstructor Book in BookList)
                    {
                        Book.publisher = publisherinput;
                    }
                    break;
                case 5:
                    int quantityinput = int.Parse(Console.ReadLine());
                    foreach (BookConstructor Book in BookList)
                    {
                        Book.quantity = quantityinput;
                    }
                    break;
                case 6:
                    int priceinput = int.Parse(Console.ReadLine());
                    foreach (BookConstructor Book in BookList)
                    {
                        Book.price = priceinput;
                    }
                    break;
                case 7:
                    string publicationDateinput = Console.ReadLine();
                    foreach (BookConstructor Book in BookList)
                    {
                        Book.publicationDate = publicationDateinput;
                    }
                    break;
                case 8:
                    string isbninput = Console.ReadLine();
                    foreach (BookConstructor Book in BookList)
                    {
                        Book.isbn = isbninput;
                    }
                    break;
                case 9:
                    string infoinput = Console.ReadLine();
                    foreach (BookConstructor Book in BookList)
                    {
                        Book.info = infoinput;
                    }
                    break;
            }
            Console.WriteLine("정보가 수정되었습니다.");
        }
    }
}
