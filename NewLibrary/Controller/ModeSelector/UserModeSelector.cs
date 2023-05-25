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
using static NewLibrary.Constant.MenuHandler;

namespace NewLibrary.Controller
{
    internal class UserModeSelector
    {
        private string userId;

        public void SelectMode()
        //유저 모드 또는 관리자 모드 중 선택하는 메소드
        {
            ModeSelectView modeSelectView = new ModeSelectView();
            AccountView userAccountView = new AccountView();
            AccountView AccountView = new AccountView();
            ManagerModeSelector managerModeSelector = new ManagerModeSelector();
            UserModeSelector userModeSelector = new UserModeSelector();
            TextPrinterWithCursor textPrinterWithCursor = new TextPrinterWithCursor();
            Account userModeAccount = new Account(userId);
            UserMenu userMenu = new UserMenu();
            MenuHandler menuHandler = new MenuHandler();

            bool checker = true;
            while (checker)
            {
                Console.CursorVisible = false;
                Console.SetWindowSize(56, 22);

                modeSelectView.ViewLibraryLogo();
                modeSelectView.ViewModeSelect();

                //SelectModeWithCursor 메소드에서 받아온 cursorNumber
                int cursorNumber = SelectModeWithCursor(textPrinterWithCursor);

                //cursorNumber가 0이면 프로그램 종료 
                if (cursorNumber == 0)
                    return;

                bool selectMode = true;

                if (cursorNumber == (int)SelectModeByCursor.UserMode)
                {
                    checker = HandleUserMode(out cursorNumber);
                    if (!checker)
                        checker = cursorNumber != 0;
                }
                else if (cursorNumber == (int)SelectModeByCursor.ManagerMode)
                {
                    checker = HandleManagerMode(out cursorNumber);
                    if (!checker)
                        checker = cursorNumber == 0;
                }
            }
        }

        private int SelectModeWithCursor(TextPrinterWithCursor textPrinterWithCursor)
        {
            //cursorNumber에 따라, 색깔 바꿔주는 메소드
            int cursorNumber = 1;

            while (true)
            {
                switch (cursorNumber)
                {
                    case (int)SelectModeByCursor.UserMode:
                        //유저 모드를 초록색, 관리자 모드를 하얀색으로 설정
                        textPrinterWithCursor.SetTextColorGreen(20, 14, "● 유저 모드");
                        textPrinterWithCursor.SetTextColorWhite(19, 15, "○ 관리자 모드");
                        break;
                    case (int)SelectModeByCursor.ManagerMode:
                        //유저 모드를 하얀색, 관리자 모드를 초록색으로 설정 
                        textPrinterWithCursor.SetTextColorWhite(20, 14, "○ 유저 모드");
                        textPrinterWithCursor.SetTextColorGreen(19, 15, "● 관리자 모드");
                        break;
                }

                //item1 : (int)keyNumber, item2 : (bool) check
                //keyNumber : 커서 이동할 때마다 증가 혹은 감소하는 int형 변수 
                //check : 사용자가 엔터 키를 누르면 false가 됨.

                var tuple = textPrinterWithCursor.SetColorByUpDownArrow(1, 2, cursorNumber);

                //check가 false이면 cursorNumber 반환 (= 엔터 눌리면 cursorNumber 반환)
                if (!tuple.Item2)
                    return cursorNumber;

                cursorNumber = tuple.Item1;
                //cursorNumber는 사용자의 입력에 따라 증감된 keyNumber
            }
        }

        private bool HandleUserMode(out int cursorNumber)
        {
            //모드 선택에서 유저 모드로 이동했을 경우 실행되는 메소드 
            AccountView userAccountView = new AccountView();
            ModeSelectView modeSelectView = new ModeSelectView();
            TextPrinterWithCursor textPrinterWithCursor = new TextPrinterWithCursor();

            Console.Clear();

            modeSelectView.ViewLibraryLogo();
            userAccountView.ViewUserAccount();

            //커서에 따라 색상을 설정하는 값을 number에 할당
            int number = SetColorByCursor();
            //number에 따라 로그인 또는 회원가입 처리, 그 결과를 cursorNumber에 할당
            cursorNumber = LoginOrSignUp(number);

            //커서 번호를 out 매개변수를 통해 반환
            //number가 0이 아니면 true, 0이면 false 반환
            return number != 0;
        }

