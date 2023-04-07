using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace tictactoe
{
    //해야할거 1. 예외처리 2. 무승부
    class tictactoe
    {
        public static void Main(String[] args) //메인함수
        {
            Menu menu = new Menu();
            menu.Display();
        }
    }

    class Menu
    {
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

    class Number //메뉴에서 번호 선택
    {
        public int num=0;
        public void Numberinput()
        {

            num = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Game game = new Game();


            switch (num)
            {
                case 1:
                    game.Display1();
                    break;

                case 2:
                    
                    game.Display2();
                    break;

                case 3:
                   
                    game.Score();
                    break;

                case 4:
                    return;
                    break;
                
            }
        }
    }

    class Game 
    {
        //틱택토 화면 실제로 나오는 부분
        private string a1 = "   ", b1 = "   ", c1 = "   ", d1 = "   ", e1 = "   ", f1 = "   ", g1 = "   ", h1 = "   ", i1 = "   ";
        private string a2 = "   ", b2 = "   ", c2 = "   ", d2 = "   ", e2 = "   ", f2 = "   ", g2 = "   ", h2 = "   ", i2 = "   ";
        private int cnt=1;
        private int win1=0, win2=0, comwin=0, userwin=0;

        public void Display1() //버전1
        {
            Console.Clear();
            Console.WriteLine("        <Scoreboard>\n");
            Console.WriteLine(" ★*user*★  ★*Computer*★   ");
            Console.WriteLine("     " + userwin + "             " + comwin);
            Console.WriteLine(" ★＊★＊★  ★＊★＊★＊★   \n\n");

            Console.WriteLine("  press ①~⑨");
            Console.WriteLine("press zero to quit\n");

            Console.WriteLine("----------------");
            Console.WriteLine("l ① I ② I ③ I");
            Console.WriteLine("----------------");
            Console.WriteLine("l ④ I ⑤ I ⑥ I");
            Console.WriteLine("----------------");
            Console.WriteLine("l ⑦ I ⑧ I ⑨ I");
            Console.WriteLine("----------------");

            Console.WriteLine("----------------");
            Console.WriteLine("l" + a1 + "I" + b1 + " I" + c1 + " I");
            Console.WriteLine("----------------");
            Console.WriteLine("l" + d1 + "I" + e1 + " I" + f1 + " I");
            Console.WriteLine("----------------");
            Console.WriteLine("l" + g1 + "I" + h1 + " I" + i1 + " I");
            Console.WriteLine("----------------");

            if (cnt % 2 != 0)
            {
                user1();

            }
            else
            {

            }
            Random rand = new Random();

            
             Console.WriteLine(rand.Next(1,10)); //1이상 10미만의 랜덤 숫자 생성

            
            

        }
        public void Display2() { //버전2
            
            Console.Clear();

            cnt++;
            Judge();
            Console.WriteLine("        <Scoreboard>\n");
            Console.WriteLine(" ★*user1*★  ★*user2*★   ");
            Console.WriteLine("     " + win1 + "           " + win2);
            Console.WriteLine(" ★＊★＊★  ★＊★＊★   \n\n");


            Console.WriteLine("  press ①~⑨");
            Console.WriteLine("press zero to quit\n");

            Console.WriteLine("----------------");
            Console.WriteLine("l ① I ② I ③ I");
            Console.WriteLine("----------------");
            Console.WriteLine("l ④ I ⑤ I ⑥ I");
            Console.WriteLine("----------------");
            Console.WriteLine("l ⑦ I ⑧ I ⑨ I");
            Console.WriteLine("----------------");
            
            Console.WriteLine("----------------");
            Console.WriteLine("l"+a2+ "I" + b2 + " I" + c2 + " I");
            Console.WriteLine("----------------");
            Console.WriteLine("l" + d2 + "I" + e2 + " I" + f2 + " I");
            Console.WriteLine("----------------");
            Console.WriteLine("l" + g2 + "I" + h2 + " I" + i2 + " I");
            Console.WriteLine("----------------");
            if (cnt % 2 == 0)
            {
                user1();
            }
            
            else if (cnt % 2 == 1)
            {
                user2();
            }


        }

        //유저 대 유저 게임에서 유저1의 입력값 저장
        public void user1()
        {
            int essence;
            essence=int.Parse(ReadLine());

            switch (essence)
            {
                case 0:
                    Menu menu = new Menu();
                    menu.Display();
                    break;

                case 1:
                    a2 = " O ";
                    break;

                case 2:
                    b2 = " O ";
                    break;
                case 3:
                    c2 = " O ";
                    break;
                case 4:
                    d2 = " O ";
                    break;
                case 5:
                    e2 = " O ";
                    break;
                case 6:
                    f2 = " O ";
                    break;
                case 7:
                    g2 = " O ";
                    break;
                case 8:
                    h2 = " O ";
                    break;
                case 9:
                    i2 = " O ";
                    break;

            }

            //유저의 입력값에 따라서 a~i 변수에 'O' 를 넣어주고, 바로 틱택토 화면에 적용되도록 display 메소드 호출

            Display2();
        }

        //유저 대 유저 게임에서 유저2의 입력값 저장 
        public void user2()
        {
            int essence;
            essence = int.Parse(ReadLine());

            switch (essence)
            {
                case 0:
                    Menu menu = new Menu();
                    menu.Display();
                    break;

                case 1:
                    a2 = " X ";
                    break;

                case 2:
                    b2 = " X ";
                    break;
                case 3:
                    c2 = " X ";
                    break;
                case 4:
                    d2 = " X ";
                    break;
                case 5:
                    e2 = " X ";
                    break;
                case 6:
                    f2 = " X ";
                    break;
                case 7:
                    g2 = " X ";
                    break;
                case 8:
                    h2 = " X ";
                    break;
                case 9:
                    i2 = " X ";
                    break;
            }

            //유저의 입력값에 따라서 a~i 변수에 'X' 를 넣어주고, 바로 틱택토 화면에 적용되도록 display 메소드 호출

            Display2();
        }

        public void Judge() //틱택토 화면에서 빙고가 나왔는지 판단하는 메소드
                            // 빙고가 나왔다면 resetting 메소드로 a~i 변수의 값을 공백으로 초기화하고, 이긴 유저의 점수 하나 올리기
        {
            //가로빙고

            if (a2.Trim() == "O" && b2.Trim() == "O" && c2.Trim() == "O" || d2.Trim() == "O" && e2.Trim() == "O" && f2.Trim() == "O" || g2.Trim() == "O" && h2.Trim() == "O" && i2.Trim() == "O")
            {  //Trim -> 양쪽 공백을 제거                                                                                                          
                win1++;

                resetting();

            }
            if (a2.Trim() == "X" && b2.Trim() == "X" && c2.Trim() == "X" || d2.Trim() == "X" && e2.Trim() == "X" && f2.Trim() == "X" || g2.Trim() == "X" && h2.Trim() == "X" && i2.Trim() == "X")
            {
                win2++;
                resetting();

            }
            //세로빙고
             if (a2.Trim() == "O" && d2.Trim() == "O" && g2.Trim() == "O" || b2.Trim() == "O" && e2.Trim() == "O" && h2.Trim() == "O" || c2.Trim() == "O" && f2.Trim() == "O" && i2.Trim() == "O")
                {
                    win1++;
                resetting();

                }

                if (a2.Trim() == "X" && d2.Trim() == "X" && g2.Trim() == "X" || b2.Trim() == "X" && e2.Trim() == "X" && h2.Trim() == "X" || c2.Trim() == "X" && f2.Trim() == "X" && i2.Trim() == "X")
                {
                    win2++;
                resetting();

                }

             //대각선빙고

                if (a2.Trim() == "O" && e2.Trim() == "O" && i2.Trim() == "O" || c2.Trim() == "O" && e2.Trim() == "O" && g2.Trim() == "O")
                {
                    win1++;
                resetting();

                }

                if (a2.Trim() == "X" && e2.Trim() == "X" && i2.Trim() == "X" || c2.Trim() == "X" && e2.Trim() == "X" && g2.Trim() == "X")
                {
                    win2++;
                resetting();

                }


            }

    
        
        public void Score() //점수판을 보여주는 메소드
        {
            
                Console.WriteLine("        <Scoreboard>\n\n\n");
                Console.WriteLine("① ★*user*★  ★*Computer*★   ");
                Console.WriteLine("       " + userwin + "             " + comwin);
                Console.WriteLine("   ★＊★＊★  ★＊★＊★＊★   \n\n");
            
            
            
                Console.WriteLine("② ★*user1*★  ★*user2*★   ");
                Console.WriteLine("       " + win1 + "            " + win2);
                Console.WriteLine("   ★＊★＊★   ★＊★＊★   \n\n\n");
                Console.WriteLine("    Press 0 to back menu");
            
                int essence;
                essence = int.Parse(ReadLine());

                if (essence == 0)
                {
                    Console.Clear();
                    Menu menu = new Menu();
                    menu.Display();
                }
            }

            

            



        

        public void resetting() //변수 a~i의 값을 초기화하는 메소드
        {
            a2 = "   ";
            b2 = "   ";
            c2 = "   ";
            d2 = "   ";
            e2 = "   ";
            f2 = "   ";
            g2 = "   ";
            h2 = "   ";
            i2 = "   ";
            cnt = 0;

        }

    }
}