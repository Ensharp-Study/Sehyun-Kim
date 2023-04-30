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
using static Library.Controller.Account;

namespace Library.Controller
{
    internal class BookUpdater
    {
        private BookData bookData;
        private UserData userData;
        private AllBookDisplay showAllBook;

        public BookUpdater(BookData bookData, UserData userData)
        {
            this.bookData = bookData;
            this.userData = userData;
            showAllBook = new AllBookDisplay(bookData, userData);
        }
        
        public void modifyBookInfo()
        {
            Console.Clear();
            showAllBook.DisplayAllBook();
            RulesForBookData viewRulesForBookData = new RulesForBookData();
            RegexValidator determineWithRegularExpression = new RegexValidator(bookData, userData);
            InputTaker checkInputIsEnter = new InputTaker(bookData, userData);
            BookUpdateView showForUpdateBookInfo = new BookUpdateView(bookData, userData);

            Console.WriteLine("수정할 책 id를 입력하세요.");
            int inputBookId = int.Parse(Console.ReadLine());
            int booklistnumber = 0;
            int count = 0;
            int flag = 0;
            foreach (BookConstructor book in bookData.BookList)
            {
                count++;
                if (book.id == inputBookId)
                {
                    Console.Clear();
                    booklistnumber = count - 1;
                    showForUpdateBookInfo.ViewForUpdateBookInfo(booklistnumber);
                    viewRulesForBookData.ViewRulesForBookData();

                    //ㅡㅡㅡㅡㅡㅡㅡIDㅡㅡㅡㅡㅡㅡㅡㅡㅡ 
                    Console.SetCursorPosition(5, 13);
                    string randomExpression = "";
                    int Entercase = 0;
                    int TypeCheck = 0;
                    checkInputIsEnter.SaveIDIfNotEnter(randomExpression, Entercase, booklistnumber);

                    //ㅡㅡㅡㅡㅡㅡㅡTitleㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(8, 14);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    checkInputIsEnter.SaveTitleIfNotEnter(randomExpression, Entercase, booklistnumber);
                    //ㅡㅡㅡㅡㅡㅡㅡauthorㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(9, 15);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    checkInputIsEnter.SaveAuthorIfNotEnter(randomExpression, Entercase, booklistnumber);
                    //ㅡㅡㅡㅡㅡㅡㅡㅡpublisherㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(12, 16);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    checkInputIsEnter.SavePublisherIfNotEnter(randomExpression, Entercase, booklistnumber);
                    //ㅡㅡㅡㅡㅡㅡㅡㅡpriceㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(8, 17);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    checkInputIsEnter.SavePriceIfNotEnter(randomExpression, Entercase, booklistnumber);
                    //ㅡㅡㅡㅡㅡㅡㅡㅡquantityㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(11, 18);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    checkInputIsEnter.SaveQuantityIfNotEnter(randomExpression, Entercase, booklistnumber);
                    //ㅡㅡㅡㅡㅡㅡㅡㅡpublcationㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(18, 19);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    checkInputIsEnter.SavePublicationIfNotEnter(randomExpression, Entercase, booklistnumber);
                    //ㅡㅡㅡㅡㅡㅡㅡㅡisbnㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(7, 20);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    checkInputIsEnter.SaveIsbnIfNotEnter(randomExpression, Entercase, booklistnumber);
                    //ㅡㅡㅡㅡㅡㅡㅡㅡinfoㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(7, 21);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    checkInputIsEnter.SaveInfoIfNotEnter(randomExpression, Entercase, booklistnumber);
                    flag = 1;
                }




            }
            Console.Clear();
            if (flag == 1)
            {
                Console.WriteLine("정보가 성공적으로 수정되었습니다.");
            }
        }
    }
}
