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

namespace Library.Controller
{
    
    internal class Account
    {
        public static int userlistnumber; 
        public static int flag;
        

        private BookData bookData;
        private UserData userData;

        AccountView userSignUpDisplay;

        public Account(BookData bookData, UserData userData)
        {
            this.bookData = bookData;
            this.userData = userData;
            userSignUpDisplay = new AccountView();
        }
        
        public void Login() //로그인
        {
            UserMenuDisplay userMenuDisplay = new UserMenuDisplay();
            NumberInputUser numberInputUser = new NumberInputUser();
            PasswordMasker getHiddenConsoleInput = new PasswordMasker();
            UserMenu userMenu = new UserMenu(bookData, userData);

            Console.WriteLine("아이디를 입력하세요.");
            string inputId = Console.ReadLine();

            Console.WriteLine("비밀번호를 입력하세요.");
            string inputPw = getHiddenConsoleInput.HideConsoleInput();

            bool isLogin = false;
            

            int count = 0;
            int number=0;
            foreach (var user in this.userData.UserList)
            {
                count++;
                if (user.userid == inputId && user.password == inputPw)
                {
                    Console.Clear();
                    Console.WriteLine("로그인 성공!");
                    
                    isLogin = true;
                    userlistnumber = count-1;
                    count = 0;
                    userMenu.SelectNumberInUserMenu();
                    break;
                }
            }

            if (!isLogin)
            {
                Console.Clear();
                Console.WriteLine("로그인 실패. 아이디 또는 비밀번호가 일치하지 않습니다.");
                userSignUpDisplay.ViewAccountMenu();
            }

        }
        public void Register() //회원가입 
        {
            UserMenuDisplay viewMenu = new UserMenuDisplay();
            Constant.ManagerMenu menuConstant = new Constant.ManagerMenu(bookData, userData);
            PasswordMasker getHiddenConsoleInput = new PasswordMasker();
            UserMenu userMenu = new UserMenu(bookData, userData);
            NumberInputUser numberInputUser = new NumberInputUser();

            int number = 0;
            flag++;
            Console.Write(" id : ");
            string userid = Console.ReadLine();
            Console.Write("Password : ");
            string password = getHiddenConsoleInput.HideConsoleInput();
            Console.Write("Name : ");
            string Name = Console.ReadLine();
            Console.Write("Age : ");
            int Age = int.Parse(Console.ReadLine());
            Console.Write("PhoneNumber : ");
            int PhoneNumber = int.Parse(Console.ReadLine());
            Console.Write(" Address : ");
            string Address = Console.ReadLine();

            userData.UserList.Add(new UserConstructor(userid, password, Name, Age, PhoneNumber, Address));
            Console.Clear();
            Console.WriteLine("회원가입 성공!");
            userMenu.SelectNumberInUserMenu();
        }

        
    }
}
