using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe;
namespace TicTacToe
{
    internal class Number
    {
        
            public void NumberInput()
            {//입력방법 수정 -> 예외처리를 위해서

                //num 변수명 교체 (number)
                //Console.ReadLine()메서드는 사용자가 엔터를 누를때까지 입력 받아들임
                // ctrl+c : 일반적으로 프로그램이 종료되게 함 따라서 예외처리할 것 

                int number = 0;
                Game game = new Game();

                bool isNumber = false;
                Menu menu = new Menu();
                while (!isNumber)
                {

                    string input = Console.ReadLine();

                    if (int.TryParse(input, out number))
                    {
                        isNumber = true;
                    }



                    if (number >= 1 && number <= 4)
                    {
                        switch (number)
                        {

                            case 1:
                                game.Display1();
                                break;

                            case 2:

                                game.Display2();
                                break;

                            case 3:
                                Console.Clear();
                                game.Score();
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
