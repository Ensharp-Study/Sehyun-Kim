using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLibrary.Constant;
using NewLibrary.Controller.Function;
using NewLibrary.Controller.ModeSelector;
using NewLibrary.Controller.UserFunction;
using NewLibrary.Utility;
using NewLibrary.View;
using NewLibrary.View.FunctionView;
using NewLibrary.View.MenuView;

namespace NewLibrary.Controller
{
    internal class UserModeSelector
    {
        private string userId;

        public void SelectMode()
        {
            ModeSelectView modeSelectView = new ModeSelectView();
            AccountView userAccountView = new AccountView();
            AccountView AccountView = new AccountView();
            ManagerModeSelector managerModeSelector = new ManagerModeSelector();
            UserModeSelector userModeSelector = new UserModeSelector();
            TextPrinterWithCursor textPrinterWithCursor = new TextPrinterWithCursor();
            Account userModeAccount = new Account(userId);
            UserMenu userMenu = new UserMenu();

            bool exit = true;

            while (exit)
            {
                Console.CursorVisible = false;
                Console.SetWindowSize(56, 22);

                modeSelectView.ViewLibraryLogo();
                modeSelectView.ViewModeSelect();

                int cursorNumber = SelectModeWithCursor(textPrinterWithCursor);

                if (cursorNumber == 0)
                    return;

                bool selectMode = true;
                bool checker = true;

                while (selectMode)
                {
                    switch (cursorNumber)
                    {
                        case (int)SelectModeByCursor.userMode: // 유저 모드
                            selectMode = HandleUserMode(out cursorNumber);
                            if (!selectMode)
                                checker = cursorNumber != 0;
                            break;
                        case (int)SelectModeByCursor.managerMode: // 관리자 모드
                            selectMode = HandleManagerMode(out cursorNumber);
                            if (!selectMode)
                                checker = cursorNumber != 0;
                            break;
                    }
                }

                if (!checker)
                    return;
            }
        }
        public enum SelectModeByCursor
        {
            userMode = 1,
            managerMode = 2
        }


        private int SelectModeWithCursor(TextPrinterWithCursor textPrinterWithCursor)
        {
            int cursorNumber = 1;

            while (true)
            {
                switch (cursorNumber)
                {
                    case (int)SelectModeByCursor.userMode:
                        textPrinterWithCursor.SetTextColorGreen(20, 14, "● 유저 모드");
                        textPrinterWithCursor.SetTextColorWhite(19, 15, "○ 관리자 모드");
                        break;
                    case (int)SelectModeByCursor.managerMode:
                        textPrinterWithCursor.SetTextColorWhite(20, 14, "○ 유저 모드");
                        textPrinterWithCursor.SetTextColorGreen(19, 15, "● 관리자 모드");
                        break;
                }

                var tuple = textPrinterWithCursor.SetColorByUpDownArrow(1, 2, cursorNumber);

                if (!tuple.Item2)
                    return cursorNumber;

                cursorNumber = tuple.Item1;
            }
        }

        private bool HandleUserMode(out int cursorNumber)
        {
            AccountView userAccountView = new AccountView();
            ModeSelectView modeSelectView = new ModeSelectView();
            TextPrinterWithCursor textPrinterWithCursor = new TextPrinterWithCursor();

            Console.Clear();

            modeSelectView.ViewLibraryLogo();
            userAccountView.ViewUserAccount();

            int number = SetColorByCursor();
            cursorNumber = LoginOrSignUp(number);

            return number != 0;
        }

        private bool HandleManagerMode(out int cursorNumber)
        {
            ModeSelectView modeSelectView = new ModeSelectView();
            AccountView userAccountView = new AccountView();
            Account userModeAccount = new Account(userId);
            UserMenu userMenu = new UserMenu();
            ManagerModeSelector managerModeSelector = new ManagerModeSelector();

            Console.Clear();

            modeSelectView.ViewLibraryLogo();
            userAccountView.ViewLogin();
            userId = userModeAccount.Login(2);

            if (userId == null)
            {
                cursorNumber = 0;
                return false;
            }

            while (true)
            {
                Console.Clear();
                modeSelectView.ViewLibraryLogo();
                userMenu.ViewManagerMenu();
                int number = managerModeSelector.GoFunctionInManagerMenu();
                managerModeSelector.SelectNumberInManagerMenu(number);
                if (number == 0)
                {
                    cursorNumber = 0;
                    return false;
                }
            }
        }




