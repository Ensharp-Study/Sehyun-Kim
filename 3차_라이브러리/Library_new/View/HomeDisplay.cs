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

            UserData userData = new UserData();
            userData.InsertUserData();
            BookData bookData = new BookData();
            bookData.InsertBookData();

            UserSignUpDisplay userSignUpDisplay = new UserSignUpDisplay(bookData, userData);

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

            
            int number = int.Parse(Console.ReadLine());
            ManagerMode managerMode = new ManagerMode(bookData, userData);
            switch (number)
            {
                case 0:
                    Console.Clear();
                    return;
                    break;
                case 1: //유저모드 -> 로그인 또는 회원가입 
                    Console.Clear();
                    userSignUpDisplay.inputInfo();
                    break;
                case 2: //관리자모드
                    Console.Clear();
                    managerMode.modOfManager();
                    break;
            }


        }

       
    }
}
