using System;
using System.Collections.Generic;
using System.Diagnostics; //Debug
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; //정규식 쓸 때 넣는 코드 
using System.Threading.Tasks;
using Library.Model;
using Library.View;
using Library.Controller;

namespace Library.Controller
{
    internal class DetermineWithRegularExpression
    {
        private BookData bookData;
        private UserData userData;

        public DetermineWithRegularExpression(BookData bookData, UserData userData)
        {
            this.bookData = bookData;
            this.userData = userData;
        }

        public void JudgeID(string EssenceValue, int TypeCheck, int booklistnumber) //아이디 정규식 검사 
        {
            CheckInputIsEnter checkInputIsEnter = new CheckInputIsEnter(bookData, userData);
           

            Regex reg = new Regex(@"^[0-9]+");//숫자로만 이루어져 있는가?

            if (!reg.IsMatch(EssenceValue))
            {
                int variablelength = EssenceValue.Length;
                for (int reckon = 0; reckon < variablelength; reckon++)
                {
                    Console.Write("\b");
                }
                Console.SetCursorPosition(5, 13);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("잘못된 형식을 입력했습니다.");
                Console.ForegroundColor = ConsoleColor.White;

                string randomExpression = "";
                int Entercase = 0;
                Console.SetCursorPosition(5, 13);
                checkInputIsEnter.SaveIDIfNotEnter(randomExpression, Entercase, booklistnumber);

            }
            else
            {
                bookData.BookList[booklistnumber].id = Int32.Parse(EssenceValue);
                
            }
        }
        
        public void JudgeBookName(string BookNameValue, int TypeCheck, int booklistnumber)
        {
            CheckInputIsEnter checkInputIsEnter = new CheckInputIsEnter(bookData, userData);
           

            Regex reg = new Regex(@"^[\p{L}\p{N}]+$");//영어,한글,숫자 1글자 이상으로 이루어져 있는가?

            if (!reg.IsMatch(BookNameValue))
            {
                int variablelength = BookNameValue.Length;
                for (int reckon = 0; reckon < variablelength; reckon++)
                {
                    Console.Write("\b");
                }
                Console.SetCursorPosition(8, 14);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("잘못된 형식을 입력했습니다.");
                Console.ForegroundColor = ConsoleColor.White;//잘못된 형식을 입력한 경우 다시 saveifnotenter 메소드로 가야 한다.
                Console.SetCursorPosition(8, 14);
                string randomExpression = "";
                int Entercase = 0;
                checkInputIsEnter.SaveTitleIfNotEnter(randomExpression, Entercase, booklistnumber);
               
            }
            else
            {
                bookData.BookList[booklistnumber].bookName = BookNameValue;
            }
        }
        