        public int SetColorByCursor()
        {
            TextPrinterWithCursor textPrinterWithCursor = new TextPrinterWithCursor();
            Account userModeAccount = new Account(userId);
            AccountView userAccountView = new AccountView();
            bool fine = true;
            int Number = 1;

            while (fine)
            {
                switch (Number)
                {
                    case 0:
                        Console.Clear();
                        return Number; //esc 누르면 keyNumber값을 0으로 설정하고 종료하기
                    case (int)SelectModeByCursor.userMode:
                        textPrinterWithCursor.SetTextColorGreen(22, 14, "● 로그인");
                        textPrinterWithCursor.SetTextColorWhite(21, 15, "○ 회원 가입");
                        break;
                    case (int)SelectModeByCursor.managerMode:
                        textPrinterWithCursor.SetTextColorWhite(22, 14, "○ 로그인");
                        textPrinterWithCursor.SetTextColorGreen(21, 15, "● 회원 가입");
                        break;
                }
                //tuple의 반환값은 keyNumber, check -> check는 엔터 누르면 false가 됨
                var tuple = textPrinterWithCursor.SetColorByUpDownArrow(1, 2, Number);
                if (tuple.Item2 == false) //만약 check가 false이면
                {
                    fine = false;
                }
                else
                {
                    Number = tuple.Item1;
                }
            }
            return Number;
        }
        public int LoginOrSignUp(int number)
        {
            ModeSelectView modeSelectView = new ModeSelectView();
            Account userModeAccount = new Account(userId);
            AccountView userAccountView = new AccountView();
            UserMenu userMenu = new UserMenu();

            switch (number)
            {
                case 0:
                    return 1;
                case 1: // 로그인
                    Console.Clear();
                    Console.CursorVisible = true;
                    modeSelectView.ViewLibraryLogo();
                    userAccountView.ViewLogin();
                    userId = userModeAccount.Login(1);
                    if (userId == null)
                    {
                        Console.CursorVisible = false;
                        return 1;
                    }

                    while (true)
                    { 
                        Console.SetWindowSize(62, 27);
                        modeSelectView.ViewLibraryLogo();
                        userMenu.ViewUserMenu();
                        int selectedNumber = SelectInUserMenu();
                        userId = MethodInUserMenu(selectedNumber, userId);
                        if (userId == null)
                        {
                            break;
                        }
                    }
                    break;
                case 2: // 회원가입
                    Console.Clear();
                    Console.SetWindowSize(62, 27);
                    modeSelectView.ViewLibraryLogo();
                    userAccountView.ViewSignUp();
                    bool checker = userModeAccount.UserSignUp();
                    if (!checker)
                    {
                        Console.CursorVisible = false;
                        return 1;
                    }
                    break;
            }

            return 1;
        }

