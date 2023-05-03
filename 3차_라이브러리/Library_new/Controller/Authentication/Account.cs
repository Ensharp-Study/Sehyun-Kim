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
using Library.Controller.Form;
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
        private string idVariable;

        public string IdVariable
        {
            get { return idVariable; }
            set { idVariable = value; }
             
        }
        public void Login() //로그인
        {
            UserMenuDisplay userMenuDisplay = new UserMenuDisplay();
            NumberInputUser numberInputUser = new NumberInputUser();
            PasswordMasker getHiddenConsoleInput = new PasswordMasker();
            UserMenu userMenu = new UserMenu(bookData, userData);
            MysqlConnecter mysqlConnecter = new MysqlConnecter();
            LoginSignupSelector loginSignupSelector = new LoginSignupSelector(bookData, userData);
            InputSaverUnlessEnter inputSaverUnlessEnter = new InputSaverUnlessEnter();
            
            bool fine;
            //아이디 정규식 : 
            Console.WriteLine("아이디를 입력하세요.");
            string userid = inputSaverUnlessEnter.SaveInputUnlessEnter(@"^(?=.*[a-zA-Z])(?=.*\d)[a-zA-Z\d]{3,16}$", 0,27);
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("비밀번호를 입력하세요.");
            string inputPw = getHiddenConsoleInput.HideConsoleInput(0,29);
            inputSaverUnlessEnter.CheckPwRegex(inputPw, @"^[\p{L}\p{N}]+$", 0, 29);
            
            fine = mysqlConnecter.SelectMysql(userid, inputPw);
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
                idVariable = userid;
                userMenu.SelectNumberInUserMenu();
            }

            
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

            Console.Write("아이디를 입력하세요: ");
            string userid = Console.ReadLine();
            Console.Write("비밀번호를 입력하세요: ");
            string password = Console.ReadLine();
            Console.Write("이름을 입력하세요: ");
            string name = Console.ReadLine();
            Console.Write("나이를 입력하세요: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("전화번호를 입력하세요: ");
            string phonenumber = Console.ReadLine();
            Console.Write("주소를 입력하세요: ");
            string address = Console.ReadLine();

            mysqlConnecter.InsertMysql(userid,  password,  name,  age,  phonenumber,  address);
            Console.Clear();
            Console.WriteLine("회원가입 성공!");
            loginSignupSelector.SelectLoginSignup();
        }

        
    }
}
