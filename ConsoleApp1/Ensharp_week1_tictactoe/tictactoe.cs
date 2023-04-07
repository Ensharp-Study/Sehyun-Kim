using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace Menu
{
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
        public void Display()
        {
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

    class Number
    {
        public int num=0;
        public int count = 0;
        public void Numberinput()
        {

            num = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Game game = new Game();


            switch (num)
            {
                case 1:
                    count = 1;
                    break;

                case 2:
                    count = 2;
                    game.display();
                    break;

                case 3:
                    count = 3;
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
        private string a = "   ", b = "   ", c = "   ", d = "   ", e = "   ", f = "   ", g = "   ", h = "   ", i = "   ";
        private int cnt=0;
        private int win1=0, win2=0, comwin=0, userwin=0;
        public void display() { 
            Console.Clear();

            cnt++;
            Judge();
            Score();
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
            Console.WriteLine("l"+a+ "I" + b + " I" + c + " I");
            Console.WriteLine("----------------");
            Console.WriteLine("l" + d + "I" + e + " I" + f + " I");
            Console.WriteLine("----------------");
            Console.WriteLine("l" + g + "I" + h + " I" + i + " I");
            Console.WriteLine("----------------");
            if (cnt % 2 != 0)
            {
                user1();
                
            }
            
            else
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
                    Console.Clear();
                    Menu menu = new Menu();
                    menu.Display();
                    break;

                case 1:
                    a = " O ";
                    break;

                case 2:
                    b = " O ";
                    break;
                case 3:
                    c = " O ";
                    break;
                case 4:
                    d = " O ";
                    break;
                case 5:
                    e = " O ";
                    break;
                case 6:
                    f = " O ";
                    break;
                case 7:
                    g = " O ";
                    break;
                case 8:
                    h = " O ";
                    break;
                case 9:
                    i = " O ";
                    break;

            }

            //유저의 입력값에 따라서 a~i 변수에 'O' 를 넣어주고, 바로 틱택토 화면에 적용되도록 display 메소드 호출

            display();
        }

        //유저 대 유저 게임에서 유저2의 입력값 저장 
        public void user2()
        {
            int essence;
            essence = int.Parse(ReadLine());

            switch (essence)
            {
                case 1:
                    a = " X ";
                    break;

                case 2:
                    b = " X ";
                    break;
                case 3:
                    c = " X ";
                    break;
                case 4:
                    d = " X ";
                    break;
                case 5:
                    e = " X ";
                    break;
                case 6:
                    f = " X ";
                    break;
                case 7:
                    g = " X ";
                    break;
                case 8:
                    h = " X ";
                    break;
                case 9:
                    i = " X ";
                    break;
            }

            //유저의 입력값에 따라서 a~i 변수에 'O' 를 넣어주고, 바로 틱택토 화면에 적용되도록 display 메소드 호출

            display();
        }

        public void Judge() //틱택토 화면에서 빙고가 나왔는지 판단하는 메소드
                            // 빙고가 나왔다면 resetting 메소드로 a~i 변수의 값을 공백으로 초기화하고, 이긴 유저의 점수 하나 올리기
        {
            //가로빙고

            if (a.Trim() == "O" && b.Trim() == "O" && c.Trim() == "O" || d.Trim() == "O" && e.Trim() == "O" && f.Trim() == "O" || g.Trim() == "O" && h.Trim() == "O" && i.Trim() == "O")
            {  //Trim -> 양쪽 공백을 제거                                                                                                          
                win1++;
                resetting();

            }
            if (a.Trim() == "X" && b.Trim() == "X" && c.Trim() == "X" || d.Trim() == "X" && e.Trim() == "X" && f.Trim() == "X" || g.Trim() == "X" && h.Trim() == "X" && i.Trim() == "X")
            {
                win2++;
                resetting();

            }
            //세로빙고
             if (a.Trim() == "O" && d.Trim() == "O" && g.Trim() == "O" || b.Trim() == "O" && e.Trim() == "O" && h.Trim() == "O" || c.Trim() == "O" && f.Trim() == "O" && i.Trim() == "O")
                {
                    win1++;
                resetting();

                }

                if (a.Trim() == "X" && d.Trim() == "X" && g.Trim() == "X" || b.Trim() == "X" && e.Trim() == "X" && h.Trim() == "X" || c.Trim() == "X" && f.Trim() == "X" && i.Trim() == "X")
                {
                    win2++;
                resetting();

                }

             //대각선빙고

                if (a.Trim() == "O" && e.Trim() == "O" && i.Trim() == "O" || c.Trim() == "O" && e.Trim() == "O" && g.Trim() == "O")
                {
                    win1++;
                resetting();

                }

                if (a.Trim() == "X" && e.Trim() == "X" && i.Trim() == "X" || c.Trim() == "X" && e.Trim() == "X" && g.Trim() == "X")
                {
                    win2++;
                resetting();

                }


            }

    
        
        public void Score() //점수판을 보여주는 메소드
        {
            Number number = new Number();
            if (number.count == 1|| number.count == 3)
            {
                Console.WriteLine("       <Scoreboard>\n\n\n");
                Console.WriteLine("① ★*user*★  ★*Computer*★   ");
                Console.WriteLine("       " + userwin + "             " + comwin);
                Console.WriteLine("   ★＊★＊★  ★＊★＊★＊★   \n\n");
            }
            
            else if (number.count == 2 || number.count == 3)
            {
                Console.WriteLine("② ★*user1*★  ★*user2*★   ");
                Console.WriteLine("       " + win1 + "            " + win2);
                Console.WriteLine("   ★＊★＊★   ★＊★＊★   \n\n\n");
                Console.WriteLine("    Press 0 to back menu");
            }

            if (number.count == 3)
            {
                int essence;
                essence = int.Parse(ReadLine());

                if (essence == 0)
                {
                    Console.Clear();
                    Menu menu = new Menu();
                    menu.Display();
                }
            }

            

            



        }

        public void resetting() //변수 a~i의 값을 초기화하는 메소드
        {
            a = "   ";
            b = "   ";
            c = "   ";
            d = "   ";
            e = "   ";
            f = "   ";
            g = "   ";
            h = "   ";
            i = "   ";

        }

    }
}