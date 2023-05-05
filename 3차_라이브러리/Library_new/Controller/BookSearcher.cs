using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;
using Library.Model;
using Library.View;
using Library.Controller;
using Library.Constant;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Library.Controller
{
    internal class BookSearcher
    {
        
        public void SearchBook(bool check) //check -> 유저모드면 true, 관리자모드면 false
        {
            RegexChecker regexChecker = new RegexChecker();
            Console.Clear();
            BookUpdater bookUpdater = new BookUpdater();

            bookUpdater.DisplayAllBook(); //모든 책 표시

            Console.WriteLine(" < 도서 찾기 >  \n");

            Console.WriteLine(" ⓛ 제목으로 찾기 ");
            Console.WriteLine(" ② 작가명으로 찾기");
            Console.WriteLine(" ③ 출판사명으로 찾기");

            Console.WriteLine(" 0을 입력해 돌아가기");
            int number;
            number = regexChecker.CheckRegexWhenValueIsNumber(0, 3, "^[0-3]$"); //정규식 만족하면 검색하기, 0부터 3
            SearchBookWithNumber(number, check);

        }
        public void SearchBookWithNumber(int number, bool modeChecker)
        {
            ManagerMenu managerMenu = new ManagerMenu();
            UserMenuDisplay userMenuDisplay = new UserMenuDisplay();
            BookUpdater bookUpdater = new BookUpdater();

            int flag = 0;

            switch (number)
            {
                case 0: //돌아가기
                    Console.Clear();
                    if (modeChecker) {
                        //유저모드면 유저메뉴로 돌아가기
                        userMenuDisplay.ViewUserMenu();
                    } 
                    else
                    { //관리자모드면 관리자메뉴로 돌아가기
                        managerMenu.SelectNumberInManagerMenu();
                    }
                    break;
                case 1:
                    Console.Write("제목을 입력하세요 : ");
                    string title = Console.ReadLine();
                    Console.Clear();
                    bookUpdater.DisplayBookInformation($"SELECT * FROM bookconstructor WHERE bookName = '{title}'");
                    
                    break;
                case 2:
                    Console.Write("작가명을 입력하세요 : ");
                    string authorname = Console.ReadLine();
                    Console.Clear();
                    bookUpdater.DisplayBookInformation($"SELECT * FROM bookconstructor WHERE author = '{authorname}'");

                    break;
                case 3:
                    Console.Write("출판사명을 입력하세요 : ");
                    string publishername = Console.ReadLine();
                    Console.Clear();
                    bookUpdater.DisplayBookInformation($"SELECT * FROM bookconstructor WHERE publisher = '{publishername}'");
                    break;


            }


        }
    }
        
}
