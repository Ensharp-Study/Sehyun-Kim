using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;
namespace Library
{
    
    internal class LoginOrNewmember
    {
        public static int userlistnumber; //static const 

        public static int flag;
        private Display display;
        UserMode userMode = new UserMode();
        UserData userData = new UserData();
        public LoginOrNewmember(Display display)
        {
            this.display = display;
        }

        //List<UserConstructor> userList = new List<UserConstructor>();

        //생성자 안에서도 객체초기화해놓기 


        public void LoginProcess() //로그인
        {
            
            Console.WriteLine("아이디를 입력하세요.");
            string inputId = Console.ReadLine();

            Console.WriteLine("비밀번호를 입력하세요.");
            string inputPw = GetHiddenConsoleInput();

            bool isLogin = false;
            /*
             
             */
            int i = 0;
            foreach (var user in UserData.UserList)
            {
                i++;
                if (user.userid == inputId && user.password == inputPw)
                {
                    Console.Clear();
                    Console.WriteLine("로그인 성공!");
                    
                    isLogin = true;
                    userlistnumber = i-1;
                    i = 0;
                    userMode.usermenu();

                    break;
                }
            }

            if (!isLogin)
            {
                Console.Clear();
                Console.WriteLine("로그인 실패. 아이디 또는 비밀번호가 일치하지 않습니다.");
                display.inputInfo();
            }

            

            

        }
        public string GetHiddenConsoleInput()
        {
            string input = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    input += key.KeyChar;
                    Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        input = input.Substring(0, (input.Length - 1));
                        ClearLine(Console.CursorLeft, Console.CursorTop);
                        Write(new string(' ', Console.WindowWidth));
                        ClearLine(Console.CursorLeft, Console.CursorTop);
                        for (int i = 0; i < input.Length; i++)
                        {
                            Write("*");
                        }
                    }
                }
            } while (key.Key != ConsoleKey.Enter);
            return input;
        }
        private void ClearLine(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(left, top);
        }
        public void NewMemberProcess() //회원가입 
        {
            
            flag++;
            Console.Write(" id : ");
            string userid = Console.ReadLine();
            Console.Write("Password : ");
            string password = GetHiddenConsoleInput();
            Console.Write("Name : ");
            string Name = Console.ReadLine();
            Console.Write("Age : ");
            int Age = int.Parse(Console.ReadLine());
            Console.Write("PhoneNumber : ");
            int PhoneNumber = int.Parse(Console.ReadLine());
            Console.Write(" Address : ");
            string Address = Console.ReadLine();

            UserData.UserList.Add(new UserConstructor(userid, password, Name, Age, PhoneNumber, Address));
            Console.Clear();
            Console.WriteLine("회원가입 성공!");
            display.inputInfo();
        }

        
    }
}
