using System.Text;
using static System.Console;
using System.Threading.Tasks;
using Library.Model;
using Library.View;
using Library.Controller;
namespace Library.View
{
    internal class UserSignUpDisplay
    {
        private BookData bookData;
        private UserData userData;

        // private LoginOrNewmember loginOrNewmember;
        //private HomeDisplay homeDisplay;

        //public UserSignUpDisplay(HomeDisplay homeDisplay)
        //{
        //    this.homeDisplay = homeDisplay;
        //}
        public UserSignUpDisplay(BookData bookData, UserData userData)
        {
            this.bookData = bookData;
            this.userData = userData;
        }

        public void inputInfo()
        { //로그인 또는 회원가입 메뉴
            HomeDisplay homeDisplay = new HomeDisplay();
            LoginOrNewmember loginOrNewmember = new LoginOrNewmember(bookData,userData);
           
        /*
        private HomeDisplay display;
    UserMode userMode = new UserMode();
    UserData userData = new UserData();
    UserSignUpDisplay userSignUpDisplay = new UserSignUpDisplay();
    public LoginOrNewmember(HomeDisplay display)
    {
        this.display = display;
    }
        */


        Console.WriteLine("                                                                     ");
            Console.WriteLine("       ■       ■■■    ■■■     ■■■         ■       ■■■     ■    ■                             ");
            Console.WriteLine("       ■         ■      ■    ■   ■    ■      ■■      ■    ■   ■    ■                          ");
            Console.WriteLine("       ■         ■      ■■■     ■■■       ■  ■     ■■■      ■  ■                                ");
            Console.WriteLine("       ■         ■      ■    ■   ■  ■      ■ ■ ■    ■  ■        ■                          ");
            Console.WriteLine("       ■■■   ■■■    ■■■     ■    ■   ■      ■   ■    ■      ■                             ");
            Console.WriteLine("                                                                    ");
            Console.WriteLine("                                                                    \n\n\n\n\n\n\n ");



            Console.WriteLine("                      ■□■□■□■□■□■□■□■□■□■");
            Console.WriteLine("                      □                                  □              ");
            Console.WriteLine("                      ■                                  ■    ");
            Console.WriteLine("                      □            ① 로그인             □            ");
            Console.WriteLine("                      ■           ② 회원가입            ■                    ");
            Console.WriteLine("                      □                                  □               ");
            Console.WriteLine("                      ■         0을 눌러 돌아가기        ■               ");
            Console.WriteLine("                      □■□■□■□■□■□■□■□■□■□\n\n");

            int num = int.Parse(Console.ReadLine());

            switch (num)
            {
                case 0:
                    homeDisplay.InitialDisplay();
                    break;
                case 1: //로그인
                    loginOrNewmember.LoginProcess();
                    break;
                case 2: //회원가입
                    loginOrNewmember.NewMemberProcess();
                    break;

            }
        }
    }
}
