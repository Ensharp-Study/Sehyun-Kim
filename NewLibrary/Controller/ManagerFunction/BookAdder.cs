using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLibrary.Constant;
using NewLibrary.Model;
using NewLibrary.Utility;
using Newtonsoft.Json.Linq;

namespace NewLibrary.Controller.ManagerFunction
{
    internal class BookAdder
    {
        public void AddBook()
        { //도서 추가
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            APIConnection apiConnection = new APIConnection();
            CRUDInDAO mysqlConnecter = new CRUDInDAO();
            string inputBookWord = "";
            string inputBookisbn = "";
            string inputBookId = "";
            string inputBookQuantity = "0";
            string inputBookInfo = "";
            bool fine = true;

            Console.CursorVisible = true;

            while (fine)
            {//inputBookWord 입력&예외처리
                inputBookWord = inputKeyUnlessEnter.SaveInputUnlessEnter(12, 6);
                fine = inputKeyUnlessEnter.CheckRegex(inputBookQuantity, RegexConstant.englishKoreanNumberRegex, 12, 6, 20, 6, "잘못된 입력입니다");
            }
            fine = true;

            while (fine)
            {//inputBookQuantity 입력&예외처리
                inputBookQuantity = inputKeyUnlessEnter.SaveInputUnlessEnter(12, 7);
                fine = inputKeyUnlessEnter.CheckRegex(inputBookQuantity, RegexConstant.onlyNumberRegex, 12, 7, 20, 7, "잘못된 입력입니다");
            }

            int quantity = int.Parse(inputBookQuantity);
            fine = true;

            JArray items = apiConnection.ConnectNaverApi(quantity, inputBookWord);
            Console.SetCursorPosition(0,17);
            Console.WriteLine("============================================================");
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
            Console.SetCursorPosition(0,9);
            Console.WriteLine("추가할 책의 isbn을 입력하세요");
            Console.SetCursorPosition(0, 11);
            Console.WriteLine("책의 id를 설정하세요.");
            Console.SetCursorPosition(0, 13);
            Console.WriteLine("책의 수량을 설정하세요.");
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("책의 info를 설정하세요.");


            while (fine)
            {//inputBookisbn 입력&예외처리
                inputBookisbn = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 10);
                fine = inputKeyUnlessEnter.CheckRegex(inputBookisbn, RegexConstant.onlyNumberRegex, 0, 10, 10, 10, "잘못된 입력입니다");
            }
            fine = true;
            while (fine)
            {//inputBookId 입력&예외처리
                inputBookId = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 12);
                fine = inputKeyUnlessEnter.CheckRegex(inputBookId, RegexConstant.onlyNumberRegex, 0, 12, 10, 12, "잘못된 입력입니다");
            }
            fine = true;
            int intid = int.Parse(inputBookId);
            while (fine)
            {//inputBookQuantity 입력&예외처리
                inputBookQuantity = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 14);
                fine = inputKeyUnlessEnter.CheckRegex(inputBookQuantity, RegexConstant.quantityRegex, 0, 14, 10, 14, "잘못된 입력입니다");
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
                if (isbn == inputBookisbn)
                {
                    bool check = mysqlConnecter.InsertUpdateDelete($"INSERT INTO bookconstructor(id, bookName, author, publisher, quantity, price, publicationDate, isbn, info, rentpossible) VALUES('{intid}','{title}','{author}','{publisher}','{intquantity}','{intDiscount}','{pubdate}','{isbn}','{inputBookInfo}','{intquantity}')");
                
                    if (check)
                    {
                        Console.WriteLine("도서가 성공적으로 추가되었습니다.");
                    }
                
                }
            }

            Console.WriteLine("ESC를 눌러 돌아가기");

        }
    }
}