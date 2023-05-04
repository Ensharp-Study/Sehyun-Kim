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
    internal class UserInfoUpdater
    {
        private BookData bookData;
        private UserData userData;

        public UserInfoUpdater(BookData bookData, UserData userData)
        {
            this.bookData = bookData;
            this.userData = userData;
        }
        

        public void modifyuserinfo()
        {
            PasswordMasker passwordMasker = new PasswordMasker();   
            Console.Clear();
            //현재 회원 정보를 표시함
            Console.WriteLine("현재 회원님의 정보를 표시합니다.");
            Console.WriteLine("=================================================");
            Console.WriteLine("  userid: " + userData.UserList[userlistnumber].userid);
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
                    
                    string pwinput = passwordMasker.HideConsoleInput(0, 15);
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
            Console.WriteLine("  userid: " + userData.UserList[userlistnumber].userid);
            Console.WriteLine("  Name: " + userData.UserList[userlistnumber].Name);
            Console.WriteLine("  Age: " + userData.UserList[userlistnumber].Age);
            Console.WriteLine("  PhoneNumber: " + userData.UserList[userlistnumber].PhoneNumber);
            Console.WriteLine("  Address: " + userData.UserList[userlistnumber].Address);
            Console.WriteLine("==================================================");

        }
    }
}
