using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLibrary.Constant;
using NewLibrary.Controller.Function;
using NewLibrary.Controller.ManagerFunction;
using NewLibrary.Model;
using NewLibrary.Utility;
using NewLibrary.View.FunctionView;

namespace NewLibrary.Controller.ModeSelector
{
    internal class ManagerModeSelector
    {
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
            APIConnection apiConnection = new APIConnection();
            AppliedBookManager appliedBookManager = new AppliedBookManager();
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            BookSearcher bookSearcher = new BookSearcher();
            UserFunctionView userFunctionView = new UserFunctionView();
            BookDisplayer bookDisplay = new BookDisplayer();

            bool fine = true;
            string v = "";

            switch (number)
            {
                case 0:
                    return;
                    break;
                case 1://도서찾기
                    while (true)
                    {
                        Console.Clear();

                        userFunctionView.ViewBookSearcherManager();
                        bookDisplay.DisplayAllBook();
                        v = bookSearcher.SearchBook("dfd");
                        if (v == "dfd")
                        {
                            return;
                        }
                        while (true)
                        {
                            ConsoleKeyInfo input = Console.ReadKey(true);
                            if (input.Key == ConsoleKey.Escape) //esc 입력됐을 경우
                            {
                                Console.Clear();
                                return;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }

                    break;
                case 2://도서 추가
                    while (true)
                    {
                        Console.Clear();
                        string inputNumber = "0";
                        string resultValue = "";
                        Console.WriteLine("제목 :");
                        Console.WriteLine("수량 :");
                        while (fine)
                        {
                            resultValue = inputKeyUnlessEnter.SaveInputUnlessEnter(5, 0);
                            fine = inputKeyUnlessEnter.CheckRegex(resultValue, RegexConstant.englishKoreanNumberRegex, 5, 0, 20, 0, "입력이 잘못되었습니다.");
                        }
                        while (fine)
                        {
                            inputNumber = inputKeyUnlessEnter.SaveInputUnlessEnter(5, 1);
                            fine = inputKeyUnlessEnter.CheckRegex(inputNumber, RegexConstant.onlyNumberRegex, 5, 1, 20, 1, "입력이 잘못되었습니다.");
                        }
                        int resultNumber = int.Parse(inputNumber);

                        //v=apiConnection.ConnectNaverApi(resultNumber, resultValue);
                        Console.WriteLine("ESC를 눌러 종료");
                        while (true)
                        {
                            ConsoleKeyInfo input = Console.ReadKey(true);
                            if (input.Key == ConsoleKey.Escape) //esc 입력됐을 경우
                            {
                                Console.Clear();
                                return;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
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

                    while (true)
                    {
                        Console.Clear();
                        appliedBookManager.ManagerAppliedBook();
                        Console.WriteLine("ESC를 눌러 종료");
                        while (true)
                        {
                            ConsoleKeyInfo input = Console.ReadKey(true);
                            if (input.Key == ConsoleKey.Escape) //esc 입력됐을 경우
                            {
                                Console.Clear();
                                return;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    break;


            }
            return;
        }
    }
}
