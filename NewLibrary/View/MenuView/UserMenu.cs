using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLibrary.View.MenuView
{
    internal class UserMenu
    {
        public void ViewUserMenu()
        {
            Console.WriteLine("                       -* 유저 모드 *-");
            Console.WriteLine("                           < 메뉴 > ");
            Console.WriteLine("   ┌ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┐");
            Console.WriteLine("   |                                                       | ");
            Console.WriteLine("   |                      도서 찾기                        | ");
            Console.WriteLine("   |                      도서 대여                        | ");
            Console.WriteLine("   |                      도서 반납                        | ");
            Console.WriteLine("   |                      도서 대여 확인                   | ");
            Console.WriteLine("   |                      도서 반납 내역                   | ");
            Console.WriteLine("   |                      회원 정보 수정                   | ");
            Console.WriteLine("   |                      회원 탈퇴                        | ");
            Console.WriteLine("   |                      도서 신청                        | ");
            Console.WriteLine("   |                   ↑↓ 위, 아래 이동                  | ");
            Console.WriteLine("   └ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┘");
            Console.WriteLine("                   선택하려면 ENTER를 누르세요");
            Console.WriteLine("                      ESC를 눌러 돌아가기");
        }
    }
}
