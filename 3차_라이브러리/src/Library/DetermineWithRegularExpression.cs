using System;
using System.Collections.Generic;
using System.Diagnostics; //Debug
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; //정규식 쓸 때 넣는 코드 
using System.Threading.Tasks;
namespace Library
{
    internal class DetermineWithRegularExpression
    {
        public void JudgeBookID(string IDValue) //아이디 정규식 검사 
        {
            Regex reg = new Regex(@"^[0-9]+");//숫자로만 이루어져 있는가?

            if(!reg.IsMatch(IDValue))
            {
                int variablelength = IDValue.Length;
                for (int reckon = 0; reckon < variablelength; reckon++)
                {
                    Console.Write("\b");
                }
                Console.SetCursorPosition(5, 13);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("잘못된 형식을 입력했습니다.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void JudgeBookName(string BookNameValue)
        {
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
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void Judgeauthor(string authorValue)
        {
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
            }
        }
        public void JudgePublisher(string PublisherValue)
        {
            Regex reg = new Regex(@"^[\p{L}]+$");//영어,한글,숫자 1글자 이상으로 이루어져 있는가?

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
            }
        }
        public void Judgeprice(string priceValue)
        {
            Regex reg = new Regex(@"^[1-9][0-9]{0,2}$");//1-999 사이 자연수로 이루어져 있는가?

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
            }
        }
        public void Judgequantity(string quantityValue)
        {
            Regex reg = new Regex(@"^[1-9][0-9]{0,6}$");//1-9999999 사이 자연수로 이루어져 있는가?

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
            }
        }

        public void JudgepublicationDate(string publicationDateValue)
        {
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
            }
        }
        
        public void Judgeisbn(string isbnValue)
        {
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
            }
        }

        public void Judgeinfo(string infoValue)
        {
            Regex reg = new Regex(@"^\d{9}$");//정수 9개로 이루어져 있는가?

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
