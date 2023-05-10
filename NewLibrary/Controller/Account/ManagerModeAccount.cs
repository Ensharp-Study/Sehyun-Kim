using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.View;
using NewLibrary.Constant;
using NewLibrary.Utility;

namespace NewLibrary.Controller
{
    internal class ManagerModeAccount
    {
        public string Login() //로그인
        {
            //매개변수 constructor : MySQL 테이블 이름 (유저 테이블 OR 매니저 테이블)

            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            PasswordMasker passwordMasker = new PasswordMasker();
            CRUDInDAO mysqlConnecter = new CRUDInDAO();

            DateTime returnTime;
            string inputId = "";
            string inputPw = "";
            string returnTimeString = "";

            while (true)
            {
                bool fine = true;
                bool check = true;

                inputId = "";
                inputPw = "";

                while (fine)
                {
                    //inputId 입력받기
                    inputId = inputKeyUnlessEnter.SaveInputUnlessEnter(20, 14);
                    if (inputId == null) // esc 키가 눌리면 즉시 종료
                    {
                        return null;
                    }
                    //입력이 잘못되었습니다 안내 메세지 지우기
                    Console.SetCursorPosition(16, 16);
                    Console.Write("                        ");
                    Console.SetCursorPosition(15, 17);
                    Console.Write("                        ");
                    fine = inputKeyUnlessEnter.CheckRegex(inputId, RegexConstant.userIdRegex, 20, 14, 16, 16, "입력이 잘못되었습니다.");
                    //view 깨짐 방지 
                    Console.SetCursorPosition(40, 14);
                    Console.Write("|");
                }
                //입력이 잘못되었습니다 안내 메세지 지우기
                fine = true;
                Console.SetCursorPosition(16, 16);
                Console.Write("                        ");

                while (fine)
                {
                    inputPw = passwordMasker.HideConsoleInput(20, 15);
                    if (inputPw == null) // esc 키가 눌리면 즉시 종료
                    {
                        Console.Clear();
                        return null;
                    }
                    fine = inputKeyUnlessEnter.CheckRegex(inputPw, RegexConstant.userPwRegex, 20, 15, 16, 16, "입력이 잘못되었습니다.");
                    Console.SetCursorPosition(40, 15);
                    Console.Write("|");
                }
                Console.SetCursorPosition(16, 16);
                Console.Write("                        ");

                check = mysqlConnecter.SelectData(string.Format("SELECT * FROM managerconstructor WHERE userid = '{0}' AND password = '{1}'", inputId, inputPw));


                if (!check)//로그인 성공하면 return
                {
                    returnTime = DateTime.Now;
                    returnTimeString = returnTime.ToString("yyyy-MM-dd HH:mm:ss"); //현재시각측정
                    mysqlConnecter.InsertUpdateDelete($"INSERT INTO log(log_time, log_user, log_info, log_behave) VALUES( '{returnTimeString}', '{"매니저"}', '{"성공"}', '{"로그인"}')");
                    return inputId;
                }
                //로그인 실패시 화면 지우기

                Console.SetCursorPosition(20, 14);
                Console.Write("                    |               ");
                Console.SetCursorPosition(20, 15);
                Console.Write("                    |                  ");
                Console.SetCursorPosition(16, 16);
                Console.Write("     로그인 실패");
                Console.SetCursorPosition(15, 17);
                Console.Write("   다시 입력해주세요.");
                returnTime = DateTime.Now;
                returnTimeString = returnTime.ToString("yyyy-MM-dd HH:mm:ss"); //현재시각측정
                mysqlConnecter.InsertUpdateDelete($"INSERT INTO log(log_time, log_user, log_info, log_behave) VALUES( '{returnTimeString}', '{"매니저"}', '{"실패"}', '{"로그인"}')");
            }

            return inputId; //로그인 성공한 유저의 아이디 반환됨.
        }
    }
}
