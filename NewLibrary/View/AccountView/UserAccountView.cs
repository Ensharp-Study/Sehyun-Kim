using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLibrary.View
{
    internal class UserAccountView
    {
        public void ViewUserAccount()
        {
            Console.WriteLine("                   -* 유저 모드 *-");
            Console.WriteLine("                  Enter를 눌러 선택");
            Console.WriteLine("            ┌ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┐");
            Console.WriteLine("            |                           | ");
            Console.WriteLine("            |                           | ");
            Console.WriteLine("            |         ○ 로그인         | ");
            Console.WriteLine("            |        ○ 회원 가입       | ");
            Console.WriteLine("            |                           | ");
            Console.WriteLine("            |                           | ");
            Console.WriteLine("            └ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┘");
            Console.WriteLine("                 ↑↓ 위, 아래 이동");
            Console.WriteLine("                   ESC를 눌러 종료");

        }

        public void ViewLogin()
        {
            Console.WriteLine("                   -* 유저 모드 *-");
            Console.WriteLine("                     < 로그인 >");
            Console.WriteLine("            ┌ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┐");
            Console.WriteLine("            |                           | ");
            Console.WriteLine("            |                           | ");
            Console.WriteLine("            |  ID:                      | ");
            Console.WriteLine("            |  PW:                      | ");
            Console.WriteLine("            |                           | ");
            Console.WriteLine("            |                           | ");
            Console.WriteLine("            └ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┘");
            Console.WriteLine("              입력 후 ENTER를 누르세요");
            Console.WriteLine("                 ESC를 눌러 돌아가기");
        }

        public void ViewSignUp()
        {
            Console.WriteLine("                       -* 유저 모드 *-");
            Console.WriteLine("                        < 회원 가입 > ");
            Console.WriteLine("   ┌ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┐");
            Console.WriteLine("   |                                                       | ");
            Console.WriteLine("   |                                                       | ");
            Console.WriteLine("   |  ID:                                                  | ");
            Console.WriteLine("   |  PW:                                                  | ");
            Console.WriteLine("   |  Name:                                                | ");
            Console.WriteLine("   |  Age:                                                 | ");
            Console.WriteLine("   |  PhoneNumber :                                        | ");
            Console.WriteLine("   |  Address :                                            | ");
            Console.WriteLine("   |                                                       | ");
            Console.WriteLine("   |                                                       | ");
            Console.WriteLine("   └ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┘");
            Console.WriteLine("                   입력 후 ENTER를 누르세요");
            Console.WriteLine("                      ESC를 눌러 돌아가기");
        }
    }
}