        public void Judgeauthor(string authorValue, int TypeCheck, int booklistnumber)
        {
            CheckInputIsEnter checkInputIsEnter = new CheckInputIsEnter(bookData, userData);
           

            Regex reg = new Regex(@"^[\p{L}]+$");//영어, 한글 1글자 이상으로 이루어져 있는가?

            if (!reg.IsMatch(authorValue))
            {
                int variablelength = authorValue.Length;
                for (int reckon = 0; reckon < variablelength; reckon++)
                {
                    Console.Write("\b");
                }
                Console.SetCursorPosition(9, 15);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("잘못된 형식을 입력했습니다.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(9, 15);
                string randomExpression = "";
                int Entercase = 0;
                checkInputIsEnter.SaveAuthorIfNotEnter(randomExpression, Entercase, booklistnumber);
               
            }
            else
            {
                bookData.BookList[booklistnumber].author = authorValue;
            }
        }
        
        public void JudgePublisher(string PublisherValue, int TypeCheck, int booklistnumber)
        {
            CheckInputIsEnter checkInputIsEnter = new CheckInputIsEnter(bookData, userData);
            

            Regex reg = new Regex(@"^[\p{L}\p{N}]+$");//영어,한글,숫자 1글자 이상으로 이루어져 있는가?

            if (!reg.IsMatch(PublisherValue))
            {
                int variablelength = PublisherValue.Length;
                for (int reckon = 0; reckon < variablelength; reckon++)
                {
                    Console.Write("\b");
                }
                Console.SetCursorPosition(12, 16);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("잘못된 형식을 입력했습니다.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(12, 16);
                string randomExpression = "";
                int Entercase = 0;
                checkInputIsEnter.SavePublisherIfNotEnter(randomExpression, Entercase, booklistnumber);
                
            }
            else
            {
                bookData.BookList[booklistnumber].publisher = PublisherValue;
            }
        }
        
        public void Judgeprice(string priceValue, int TypeCheck, int booklistnumber)
        {
            CheckInputIsEnter checkInputIsEnter = new CheckInputIsEnter(bookData, userData);
           
            Regex reg = new Regex(@"^[1-9][0-9]{0,6}$");//1-9999999 사이 자연수로 이루어져 있는가?

            if (!reg.IsMatch(priceValue))
            {
                int variablelength = priceValue.Length;
                for (int reckon = 0; reckon < variablelength; reckon++)
                {
                    Console.Write("\b");
                }
                Console.SetCursorPosition(8, 17);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("잘못된 형식을 입력했습니다.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(8, 17);
                string randomExpression = "";
                int Entercase = 0;
                checkInputIsEnter.SavePriceIfNotEnter(randomExpression, Entercase, booklistnumber);
                
            }
            else
            {
                bookData.BookList[booklistnumber].price = Int32.Parse(priceValue);
            }

        }
        
        public void Judgequantity(string quantityValue, int TypeChec, int booklistnumber)
        {
            CheckInputIsEnter checkInputIsEnter = new CheckInputIsEnter(bookData, userData); 

            Regex reg = new Regex(@"^[1-9][0-9]{0,2}$");//1-999 사이 자연수로 이루어져 있는가?
            if (!reg.IsMatch(quantityValue))
            {
                int variablelength = quantityValue.Length;
                for (int reckon = 0; reckon < variablelength; reckon++)
                {
                    Console.Write("\b");
                }
                Console.SetCursorPosition(11, 18);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("잘못된 형식을 입력했습니다.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(11, 18);
                string randomExpression = "";
                int Entercase = 0;
                checkInputIsEnter.SaveQuantityIfNotEnter(randomExpression, Entercase, booklistnumber);
                
            }
            else
            {
                bookData.BookList[booklistnumber].quantity = Int32.Parse(quantityValue);
            }
        }
        
        public void JudgepublicationDate(string publicationDateValue, int TypeCheck, int booklistnumber)
        {
            CheckInputIsEnter checkInputIsEnter = new CheckInputIsEnter(bookData, userData);
            

            Regex reg = new Regex(@"^(19|20)\d{2}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[0-1])");//출판일자로 이루어져 있는가?

            if (!reg.IsMatch(publicationDateValue))
            {
                int variablelength = publicationDateValue.Length;
                for (int reckon = 0; reckon < variablelength; reckon++)
                {
                    Console.Write("\b");
                }
                Console.SetCursorPosition(18, 19);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("잘못된 형식을 입력했습니다.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(18, 19);
                string randomExpression = "";
                int Entercase = 0;
                checkInputIsEnter.SavePublicationIfNotEnter(randomExpression, Entercase, booklistnumber);
                
            }
            else
            {
                bookData.BookList[booklistnumber].publicationDate = publicationDateValue;
            }
        }
        
        public void Judgeisbn(string isbnValue, int TypeCheck, int booklistnumber)
        {
            CheckInputIsEnter checkInputIsEnter = new CheckInputIsEnter(bookData, userData);
            
            Regex reg = new Regex(@"^\d{9}$");//정수 9개로 이루어져 있는가?

            if (!reg.IsMatch(isbnValue))
            {

                int variablelength = isbnValue.Length;
                for (int reckon = 0; reckon < variablelength; reckon++)
                {
                    Console.Write("\b");
                }
                Console.SetCursorPosition(7, 20);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("잘못된 형식을 입력했습니다.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(7, 20);
                string randomExpression = "";
                int Entercase = 0;
                 checkInputIsEnter.SaveIsbnIfNotEnter(randomExpression, Entercase, booklistnumber);
                
            }
            else
            {
                bookData.BookList[booklistnumber].isbn = isbnValue;
            }
        }
        

        public void Judgeinfo(string infoValue, int TypeCheck, int booklistnumber)
        {
            CheckInputIsEnter checkInputIsEnter = new CheckInputIsEnter(bookData, userData);
            

            Regex reg = new Regex(@"^[\p{L}\p{N}]+$");//영어,한글,숫자 1글자 이상으로 이루어져 있는가?

            if (!reg.IsMatch(infoValue))
            {
                int variablelength = infoValue.Length;
                for (int reckon = 0; reckon < variablelength; reckon++)
                {
                    Console.Write("\b");
                }
                Console.SetCursorPosition(7, 21);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("잘못된 형식을 입력했습니다.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(7, 21);
                string randomExpression = "";
                int Entercase = 0;
                checkInputIsEnter.SaveInfoIfNotEnter(randomExpression, Entercase, booklistnumber);
                
            }
            else
            {
                bookData.BookList[booklistnumber].info = infoValue;
            }
        }

    }


}
/*    @"^[\p{L}]+$" 영어 한글 1글자
 *    @"^[\p{L}\p{N}]+$" 영어,한글,숫자 1글자
 *    @"^[1-9][0-9]{0,2}$" 1-999 사이 자연수
 *    @"^[1-9][0-9]{0,6}$"  1-9999999
 *    @"^\d{9}$" 정수 9개
 *    @"^(19|20)\d{2}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[0-1])" 출판일자
*/
