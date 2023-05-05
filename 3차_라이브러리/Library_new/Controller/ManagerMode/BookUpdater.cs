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
using MySql.Data.MySqlClient;
namespace Library.Controller
{
    internal class BookUpdater
    {

        public void DisplayBookInformation(string selectQuery)
        {
            
            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            //string selectQuery = $"SELECT * FROM bookconstructor WHERE id = '{number}'"; //number 입력받아서 id=number인 행 찾기 
            MySqlCommand command = new MySqlCommand(selectQuery, connection);

            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine("=================================================");
                Console.WriteLine("  id: " + reader["id"]);
                Console.WriteLine("  bookName: " + reader["bookName"]);
                Console.WriteLine("  author: " + reader["author"]);
                Console.WriteLine("  publisher: " + reader["publisher"]);
                Console.WriteLine("  quantity: " + reader["quantity"]);
                Console.WriteLine("  price: " + reader["price"]);
                Console.WriteLine("  publicationDate: " + reader["publicationDate"]);
                Console.WriteLine("  isbn: " + reader["isbn"]);
                Console.WriteLine("  info: " + reader["info"]);
                Console.WriteLine("==================================================");
            }
            else
            {
                Console.WriteLine("책 정보가 없습니다.");
            }

            reader.Close();
            connection.Close();
        }
        public void DisplayAllBook()
        {
            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            string selectQuery = "SELECT * FROM bookconstructor";
            MySqlCommand command = new MySqlCommand(selectQuery, connection);

            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("  id: " + reader["id"].ToString());
                Console.WriteLine("  bookName: " + reader["bookName"].ToString());
                Console.WriteLine("  author: " + reader["author"].ToString());
                Console.WriteLine("  publisher: " + reader["publisher"].ToString());
                Console.WriteLine("  quantity: " + reader["quantity"].ToString());
                Console.WriteLine("  price: " + reader["price"].ToString());
                Console.WriteLine("  publicationDate: " + reader["publicationDate"].ToString());
                Console.WriteLine("  isbn: " + reader["isbn"].ToString());
                Console.WriteLine("  info: " + reader["info"].ToString());
                Console.WriteLine("==================================================");
            }

