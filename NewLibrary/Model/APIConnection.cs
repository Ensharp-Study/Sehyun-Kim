using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NewLibrary.Controller;
using Newtonsoft.Json.Linq;

namespace NewLibrary.Model
{
    internal class APIConnection
    {
        
        public void ConnectApi(int inputBookQuantity, string inputBookWord, string userId)
        {//도서 신청하기 
            CRUDInDAO mysqlConnecter = new CRUDInDAO();
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

                bool check = mysqlConnecter.InsertUpdateDelete($"SELECT * FROM appliedbooklist WHERE title='{title}' AND userid='{userId}'");
                if (check)
                {
                    Console.WriteLine("이미 신청하신 도서입니다.");
                    continue;
                }

                checkMysql = mysqlConnecter.InsertUpdateDelete($"INSERT INTO appliedbooklist(title, author, publisher, pubdate, discount, isbn,userid) VALUES('{title}', '{author}', '{publisher}', {pubdate}, '{discount}', '{isbn}','{userId}')");
            }
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
