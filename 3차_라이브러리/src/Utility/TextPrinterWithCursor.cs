using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLibrary.Controller
{
    internal class TextPrinterWithCursor
    {
        public void SetTextColorGreen(int xCoordinate, int yCoordinate, string text)
        {
            Console.SetCursorPosition(xCoordinate, yCoordinate);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text);
        } //text의 좌표를 설정하고 초록색으로 출력하는 메소드

        public void SetTextColorWhite(int xCoordinate, int yCoordinate, string text)
        {
            Console.SetCursorPosition(xCoordinate, yCoordinate);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text);
        } //text의 좌표를 설정하고 하얀색으로 출력하는 메소드

       
        public Tuple<int,bool> SetColorByUpDownArrow(int firstCursor, int lastCursor, int keyNumber)
        {//매개변수로 입력된 두 int값 범위 내에서 위 아래로 움직일 때마다 keyNumber 값 변화시키는 메소드

            bool check = true;
            while (true)
            {
                ConsoleKeyInfo keyInput = Console.ReadKey();

                if (keyInput.Key == ConsoleKey.Enter) //엔터키 누르면 정지
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    check = false;
                    break;
                }
                else if (keyInput.Key == ConsoleKey.UpArrow && keyNumber > firstCursor) //위 방향키 누르면
                {
                    keyNumber--;
                    break;
                }
                else if (keyInput.Key == ConsoleKey.DownArrow && keyNumber < lastCursor) //아래 방향키 누르면
                {
                    keyNumber++;
                    break;
                }
                else if (keyInput.Key == ConsoleKey.Escape) //esc 누르면
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    keyNumber = 0;
                    break;
                }
                else 
                {
                    continue;
                }
                
            }
            return new Tuple<int, bool>(keyNumber, check);

        }
    }
}
