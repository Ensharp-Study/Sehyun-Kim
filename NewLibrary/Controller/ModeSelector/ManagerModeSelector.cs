using NewLibrary.Constant;
using NewLibrary.Controller.Log;
using NewLibrary.Controller.ManagerFunction;
using NewLibrary.Model;
using NewLibrary.Utility;
using NewLibrary.View.FunctionView;
using static NewLibrary.Constant.MenuHandler;

namespace NewLibrary.Controller.ModeSelector
{
    internal class ManagerModeSelector
    {
        public int GoFunctionInManagerMenu(string userId)
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


        public void SelectNumberInManagerMenu(int number, string userId)
        {
            MemberManagement memberManagement = new MemberManagement();
            APIConnection apiConnection = new APIConnection();
            AppliedBookManager appliedBookManager = new AppliedBookManager();
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            BookSearcher bookSearcher = new BookSearcher();
            FunctionView functionView = new FunctionView();
            DataDisplayer dataDisplayer = new DataDisplayer();
            BookManager bookManager = new BookManager();
            DisplayLog displayLog = new DisplayLog();

            bool fine = true;

            switch (number)
            {
                case (int)ManagerMenuSelect.None:
                    // 돌아가기
                    return;

                case (int)ManagerMenuSelect.BookSearch:
                    // 도서찾기
                    DoBookSearch(memberManagement, functionView, dataDisplayer, bookSearcher, userId);
                    break;

                case (int)ManagerMenuSelect.BookAdder:
                    // 도서 추가
                    DoAddBook(functionView, bookManager, userId);
                    break;

                case (int)ManagerMenuSelect.BookDeleter:
                    // 도서 삭제
                    DoDeleteBook(functionView, dataDisplayer, bookManager, userId);
                    break;

                case (int)ManagerMenuSelect.BookModifier:
                    // 도서 수정
                    DoModifyBook(functionView, dataDisplayer, bookManager, userId);
                    break;

                case (int)ManagerMenuSelect.MemberUpdater:
                    // 회원 관리
                    DoManageMember(functionView, memberManagement, userId);
                    break;

                case (int)ManagerMenuSelect.RentalStatus:
                    // 대여 상황
                    memberManagement.DisplayRentalStatus(userId);
                    break;

                case (int)ManagerMenuSelect.LogDownloader:
                    // 로그 저장
                    displayLog.DownloadLog(userId);
                    break;

                case (int)ManagerMenuSelect.AppliedBookManager:
                    // 신청 도서 관리
                    appliedBookManager.ManagerAppliedBook(userId);
                    break;
            }

            return;
        }

        private void DoBookSearch(MemberManagement memberManagement, FunctionView userFunctionView, DataDisplayer dataDisplayer, BookSearcher bookSearcher, string userId)
        {
            Console.Clear();
            userFunctionView.ViewBookSearcherManager();
            dataDisplayer.DisplayAllBook();
            bookSearcher.SearchBook(userId);
        }

        private void DoAddBook(FunctionView userFunctionView, BookManager bookManager, string userId)
        {
            Console.Clear();
            userFunctionView.ViewAddBook();
            bookManager.AddBook(userId);
        }

        private void DoDeleteBook(FunctionView userFunctionView, DataDisplayer dataDisplayer, BookManager bookManager, string userId)
        {
            Console.Clear();
            userFunctionView.ViewDeleteBook();
            Console.SetCursorPosition(0, 8);
            dataDisplayer.DisplayAllBook();
            Console.SetCursorPosition(0, 5);
            bookManager.DeleteBook(userId);
        }

        private void DoModifyBook(FunctionView functionView, DataDisplayer dataDisplayer, BookManager bookManager, string userId)
        {
            Console.Clear();
            functionView.ViewUpdateBook();
            Console.SetCursorPosition(0, 22);
            dataDisplayer.DisplayAllBook();
            Console.SetCursorPosition(0, 5);
            bookManager.ModifyBook(userId);
        }
        private void DoManageMember(FunctionView functionView, MemberManagement memberManagement, string userId)
        {
            Console.Clear();
            functionView.ViewUpdateUserData();
            Console.SetCursorPosition(0, 22);
            memberManagement.DisplayMemberData(userId);
            Console.SetCursorPosition(0, 5);
            memberManagement.ManageMember(userId);
        }

        // 대여 상황
        private void DoDisplayRentalStatus(MemberManagement memberManagement, string userId)
        {
            Console.Clear();
            memberManagement.DisplayRentalStatus(userId);
        }

        // 로그 저장
        private void DoDownloadLog(DisplayLog displayLog, string userId)
        {
            Console.Clear();
            displayLog.DownloadLog(userId);
        }

        // 신청 도서 관리
        private void DoManagerAppliedBook(AppliedBookManager appliedBookManager, string userId)
        {
            Console.Clear();
            appliedBookManager.ManagerAppliedBook(userId);
        }
    }
}
