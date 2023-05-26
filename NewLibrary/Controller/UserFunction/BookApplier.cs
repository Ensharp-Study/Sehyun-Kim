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
        { //신청된 도서 추가하기  
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            APIConnection apiConnection = new APIConnection();
            FunctionInDAO mysqlConnecter = new FunctionInDAO();

            string inputBookWord="";
            string inputBookQuantity="0";
            bool fine = true;
            DateTime returnTime;
            string returnTimeString = "";
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

            Console.SetCursorPosition(0, 17);
            Console.WriteLine("============================================================");
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
            Console.SetCursorPosition(0, 9);
            Console.WriteLine("추가할 책의 isbn을 입력하세요");
            Console.SetCursorPosition(0, 11);
            Console.WriteLine("책의 id를 설정하세요.");
            Console.SetCursorPosition(0, 13);
            Console.WriteLine("책의 수량을 설정하세요.");
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("책의 info를 설정하세요.");

            string inputBookisbn = "";
            string inputBookId = "";
            string inputBookInfo = "";
            string inputQuantity = "0";
            while (fine)
            {//inputBookisbn 입력&예외처리
                inputBookisbn = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 10);
                fine = inputKeyUnlessEnter.CheckRegex(inputBookisbn, RegexConstant.isbnRegex, 0, 10, 10, 10, "잘못된 입력입니다");
                int modifyImpossible = 0;
                modifyImpossible = mysqlConnecter.ReadData("isbn", $"SELECT isbn FROM bookconstructor WHERE isbn ='{inputBookisbn}'");
                if (modifyImpossible >= 1)
                {
                    fine = true;
                    Console.SetCursorPosition(10, 10);
                    Console.WriteLine("이미 존재하는 isbn입니다!");
                }
            }
            fine = true;
            while (fine)
            {//inputBookId 입력&예외처리
                inputBookId = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 12);
                fine = inputKeyUnlessEnter.CheckRegex(inputBookId, RegexConstant.onlyNumberRegex, 0, 12, 10, 12, "잘못된 입력입니다");
                int modifyImpossible = 0;
                modifyImpossible = mysqlConnecter.ReadData("id", $"SELECT id FROM bookconstructor WHERE id ='{inputBookId}'");
                if (modifyImpossible >= 1)
                {
                    fine = true;
                    Console.SetCursorPosition(10, 12);
                    Console.WriteLine("이미 존재하는 id입니다!");
                }
            }
            fine = true;
            int intid = int.Parse(inputBookId);
            while (fine)
            {//inputBookQuantity 입력&예외처리
                inputQuantity = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 14);
                fine = inputKeyUnlessEnter.CheckRegex(inputQuantity, RegexConstant.quantityRegex, 0, 14, 10, 14, "잘못된 입력입니다");
            }
            fine = true;
            int intquantity = int.Parse(inputBookQuantity);
            while (fine)
            {//inputBookInfo 입력&예외처리
                inputBookInfo = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 16);
                fine = inputKeyUnlessEnter.CheckRegex(inputBookInfo, RegexConstant.englishKoreanNumberRegex, 0, 16, 10, 16, "잘못된 입력입니다");
            }
            fine = true;
            foreach (var item in items)
            {
                string title = item["title"].ToString();
                string author = item["author"].ToString();
                string discount = item["discount"].ToString();
                string publisher = item["publisher"].ToString();
                string pubdate = item["pubdate"].ToString();
                string isbn = item["isbn"].ToString();

                int intDiscount = int.Parse(discount);
                // bookconstructor 테이블에 해당하는 책 추가
                if (isbn == inputIsbn)
                {
                    bool check = mysqlConnecter.InsertUpdateDelete($"INSERT INTO bookconstructor(id, bookName, author, publisher, quantity, price, publicationDate, isbn, info, rentpossible) VALUES('{intid}','{title}','{author}','{publisher}','{intquantity}','{intDiscount}','{pubdate}','{isbn}','{inputBookInfo}','{intquantity}')");

                    if (check)
                    {
                        Console.SetCursorPosition(0, 17);
                        Console.WriteLine("도서가 성공적으로 추가되었습니다.");
                        returnTime = DateTime.Now;
                        returnTimeString = returnTime.ToString("yyyy-MM-dd HH:mm:ss"); //현재시각측정
                        mysqlConnecter.InsertUpdateDelete(string.Format(ConstantOfQuery.InsertInLogQuery, returnTimeString, "매니저", "성공", "도서 추가"));
                    }

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
