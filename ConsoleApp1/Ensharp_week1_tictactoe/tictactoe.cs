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
            Console.WriteLine("*                   Welcome to play Tic Tac Toe!                *");
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
        public void Numberinput()
        {
            int num = 0;
            num = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Game game = new Game();
            

            switch (num)
            {
                case 1:
                    Console.Clear();
                    game.computer();
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    break;

            }
        }
    }

    class Game
    {
        private string a = "   ", b = "   ", c = "   ", d = "   ", e = "   ", f = "   ", g = "   ", h = "   ", i = "   ";
        
        Number number = new Number();
        public void computer()
        {
            
            Console.WriteLine("----------------");
            Console.WriteLine("l ① I ② I ③ I");
            Console.WriteLine("----------------");
            Console.WriteLine("l ④ I ⑤ I ⑥ I");
            Console.WriteLine("----------------");
            Console.WriteLine("l ⑦ I ⑧ I ⑨ I");
            Console.WriteLine("----------------");

            Console.WriteLine("----------------");
            Console.WriteLine("l${a} I{0} I{0} I", a, b, c);
            Console.WriteLine("----------------");
            Console.WriteLine("l{0} I{0} I{0} I", d, e, f);
            Console.WriteLine("----------------");
            Console.WriteLine("l{0} I{0} I{0} I", g, h, i);
            Console.WriteLine("----------------");

        }

        public void Number(int a)
        {
            int essence = int.Parse(Console.ReadLine());

            switch (essence)
            {
                case 1:
                    a='O'
                    break;
            }
    }

    
}