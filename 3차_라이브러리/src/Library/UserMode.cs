using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;

namespace Library
{

    internal class UserMode
    {
        BookData bookData = new BookData();
        public static int booklistnumber = 0;
        List<BookConstructor> BookList = new List<BookConstructor>();
        List<BookConstructor> rentedBooks = new List<BookConstructor>();
        List<BookConstructor> returnedBooks = new List<BookConstructor>();
        public void usermenu()
        { //로그인 또는 회원가입 메뉴

            Console.WriteLine("                      □■□■□■□■□■□■□■□■□■□");
            Console.WriteLine("                      ■                                  ■              ");
            Console.WriteLine("                      □                                  □              ");
            Console.WriteLine("                      ■          ① 도서 찾기            ■    ");
            Console.WriteLine("                      □                                  □              ");
            Console.WriteLine("                      ■          ② 도서 대여            ■    ");
            Console.WriteLine("                      □                                  □              ");
            Console.WriteLine("                      ■          ③ 도서 반납            ■    ");
            Console.WriteLine("                      □                                  □              ");
            Console.WriteLine("                      ■          ④ 도서 대여 확인       ■    ");
            Console.WriteLine("                      □                                  □              ");
            Console.WriteLine("                      ■          ⑤ 도서 반납 내역       ■    ");
            Console.WriteLine("                      □                                  □              ");
            Console.WriteLine("                      ■          ⑥ 회원 정보 수정       ■    ");
            Console.WriteLine("                      □                                  □            ");
            Console.WriteLine("                      ■          ⑦ 회원 탈퇴            ■                    ");
            Console.WriteLine("                      □                                  □               ");
            Console.WriteLine("                      ■         0을 눌러 돌아가기        ■               ");
            Console.WriteLine("                      □■□■□■□■□■□■□■□■□■□");


            Display display = new Display();
            int num = int.Parse(Console.ReadLine());
            switch (num)
            {

                case 0:
                    display.inputInfo();
                    break;

                case 1:
                    allBook();
                    searchBook();
                    usermenu();
                    break;

                case 2:
                    allBook();
                    borrowBook();
                    usermenu();
                    break;

                case 3:
                    borrowhistory();
                    returnBook();
                    usermenu();
                    break;

                case 4:
                    borrowhistory();
                    usermenu();
                    break;
                case 5:
                    returnhistory();
                    usermenu();
                    break;
                case 6:
                    modifyinfo();
                    usermenu();
                    break;
                case 7:
                    deleteinfo();
                    usermenu();
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
                Console.WriteLine("==================================================");
            }
        }


        public void searchBook()
        {
            BookData bookData = new BookData();  // BookData 객체 생성

            Console.WriteLine(" < 도서 찾기 >  \n");

            Console.WriteLine(" ⓛ 제목으로 찾기 ");
            Console.WriteLine(" ② 작가명으로 찾기");
            Console.WriteLine(" ③ 출판사명으로 찾기");

            int num = int.Parse(Console.ReadLine());

            switch (num)
            {
                case 1:
                    Console.Write("제목을 입력하세요 : ");
                    string title = Console.ReadLine();
                    foreach (var book in bookData.BookList)
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
                        if (book.bookName.IndexOf(authorname, StringComparison.OrdinalIgnoreCase) >= 0)
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
                        if (book.bookName.IndexOf(publishername, StringComparison.OrdinalIgnoreCase) >= 0)
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

        public void borrowBook()
        {
            Console.WriteLine("대여할 책 id를 입력하세요.");
            int inputBookId = int.Parse(Console.ReadLine());
            
            foreach (var book in bookData.BookList)
            {
                if (book.id == inputBookId)
                {
                    Console.WriteLine("대여 완료했습니다.");
                    rentedBooks.Add(book);
                    
                    break;
                }
            }
        }

        public void returnBook()
        {
            Console.WriteLine("반납할 책 id를 입력하세요.");
            int inputBookId2 = int.Parse(Console.ReadLine());
            foreach (var book in bookData.BookList)
            {
                if (book.id == inputBookId2)
                {
                    Console.WriteLine("반납 완료했습니다.");
                    returnedBooks.Add(book);
                    rentedBooks.Remove(book);
                    break;
                }
            }
        }

        public void borrowhistory()
        {
            foreach (BookConstructor book in rentedBooks)
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

        public void returnhistory()
        {
            foreach (BookConstructor book in returnedBooks)
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

        public void modifyinfo()
        {

            Console.WriteLine("어떤 정보를 수정하시겠습니까?");
            Console.WriteLine("1. password");
            Console.WriteLine("2. Name");
            Console.WriteLine("3. Age");
            Console.WriteLine("4. PhoneNumber");
            Console.WriteLine("5. Address");
            List<UserData> userList = new List<UserData>();

            int num= int.Parse(Console.ReadLine());
            switch (num)
            {
                case 1:
                    string pwinput = Console.ReadLine();
                    foreach (UserData user in userList)
                    {
                        user.password = pwinput;
                    }
                        
                    break;
                case 2:
                    string nameinput = Console.ReadLine();
                    foreach (UserData user in userList)
                    {
                        user.Name = nameinput;
                    }
                    break;
                case 3:
                    int ageinput = int.Parse(Console.ReadLine());
                    foreach (UserData user in userList)
                    {
                        user.Age = ageinput;
                    }
                    break;
                case 4:
                    int phoneinput = int.Parse(Console.ReadLine());
                    foreach (UserData user in userList)
                    {
                        user.PhoneNumber = phoneinput;
                    }
                    break;
                case 5:
                    int addressinput = int.Parse(Console.ReadLine());
                    foreach (UserData user in userList)
                    {
                        user.Address = addressinput;
                    }
                    break;
            }
            Console.WriteLine("정보가 수정되었습니다.");


        }

        public void deleteinfo()
        {
            List<UserData> userList = new List<UserData>();
            // 사용자가 대여한 도서가 있는지 확인합니다.
            bool hasRentedBooks = rentedBooks.Any(book => book.id > 0);

            if (hasRentedBooks)
            {
                Console.WriteLine("대여중인 도서가 있어 탈퇴할 수 없습니다.");
            }
            else
            {
                // 사용자 데이터를 UserData 클래스 내부의 Remove 메서드를 사용하여 삭제합니다.
                
            }
        }
    }
}
