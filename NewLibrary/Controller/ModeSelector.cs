using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLibrary.Controller.DataDisplayer;
using NewLibrary.Controller.Function;
using NewLibrary.Controller.UserFunction;
using NewLibrary.Utility;
using NewLibrary.View;
using NewLibrary.View.FunctionView;
using NewLibrary.View.MenuView;

namespace NewLibrary.Controller
{
    internal class ModeSelector
    {
        private string userId;
        public void SelectMode() //유저 모드, 관리자 모드 둘 중 하나 선택하는 메소드 
        {
            ModeSelectView modeSelectView = new ModeSelectView();
            TextPrinterWithCursor textPrinterWithCursor = new TextPrinterWithCursor();
            UserAccountView userAccountView = new UserAccountView();
            ManagerAccountView managerAccountView = new ManagerAccountView();
            ManagerMenu managerMenu = new ManagerMenu();    
            bool exit = true;

            while (exit) //exit 값이 true인 동안 반복한다.
            {
                Console.CursorVisible = false; //커서 안 보이게
                Console.SetWindowSize(56, 22);
                modeSelectView.ViewModeSelect(); //모드 고르는 메뉴 view

                bool fine = true;
                int keyNumber = 1;

                while (fine) //keyNumber은 초기값이 1인 상태로 fine이 true일 동안 계속 반복
                {
                    switch (keyNumber)
                    {
                        case 0:
                            return; //esc 누르면 keyNumber값을 0으로 설정하고 종료하기
                        case 1:
                            textPrinterWithCursor.SetTextColorGreen(20, 14, "● 유저 모드");
                            textPrinterWithCursor.SetTextColorWhite(19, 15, "○ 관리자 모드");
                            break;
                        case 2:
                            textPrinterWithCursor.SetTextColorWhite(20, 14, "○ 유저 모드");
                            textPrinterWithCursor.SetTextColorGreen(19, 15, "● 관리자 모드");
                            break;
                    }
                    //tuple의 반환값은 keyNumber, check -> check는 엔터 누르면 false가 됨
                    var tuple = textPrinterWithCursor.SetColorByUpDownArrow(1, 2, keyNumber);
                    if (tuple.Item2 == false) //만약 check가 false이면 반복문 정지하고 keyNumber문으로 이동
                    {                       //check가 false 다 = 엔터가 눌렸다
                        fine = false;
                    }
                    else //엔터가 안 눌렸다 그래서 반환된 값을 다시 keyNumber에 넣어서 또 반복한다.
                    {
                        keyNumber = tuple.Item1;
                    }
                }
                bool checker = true;
                //while(fine)문에서 엔터가 눌렸기 때문에 switch(keyNumber)로 간다.
                while (checker)
                {
                    switch (keyNumber)
                    {
                        case 0:
                            Console.Clear();
                            Environment.Exit(0);
                            break;
                        case 1: //유저 메뉴
                            Console.Clear();

                            userAccountView.ViewUserAccount(); //로그인, 회원가입 고르는 view
                            int Number = SetColorByCursor(); // 로그인, 회원가입 커서이동 엔터값에 따라 Number
                            keyNumber = LoginOrSignUp(Number); //입력된 number로 로그인이나 회원가입 들어가기 
                            if (Number == 0)
                                checker = false;
                            break;
                        case 2: //관리자 메뉴
                            while (checker)
                            {
                                Console.Clear();
                                managerMenu.ViewManagerMenu();
                                fine = true;
                                int number = managerMenu.GoFunctionInManagerMenu();
                                managerMenu.SelectNumberInManagerMenu(number);
                                if (number == 0)
                                    checker = false;
                            }
                            break;

                    }
                }
            }
        }
        public int SetColorByCursor()
        {
            TextPrinterWithCursor textPrinterWithCursor = new TextPrinterWithCursor();
            UserModeAccount userModeAccount = new UserModeAccount(userId);
            UserAccountView userAccountView = new UserAccountView();
            bool fine = true;
            int Number = 1;

            while (fine)
            {
                switch (Number)
                {
                    case 0:
                        Console.Clear();
                        return Number; //esc 누르면 keyNumber값을 0으로 설정하고 종료하기
                    case 1:
                        textPrinterWithCursor.SetTextColorGreen(22, 14, "● 로그인");
                        textPrinterWithCursor.SetTextColorWhite(21, 15, "○ 회원 가입");
                        break;
                    case 2:
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
        public int LoginOrSignUp(int Number)
        {
            TextPrinterWithCursor textPrinterWithCursor = new TextPrinterWithCursor();
            UserModeAccount userModeAccount = new UserModeAccount(userId);
            UserAccountView userAccountView = new UserAccountView();
            UserMenu userMenu = new UserMenu();
            int keyNumber = 1;
            int selectedNumber;
            bool check = true;
            switch (Number)
            {
                case 0:
                    return keyNumber;
                case 1: //로그인
                    Console.Clear();
                    Console.CursorVisible = true;
                    userAccountView.ViewLogin(); //로그인 화면 view
                    userId = userModeAccount.Login("userconstructor"); //로그인 기능 메소드
                    if (userId == null) //로그인 기능 중 esc가 눌린 경우 -> 로그인 또는 회원가입 메뉴로
                    {
                        Console.CursorVisible = false;
                        keyNumber = 1;
                        return keyNumber;
                    }
                    
                    while (check)
                    {
                        Console.Clear();
                        Console.SetWindowSize(62, 27);
                        userMenu.ViewUserMenu(); //유저 메뉴 view
                        selectedNumber = SelectInUserMenu(); //유저 메뉴에서 기능 고르기 
                        userId=MethodInUserMenu(selectedNumber, userId);
                        if (userId == null)
                        {
                            break;
                        }
                    }
                    break;
                case 2: //회원가입
                    bool checker = true;
                    Console.Clear();
                    Console.SetWindowSize(62, 27);
                    userAccountView.ViewSignUp(); //회원가입 화면 view
                    checker = userModeAccount.UserSignUp(); //회원가입 기능 메소드
                    if (!checker)
                    {
                        Console.CursorVisible = false;
                        keyNumber = 1;
                        return keyNumber;
                    }
                    break;
            }
            return keyNumber;
        }
        public string MethodInUserMenu(int selectedNumber, string userId)
        {
            BookSearcher bookSearcher = new BookSearcher();
            UserFunctionView userFunctionView = new UserFunctionView();
            BookDisplayer bookDisplay = new BookDisplayer();
            BookLender bookLender = new BookLender();
            BookReturner bookReturner = new BookReturner();
            UserDataUpdater userDataUpdater = new UserDataUpdater();
            UserDataDeleter userDataDeleter = new UserDataDeleter();
            UserDisplayer userDisplayer = new UserDisplayer();
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
                    bookDisplay.DisplayAllBook();
                    bookSearcher.SearchBook(userId);
                    break;
                case 2: //도서 대여
                    Console.Clear();
                    userFunctionView.ViewBookLenderTop();
                    bookDisplay.DisplayAllBook();
                    bookLender.RentOutBook(userId);
                    break;
                case 3: //도서 반납
                    check = false;
                    Console.Clear();
                    userFunctionView.ViewBookReturnerTop();
                    bookLender.BorrowHistory(userId, check);
                    bookReturner.ReturnBook(userId);
                    break;
                case 4: //도서 대여 확인
                    Console.Clear();
                    check = true;
                    bookLender.BorrowHistory(userId, check);
                    break;
                case 5: //도서 반납 내역
                    Console.Clear();
                    bookReturner.ReturnHistory(userId);
                    break;
                case 6: //회원 정보 수정
                    Console.Clear();
                    userFunctionView.ViewUserDataUpdaterTop();
                    check = false;
                    bool fine = true;
                    userDisplayer.DisplayUserInformation(userId,check);
                    userFunctionView.ViewUserDataUpdaterBottom();
                    number = userDataUpdater.SetCursorWhenUpdate(userId);
                    userDataUpdater.UpdateUserData(userId, number);
                    break;
                case 7: //회원 탈퇴 
                    Console.Clear();
                    userFunctionView.ViewUserDataDeleter();
                    userDataDeleter.DeleteUserData(userId);
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
            UserAccountView userAccountView = new UserAccountView();
            ManagerAccountView managerAccountView = new ManagerAccountView();
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
