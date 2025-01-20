using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NewLibrary.Constant;
using NewLibrary.Controller;
using NewLibrary.Utility;
using Newtonsoft.Json.Linq;

namespace NewLibrary.Model
{
    internal class APIConnection
    {
        public void ConnectApiWhenApply(int inputBookQuantity, string inputBookWord, string userId)
        {//도서 신청하기 
            FunctionInDAO mysqlConnecter = new FunctionInDAO();
            APIConnection connection = new APIConnection();
            string url = "https://openapi.naver.com/v1/search/book.json?display={0}&query={1}";
            url = string.Format(url, inputBookQuantity, inputBookWord);

            string test = connection.CallWebRequest(url);
            Console.WriteLine(test);

            JObject jObject = JObject.Parse(test);

            JArray items = (JArray)jObject["items"];
            bool checkMysql = true;
            foreach (var item in items)
            {
                string title = item["title"].ToString();
                string link = item["link"].ToString();
                string image = item["image"].ToString();
                string author = item["author"].ToString();
                string discount = item["discount"].ToString();
                string publisher = item["publisher"].ToString();
                string pubdate = item["pubdate"].ToString();
                string isbn = item["isbn"].ToString();

                bool check = mysqlConnecter.InsertUpdateDelete($"SELECT * FROM appliedbooklist WHERE isbn='{isbn}' AND userid='{userId}'");
                if (check)
                {
                    Console.WriteLine("이미 신청하신 도서입니다.");
                    continue;
                }

                checkMysql = mysqlConnecter.InsertUpdateDelete($"INSERT INTO appliedbooklist(title, author, publisher, pubdate, discount, isbn,userid) VALUES('{title}', '{author}', '{publisher}', {pubdate}, '{discount}', '{isbn}','{userId}')");
            }
        }
        public void ConnectApiWhenAdd(int inputBookQuantity, string inputBookWord)
        {//도서 추가하기 
            FunctionInDAO mysqlConnecter = new FunctionInDAO();
            APIConnection connection = new APIConnection();
            string url = "https://openapi.naver.com/v1/search/book.json?display={0}&query={1}";
            url = string.Format(url, inputBookQuantity, inputBookWord);
            
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            string test = connection.CallWebRequest(url);
            Console.WriteLine(test);

            JObject jObject = JObject.Parse(test);

            JArray items = (JArray)jObject["items"];
            bool checkMysql = true;
            bool fine = true;
            string idInput = "0";
            string quantityValue = "0";
            string infoValue = "";
            int id=0;

           

            while (true)
            {
                Console.WriteLine("추가할 도서의 id를 입력하세요.");
                while (fine)
                {
                    idInput = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 1);
                    fine = inputKeyUnlessEnter.CheckRegex(idInput, RegexConstant.onlyNumberRegex, 0, 1, 20, 1, "입력이 잘못되었습니다.");
                }
                id = int.Parse(idInput);
                bool check = mysqlConnecter.InsertUpdateDelete($"SELECT * FROM bookconstructor WHERE id='{id}'");
                if (check)
                {
                    Console.WriteLine("이미 존재하는 id입니다.");
                    continue;

                }
            }
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("추가할 도서 수량을 입력하세요.");
            while (fine)
            {
                quantityValue = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 3);
                fine = inputKeyUnlessEnter.CheckRegex(quantityValue, RegexConstant.quantityRegex, 0, 3, 20, 3, "입력이 잘못되었습니다.");
            }
            int quantity = int.Parse(quantityValue);
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("추가할 도서 info를 입력하세요.");
            while (fine)
            {
                infoValue = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 5);
                fine = inputKeyUnlessEnter.CheckRegex(infoValue, RegexConstant.englishKoreanNumberRegex, 0, 5, 20, 5, "입력이 잘못되었습니다.");
            }
            foreach (var item in items)
            {
                string title = item["title"].ToString();
                string link = item["link"].ToString();
                string image = item["image"].ToString();
                string author = item["author"].ToString();
                string discount = item["discount"].ToString();
                string publisher = item["publisher"].ToString();
                string pubdate = item["pubdate"].ToString();
                string isbn = item["isbn"].ToString();

               
                
                checkMysql = mysqlConnecter.InsertUpdateDelete($"INSERT INTO bookconstructor(id, bookName, author, publisher,quantity, publicationDate, isbn,userid) VALUES('{id}',{title}', '{author}', '{publisher}','{quantity}','{discount}', {pubdate}', '{isbn}','{infoValue}')");
            }
        }


        public JArray ConnectNaverApi(int inputBookQuantity, string inputBookWord)
        {
            FunctionInDAO mysqlConnecter = new FunctionInDAO();
            APIConnection connection = new APIConnection();

            string url = "https://openapi.naver.com/v1/search/book.json?display={0}&query={1}";
            url = string.Format(url, inputBookQuantity, inputBookWord);

            string test = connection.CallWebRequest(url);
            
            JObject jObject = JObject.Parse(test); 

            JArray items = (JArray)jObject["items"];

            //jObject : 검색 결과 전체를 담고 있는 JSON 객체
            //items : 검색 결과 중에서도 검색된 책들의 정보가 담긴 JSON 배열
            //따라서 jObject에서 items 배열만 추출해서 반환한다.

            return items;
            
        }

        public string CallWebRequest(string targetURL)
        {
            string result = string.Empty;

            try
            {
                WebClient client = new WebClient();

                client.Headers["X-Naver-Client-Id"] = "b1uvFnmCfhn6c0Tkbxuk";
                client.Headers["X-Naver-Client-Secret"] = "sk97B7Ol_I";

                using (Stream data = client.OpenRead(targetURL))
                {
                    using (StreamReader reader = new StreamReader(data))
                    {
                        string s = reader.ReadToEnd();
                        result = s;

                        reader.Close();
                        data.Close();
                    }
                }
            }
            catch (Exception e)
            {
                //통신 실패시 처리로직
                Console.WriteLine(e.ToString());
            }

            return result;
        }
    }
}
