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
            Console.SetCursorPosition(0, 19);
            switch (intInputNumber)
            {
                case 1:
                    Console.WriteLine("새로운 id를 입력하세요.");
                    string idinput = Console.ReadLine();
                    check = crudInDAO.InsertUpdateDelete(string.Format("UPDATE bookconstructor SET id = '{0}' WHERE id = '{1}'", idinput, intInputBookId)); ;
                    break;

                case 2:
                    Console.WriteLine("새로운 bookName을 입력하세요.");
                    string bookNameinput = Console.ReadLine();
                    check = crudInDAO.InsertUpdateDelete(string.Format("UPDATE bookconstructor SET bookName = '{0}' WHERE id = '{1}'", bookNameinput, intInputBookId)); ;
                    break;
                case 3:
                    Console.WriteLine("새로운 author를 입력하세요.");
                    string authorinput = Console.ReadLine();
                    check = crudInDAO.InsertUpdateDelete(string.Format("UPDATE bookconstructor SET author = '{0}' WHERE id = '{1}'", authorinput, intInputBookId));
                    break;
                case 4:
                    Console.WriteLine("새로운 publisher를 입력하세요.");
                    string publisherinput = Console.ReadLine();
                    check = crudInDAO.InsertUpdateDelete(string.Format("UPDATE bookconstructor SET publisher = '{0}' WHERE id = '{1}'", publisherinput, intInputBookId));
                    break;
                case 5:
                    Console.WriteLine("새로운 quantity를 입력하세요.");
                    string quantityinput = Console.ReadLine();
                    check = crudInDAO.InsertUpdateDelete(string.Format("UPDATE bookconstructor SET quantity = '{0}' WHERE id = '{1}'", quantityinput, intInputBookId));
                    break;
                case 6:
                    Console.WriteLine("새로운 price 입력하세요.");
                    string priceinput = Console.ReadLine();
                    check = crudInDAO.InsertUpdateDelete(string.Format("UPDATE bookconstructor SET price = '{0}' WHERE id = '{1}'", priceinput, intInputBookId));
                    break;
                case 7:
                    Console.WriteLine("새로운 publicationDate를 입력하세요.");
                    string publicationDateinput = Console.ReadLine();
                    check = crudInDAO.InsertUpdateDelete(string.Format("UPDATE bookconstructor SET publicationDate = '{0}' WHERE id = '{1}'", publicationDateinput, intInputBookId));
                    break;
                case 8:
                    Console.WriteLine("새로운 isbn를 입력하세요.");
                    string isbninput = Console.ReadLine();
                    check = crudInDAO.InsertUpdateDelete(string.Format("UPDATE bookconstructor SET isbn = '{0}' WHERE id = '{1}'", isbninput, intInputBookId));
                    break;
                case 9:
                    Console.WriteLine("새로운 info를 입력하세요.");
                    string infoinput = Console.ReadLine();
                    check = crudInDAO.InsertUpdateDelete(string.Format("UPDATE bookconstructor SET info = '{0}' WHERE id = '{1}'", infoinput, intInputBookId));
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