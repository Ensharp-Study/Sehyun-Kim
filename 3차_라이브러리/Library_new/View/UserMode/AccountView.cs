using System.Text;
using static System.Console;
using System.Threading.Tasks;
using Library.Model;
using Library.View;
using Library.Controller;
namespace Library.View
{
    internal class AccountView
    {
        
        public void ViewAccountMenu()
        { //로그인 또는 회원가입 메뉴
            
           


            Console.WriteLine("                                                                     ");
            Console.WriteLine("       ■       ■■■    ■■■     ■■■         ■       ■■■     ■    ■                             ");
            Console.WriteLine("       ■         ■      ■    ■   ■    ■      ■■      ■    ■   ■    ■                          ");
            Console.WriteLine("       ■         ■      ■■■     ■■■       ■  ■     ■■■      ■  ■                                ");
            Console.WriteLine("       ■         ■      ■    ■   ■  ■      ■ ■ ■    ■  ■        ■                          ");
            Console.WriteLine("       ■■■   ■■■    ■■■     ■    ■   ■      ■   ■    ■      ■                             ");
            Console.WriteLine("                                                                    ");
            Console.WriteLine("                                                                    \n\n\n\n\n\n\n ");



            Console.WriteLine("                      ■□■□■□■□■□■□■□■□■□■");
            Console.WriteLine("                      □                                  □              ");
            Console.WriteLine("                      ■                                  ■    ");
            Console.WriteLine("                      □            ① 로그인             □            ");
            Console.WriteLine("                      ■           ② 회원가입            ■                    ");
            Console.WriteLine("                      □                                  □               ");
            Console.WriteLine("                      ■         0을 눌러 돌아가기        ■               ");
            Console.WriteLine("                      □■□■□■□■□■□■□■□■□■□\n\n");

           
        }
    }
}
