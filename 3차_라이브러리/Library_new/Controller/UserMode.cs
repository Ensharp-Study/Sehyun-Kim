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

    internal class UserMode
    {
        
        public static int booklistnumber = 0;
        private BookData bookData;
        private UserData userData;

        public UserMode(BookData bookData, UserData userData)
        {
            this.bookData = bookData;
            this.userData = userData;
        }

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

            HomeDisplay display = new HomeDisplay(); 
            
            Regex regex = new Regex("^[0-7]$"); // 정규식 패턴
            int num;
            while (true)
            {
                num = int.Parse(Console.ReadLine());
                string str = Convert.ToString(num);
                if (!regex.IsMatch(str))
                {
                    Console.WriteLine("0-7 사이의 값을 입력해주세요");
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
                    
                    returnBook();
                    usermenu();
                    break;

                case 4:
                    Console.Clear();
                    borrowhistory();
                    usermenu();
                    break;
                case 5:
                    Console.Clear();
                    returnhistory();
                    usermenu();
                    break;
                case 6:
                    modifyinfo();
                    usermenu();
                    break;
                case 7:
                    deleteinfo();
                    
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

            Console.WriteLine(" < 도서 찾기 >  \n");

            Console.WriteLine(" ⓛ 제목으로 찾기 ");
            Console.WriteLine(" ② 작가명으로 찾기");
            Console.WriteLine(" ③ 출판사명으로 찾기");
            Console.WriteLine(" 0을 눌러 돌아가기");

            int num = int.Parse(Console.ReadLine());

            switch (num)
            {
                case 0:
                    Console.Clear();
                    usermenu();
                    break;
                case 1:
                    Console.Write("제목을 입력하세요 : ");
                    string title = Console.ReadLine();
                    foreach (var book in bookData.BookList)
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
                        }
                    }

                    break;


            }


        }

        public void borrowBook()
        {
            Console.Clear();
            allBook();
            Console.WriteLine("대여할 책 id를 입력하세요.");
            Console.WriteLine("(뒤로 가려면 0을 누르세요.)");
            int inputBookId = int.Parse(Console.ReadLine());
            if (inputBookId == 0)
            {
                Console.Clear();
                usermenu();

            }
            int i = 0;
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

        public void returnBook()
        {
            borrowhistory();
            Console.WriteLine("반납할 책 id를 입력하세요.");
            Console.WriteLine("(뒤로 가려면 0을 누르세요.)");
            int inputBookId2 = int.Parse(Console.ReadLine());

            if (inputBookId2 == 0)
            {
                Console.Clear();
                usermenu();

            }
            int i = 0;
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
        }//userlistnumber로 해당회원리스트접근가능 
        //패키징하면데이터x const
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
        
        public void returnhistory()
        {
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
        }
        
        public void modifyinfo()
        { 
            
            Console.Clear();
            //현재 회원 정보를 표시함
            Console.WriteLine("현재 회원님의 정보를 표시합니다.");
            Console.WriteLine("=================================================");
                Console.WriteLine("  userid: " + userData.UserList[userlistnumber].UserId);
                Console.WriteLine("  Name: " + userData.UserList[userlistnumber].Name);
                Console.WriteLine("  Age: " + userData.UserList[userlistnumber].Age);
                Console.WriteLine("  PhoneNumber: " + userData.UserList[userlistnumber].PhoneNumber);
                Console.WriteLine("  Address: " + userData.UserList[userlistnumber].Address);
                Console.WriteLine("==================================================");
            
            Console.WriteLine("어떤 정보를 수정하시겠습니까?");
            
            Console.WriteLine("1. password");
            Console.WriteLine("2. Name");
            Console.WriteLine("3. Age");
            Console.WriteLine("4. PhoneNumber");
            Console.WriteLine("5. Address");
            //userlistnumber 로그인 클래스에서 받아서 저장되어있음
            int num= int.Parse(Console.ReadLine());
            Console.Clear();
            switch (num)
            {
                case 1:
                    Console.WriteLine("새로운 패스워드를 입력하세요.");
                    string pwinput = GetHiddenConsoleInput();
                    userData.UserList[userlistnumber].password = pwinput;
                        
                    break;
                case 2:
                    Console.WriteLine("새로운 이름을 입력하세요.");
                    string nameinput = Console.ReadLine();
                    userData.UserList[userlistnumber].Name = nameinput;
                    break;
                case 3:
                    Console.WriteLine("새로운 나이를 입력하세요.");
                    int ageinput = int.Parse(Console.ReadLine());
                    userData.UserList[userlistnumber].Age = ageinput;
                    break;
                case 4:
                    Console.WriteLine("새로운 전화번호를 입력하세요.");
                    int phoneinput = int.Parse(Console.ReadLine());
                    userData.UserList[userlistnumber].PhoneNumber = phoneinput;
                    break;
                case 5:
                    Console.WriteLine("새로운 주소를 입력하세요.");
                    string addressinput = Console.ReadLine();
                    userData.UserList[userlistnumber].Address = addressinput;
                    break;
            }
            Console.Clear();
            Console.WriteLine("정보가 수정되었습니다.");
            Console.WriteLine("수정된 회원님의 정보를 표시합니다.");
            Console.WriteLine("=================================================");
            Console.WriteLine("  userid: " + userData.UserList[userlistnumber].UserId);
            Console.WriteLine("  Name: " + userData.UserList[userlistnumber].Name);
            Console.WriteLine("  Age: " + userData.UserList[userlistnumber].Age);
            Console.WriteLine("  PhoneNumber: " + userData.UserList[userlistnumber].PhoneNumber);
            Console.WriteLine("  Address: " + userData.UserList[userlistnumber].Address);
            Console.WriteLine("==================================================");

        }
        public string GetHiddenConsoleInput()
        {
            string input = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    input += key.KeyChar;
                    Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        input = input.Substring(0, (input.Length - 1));
                        ClearLine(Console.CursorLeft, Console.CursorTop);
                        Write(new string(' ', Console.WindowWidth));
                        ClearLine(Console.CursorLeft, Console.CursorTop);
                        for (int i = 0; i < input.Length; i++)
                        {
                            Write("*");
                        }
                    }
                }
            } while (key.Key != ConsoleKey.Enter);
            return input;
        }
        private void ClearLine(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(left, top);
        }
        public void deleteinfo()
        {
            Console.Clear();
            HomeDisplay display = new HomeDisplay();
            List<UserConstructor> userList = new List<UserConstructor>();
            // 사용자가 대여한 도서가 있는지 확인
            bool hasRentedBooks = userData.UserList[userlistnumber].rentedbooklist.Any(book => book.id > 0);

            if (hasRentedBooks)
            {
                Console.WriteLine("대여중인 도서가 있어 탈퇴할 수 없습니다.");
            }
            else
            {
                userData.UserList.RemoveAt(userlistnumber);
                Console.WriteLine("회원 탈퇴되었습니다.");
                display.InitialDisplay();
                
            }
        }
    }
}