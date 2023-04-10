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
        public static int flag;
        private Display display;
        UserMode userMode = new UserMode();
        public LoginOrNewmember(Display display)
        {
            this.display = display;
        }
        List<UserData> userList = new List<UserData>();

        public void LoginProcess() //로그인
        {
            Console.WriteLine("아이디를 입력하세요.");
            string inputId = Console.ReadLine();

            Console.WriteLine("비밀번호를 입력하세요.");
            string inputPw = Console.ReadLine();

            bool isLogin = false;

            foreach (UserData user in userList)
            {
                if (user.userid == inputId && user.password == inputPw)
                {
                    Console.Clear();
                    Console.WriteLine("로그인 성공!");
                    
                    isLogin = true;
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
        public void NewMemberProcess() //회원가입 
        {

            flag++;
            Console.Write(" id : ");
            string userid = Console.ReadLine();
            Console.Write("Password : ");
            string password = Console.ReadLine();
            Console.Write("Name : ");
            string Name = Console.ReadLine();
            Console.Write("Age : ");
            int Age = int.Parse(Console.ReadLine());
            Console.Write("PhoneNumber : ");
            int PhoneNumber = int.Parse(Console.ReadLine());
            Console.Write(" Address : ");
            int Address = int.Parse(Console.ReadLine());

            userList.Add(new UserData(userid, password, Name, Age, PhoneNumber, Address));
            Console.Clear();
            Console.WriteLine("회원가입 성공!");
            display.inputInfo();
        }

        
    }
}
