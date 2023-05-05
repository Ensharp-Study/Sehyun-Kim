using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;
using Library.Model;
using Library.View;
using Library.Controller;
namespace Library.View
{
    internal class HomeDisplay
    {
        
        public void InitialDisplay() { //처음 메뉴 디스플레이
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
            Console.WriteLine("                      □          ① 유저 모드            □            ");
            Console.WriteLine("                      ■         ② 관리자 모드           ■                    ");
            Console.WriteLine("                      □                                  □               ");
            Console.WriteLine("                      ■        0을 눌러 종료하기         ■               ");
            Console.WriteLine("                      □■□■□■□■□■□■□■□■□■□\n\n");

            
            


        }

       
    }
}
