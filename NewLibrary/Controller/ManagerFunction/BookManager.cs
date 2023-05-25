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
    internal class BookManager
    {
        public void AddBook(string userId)
        { //도서 추가
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            APIConnection apiConnection = new APIConnection();
            FunctionInDAO mysqlConnecter = new FunctionInDAO();
            string inputBookWord = "";
            string inputBookisbn = "";
            string inputBookId = "";
            string inputBookQuantity = "0";
            string inputBookInfo = "";
            bool fine = true;
            DateTime returnTime;
            string returnTimeString = "";
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
            Console.SetCursorPosition(0,19);
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
                    bool check = mysqlConnecter.InsertUpdateDelete(string.Format("INSERT INTO bookconstructor(id, bookName, author, publisher, quantity, price, publicationDate, isbn, info, rentpossible) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
                                           intid, title, author, publisher, intquantity, intDiscount, pubdate, isbn, inputBookInfo, intquantity));

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
            Console.SetCursorPosition(0,18);
            Console.WriteLine("ESC를 눌러 돌아가기");
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

        public void DeleteBook(string userId)
        { //도서 추가
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            APIConnection apiConnection = new APIConnection();
            FunctionInDAO mysqlConnecter = new FunctionInDAO();
            string inputBookisbn = "";
            bool fine = true;
            DateTime returnTime;
            string returnTimeString = "";

            Console.CursorVisible = true;

            Console.WriteLine("삭제할 책의 isbn을 입력하세요");

            while (fine)
            {//inputBookisbn 입력&예외처리
                inputBookisbn = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 6);
                fine = inputKeyUnlessEnter.CheckRegex(inputBookisbn, RegexConstant.onlyNumberRegex, 0, 6, 10, 6, "잘못된 입력입니다");
            }
            
            fine = mysqlConnecter.InsertUpdateDelete(string.Format("DELETE FROM bookconstructor WHERE isbn='{0}'", inputBookisbn));
            mysqlConnecter.InsertUpdateDelete(string.Format("DELETE FROM borrowlist WHERE isbn='{0}'", inputBookisbn));
            mysqlConnecter.InsertUpdateDelete(string.Format("DELETE FROM returnlist WHERE isbn='{0}'", inputBookisbn));
            if (!fine)
            {
                Console.WriteLine();
                Console.WriteLine("               도서 삭제가 완료되었습니다.");
                returnTime = DateTime.Now;
                returnTimeString = returnTime.ToString("yyyy-MM-dd HH:mm:ss"); //현재시각측정
                mysqlConnecter.InsertUpdateDelete(string.Format(ConstantOfQuery.InsertInLogQuery, returnTimeString, "매니저", "성공", "도서 삭제"));
            }

            Console.WriteLine("ESC를 눌러 돌아가기");
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

        public void ModifyBook(string userId)
        {
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            APIConnection apiConnection = new APIConnection();
            FunctionInDAO crudInDAO = new FunctionInDAO();
            string inputBookId = "";
            int intInputBookId;
            int intInputNumber;
            string numberInput = "0";
            bool fine = true;
            DateTime returnTime;
            string returnTimeString = "";
            Console.WriteLine("수정할 책 id를 입력해주세요.");
            while (fine)
            {//inputBookId 입력&예외처리
                inputBookId = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 6);
                fine = inputKeyUnlessEnter.CheckRegex(inputBookId, RegexConstant.onlyNumberRegex, 0, 6, 20, 6, "잘못된 입력입니다");
            }
            intInputBookId = int.Parse(inputBookId);
            fine = true;
            Console.SetCursorPosition(0, 7);

            Console.WriteLine("============================================================");
            Console.WriteLine("어떤 정보를 수정하시겠습니까?");
            Console.WriteLine("① id");
            Console.WriteLine("② bookName");
            Console.WriteLine("③ author");
            Console.WriteLine("④ publisher");
            Console.WriteLine("⑤ quantity");
            Console.WriteLine("⑥ price");
            Console.WriteLine("⑦ publicationDate");
            Console.WriteLine("⑧ isbn");
            Console.WriteLine("⑨ info");

            while (fine)
            {//numberInput 입력&예외처리
                numberInput = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 18);
                fine = inputKeyUnlessEnter.CheckRegex(numberInput, RegexConstant.menuNumberRegex, 0, 18, 10, 18, "잘못된 입력입니다");
            }
            intInputNumber = int.Parse(numberInput);


            bool check = true;
            bool inputChecker = true;
            Console.SetCursorPosition(0, 19);
            switch (intInputNumber)
            {
                case 1:
                    int intIdInput = 0;
                    string idInput = "0";
                    Console.WriteLine("새로운 id를 입력하세요.");
                    while (inputChecker)
                    {
                        idInput = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 20);
                        inputChecker = inputKeyUnlessEnter.CheckRegex(idInput, RegexConstant.onlyNumberRegex, 0, 20, 10, 20, "잘못된 입력입니다");

                        int modifyImpossible = 0;
                        modifyImpossible = crudInDAO.ReadData("id", $"SELECT id FROM bookconstructor WHERE id ='{idInput}'");
                        if (modifyImpossible >= 1)
                        {
                            inputChecker = true;
                            Console.SetCursorPosition(20, 20);
                            Console.WriteLine("이미 존재하는 id입니다!");
                        }
                    }
                    intIdInput = int.Parse(idInput);
                    check = crudInDAO.InsertUpdateDelete(string.Format(ConstantOfQuery.UpdateBookQuery,"id", idInput, intInputBookId)); ;
                    break;

                case 2:
                    string bookNameInput = "";
                    Console.WriteLine("새로운 bookName을 입력하세요.");
                    while (inputChecker)
                    {
                        bookNameInput = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 20);
                        inputChecker = inputKeyUnlessEnter.CheckRegex(bookNameInput, RegexConstant.englishKoreanNumberRegex, 0, 20, 10, 20, "잘못된 입력입니다");
                        int modifyImpossible = 0;
                        modifyImpossible = crudInDAO.ReadData("bookName", $"SELECT bookName FROM bookconstructor WHERE  bookName ='{bookNameInput}'");
                        if (modifyImpossible >= 1)
                        {
                            inputChecker = true;
                            Console.SetCursorPosition(20, 20);
                            Console.WriteLine("이미 존재하는 bookName입니다!");
                        }
                    }
                    inputChecker = true;
                    check = crudInDAO.InsertUpdateDelete(string.Format(ConstantOfQuery.UpdateBookQuery, "bookName", bookNameInput, intInputBookId)); ;
                    break;
                case 3:
                    string authorInput = "";
                    Console.WriteLine("새로운 author를 입력하세요.");
                    while (inputChecker)
                    {
                        authorInput = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 20);
                        inputChecker = inputKeyUnlessEnter.CheckRegex(authorInput, RegexConstant.englishKoreanNumberRegex, 0, 20, 10, 20, "잘못된 입력입니다");
                        int modifyImpossible = 0;
                        modifyImpossible = crudInDAO.ReadData("author", $"SELECT author FROM bookconstructor WHERE author ='{authorInput}'");
                        if (modifyImpossible >= 1)
                        {
                            inputChecker = true;
                            Console.SetCursorPosition(20, 20);
                            Console.WriteLine("이미 존재하는 author입니다!");
                        }
                    }
                    inputChecker = true;
                    check = crudInDAO.InsertUpdateDelete(string.Format(ConstantOfQuery.UpdateBookQuery, "author", authorInput, intInputBookId));
                    break;
                case 4:
                    string publisherInput = "";
                    Console.WriteLine("새로운 publisher를 입력하세요.");
                    while (inputChecker)
                    {
                        publisherInput = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 20);
                        inputChecker = inputKeyUnlessEnter.CheckRegex(publisherInput, RegexConstant.englishKoreanNumberRegex, 0, 20, 10, 20, "잘못된 입력입니다");
                        int modifyImpossible = 0;
                        modifyImpossible = crudInDAO.ReadData("publisher", $"SELECT publisher FROM bookconstructor WHERE publisher ='{publisherInput}'");
                        if (modifyImpossible >= 1)
                        {
                            inputChecker = true;
                            Console.SetCursorPosition(20, 20);
                            Console.WriteLine("이미 존재하는 publisher입니다!");
                        }
                    }
                    inputChecker = true;
                    check = crudInDAO.InsertUpdateDelete(string.Format(ConstantOfQuery.UpdateBookQuery, "publisher", publisherInput, intInputBookId));
                    break;
                case 5:
                    int intQuantityInput = 0;
                    string quantityinput = "0";
                    Console.WriteLine("새로운 quantity를 입력하세요.");
                    while (inputChecker)
                    {
                        quantityinput = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 20);
                        inputChecker = inputKeyUnlessEnter.CheckRegex(quantityinput, RegexConstant.quantityRegex, 0, 20, 10, 20, "잘못된 입력입니다");
                        
                    }
                    inputChecker = true;
                    intQuantityInput = int.Parse(quantityinput);
                    check = crudInDAO.InsertUpdateDelete(string.Format(ConstantOfQuery.UpdateBookQuery, "quantity", intQuantityInput, intInputBookId));
                    break;
                case 6:
                    int intpriceinput = 0;
                    string priceinput = "0";
                    Console.WriteLine("새로운 price 입력하세요."); 
                    while (inputChecker)
                    {
                        priceinput = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 20);
                        inputChecker = inputKeyUnlessEnter.CheckRegex(priceinput, RegexConstant.priceRegex, 0, 20, 10, 20, "잘못된 입력입니다");
                        
                    }
                    inputChecker = true;
                    intpriceinput = int.Parse(priceinput);
                    check = crudInDAO.InsertUpdateDelete(string.Format(ConstantOfQuery.UpdateBookQuery, "price", priceinput, intInputBookId));
                    break;
                case 7:
                    string publicationDateinput = "";
                    Console.WriteLine("새로운 publicationDate를 입력하세요."); 
                    while (inputChecker)
                    {
                        publicationDateinput = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 20);
                        inputChecker = inputKeyUnlessEnter.CheckRegex(publicationDateinput, RegexConstant.publicationDateRegex, 0, 20, 10, 20, "잘못된 입력입니다");
                        
                    }
                    inputChecker = true;
                    check = crudInDAO.InsertUpdateDelete(string.Format(ConstantOfQuery.UpdateBookQuery, "publicationDate", publicationDateinput, intInputBookId));
                    break;
                case 8:
                    string isbninput = "";
                    Console.WriteLine("새로운 isbn를 입력하세요."); 
                    while (inputChecker)
                    {
                        isbninput = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 20);
                        inputChecker = inputKeyUnlessEnter.CheckRegex(isbninput, RegexConstant.isbnRegex, 0, 20, 10, 20, "잘못된 입력입니다");
                        int modifyImpossible = 0;
                        modifyImpossible = crudInDAO.ReadData("isbn", $"SELECT isbn FROM bookconstructor WHERE isbn ='{isbninput}'");
                        if (modifyImpossible >= 1)
                        {
                            inputChecker = true;
                            Console.SetCursorPosition(20, 20);
                            Console.WriteLine("이미 존재하는 isbn입니다!");
                        }
                    }
                    inputChecker = true;
                    check = crudInDAO.InsertUpdateDelete(string.Format(ConstantOfQuery.UpdateBookQuery, "isbn", isbninput, intInputBookId));
                    break;
                case 9:
                    string infoinput = "";
                    Console.WriteLine("새로운 info를 입력하세요."); 
                    while (inputChecker)
                    {
                        infoinput = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 20);
                        inputChecker = inputKeyUnlessEnter.CheckRegex(infoinput, RegexConstant.englishKoreanNumberRegex, 0, 20, 10, 20, "잘못된 입력입니다");
                        
                    }
                    inputChecker = true;
                    check = crudInDAO.InsertUpdateDelete(string.Format(ConstantOfQuery.UpdateBookQuery, "info", infoinput, intInputBookId));
                    break;

            }
            Console.Clear();
            if (check)
            {
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("책 정보가 성공적으로 수정되었습니다.");
                returnTime = DateTime.Now;
                returnTimeString = returnTime.ToString("yyyy-MM-dd HH:mm:ss"); //현재시각측정
                crudInDAO.InsertUpdateDelete(string.Format(ConstantOfQuery.InsertInLogQuery, returnTimeString, "매니저", "성공", "도서 수정"));
            }
            else
            {
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("책 정보 수정에 실패했습니다.");
                returnTime = DateTime.Now;
                returnTimeString = returnTime.ToString("yyyy-MM-dd HH:mm:ss"); //현재시각측정
                crudInDAO.InsertUpdateDelete(string.Format(ConstantOfQuery.InsertInLogQuery, returnTimeString, "매니저", "실패", "도서 수정"));
            }
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("ESC를 눌러 돌아가기");
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