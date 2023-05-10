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

        public void ViewBookSearcherManager()
        {
            Console.WriteLine("                                                   ");
            Console.WriteLine("                       -*매니저 모드 *-");
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

        public void ViewBookLenderTop()
        {
            Console.WriteLine("                                                   ");
            Console.WriteLine("                       -* 유저 모드 *-");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                        < 도서 대여 > ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("     대여할 책 ID를 입력하세요 :");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("============================================================");
        }

        public void ViewBookReturnerTop()
        {
            Console.WriteLine("                                                   ");
            Console.WriteLine("                    -* 유저 모드 *-");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                     < 도서 반납 > ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("     반납할 책 ID를 입력하세요 :");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
        }

        public void ViewUserDataUpdaterTop()
        {
            Console.WriteLine("                                                   ");
            Console.WriteLine("                       -* 유저 모드 *-");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                        < 정보 수정 > ");
        }

        public void ViewUserDataUpdaterBottom()
        {
            Console.WriteLine("   ┌ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┐");
            Console.WriteLine("   |                   ↑↓ 위, 아래 이동                  | ");
            Console.WriteLine("   |                    ENTER를 눌러 선택                  | ");
            Console.WriteLine("   |                                                       | ");
            Console.WriteLine("   |  PW:                                                  | ");
            Console.WriteLine("   |  Name:                                                | ");
            Console.WriteLine("   |  Age:                                                 | ");
            Console.WriteLine("   |  PhoneNumber :                                        | ");
            Console.WriteLine("   |  Address :                                            | ");
            Console.WriteLine("   |                                                       | ");
            Console.WriteLine("   |                                                       | ");
            Console.WriteLine("   └ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┘");
            Console.WriteLine("                    입력 후 ENTER를 누르세요 ");
            Console.WriteLine("                      ESC를 눌러 돌아가기");
        }

        public void ViewUserDataDeleter()
        {
                Console.WriteLine("                                                   ");
                Console.WriteLine("                  -* 유저 모드 *-");
                Console.WriteLine("                                                     ");
                Console.WriteLine("                   < 회원 탈퇴 > ");
            
        }

        public void ViewApplyBook()
        {
            Console.WriteLine("                                                   ");
            Console.WriteLine("                       -* 유저 모드 *-");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                        < 도서 신청 > \n");

            Console.WriteLine("============================================================");
            Console.WriteLine(" 책 제목  :                         ");
            Console.WriteLine(" 수량     : ");
            Console.WriteLine("============================================================");

        }
    }
}
