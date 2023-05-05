using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLibrary.View
{
    internal class ModeSelectView
    {
        public void ViewModeSelect()
        {
            Console.SetWindowSize(56, 21);
            
            Console.WriteLine("       _      _  _  ");
            Console.WriteLine("      | |    (_)| |");
            Console.WriteLine("      | |     _ | |__   _ __   __ _  _ __  _   _ ");
            Console.WriteLine("      | |    | || '_ ＼| '__| / _` || '__|| | | |");
            Console.WriteLine("      | |____| || |_) || |   | (_| || |   | |_| |");
            Console.WriteLine("      ＼____/|_||_.__/ |_|   ＼__,_||_|   ＼__, |");
            Console.WriteLine("                                            __/ |");
            Console.WriteLine("                                           |___/ ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                  Enter를 눌러 선택");
            Console.WriteLine("            ┌ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┐");
            Console.WriteLine("            |                           | ");
            Console.WriteLine("            |                           | ");
            Console.WriteLine("            |       ○ 유저 모드        | ");
            Console.WriteLine("            |      ○ 관리자 모드       | ");
            Console.WriteLine("            |                           | ");
            Console.WriteLine("            |                           | ");
            Console.WriteLine("            └ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┘");
            Console.WriteLine("                 ↑↓ 위, 아래 이동");

            Console.CursorVisible = false;
            SetColorByUpDownArrow(1, 2);


        }
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

        public void ChangeTextColorByKeyNumber(int keyNumber) //SetColorByUpDownArrow로 받아온 keyNumber값으로 글자 출력
        {
            if (keyNumber == 1)
            {
                SetTextColorGreen(20, 14, "● 유저 모드");
                SetTextColorWhite(19, 15, "○ 관리자 모드");
            }
            else if (keyNumber == 2)
            {
                SetTextColorWhite(20, 14, "○ 유저 모드");
                SetTextColorGreen(19, 15, "● 관리자 모드");
            }

        } 
        public void SetColorByUpDownArrow(int firstCursor,int lastCursor)
        {//매개변수로 입력된 두 int값 범위 내에서 위 아래로 움직일 때마다 keyNumber 값 변화시키는 메소드
            
            int keyNumber = 1;

            while (true) {
                ChangeTextColorByKeyNumber(keyNumber);
                ConsoleKeyInfo keyInput = Console.ReadKey();

                if (keyInput.Key == ConsoleKey.Enter) //엔터키 누르면 정지
                {
                    break;
                }
                else if (keyInput.Key == ConsoleKey.UpArrow&&keyNumber>firstCursor) //위 방향키 누르면
                {
                    keyNumber--;
                }
                else if (keyInput.Key == ConsoleKey.DownArrow&&keyNumber<lastCursor) //아래 방향키 누르면
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