            reader.Close();
            connection.Close();
        }
        public void ModifyBookInfo()
        {
            DisplayAllBook();
            Console.WriteLine("수정할 책 id를 입력해주세요.");
            int number = int.Parse(Console.ReadLine());
            Console.Clear();

            DisplayBookInformation($"SELECT * FROM bookconstructor WHERE id = '{number}'"); //id 받아서 modifybookinfo로 넘겨서 현재 정보 출력

            Console.WriteLine("어떤 정보를 수정하시겠습니까?");

            Console.WriteLine("1. id");
            Console.WriteLine("2. bookName");
            Console.WriteLine("3. author");
            Console.WriteLine("4. publisher");
            Console.WriteLine("5. quantity");
            Console.WriteLine("6. price");
            Console.WriteLine("7. publicationDate");
            Console.WriteLine("8. isbn");
            Console.WriteLine("9. info");
            int numberInput = int.Parse(Console.ReadLine());
            Console.Clear();
            CRUDInDAO crudInDAO = new CRUDInDAO();
            bool check = true;
            switch (numberInput)
            {
                case 1:
                    Console.WriteLine("새로운 id를 입력하세요.");
                    string idinput = Console.ReadLine();
                    check = crudInDAO.InsertUpdateDelete($"UPDATE bookconstructor SET id = '{idinput}' WHERE id = '{number}'");
                    break;

                case 2:
                    Console.WriteLine("새로운 bookName을 입력하세요.");
                    string bookNameinput = Console.ReadLine();
                    check = crudInDAO.InsertUpdateDelete($"UPDATE bookconstructor SET bookName ='{bookNameinput}'WHERE id = '{number}'");
                    break;
                case 3:
                    Console.WriteLine("새로운 author를 입력하세요.");
                    string authorinput = Console.ReadLine();
                    check = crudInDAO.InsertUpdateDelete($"UPDATE bookconstructor SET author ='{authorinput}'WHERE id = '{number}'");
                    break;
                case 4:
                    Console.WriteLine("새로운 publisher를 입력하세요.");
                    string publisherinput = Console.ReadLine();
                    check = crudInDAO.InsertUpdateDelete($"UPDATE bookconstructor SET publisher ='{publisherinput}'WHERE id = '{number}'");
                    break;
                case 5:
                    Console.WriteLine("새로운 quantity를 입력하세요.");
                    string quantityinput = Console.ReadLine();
                    check = crudInDAO.InsertUpdateDelete($"UPDATE bookconstructor SET quantity ='{quantityinput}'WHERE id = '{number}'");
                    break;
                case 6:
                    Console.WriteLine("새로운 price 입력하세요.");
                    string priceinput = Console.ReadLine();
                    check = crudInDAO.InsertUpdateDelete($"UPDATE bookconstructor SET price ='{priceinput}'WHERE id = '{number}'");
                    break;
                case 7:
                    Console.WriteLine("새로운 publicationDate를 입력하세요.");
                    string publicationDateinput = Console.ReadLine();
                    check = crudInDAO.InsertUpdateDelete($"UPDATE bookconstructor SET publicationDate ='{publicationDateinput}'WHERE id = '{number}'");
                    break;
                case 8:
                    Console.WriteLine("새로운 isbn를 입력하세요.");
                    string isbninput = Console.ReadLine();
                    check = crudInDAO.InsertUpdateDelete($"UPDATE bookconstructor SET isbn ='{isbninput}'WHERE id = '{number}'");
                    break;
                case 9:
                    Console.WriteLine("새로운 info를 입력하세요.");
                    string infoinput = Console.ReadLine();
                    check = crudInDAO.InsertUpdateDelete($"UPDATE bookconstructor SET info ='{infoinput}'WHERE id = '{number}'");
                    break;

            }
            Console.Clear();
            if (check)
            {
                Console.WriteLine("책 정보가 성공적으로 수정되었습니다.");
            }
            else
            {
                Console.WriteLine("책 정보 수정에 실패했습니다.");
            }
        }




        /*
        
        public void modifyBookInfo()
        {
            Console.Clear();
            showAllBook.DisplayAllBook();
            RulesForBookData viewRulesForBookData = new RulesForBookData();

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
                    bookUpdateView.ViewForUpdateBookInfo(booklistnumber);
                    viewRulesForBookData.ViewRulesForBookData();

                    //ㅡㅡㅡㅡㅡㅡㅡIDㅡㅡㅡㅡㅡㅡㅡㅡㅡ 
                    Console.SetCursorPosition(5, 13);
                    string randomExpression = "";
                    int Entercase = 0;
                    int TypeCheck = 0;
                    inputTaker.SaveIDIfNotEnter(randomExpression, Entercase, booklistnumber);

                    //ㅡㅡㅡㅡㅡㅡㅡTitleㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(8, 14);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    inputTaker.SaveTitleIfNotEnter(randomExpression, Entercase, booklistnumber);
                    //ㅡㅡㅡㅡㅡㅡㅡauthorㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(9, 15);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    inputTaker.SaveAuthorIfNotEnter(randomExpression, Entercase, booklistnumber);
                    //ㅡㅡㅡㅡㅡㅡㅡㅡpublisherㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(12, 16);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    inputTaker.SavePublisherIfNotEnter(randomExpression, Entercase, booklistnumber);
                    //ㅡㅡㅡㅡㅡㅡㅡㅡpriceㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(8, 17);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    inputTaker.SavePriceIfNotEnter(randomExpression, Entercase, booklistnumber);
                    //ㅡㅡㅡㅡㅡㅡㅡㅡquantityㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(11, 18);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    inputTaker.SaveQuantityIfNotEnter(randomExpression, Entercase, booklistnumber);
                    //ㅡㅡㅡㅡㅡㅡㅡㅡpublcationㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(18, 19);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    inputTaker.SavePublicationIfNotEnter(randomExpression, Entercase, booklistnumber);
                    //ㅡㅡㅡㅡㅡㅡㅡㅡisbnㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(7, 20);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    inputTaker.SaveIsbnIfNotEnter(randomExpression, Entercase, booklistnumber);
                    //ㅡㅡㅡㅡㅡㅡㅡㅡinfoㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                    Console.SetCursorPosition(7, 21);
                    randomExpression = "";
                    Entercase = 0;
                    TypeCheck = 0;
                    inputTaker.SaveInfoIfNotEnter(randomExpression, Entercase, booklistnumber);
                    flag = 1;
                }




            }
            Console.Clear();
            if (flag == 1)
            {
                Console.WriteLine("정보가 성공적으로 수정되었습니다.");
            }
        }
        */
    }
}
