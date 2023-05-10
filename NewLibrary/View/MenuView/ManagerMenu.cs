using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLibrary.Constant;
using NewLibrary.Controller;
using NewLibrary.Controller.Function;
using NewLibrary.Controller.ManagerFunction;
using NewLibrary.Model;
using NewLibrary.Utility;
using NewLibrary.View.FunctionView;

namespace NewLibrary.View.MenuView
{
    internal class ManagerMenu
    {
        public void ViewManagerMenu()
        {
            Console.WriteLine("                       -* 매니저 모드 *-");
            Console.WriteLine("                           < 메뉴 > ");
            Console.WriteLine("   ┌ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┐");
            Console.WriteLine("   |                                                       | ");
            Console.WriteLine("   |                     1  도서 찾기                       | ");
            Console.WriteLine("   |                     2  도서 추가                       | ");
            Console.WriteLine("   |                     3  도서 삭제                       | ");
            Console.WriteLine("   |                    4   도서 수정                       | ");
            Console.WriteLine("   |                    5   회원 관리                       | ");
            Console.WriteLine("   |                    6   대여 상황                       | ");
            Console.WriteLine("   |                    7   로그 삭제                      | ");
            Console.WriteLine("   |                    8   로그 저장                       | ");
            Console.WriteLine("   |                    9  신청 도서 관리                  | ");
            Console.WriteLine("   └ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┘");
            Console.WriteLine("                   ");
            Console.WriteLine("                      ESC를 눌러 돌아가기");
        }

        
    }
}
