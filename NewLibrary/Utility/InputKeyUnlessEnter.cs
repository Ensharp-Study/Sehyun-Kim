using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using NewLibrary.Constant;

namespace NewLibrary.Utility
{
    internal class InputKeyUnlessEnter
    {
        //정규식 검사할때 공백이면 안하고 공백이아니면 하기 
        public string SaveInputUnlessEnter(int xCoordination, int yCoordination)
        {
            string randomExpression = "";

            Console.SetCursorPosition(xCoordination, yCoordination);
            Regex regex = new Regex(RegexConstant.koreanChar);

            while (true)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);

                if (input.Key == ConsoleKey.Enter) //엔터 입력됐을 경우
                {
                    break;
                }
                else if (input.Key == ConsoleKey.Backspace) //백스페이스 입력됐을 경우
                {
                    if (randomExpression.Length > 0) //길이가 0보다 길다면
                    {
                        if (regex.IsMatch(randomExpression.Substring(randomExpression.Length - 1))) //한글인 경우
                        {
                            Console.SetCursorPosition(xCoordination + (randomExpression.Length - 1) * 2, yCoordination);
                            Console.Write("  ");
                            Console.SetCursorPosition(xCoordination + (randomExpression.Length - 1) * 2, yCoordination);
                            randomExpression = randomExpression.Substring(0, randomExpression.Length - 1);
                        }
                        else // 한글이 아닌 경우
                        {
                            Console.SetCursorPosition(xCoordination + (randomExpression.Length - 1), yCoordination);
                            Console.Write(" ");
                            Console.SetCursorPosition(xCoordination + (randomExpression.Length - 1), yCoordination);
                            randomExpression = randomExpression.Substring(0, randomExpression.Length - 1);
                        }
                    }
                }
                else // 나머지 다른 문자 입력됐을 경우
                {
                    Console.Write(input.KeyChar);
                    randomExpression += input.KeyChar;
                }
            }

            return randomExpression;
        }

        public bool CheckRegex(string expression, string regexExpression, int xCoordinate, int yCoordinate, int interval)
        {
            //expression : 정규식 검사할 문자열
            //regexExpression : 정규식
            //xCoordinate, yCoordinate : 커서 set해서 입력받을 좌표
            //interval : 입력이 잘못되었습니다 안내 메세지 띄울 간격

            bool check = true;

            Regex regex = new Regex(regexExpression);

            if (!regex.IsMatch(expression)) //정규식 안만족하면
            {
                Console.SetCursorPosition(xCoordinate, yCoordinate);
                Console.Write("                                        ");
                Console.SetCursorPosition(xCoordinate + interval, yCoordinate);
                Console.WriteLine("입력이 잘못되었습니다.");
                Console.SetCursorPosition(xCoordinate, yCoordinate);
                check = false;
                //다시 입력을 받아야 한다.
            }
            check = true;
            return check; //정규식 만족하면 true가 된 check를 반환

        }

        /* 두 메소드 사용하는 방법 예시 
        public void menu()
        {
            bool fine = false;
            while (!fine) fine 
            {
                string id = SaveInputUnlessEnter(0, 0);
                fine=CheckRegex(id, RegexConstant.koreanChar, 0, 0, 40);
            }
        }
        */
    }

}
