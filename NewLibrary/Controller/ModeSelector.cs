﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLibrary.View;
namespace NewLibrary.Controller
{
    internal class ModeSelector
    {
        public void SelectMode()
        {
            ModeSelectView modeSelectView = new ModeSelectView();
            TextPrinterWithCursor textPrinterWithCursor = new TextPrinterWithCursor();

            UserAccountView userAccountView = new UserAccountView();
            ManagerAccountView managerAccountView = new ManagerAccountView();  
             
            
            Console.CursorVisible = false; //커서 안 보이게
            
            modeSelectView.ViewModeSelect(); //모드 고르는 메뉴 view

            bool fine = true;
            int keyNumber = 1;
            while (fine)
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
                if (tuple.Item2==false) //만약 check가 false이면
                {
                    fine = false;
                }
                else
                {
                    keyNumber = tuple.Item1;
                }
            }
            switch (keyNumber)
            {
                case 1:
                    Console.Clear();
                    userAccountView.ViewUserAccount();
                    SelectUserLog();
                    //유저 모드view -> 로그인/회원가입 view
                    //account이랑 signup 둘중에 고르기
                    //if account 메소드에서 반환된 bool값이 true이면 유저 모드로 간다
                    //유저 모드 view
                    //while 유저 모드에서 입력받기 -> esc를 누르면 나온다. 중지
                    break;
                case 2:
                    Console.Clear();
                    //관리자 모드
                    break;
            }
        }

        private string userId;
        public void SelectUserLog()
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
                        return; //esc 누르면 keyNumber값을 0으로 설정하고 종료하기
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
            
            switch (Number)
            {
                case 1:
                    Console.Clear();
                    Console.CursorVisible = true;
                    userAccountView.ViewLogin(); //로그인 화면 view
                    userModeAccount.UserLogin(); //로그인 기능 메소드
                    
                    //login 메소드 실행
                    break;
                case 2:
                    Console.Clear();
                    //signup 메소드 실행
                    break;
            }
        }
    }
}
