using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLibrary.Controller;
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

                check = mysqlConnecter.SelectData(string.Format("SELECT * FROM userconstructor WHERE userid = '{0}' AND password = '{1}'", inputId, inputPw));
                

                if (!check)//로그인 성공하면 return
                {
                    returnTime = DateTime.Now;
                    returnTimeString = returnTime.ToString("yyyy-MM-dd HH:mm:ss"); //현재시각측정
                    mysqlConnecter.InsertUpdateDelete($"INSERT INTO log(log_time, log_user, log_info, log_behave) VALUES( '{returnTimeString}', '{"유저"}', '{"성공"}', '{"로그인"}')");
                    return inputId;
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
                returnTime = DateTime.Now;
                returnTimeString = returnTime.ToString("yyyy-MM-dd HH:mm:ss"); //현재시각측정
                mysqlConnecter.InsertUpdateDelete($"INSERT INTO log(log_time, log_user, log_info, log_behave) VALUES( '{returnTimeString}', '{"유저"}', '{"실패"}', '{"로그인"}')");
            }
            
            return inputId; //로그인 성공한 유저의 아이디 반환됨.
        }

        public bool UserSignUp() //회원가입
        {
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            PasswordMasker passwordMasker = new PasswordMasker();
            CRUDInDAO mysqlConnecter = new CRUDInDAO();

            Console.CursorVisible = true;

            DateTime returnTime;
            while (true)
            {
                string inputId="";
                string inputPw = "";
                string inputName = "";
                int inputAge=0;
                string inputPhone = "";
                string inputAddress = "";
                string returnTimeString = "";
                bool fine = true;
                bool check = true;

                while (fine)
                {
                    Console.SetCursorPosition(16, 20);
                    Console.Write("ID -> 영어 또는 숫자 4-16자리");
                    inputId = inputKeyUnlessEnter.SaveInputUnlessEnter(10, 14);
                    if (inputId == null) // esc 키가 눌리면 즉시 종료
                        return false;
                    
                    fine = inputKeyUnlessEnter.CheckRegex(inputId, RegexConstant.userIdRegex, 10, 14, 0, 0," ");
                    Console.SetCursorPosition(59, 14); //입력이 칸 넘어가면 제대로 안 지워지니까 콘솔창보다 크게 지우고, 칸 한번 더 그리기
                    Console.Write("|");
                }
                fine = true;
                Console.SetCursorPosition(16, 20);
                Console.Write("                                   ");
                while (fine)
                {
                    Console.SetCursorPosition(16, 20);
                    Console.Write("PW -> 영어 또는 숫자 6-12자리");
                    inputPw = inputKeyUnlessEnter.SaveInputUnlessEnter(10, 15);
                    if (inputPw == null) // esc 키가 눌리면 즉시 종료
                        return false;
                    fine = inputKeyUnlessEnter.CheckRegex(inputPw, RegexConstant.userPwRegex, 10, 15, 0, 0, " ");
                    Console.SetCursorPosition(59, 15); //입력이 칸 넘어가면 제대로 안 지워지니까 콘솔창보다 크게 지우고, 칸 한번 더 그리기
                    Console.Write("|");
                }
                fine = true;
                Console.SetCursorPosition(16, 20);
                Console.Write("                                ");
                while (fine)
                {
                    Console.SetCursorPosition(20, 20);
                    Console.Write("Name -> 한글 2-4자리");
                    inputName = inputKeyUnlessEnter.SaveInputUnlessEnter(12, 16);
                    if (inputName == null) // esc 키가 눌리면 즉시 종료
                        return false;
                    fine = inputKeyUnlessEnter.CheckRegex(inputName, RegexConstant.userNameRegex, 12, 16, 0, 0, " ");
                    Console.SetCursorPosition(59, 16); //입력이 칸 넘어가면 제대로 안 지워지니까 콘솔창보다 크게 지우고, 칸 한번 더 그리기
                    Console.Write("|");
                }
                fine = true;
                Console.SetCursorPosition(20, 20);
                Console.Write("                                ");
                while (fine)
                {
                    string bowl;
                    Console.SetCursorPosition(23, 20);
                    Console.Write("Age -> 1에서 200 사이 정수");
                    bowl = inputKeyUnlessEnter.SaveInputUnlessEnter(12, 17);
                    if (bowl == null) // esc 키가 눌리면 즉시 종료
                        return false;
                    fine = inputKeyUnlessEnter.CheckRegex(bowl, RegexConstant.userAgeRegex, 12, 17, 0, 0, " ");
                    inputAge = int.Parse(bowl);
                    Console.SetCursorPosition(59, 17); //입력이 칸 넘어가면 제대로 안 지워지니까 콘솔창보다 크게 지우고, 칸 한번 더 그리기
                    Console.Write("|");
                }
                fine = true;
                Console.SetCursorPosition(23, 20);
                Console.Write("                                ");
                while (fine)
                {
                    Console.SetCursorPosition(16, 20);
                    Console.Write("PhoneNumber -> 01x-xxxx-xxxx");
                    inputPhone = inputKeyUnlessEnter.SaveInputUnlessEnter(22, 18);
                    if (inputPhone == null) // esc 키가 눌리면 즉시 종료
                        return false;
                    fine = inputKeyUnlessEnter.CheckRegex(inputPhone, RegexConstant.userPhoneNumberRegex, 22, 18, 0, 0, " ");
                    Console.SetCursorPosition(59, 18); //입력이 칸 넘어가면 제대로 안 지워지니까 콘솔창보다 크게 지우고, 칸 한번 더 그리기
                    Console.Write("|");
                }
                fine = true;
                Console.SetCursorPosition(16, 20);
                Console.Write("                                ");

                while (fine)
                {
                    Console.SetCursorPosition(15, 20);
                    Console.Write("Address -> 도로명 주소 or 지번 주소 or 동/호수까지");
                    inputAddress = inputKeyUnlessEnter.SaveInputUnlessEnter(20, 19);
                    if (inputAddress == null) // esc 키가 눌리면 즉시 종료
                        return false;
                    fine = inputKeyUnlessEnter.CheckRegex(inputAddress, RegexConstant.userAddressRegex, 22, 19, 0, 0, " ");
                    Console.SetCursorPosition(59, 19); //입력이 칸 넘어가면 제대로 안 지워지니까 콘솔창보다 크게 지우고, 칸 한번 더 그리기
                    Console.Write("|");
                }

                fine = true;
                Console.SetCursorPosition(20, 20);
                Console.Write("                                ");
                Console.CursorVisible = false;
                bool checkMysql = true;

                checkMysql = mysqlConnecter.InsertUpdateDelete($"INSERT INTO userconstructor(userid, password, name, age, phonenumber, address) VALUES('{inputId}', '{inputPw}', '{inputName}', {inputAge}, '{inputPhone}', '{inputAddress}')");
                returnTime = DateTime.Now;
                returnTimeString = returnTime.ToString("yyyy-MM-dd HH:mm:ss"); //현재시각측정
                mysqlConnecter.InsertUpdateDelete($"INSERT INTO log(log_time, log_user, log_info, log_behave) VALUES('{returnTimeString}', '{"유저"}', '{"성공"}', '{"회원가입"}')");
                return true;
            }
        }
    }
}
