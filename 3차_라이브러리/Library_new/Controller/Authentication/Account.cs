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
            MysqlConnecter mysqlConnecter = new MysqlConnecter();
            LoginSignupSelector loginSignupSelector = new LoginSignupSelector(bookData, userData);
            bool fine;
            /*
            fine = mysqlConnecter.SelectMysql();
            Console.Clear();

            if (fine)
            {
                //로그인 실패
                Console.Clear();
                loginSignupSelector.SelectLoginSignup();

            }
            else
            {
                //로그인 성공
                Console.Clear();
                userMenu.SelectNumberInUserMenu();
            }

            */
        }
        public void Register() //회원가입 
        {
            UserMenuDisplay viewMenu = new UserMenuDisplay();
            LoginSignupSelector loginSignupSelector = new LoginSignupSelector(bookData, userData);
            Constant.ManagerMenu menuConstant = new Constant.ManagerMenu(bookData, userData);
            PasswordMasker getHiddenConsoleInput = new PasswordMasker();
            UserMenu userMenu = new UserMenu(bookData, userData);
            NumberInputUser numberInputUser = new NumberInputUser();
            MysqlConnecter mysqlConnecter = new MysqlConnecter();

            mysqlConnecter.InsertMysql();
            Console.Clear();
            Console.WriteLine("회원가입 성공!");
            loginSignupSelector.SelectLoginSignup();
        }

        
    }
}
