using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLibrary.Controller
{
    internal class TextPrinterWithCursor
    {
        public void SetTextColorGreen(int xCooperation, int yCooperation, string text)
        {
            Console.SetCursorPosition(xCooperation, yCooperation);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text);
        } //text의 좌표를 설정하고 초록색으로 출력하는 메소드

        public void SetTextColorWhite(int xCooperation, int yCooperation, string text)
        {
            Console.SetCursorPosition(xCooperation, yCooperation);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text);
        } //text의 좌표를 설정하고 하얀색으로 출력하는 메소드

        public void ChangeTextColorByKeyNumber(int keyNumber, string text1, string text2) //SetColorByUpDownArrow로 받아온 keyNumber값으로 글자 출력
        {
            if (keyNumber == 1)
            {
                SetTextColorGreen(20, 14, "● "+ text1);
                SetTextColorWhite(19, 15, "○ "+ text2);
            }
            else if (keyNumber == 2)
            {
                SetTextColorWhite(20, 14, "○ " + text1);
                SetTextColorGreen(19, 15, "● " + text2);
            }
        }

        
        public void SetColorByUpDownArrow(int firstCursor, int lastCursor, string text1, string text2)
        {//매개변수로 입력된 두 int값 범위 내에서 위 아래로 움직일 때마다 keyNumber 값 변화시키는 메소드

            int keyNumber = 1;

            while (true)
            {
                ChangeTextColorByKeyNumber(keyNumber, text1, text2);
                ConsoleKeyInfo keyInput = Console.ReadKey();

                if (keyInput.Key == ConsoleKey.Enter) //엔터키 누르면 정지
                {
                    break;
                }
                else if (keyInput.Key == ConsoleKey.UpArrow && keyNumber > firstCursor) //위 방향키 누르면
                {
                    keyNumber--;
                }
                else if (keyInput.Key == ConsoleKey.DownArrow && keyNumber < lastCursor) //아래 방향키 누르면
                {
                    keyNumber++;
                }
                else
                {
                    continue;
                }

            }
        }
    }
}