        private bool HandleManagerMode(out int cursorNumber)
        {
            //모드 선택에서 매니저 모드로 이동했을 경우 실행되는 메소드 
            ModeSelectView modeSelectView = new ModeSelectView();
            AccountView userAccountView = new AccountView();
            Account userModeAccount = new Account(userId);
            UserMenu userMenu = new UserMenu();
            ManagerModeSelector managerModeSelector = new ManagerModeSelector();

            Console.Clear();

            modeSelectView.ViewLibraryLogo();
            userAccountView.ViewLogin();
            userId = userModeAccount.Login("managerMode");

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
                int number = managerModeSelector.GoFunctionInManagerMenu(userId);
                managerModeSelector.SelectNumberInManagerMenu(number, userId);
                if (number == 0)
                {
                    cursorNumber = 0;
                    return false;
                }
            }
        }


        public int SetColorByCursor() //view로 빼기 
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
                    case (int)SelectLoginOrSignUp.Login:
                        textPrinterWithCursor.SetTextColorGreen(22, 14, "● 로그인");
                        textPrinterWithCursor.SetTextColorWhite(21, 15, "○ 회원 가입");
                        break;
                    case (int)SelectLoginOrSignUp.SignUp:
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
            MenuVisitor menuVisitor = new MenuVisitor();

            switch (number)
            {
                case 0:
                    return 1;
                case (int)SelectLoginOrSignUp.Login: // 로그인
                    return menuVisitor.HandleLogin(modeSelectView, userAccountView, userModeAccount, userMenu, out userId);
                case (int)SelectLoginOrSignUp.SignUp: // 회원가입
                    return menuVisitor.HandleSignUp(modeSelectView, userAccountView, userModeAccount);
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
            MenuVisitor menuVisitor = new MenuVisitor();
            bool check;
            int number;

            switch (selectedNumber)
            {
                case (int)UserMenuSelect.None: // 유저 메뉴에서 기능 고를 때 esc가 눌린 것
                    userId = null;
                    break;
                case (int)UserMenuSelect.BookSearch: // 도서 찾기
                    menuVisitor.SearchBooks(userId, userFunctionView, dataDisplayer, bookSearcher);
                    break;
                case (int)UserMenuSelect.BookLender: // 도서 대여
                    menuVisitor.RentOutBook(userId, userFunctionView, dataDisplayer, bookservice);
                    break;
                case (int)UserMenuSelect.BookReturn: // 도서 반납
                    menuVisitor.ReturnBook(userId, userFunctionView, bookservice);
                    break;
                case (int)UserMenuSelect.RentalConfirmation: // 도서 대여 확인
                    menuVisitor.ShowRentalList(userId, bookservice);
                    break;
                case (int)UserMenuSelect.ReturnList: // 도서 반납 내역
                    menuVisitor.ShowReturnList(userId, bookservice);
                    break;
                case (int)UserMenuSelect.UserInfoUpdate: // 회원 정보 수정
                    menuVisitor.UpdateUserData(userId, userFunctionView, dataDisplayer, userDataService);
                    break;
                case (int)UserMenuSelect.UserWithdrawal: // 회원 탈퇴
                    menuVisitor.DeleteUserData(userId, userFunctionView, userDataService);
                    break;
                case (int)UserMenuSelect.BookApplication: // 도서 신청
                    menuVisitor.ApplyBook(userId, userFunctionView, bookApplier);
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
            List<string> strList = new List<string>() { "도서 찾기", "도서 대여", "도서 반납", "도서 대여 확인", "도서 반납 내역", "회원 정보 수정", "회원 탈퇴", "도서 신청" };

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
                        listWithColoredIndexPrinter.PrintListWithColoredIndex(strList, 0, 26, 13);
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