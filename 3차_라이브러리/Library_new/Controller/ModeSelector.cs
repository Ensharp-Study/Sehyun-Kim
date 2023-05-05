using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Constant;
using Library.Controller;
using Library.Model;
using Library.View;

namespace Library.Controller
{
    internal class ModeSelector
    {
        public void SelectMode()
        {
            UserData userData = new UserData();
            BookData bookData = new BookData();
            AccountView accountView = new AccountView();
            HomeDisplay homeDisplay = new HomeDisplay();
            NumberInputManager managerMode = new NumberInputManager();
            ModeSelector modeSelector = new ModeSelector();
            LoginSignupSelector loginSignupSelector = new LoginSignupSelector(); 
            NumberInputManager numberInputManager = new NumberInputManager();
            ManagerMenu managerMenu = new ManagerMenu();


            userData.SetUserData();
            bookData.InsertBookData(); //데이터 처음 생성

            homeDisplay.InitialDisplay(); //메인 화면

            int number = int.Parse(Console.ReadLine()); //메인 화면에서 숫자 입력 -> 1. 유저모드 , 2. 관리자모드 , 0이면 종료 
            
            switch (number)
            {
                case 0: //종료
                    Console.Clear();
                    return;
                case 1: 
                    Console.Clear();
                    loginSignupSelector.SelectLoginSignup(); //입력하는 숫자에 따라 로그인 또는 회원가입 프로세스로 이동
                    break;
                case 2: //관리자모드
                    Console.Clear();
                    managerMenu.SelectNumberInManagerMenu(); //관리자 모드로 이동
                    break;
            }
        }
    }
}
