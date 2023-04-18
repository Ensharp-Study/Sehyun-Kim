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
    internal class ModifyInfo
    {
        private BookData bookData;
        private UserData userData;

        public ModifyInfo(BookData bookData, UserData userData)
        {
            this.bookData = bookData;
            this.userData = userData;
        }
        
        public void modifyBookInfo()
        {
            Console.Clear();
            ShowAllBook showAllBook = new ShowAllBook(bookData, userData);
            showAllBook.allBook();
            ViewRulesForBookData viewRulesForBookData = new ViewRulesForBookData();
            DetermineWithRegularExpression determineWithRegularExpression = new DetermineWithRegularExpression(bookData, userData);
            CheckInputIsEnter checkInputIsEnter = new CheckInputIsEnter(bookData, userData);
            ShowForUpdateBookInfo showForUpdateBookInfo = new ShowForUpdateBookInfo(bookData, userData);

            Console.WriteLine("수정할 책 id를 입력하세요.");
            int inputBookId = int.Parse(Console.ReadLine());
            int booklistnumber = 0;
            int i = 0;
            int flag = 0;
            foreach (BookConstructor book in bookData.BookList)
            {
                i++;
                if (book.id == inputBookId)
                {
                    Console.Clear();
                    booklistnumber = i - 1;
                    showForUpdateBookInfo.ViewForUpdateBookInfo(booklistnumber);
                    viewRulesForBookData.RulesForBookData();

                    //ㅡㅡㅡㅡㅡㅡㅡIDㅡㅡㅡㅡㅡㅡㅡㅡㅡ 
                    Console.SetCursorPosition(5, 13);
                    string randomExpression = "";
                    int Entercase = 0;
                    int TypeCheck = 0;
                    checkInputIsEnter.SaveIDIfNotEnter(randomExpression, Entercase, booklistnumber);

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
                    flag = 1;
                }


            }
            Console.Clear();
            if (flag == 1)
            {
                Console.WriteLine("정보가 성공적으로 수정되었습니다.");
            }
        }

        public void modifyuserinfo()
        {
            LoginOrNewmember loginOrNewmember = new LoginOrNewmember(bookData, userData);
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
            int num = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (num)
            {
                case 1:
                    Console.WriteLine("새로운 패스워드를 입력하세요.");
                    string pwinput = loginOrNewmember.GetHiddenConsoleInput();
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
    }
}
