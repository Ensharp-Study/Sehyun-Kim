using System.Text;
using static System.Console;
using System.Threading.Tasks;
using Library.Model;
using Library.View;
using Library.Controller;

namespace Library.Controller
{
    internal class LoginSignupSelector
    {
        private BookData bookData;
        private UserData userData;

        public LoginSignupSelector(BookData bookData, UserData userData)
        {
            this.bookData = bookData;
            this.userData = userData;
        }

        //입력하는 숫자에 따라 로그인 또는 회원가입 프로세스로 이동
        public void SelectLoginSignup()
        {
            HomeDisplay homeDisplay = new HomeDisplay();
            Account loginOrNewmember = new Account(bookData, userData);
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
                    loginOrNewmember.Login(); //로그인
                    break;
                case 2: 
                    loginOrNewmember.Register(); //회원가입
                    break;

            }
        }
}
}
