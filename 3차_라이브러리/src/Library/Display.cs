using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;

namespace Library
{
    internal class Display
    {
        private LoginOrNewmember loginOrNewmember;

        public Display()
        {
            loginOrNewmember = new LoginOrNewmember(this);
        }


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
            Console.WriteLine("                      ■                                  ■               ");
            Console.WriteLine("                      □■□■□■□■□■□■□■□■□■□\n\n");


            int number = int.Parse(Console.ReadLine());
            ManagerMode managerMode = new ManagerMode();
            switch (number)
            {
                case 1: //유저모드 -> 로그인 또는 회원가입 
                    Console.Clear();
                    inputInfo();
                    break;
                case 2: //관리자모드
                    managerMode.modOfManager();
                    break;
            }


        }

        public void inputInfo() { //로그인 또는 회원가입 메뉴
            
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
            
            int num = int.Parse(Console.ReadLine());

            switch (num)
            {
                case 0:
                    InitialDisplay();
                    break;
                case 1: //로그인
                    loginOrNewmember.LoginProcess();
                    break;
                case 2: //회원가입
                    loginOrNewmember.NewMemberProcess();
                    break;
                
            }
        }

       
    }
}
