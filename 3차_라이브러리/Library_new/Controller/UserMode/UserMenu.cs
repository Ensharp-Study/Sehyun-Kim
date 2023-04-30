using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.View;
using Library.Controller;
using Library.Model;
using Library.Constant;

namespace Library.Constant
{
    internal class UserMenu
    {
        private BookData bookData;
        private UserData userData;

        public UserMenu(BookData bookData, UserData userData)
        {
            this.bookData = bookData;
            this.userData = userData;
        }

        public void SelectNumberInUserMenu()
        {
            UserMenu userMenu = new UserMenu(bookData, userData);
            UserMenuDisplay userMenuDisplay = new UserMenuDisplay();
            NumberInputUser numberInputUser = new NumberInputUser();

            userMenuDisplay.ViewUserMenu(); //1번부터 7번까지 표시하는 유저메뉴 view
            int number = numberInputUser.CheckRegex(); //정규식 만족하는 number 받아오기
            ConstantOfUserMenu(number); //받아온 number를 constantofusermenu에 넣어서 기능 실행
        }
        public void ConstantOfUserMenu(int number)
        {
            AllBookDisplay allBookDisplay = new AllBookDisplay(bookData,userData);
            ModeSelector modeSelector = new ModeSelector();
            BookSearcher bookSearcher = new BookSearcher(bookData, userData);
            UserMenuDisplay userMenuDisplay = new UserMenuDisplay();
            UserMenu userMenu = new UserMenu(bookData, userData);
            NumberInputUser numberInputUser = new NumberInputUser();
            BookLender bookLender = new BookLender(bookData, userData);
            BookReturner bookReturner = new BookReturner(bookData, userData);
            UserInfoUpdater userInfoUpdater = new UserInfoUpdater(bookData, userData);
            UserDataDeleter userDataDeleter = new UserDataDeleter(bookData, userData);  
            bool check = true; //유저모드인지 관리자모드인지 판단하는 bool, 유저모드니까 true
            
            switch (number)
            {

                case 0:
                    Console.Clear();
                    modeSelector.SelectMode(); //유저모드, 관리자모드 中1 선택하기로 돌아가기 
                    break;

                case 1: //도서 찾기 
                    Console.Clear();
                    allBookDisplay.DisplayAllBook();  //모든 책 표시하기 
                    bookSearcher.SearchBook(check); //책 검색하기. process : searchbook 도서 찾기 메뉴 (1-3 입력)
                                                    // -> searchebookwithnumber(입력한 숫자 바탕으로 책 정보 출력) -> viewusermenu(0 눌렀으면 유저메뉴로 복귀)
                    SelectNumberInUserMenu();
                    break;

                case 2: //도서 대여 
                    Console.Clear();
                    allBookDisplay.DisplayAllBook();//모든 책 표시하기 
                    bookLender.RentOutBook();// 책 대여하기
                    SelectNumberInUserMenu();
                    break;

                case 3: //도서 반납
                    Console.Clear();
                    bookReturner.returnBook();
                    SelectNumberInUserMenu();
                    break;

                case 4: //도서 대여 확인
                    Console.Clear();
                    bookLender.borrowhistory();
                    SelectNumberInUserMenu();
                    break;
                case 5: //도서 반납 내역
                    Console.Clear();
                    bookReturner.returnhistory();
                    SelectNumberInUserMenu();
                    break;
                case 6://회원 정보 수정
                    Console.Clear();
                    userInfoUpdater.modifyuserinfo();
                    SelectNumberInUserMenu();
                    break;
                case 7://회원 탈퇴 
                    Console.Clear();
                    userDataDeleter.deleteuserinfo();
                    modeSelector.SelectMode();

                    break;
            }
        }
    }
}
