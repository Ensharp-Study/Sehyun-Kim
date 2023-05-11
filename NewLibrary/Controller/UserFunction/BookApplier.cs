using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLibrary.Constant;
using NewLibrary.Model;
using NewLibrary.Utility;
using Newtonsoft.Json.Linq;

namespace NewLibrary.Controller.UserFunction
{
    internal class BookApplier
    { 
        public void ApplyBook(string userId)
        { //도서 신청하기 
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            APIConnection apiConnection = new APIConnection();

            string inputBookWord="";
            string inputBookQuantity="0";
            bool fine = true;

            Console.CursorVisible = true;

            while (fine)
            {//inputBookWord 입력&예외처리
                inputBookWord = inputKeyUnlessEnter.SaveInputUnlessEnter(12, 6);
                fine=inputKeyUnlessEnter.CheckRegex(inputBookQuantity, RegexConstant.englishKoreanNumberRegex, 10, 6, 10, 9, "잘못된 입력입니다");
            }
            fine = true;

            while (fine)
            {//inputBookQuantity 입력&예외처리
                inputBookQuantity = inputKeyUnlessEnter.SaveInputUnlessEnter(12, 7);
                fine = inputKeyUnlessEnter.CheckRegex(inputBookQuantity, RegexConstant.onlyNumberRegex, 10, 7, 10, 9, "잘못된 입력입니다");
            }

            //inputBookQuantity 변수 int 형변환
            int quantity = int.Parse(inputBookQuantity);
            
            //ConnectNaverApi 메소드에 원하는 검색 결과 수, 키워드 넣어서 JArray 받아오기
            JArray items=apiConnection.ConnectNaverApi(quantity, inputBookWord);

            Console.SetCursorPosition(0, 9);

            //ConnectNaverApi 메소드를 통해 받아온 JArray를 정렬해서 출력하기
            foreach (var item in items)
            {
                string title = item["title"].ToString();
                string link = item["link"].ToString();
                string author = item["author"].ToString();
                string discount = item["discount"].ToString();
                string publisher = item["publisher"].ToString();
                string pubdate = item["pubdate"].ToString();
                string isbn = item["isbn"].ToString();
                string description = item["description"].ToString();

                // 출력을 정렬하여 표시
                Console.WriteLine($"Title: {title}");
                Console.WriteLine($"Author: {author}");
                Console.WriteLine($"Publisher: {publisher}");
                Console.WriteLine($"Publication Date: {pubdate}");
                Console.WriteLine($"Discount: {discount}");
                Console.WriteLine($"ISBN: {isbn}");
                Console.WriteLine($"Description: {description}");
                Console.WriteLine("============================================================");
            }
            fine = true;
            string inputIsbn="";
            Console.WriteLine("추가할 도서의 isbn을 입력하세요.");
            while (fine)
            {//inputIsbn 입력&예외처리
                inputIsbn = inputKeyUnlessEnter.SaveInputUnlessEnter(12, 7);
                //이거 아이에스비엔 regex 새로 만들어놓기
                fine = inputKeyUnlessEnter.CheckRegex(inputIsbn, RegexConstant.onlyNumberRegex, 10, 7, 10, 9, "잘못된 입력입니다");
            }
            foreach (var item in items)
            {
                string isbn = item["isbn"].ToString();
                if (inputIsbn == isbn)
                {

                }

            }

            //ESC를 눌러 돌아가기 기능
            Console.WriteLine("                  ESC를 눌러 돌아가기");

            while (true)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Escape) //esc 입력됐을 경우
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
