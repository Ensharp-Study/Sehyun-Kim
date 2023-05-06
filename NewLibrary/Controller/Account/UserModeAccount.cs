using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Controller;
using Library.View;
using NewLibrary.Constant;
using NewLibrary.Utility;

namespace NewLibrary.Controller
{
    internal class UserModeAccount
    {
        public UserModeAccount(string userId)
        {
            this.userId = userId;
        }
        private string userId;

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public string UserLogin() //로그인
        {
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            PasswordMasker passwordMasker = new PasswordMasker();
            CRUDInDAO mysqlConnecter = new CRUDInDAO();
            while (true)
            {
                string inputId = "";
                string inputPw = "";
                bool fine = true;
                bool check = true;
                while (fine)
                {
                    inputId = inputKeyUnlessEnter.SaveInputUnlessEnter(20, 14);
                    Console.SetCursorPosition(16, 16);
                    Console.Write("                        ");
                    Console.SetCursorPosition(15, 17);
                    Console.Write("                        ");
                    fine = inputKeyUnlessEnter.CheckRegex(inputId, RegexConstant.userIdRegex, 20, 14, 16, 16);
                    Console.SetCursorPosition(40, 14);
                    Console.Write("|");
                }
                fine = true;
                Console.SetCursorPosition(16, 16);
                Console.Write("                        ");

                while (fine)
                {
                    inputPw = passwordMasker.HideConsoleInput(20, 15);
                    fine = inputKeyUnlessEnter.CheckRegex(inputPw, RegexConstant.userPwRegex, 20, 15, 16, 16);
                    Console.SetCursorPosition(40, 15);
                    Console.Write("|");
                }
                Console.SetCursorPosition(16, 16);
                Console.Write("                        ");

                check = mysqlConnecter.SelectData($"SELECT * FROM userconstructor WHERE userid = '{inputId}' AND password = '{inputPw}'");

                if (!check)//로그인 성공할 때까지 반복
                {
                    break;
                }
                //로그인 실패시 화면 지우기
                Console.SetCursorPosition(20, 14);
                Console.Write("                    |               ");
                Console.SetCursorPosition(20, 15);
                Console.Write("                    |                  ");
                Console.SetCursorPosition(16, 16);
                Console.Write ("     로그인 실패");
                Console.SetCursorPosition(15, 17);
                Console.Write(    "   다시 입력해주세요.");
            }
            return UserId; //로그인 성공한 유저의 아이디 반환됨.
        }

        public void UserSignUp() //회원가입
        {

        }
    }
}
