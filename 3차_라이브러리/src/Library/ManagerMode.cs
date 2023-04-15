using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;
using Library;
using static Library.LoginOrNewmember;

namespace Library
{
    internal class ManagerMode
    {
        static int booklistnumber;
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
            Display display = new Display();
            int num = int.Parse(Console.ReadLine());
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
                case 5:
                    break;
                case 6:
                    break;

            }

        }
        public void allBook()
        {

            foreach (BookConstructor book in BookData.BookList)  //전체 도서 표시
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

            int num = int.Parse(Console.ReadLine());

            switch (num)
            {
                case 0:
                    Console.Clear();
                    modOfManager();
                    break;
                case 1:
                    Console.Write("제목을 입력하세요 : ");
                    string title = Console.ReadLine();
                    foreach (BookConstructor book in BookData.BookList)
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
                    foreach (var book in BookData.BookList)
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
                    foreach (var book in BookData.BookList)
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

            BookData.BookList.Add(new BookConstructor(id, bookName, author, publisher, quantity, price, publicationDate, isbn, info, rentpossible));

        }

        public void deletebookinfo()
        {
            Console.Clear();
            int i = 0;
            allBook();
            Console.WriteLine("삭제할 책 id를 입력하세요.");
            int inputBookId = int.Parse(Console.ReadLine());

            foreach (BookConstructor book in BookData.BookList)
            {
                i++;
                if (book.id == inputBookId)
                {
                    booklistnumber = i - 1;

                    BookData.BookList.RemoveAt(booklistnumber);
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
            DetermineWithRegularExpression determineWithRegularExpression = new DetermineWithRegularExpression();
            CheckInputIsEnter checkInputIsEnter = new CheckInputIsEnter();
            Console.WriteLine("수정할 책 id를 입력하세요.");
            int inputBookId = int.Parse(Console.ReadLine());
            int i = 0;

            foreach (BookConstructor book in BookData.BookList)
            {
                i++;
                if (book.id == inputBookId)
                {
                    Console.Clear();
                    Console.WriteLine("현재 해당 도서의 정보입니다.");
                    booklistnumber = i - 1;

                    Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■");
                    Console.WriteLine("  ID: " + BookData.BookList[booklistnumber].id);
                    Console.WriteLine("  Title: " + BookData.BookList[booklistnumber].bookName);
                    Console.WriteLine("  Author: " + BookData.BookList[booklistnumber].author);
                    Console.WriteLine("  Publisher: " + BookData.BookList[booklistnumber].publisher);
                    Console.WriteLine("  price: " + BookData.BookList[booklistnumber].price);
                    Console.WriteLine("  quantity: " + BookData.BookList[booklistnumber].quantity);
                    Console.WriteLine("  publicationDate: " + BookData.BookList[booklistnumber].publicationDate);
                    Console.WriteLine("  isbn: " + BookData.BookList[booklistnumber].isbn);
                    Console.WriteLine("  info: " + BookData.BookList[booklistnumber].info);
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
                    string randomExpression = "";
                    int isOrNot=0;
                    int Entercase = 0;
                    while (true)
                    {
                       KeyValuePair<string, int> result = checkInputIsEnter.SaveIDIfNotEnter(randomExpression, isOrNot);
                        randomExpression = result.Key;

                        if (result.Value == 1) { //엔터면 멈추기 엔터 아니면 계속 입력받기 
                            Entercase = 1;
                            break;
                        }
                    }
                    if (Entercase == 0)
                    {
                        determineWithRegularExpression.JudgeBookID(randomExpression); //형식에 맞는지 검사하기 
                    }
                    
                    
                    //ㅡㅡㅡㅡㅡㅡㅡTitleㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(8, 14);
                    randomExpression = "";
                    isOrNot = 0;
                    Entercase = 0;
                    while (true)
                    {
                        KeyValuePair<string, int> result = checkInputIsEnter.SaveIDIfNotEnter(randomExpression, isOrNot);
                        randomExpression = result.Key;

                        if (result.Value == 1)
                        {
                            Entercase = 1;//엔터면 멈추기 엔터 아니면 계속 입력받기 
                            break;
                        }
                    }
                    if (Entercase == 0)
                    {
                        determineWithRegularExpression.JudgeBookName(randomExpression); //형식에 맞는지 검사하기 
                    }

                    //ㅡㅡㅡㅡㅡㅡㅡauthorㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(9, 15);
                    randomExpression = "";
                    isOrNot = 0;
                    Entercase = 0;
                    while (true)
                    {
                        KeyValuePair<string, int> result = checkInputIsEnter.SaveIDIfNotEnter(randomExpression, isOrNot);
                        randomExpression = result.Key;

                        if (result.Value == 1)
                        { //엔터면 멈추기 엔터 아니면 계속 입력받기 
                            Entercase = 1;
                            break;
                        }
                    }
                    if (Entercase == 0)
                    {
                        determineWithRegularExpression.Judgeauthor(randomExpression); //형식에 맞는지 검사하기 
                    }
                    //ㅡㅡㅡㅡㅡㅡㅡㅡpublisherㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(12, 16);
                    randomExpression = "";
                    isOrNot = 0;
                    Entercase = 0;
                    while (true)
                    {
                        KeyValuePair<string, int> result = checkInputIsEnter.SaveIDIfNotEnter(randomExpression, isOrNot);
                        randomExpression = result.Key;

                        if (result.Value == 1)
                        { //엔터면 멈추기 엔터 아니면 계속 입력받기 
                            Entercase = 1;
                            break;
                        }
                    }
                    if (Entercase == 0)
                    {
                        determineWithRegularExpression.JudgePublisher(randomExpression); //형식에 맞는지 검사하기 
                    }
                    //ㅡㅡㅡㅡㅡㅡㅡㅡpriceㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(8, 17);
                    randomExpression = "";
                    isOrNot = 0;
                    Entercase = 0;
                    while (true)
                    {
                        KeyValuePair<string, int> result = checkInputIsEnter.SaveIDIfNotEnter(randomExpression, isOrNot);
                        randomExpression = result.Key;

                        if (result.Value == 1)
                        { //엔터면 멈추기 엔터 아니면 계속 입력받기 
                            Entercase = 1;
                            break;
                        }
                    }
                    if (Entercase == 0)
                    {
                        determineWithRegularExpression.Judgeprice(randomExpression); //형식에 맞는지 검사하기 
                    }
                    //ㅡㅡㅡㅡㅡㅡㅡㅡquantityㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(11, 18);
                    randomExpression = "";
                    isOrNot = 0;
                    Entercase = 0;
                    while (true)
                    {
                        KeyValuePair<string, int> result = checkInputIsEnter.SaveIDIfNotEnter(randomExpression, isOrNot);
                        randomExpression = result.Key;

                        if (result.Value == 1)
                        { //엔터면 멈추기 엔터 아니면 계속 입력받기
                            Entercase = 1;
                            break;
                        }
                    }
                    if (Entercase == 0)
                    {
                        determineWithRegularExpression.Judgequantity(randomExpression); //형식에 맞는지 검사하기 
                    }
                    //ㅡㅡㅡㅡㅡㅡㅡㅡpublcationㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(18, 19);
                    randomExpression = "";
                    isOrNot = 0;
                    Entercase = 0;
                    while (true)
                    {
                        KeyValuePair<string, int> result = checkInputIsEnter.SaveIDIfNotEnter(randomExpression, isOrNot);
                        randomExpression = result.Key;

                        if (result.Value == 1)
                        { //엔터면 멈추기 엔터 아니면 계속 입력받기 
                            Entercase = 1;
                            break;
                        }
                    }
                    if (Entercase == 0)
                    {
                        determineWithRegularExpression.JudgepublicationDate(randomExpression); //형식에 맞는지 검사하기 
                    }
                    //ㅡㅡㅡㅡㅡㅡㅡㅡisbnㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(7, 20);
                    randomExpression = "";
                    isOrNot = 0;
                    Entercase = 0;
                    while (true)
                    {
                        KeyValuePair<string, int> result = checkInputIsEnter.SaveIDIfNotEnter(randomExpression, isOrNot);
                        randomExpression = result.Key;

                        if (result.Value == 1)
                        { //엔터면 멈추기 엔터 아니면 계속 입력받기
                            Entercase = 1;
                            break;
                        }
                    }
                    if (Entercase == 0)
                    {
                        determineWithRegularExpression.Judgeisbn(randomExpression); //형식에 맞는지 검사하기 
                    }
                    //ㅡㅡㅡㅡㅡㅡㅡㅡinfoㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(7, 21);
                    randomExpression = "";
                    isOrNot = 0;
                    Entercase = 0;
                    while (true)
                    {
                        KeyValuePair<string, int> result = checkInputIsEnter.SaveIDIfNotEnter(randomExpression, isOrNot);
                        randomExpression = result.Key;

                        if (result.Value == 1)
                        { //엔터면 멈추기 엔터 아니면 계속 입력받기 
                            Entercase = 1;
                            break;
                        }
                    }
                    if (Entercase == 0)
                    {
                        determineWithRegularExpression.Judgeinfo(randomExpression); //형식에 맞는지 검사하기 
                    }
                    /*
                    Console.WriteLine("수정하고 싶은 번호를 입력하세요.");
                    Console.WriteLine("1. id");
                    Console.WriteLine("2. bookName");
                    Console.WriteLine("3. author");
                    Console.WriteLine("4. publisher");
                    Console.WriteLine("5. quantity");
                    Console.WriteLine("6. price");
                    Console.WriteLine("7. publicationDate");
                    Console.WriteLine("8. isbn");
                    Console.WriteLine("9. info");
                    Console.WriteLine("0을 눌러 돌아가기");

                    int num = int.Parse(Console.ReadLine());
                    
                        switch (num)
                    {
                        case 0:
                            modOfManager();
                            break;
                        case 1:
                            Console.WriteLine("새로운 id를 입력하세요.");
                            int idinput = int.Parse(Console.ReadLine());
                            BookData.BookList[booklistnumber].id=idinput;
                            break;
                        case 2:
                            Console.WriteLine("새로운 이름을 입력하세요.");
                            string nameinput = Console.ReadLine();
                            BookData.BookList[booklistnumber].bookName = nameinput;
                            break;
                        case 3:
                            Console.WriteLine("새로운 작가명을 입력하세요.");
                            string authorinput = Console.ReadLine();
                            BookData.BookList[booklistnumber].author = authorinput;
                            break;
                        case 4:
                            Console.WriteLine("새로운 출판사명을 입력하세요.");
                            string publisherinput = Console.ReadLine();
                            BookData.BookList[booklistnumber].publisher = publisherinput;
                            break;
                        case 5:
                            Console.WriteLine("새로운 수량을 입력하세요.");
                            int quantityinput = int.Parse(Console.ReadLine());
                            BookData.BookList[booklistnumber].quantity = quantityinput;
                            break;
                        case 6:
                            Console.WriteLine("새로운 가격을 입력하세요.");
                            int priceinput = int.Parse(Console.ReadLine());
                            BookData.BookList[booklistnumber].price = priceinput;
                            break;
                        case 7:
                            Console.WriteLine("새로운 출판일자를 입력하세요.");
                            string publicationDateinput = Console.ReadLine();
                            BookData.BookList[booklistnumber].publicationDate = publicationDateinput;
                            break;
                        case 8:
                            Console.WriteLine("새로운 isbn을 입력하세요.");
                            string isbninput = Console.ReadLine();
                            BookData.BookList[booklistnumber].isbn = isbninput;
                            break;
                        case 9:
                            Console.WriteLine("새로운 정보를 입력하세요.");
                            string infoinput = Console.ReadLine();
                            BookData.BookList[booklistnumber].info = infoinput;
                            break;
                    }
                    Console.WriteLine("정보가 수정되었습니다.");

                    break;
                }
                    */
                }




            }
        }
    }
}
