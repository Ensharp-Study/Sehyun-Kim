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
        

        AccountView userSignUpDisplay;

        
        public Account(string userid)
        {
            this.userid = userid;
        }

        private string userid;

        public string Userid
        {
            get { return userid; }
            set { userid = value; }
        }
        public void Login() //로그인
        {
            UserMenuDisplay userMenuDisplay = new UserMenuDisplay();
            NumberInputUser numberInputUser = new NumberInputUser();
            PasswordMasker getHiddenConsoleInput = new PasswordMasker();
            UserMenu userMenu = new UserMenu();
            CRUDInDAO mysqlConnecter = new CRUDInDAO();
            LoginSignupSelector loginSignupSelector = new LoginSignupSelector();
            InputSaverUnlessEnter inputSaverUnlessEnter = new InputSaverUnlessEnter();
            
            bool fine;
            //아이디 정규식 : 
            Console.WriteLine("아이디를 입력하세요.");
            Userid = inputSaverUnlessEnter.SaveInputUnlessEnter("^[a-zA-Z0-9]{4,16}$", 0,27);
            
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("비밀번호를 입력하세요.");
            string inputPw = getHiddenConsoleInput.HideConsoleInput(0,29);
            inputSaverUnlessEnter.CheckPwRegex(inputPw, @"^[\p{L}\p{N}]+$", 0, 29);
            
            fine = mysqlConnecter.SelectData($"SELECT * FROM userconstructor WHERE userid = '{userid}' AND password = '{inputPw}'");
            Console.Clear();

            if (fine) //로그인 실패
            {
                Console.Clear();
                loginSignupSelector.SelectLoginSignup();

            }
            else //로그인 성공 
            {
                Console.Clear();
                userMenu.SelectNumberInUserMenu(Userid);
            }

            
        }
        
        
        public void Register() //회원가입 
        {
            UserMenuDisplay viewMenu = new UserMenuDisplay();
            LoginSignupSelector loginSignupSelector = new LoginSignupSelector();
            Constant.ManagerMenu menuConstant = new Constant.ManagerMenu();
            PasswordMasker getHiddenConsoleInput = new PasswordMasker();
            UserMenu userMenu = new UserMenu();
            NumberInputUser numberInputUser = new NumberInputUser();
            InputSaverUnlessEnter inputSaverUnlessEnter = new InputSaverUnlessEnter();
            CRUDInDAO mysqlConnecter = new CRUDInDAO();

            Console.Clear();
            Console.Write("아이디를 입력하세요: ");
            
            string userid = inputSaverUnlessEnter.SaveInputUnlessEnter("^[a-zA-Z0-9]{4,16}$", 30, 0);

            Console.SetCursorPosition(0, 1);
            Console.Write("비밀번호를 입력하세요: ");
            string password = inputSaverUnlessEnter.SaveInputUnlessEnter(@"^[\p{L}\p{N}]+$", 25, 1);

            Console.SetCursorPosition(0, 4);
            Console.Write("이름을 입력하세요: ");
            string name = inputSaverUnlessEnter.SaveInputUnlessEnter(@"^[가-힣]{2,4}$", 0, 5);

            Console.Write("나이를 입력하세요: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("전화번호를 입력하세요: ");
            string phonenumber = Console.ReadLine();
            Console.Write("주소를 입력하세요: ");
            string address = Console.ReadLine();
            bool fine = true;

            fine = mysqlConnecter.InsertUpdateDelete($"INSERT INTO userconstructor(userid, password, name, age, phonenumber, address) VALUES('{userid}', '{password}', '{name}', {age}, '{phonenumber}', '{address}')");
            /*
            mysqlConnecter.InsertMysql(userid,  password,  name,  age,  phonenumber,  address);
            
            Console.Clear();
            Console.WriteLine("회원가입 성공!");
            */
            Console.Clear();
            if (fine)
            {
                Console.WriteLine("회원가입 성공!");
            }
            loginSignupSelector.SelectLoginSignup();
        }

        
    }
}