        public string MethodInUserMenu(int selectedNumber, string userId)
        {
            BookSearcher bookSearcher = new BookSearcher();
            FunctionView userFunctionView = new FunctionView();
            DataDisplayer dataDisplayer = new DataDisplayer();
            BookService bookservice = new BookService();
            UserDataService userDataService = new UserDataService();
            BookApplier bookApplier = new BookApplier();
            bool check;
            int number;
            switch (selectedNumber)
            { 
                case 0: //유저 메뉴에서 기능 고를 때 esc가 눌린 것
                    userId = null;
                    break;
                case 1: //도서 찾기
                    Console.Clear();
                    userFunctionView.ViewBookSearcher();
                    Console.SetCursorPosition(0, 14);
                    dataDisplayer.DisplayAllBook();
                    bookSearcher.SearchBook(userId);
                    break;
                case 2: //도서 대여
                    Console.Clear();
                    userFunctionView.ViewBookLenderTop();
                    dataDisplayer.DisplayAllBook();
                    bookservice.RentOutBook(userId);
                    break;
                case 3: //도서 반납
                    check = false;
                    Console.Clear();
                    userFunctionView.ViewBookReturnerTop();
                    bookservice.RentalList(userId, check);
                    bookservice.ReturnBook(userId);
                    break;
                case 4: //도서 대여 확인
                    Console.Clear();
                    check = true;
                    bookservice.RentalList(userId, check);
                    break;
                case 5: //도서 반납 내역
                    Console.Clear();
                    bookservice.ReturnList(userId);
                    break;
                case 6: //회원 정보 수정
                    Console.Clear();
                    userFunctionView.ViewUserDataUpdaterTop();
                    check = false;
                    bool fine = true;
                    dataDisplayer.DisplayUserInformation(userId,check);
                    userFunctionView.ViewUserDataUpdaterBottom();
                    number = userDataService.SetCursorWhenUpdate(userId);
                    userDataService.UpdateUserData(userId, number);
                    break;
                case 7: //회원 탈퇴 
                    Console.Clear();
                    userFunctionView.ViewUserDataDeleter();
                    userDataService.DeleteUserData(userId);
                    break;
                case 8: //도서 신청
                    Console.Clear();
                    userFunctionView.ViewApplyBook();
                    bookApplier.ApplyBook(userId);
                    break;
            }
            return userId;
        }
        public int SelectInUserMenu()
        {
            ModeSelectView modeSelectView = new ModeSelectView();
            TextPrinterWithCursor textPrinterWithCursor = new TextPrinterWithCursor();
            AccountView accountView = new AccountView();
            ListWithColoredIndexPrinter listWithColoredIndexPrinter = new ListWithColoredIndexPrinter();
            bool exit = true;
            List<string> strList = new List<string>() { "도서 찾기", "도서 대여", "도서 반납", "도서 대여 확인", "도서 반납 내역", "회원 정보 수정", "회원 탈퇴","도서 신청" };

            Console.CursorVisible = false; //커서 안 보이게
            Console.SetWindowSize(62, 27);

            bool fine = true;
            int keyNumber = 1;

            while (fine) //keyNumber은 초기값이 1인 상태로 fine이 true일 동안 계속 반복
            {
                
                switch (keyNumber)
                {
                    case 0:
                        return keyNumber; //esc가 눌렸으면 keyNumber 0
                    case 1:
                        listWithColoredIndexPrinter.PrintListWithColoredIndex(strList, 0, 26,13);
                        break;
                    case 2:
                        listWithColoredIndexPrinter.PrintListWithColoredIndex(strList, 1, 26, 13);
                        break;
                    case 3:
                        listWithColoredIndexPrinter.PrintListWithColoredIndex(strList, 2, 26, 13);
                        break;
                    case 4:
                        listWithColoredIndexPrinter.PrintListWithColoredIndex(strList, 3, 26, 13);
                        break;
                    case 5:
                        listWithColoredIndexPrinter.PrintListWithColoredIndex(strList, 4, 26, 13);
                        break;
                    case 6:
                        listWithColoredIndexPrinter.PrintListWithColoredIndex(strList, 5, 26, 13);
                        break;
                    case 7:
                        listWithColoredIndexPrinter.PrintListWithColoredIndex(strList, 6, 26, 13);
                        break;
                    case 8:
                        listWithColoredIndexPrinter.PrintListWithColoredIndex(strList, 7, 26, 13);
                        break;
                }
                //tuple의 반환값은 keyNumber, check -> check는 엔터 누르면 false가 됨
                var tuple = textPrinterWithCursor.SetColorByUpDownArrow(1, 8, keyNumber);
                if (tuple.Item2 == false) //만약 check가 false이면 반복문 정지하고 keyNumber문으로 이동
                {                       //check가 false 다 = 엔터가 눌렸다
                    fine = false;
                }
                else //엔터가 안 눌렸다 그래서 반환된 값을 다시 keyNumber에 넣어서 또 반복한다.
                {
                    keyNumber = tuple.Item1;
                }
            }
            //엔터 입력시 여기로 나옴 
            return keyNumber;

        }
        
    }
}
