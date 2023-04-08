using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;



namespace tictactoe
{


    //페이지 나눠서 클래스 분할,  컴퓨터랑 상대하기ㅇ, 점수 조회 메뉴o
    // 네이밍 신경쓰기, 입력값 예외처리o 

    //1. 무승부 추가, 누가 승리했는지 알려주는 멘트 추가
    //2, 컴퓨터랑 상대하기 코드수정
    //3. 점수조회 오류난 이유  -> 전역변수로 PUBLIC **STATIC** 써야함

    class tictactoe
    {
        public static void Main(String[] args) //메인함수
        {
            Menu menu = new Menu();
            menu.Display();
        }
    }

    public partial class Menu
    {

        public static int win1, win2, comwin, userwin;
        public void Display() //메뉴 디스플레이
        {
            Console.Clear();
            Console.WriteLine("★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★");
            Console.WriteLine(" *                          　                                  *");
            Console.WriteLine("★                                                              ★");
            Console.WriteLine("*                     Welcome to Tic Tac Toe!                   *");
            Console.WriteLine("★                                                              ★");
            Console.WriteLine(" *                          　                                  *");
            Console.WriteLine("★                                                              ★");
            Console.WriteLine(" *                 ①~④ 사이의 숫자를 입력하세요.              *");
            Console.WriteLine("★                                                              ★");
            Console.WriteLine(" *                        ① vs Computer                        *");
            Console.WriteLine("★                        ② vs User                            ★");
            Console.WriteLine(" *                        ③ Scoreboard                         *");
            Console.WriteLine("★                        ④ Quit                               ★");
            Console.WriteLine(" *                                                              *");
            Console.WriteLine("★                                                              ★");
            Console.WriteLine("★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★");

            Number number = new Number();
            number.Numberinput();
        }
    }

    public partial class Number //메뉴에서 번호 선택
    {
        public int num = 0;

        public void Numberinput()
        {//입력방법 수정 -> 예외처리를 위해서

            //num 변수명 교체 (number)
            //Console.ReadLine()메서드는 사용자가 엔터를 누를때까지 입력 받아들임
            // ctrl+c : 일반적으로 프로그램이 종료되게 함 따라서 예외처리할 것 
            using program;
            Game game = new Game();

            int number = 0;
            bool isNumber = false;
            Menu menu = new Menu();
            while (!isNumber)
            {

                string input = Console.ReadLine();
                Console.CancelKeyPress += new ConsoleCancelEventHandler((sender, e) =>
                {
                    e.Cancel = true;

                });
                if (int.TryParse(input, out number))
                {
                    isNumber = true;
                }


                if (number >= 1 && number <= 4)
                {
                    switch (number)
                    {

                        case 1:
                            Display1();
                            break;

                        case 2:

                            Display2();
                            break;

                        case 3:
                            Console.Clear();
                            Score();
                            break;

                        case 4:
                            return;
                            break;

                    }
                }

                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력하세요.");
                    isNumber = false;
                }

            }

        }






    }
}
