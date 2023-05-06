using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLibrary.View;
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

                //while(fine)문에서 엔터가 눌렸기 때문에 switch(keyNumber)로 간다.
                while (true)
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
                            //keyNumber가 0이면 나가짐
                            break;
                        case 2: //관리자 메뉴
                            Console.Clear();
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
            int keyNumber=1;
            switch (Number)
            {
                case 1: //로그인
                    Console.Clear();
                    Console.CursorVisible = true;
                    userAccountView.ViewLogin(); //로그인 화면 view
                    userId = userModeAccount.UserLogin(); //로그인 기능 메소드
                    if (userId == null) //로그인 기능 중 esc가 눌린 경우 -> 로그인 또는 회원가입 메뉴로
                    {
                        Console.CursorVisible = false;
                        keyNumber = 1;
                        return keyNumber;
                    }
                    //안 눌렸으면 유저 메뉴 view
                    //유저메뉴에서 받은 값을 return
                    break;
                case 2: //회원가입
                    Console.Clear();
                    Console.SetWindowSize(62, 27);
                    userAccountView.ViewSignUp(); //회원가입 화면 view
                    userModeAccount.UserSignUp(); //회원가입 기능 메소드
                    break;
            }
            return keyNumber;
        }
    }
}
