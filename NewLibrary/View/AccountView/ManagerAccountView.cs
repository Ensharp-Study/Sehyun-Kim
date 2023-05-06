using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLibrary.View
{
    internal class ManagerAccountView
    {
        public void ViewManagerAccount()
        {
            Console.SetWindowSize(56, 21);

            Console.WriteLine("       _      _  _  ");
            Console.WriteLine("      | |    (_)| |");
            Console.WriteLine("      | |     _ | |__   _ __   __ _  _ __  _   _ ");
            Console.WriteLine("      | |    | || '_ ＼| '__| / _` || '__|| | | |");
            Console.WriteLine("      | |____| || |_) || |   | (_| || |   | |_| |");
            Console.WriteLine("      ＼____/|_||_.__/ |_|   ＼__,_||_|   ＼__, |");
            Console.WriteLine("                                            __/ |");
            Console.WriteLine("                                           |___/ ");
            Console.WriteLine("");
            Console.WriteLine("                  -* 관리자 모드 *-");
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
        }
    }
}
