using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;
using Library;
using System.Text.RegularExpressions;
using Library.Model;
using Library.View;
using Library.Controller;
using Library.Constant;
using static Library.Controller.Account;

namespace Library.Constant
{
    internal class ManagerMenu
    {
        private BookData bookData;
        private UserData userData;

        public ManagerMenu(BookData bookData, UserData userData)
        {
            this.bookData = bookData;
            this.userData = userData;
        }

        public void SelectNumberInManagerMenu()
        {
            ManagerMenuView managerMenuView = new ManagerMenuView();
            NumberInputManager numberInputManager = new NumberInputManager(bookData, userData);
            managerMenuView.viewManagermenu();
            int number=numberInputManager.modOfManager();
            ConstantOfManagerMenu(number);
        }
        public void ConstantOfManagerMenu(int num)
        {
            HomeDisplay display = new HomeDisplay();
            NumberInputManager managerMode = new NumberInputManager(bookData, userData);
            UserInfoUpdater modifyBookInfo = new UserInfoUpdater(bookData, userData);
            BookUpdater bookUpdater = new BookUpdater(bookData, userData);
            BookSearcher bookSearcher = new BookSearcher(bookData, userData);
            BookDataAdder bookDataAdder = new BookDataAdder(bookData, userData);
            ModeSelector modeSelector = new ModeSelector();
            BookDataDeleter bookDataDeleter = new BookDataDeleter(bookData, userData);  
            AllBookDisplay allBookDisplay = new AllBookDisplay(bookData, userData);
            bool check = false; //관리자모드니까 false로 설정
            switch (num)
            {
                case 0:
                    Console.Clear();
                    modeSelector.SelectMode(); //유저모드, 관리자모드 中1 선택하기로 돌아가기
                    break;
                case 1:
                    Console.Clear();
                    allBookDisplay.DisplayAllBook();  //모든 책 표시하기 
                    bookSearcher.SearchBook(check); //책 검색하기. process : searchbook 도서 찾기 메뉴 (1-3 입력)
                                                    // -> searchebookwithnumber(입력한 숫자 바탕으로 책 정보 출력) -> viewusermenu(0 눌렀으면 유저메뉴로 복귀)
                    SelectNumberInManagerMenu();
                    break;
                case 2:
                    Console.Clear();
                    bookDataAdder.appendbook();
                    SelectNumberInManagerMenu();
                    break;
                case 3:
                    Console.Clear();
                    bookDataDeleter.DeleteBookInfo();
                    SelectNumberInManagerMenu();
                    break;
                case 4:
                    Console.Clear();
                    bookUpdater.modifyBookInfo();
                    SelectNumberInManagerMenu();
                    break;


            }
        }

        
    }
}
