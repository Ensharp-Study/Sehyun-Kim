using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLibrary.Constant;
using NewLibrary.Controller.ManagerFunction;
using NewLibrary.Utility;

namespace NewLibrary.View.MenuView
{
    internal class ManagerMenu
    {
        public void ViewManagerMenu()
        {
            Console.WriteLine("           _      _  _  ");
            Console.WriteLine("          | |    (_)| |");
            Console.WriteLine("          | |     _ | |__   _ __   __ _  _ __  _   _ ");
            Console.WriteLine("          | |    | || '_ ＼| '__| / _` || '__|| | | |");
            Console.WriteLine("          | |____| || |_) || |   | (_| || |   | |_| |");
            Console.WriteLine("          ＼____/|_||_.__/ |_|   ＼__,_||_|   ＼__, |");
            Console.WriteLine("                                                __/ |");
            Console.WriteLine("                                               |___/ ");
            Console.WriteLine("");
            Console.WriteLine("                       -* 매니저 모드 *-");
            Console.WriteLine("                           < 메뉴 > ");
            Console.WriteLine("   ┌ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┐");
            Console.WriteLine("   |                                                       | ");
            Console.WriteLine("   |                     1  도서 찾기                       | ");
            Console.WriteLine("   |                     2  도서 추가                       | ");
            Console.WriteLine("   |                     3  도서 삭제                       | ");
            Console.WriteLine("   |                    4   도서 수정                       | ");
            Console.WriteLine("   |                    5   회원 관리                       | ");
            Console.WriteLine("   |                    6   대여 상황                       | ");
            Console.WriteLine("   |                    7   로그 삭제                      | ");
            Console.WriteLine("   |                    8   로그 저장                       | ");
            Console.WriteLine("   |                    9  신청 도서 관리                  | ");
            Console.WriteLine("   └ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ┘");
            Console.WriteLine("                   ");
            Console.WriteLine("                      ESC를 눌러 돌아가기");
        }

        public int GoFunctionInManagerMenu()
        {
            Console.CursorVisible = true;
            Console.SetWindowSize(56, 50);
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            bool fine = true;
            string inputString = "1";
            int inputNumber;
            while (fine)
            {
                inputString = inputKeyUnlessEnter.SaveInputUnlessEnter(20, 25);
                if (inputString == null)
                {
                    inputNumber = 0;
                    return inputNumber;
                }
                fine = inputKeyUnlessEnter.CheckRegex(inputString, RegexConstant.menuNumberRegex, 20, 25, 40, 24, "입력이 잘못되었습니다");
            }
            inputNumber = int.Parse(inputString);
            return inputNumber;
        }
        public void SelectNumberInManagerMenu(int number)
        {
            AppliedBookManager appliedBookManager = new AppliedBookManager();
            switch (number)
            {
                case 0:
                    return;
                    break;
                case 1://도서찾기
                    break;
                case 2://도서 추가
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7://로그 삭제
                    break;
                case 8://로그 저장
                    break;
                case 9://신청 도서 관리
                    Console.Clear();
                    appliedBookManager.ManagerAppliedBook();

                    break;


            }
            return;
        }
    }
}
