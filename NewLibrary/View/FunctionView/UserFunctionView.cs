using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLibrary.View.FunctionView
{
    internal class UserFunctionView
    {
        public void ViewBookSearcher()
        {
            Console.WriteLine("                                                   ");
            Console.WriteLine("                       -* 유저 모드 *-");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                        < 도서 찾기 > ");
            Console.WriteLine("   ┌ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┐");
            Console.WriteLine("   |                                                       | ");
            Console.WriteLine("   |                   ⓛ 제목으로 찾기                    | ");
            Console.WriteLine("   |                   ② 작가명으로 찾기                  | ");
            Console.WriteLine("   |                   ③ 출판사명으로 찾기                | ");
            Console.WriteLine("   |                                                       | ");
            Console.WriteLine("   └ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┘");
            Console.WriteLine("                   선택하려면 ENTER를 누르세요");
            Console.WriteLine("                      ESC를 눌러 돌아가기");
        }

        public void ViewBookLender1()
        {
            Console.WriteLine("                                                   ");
            Console.WriteLine("                       -* 유저 모드 *-");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                        < 도서 대여 > ");
            
        }

        public void ViewBookLender2()
        {
            Console.WriteLine("     대여할 책 ID를 입력하세요 :");
            
        }
    }
}
