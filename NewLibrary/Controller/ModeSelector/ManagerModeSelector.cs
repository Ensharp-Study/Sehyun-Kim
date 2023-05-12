using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLibrary.Constant;
using NewLibrary.Controller.Function;
using NewLibrary.Controller.Log;
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
            MemberManagement memberManagement = new MemberManagement(); 
            APIConnection apiConnection = new APIConnection();
            AppliedBookManager appliedBookManager = new AppliedBookManager();
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            BookSearcher bookSearcher = new BookSearcher();
            FunctionView userFunctionView = new FunctionView();
            DataDisplayer dataDisplayer = new DataDisplayer();  
            BookManager bookManager = new BookManager();
            DisplayLog displayLog = new DisplayLog();

            bool fine = true;

            switch (number)
            {
                case 0://돌아가기
                    return;
                    break;
                case 1://도서찾기
                    Console.Clear();
                    userFunctionView.ViewBookSearcherManager();
                    dataDisplayer.DisplayAllBook();
                    bookSearcher.SearchBook("0");
                    break;
                case 2://도서 추가
                    Console.Clear();
                    userFunctionView.ViewAddBook();
                    bookManager.AddBook();
                    break;
                case 3: //도서 삭제
                    Console.Clear();
                    userFunctionView.ViewDeleteBook();
                    Console.SetCursorPosition(0, 8);
                    dataDisplayer.DisplayAllBook();
                    Console.SetCursorPosition(0, 5);
                    bookManager.DeleteBook();
                    break;
                case 4: //도서 수정
                    Console.Clear();
                    userFunctionView.ViewUpdateBook();
                    Console.SetCursorPosition(0, 22);
                    dataDisplayer.DisplayAllBook();
                    Console.SetCursorPosition(0, 5);
                    bookManager.ModifyBook();
                    break;
                case 5: //회원 관리
                    Console.Clear();
                    userFunctionView.ViewUpdateUserData();
                    Console.SetCursorPosition(0, 22);
                    memberManagement.DisplayMemberData();
                    Console.SetCursorPosition(0, 5);
                    memberManagement.ManageMember();
                    break;
                case 6: //대여 상황
                    Console.Clear();
                    memberManagement.DisplayRentalStatus();
                    break;
                case 7://로그 저장
                    Console.Clear();
                    displayLog.DownloadLog();
                    break;
                case 8://신청 도서 관리
                    Console.Clear();
                    appliedBookManager.ManagerAppliedBook();
                    break;
            }
            return;
        }
    }
}
