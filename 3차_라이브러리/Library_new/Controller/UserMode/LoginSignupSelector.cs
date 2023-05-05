﻿using System.Text;
using static System.Console;
using System.Threading.Tasks;
using Library.Model;
using Library.View;
using Library.Controller;

namespace Library.Controller
{
    internal class LoginSignupSelector
    {
        private string userid;

        //입력하는 숫자에 따라 로그인 또는 회원가입 프로세스로 이동
        public void SelectLoginSignup()
        {
            HomeDisplay homeDisplay = new HomeDisplay();
            Account account = new Account(userid);
            AccountView accountView = new AccountView();
            ModeSelector modeSelector = new ModeSelector(); 

            accountView.ViewAccountMenu(); //유저모드 -> 로그인 또는 회원가입 View

            int number = int.Parse(Console.ReadLine()); //숫자 입력받기 

            switch (number)
            {
                case 0:
                    modeSelector.SelectMode(); //0을 눌러 관리자모드, 유저모드 선택으로 돌아가기 
                    break;
                case 1:
                    account.Login(); //로그인
                    break;
                case 2:
                    account.Register(); //회원가입
                    break;

            }
        }
}
}
