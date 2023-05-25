using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using NewLibrary.Constant;
using NewLibrary.Model;
using NewLibrary.Model.DAO;
using NewLibrary.Utility;

namespace NewLibrary.Controller.ManagerFunction
{
    internal class MemberManagement
    {
        //모든 회원 정보 표시 
        public void DisplayMemberData(string userId)
        {
            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            string selectQuery = ConstantOfQuery.selectFromUser; //number 입력받아서 id=number인 행 찾기 
            MySqlCommand command = new MySqlCommand(selectQuery, connection);

            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("=================================================");
            while (reader.Read())
            {

                Console.WriteLine("  userid: " + reader["userid"]);
                Console.WriteLine("  password: " + reader["password"]);
                Console.WriteLine("  name: " + reader["name"]);
                Console.WriteLine("  age: " + reader["age"]);
                Console.WriteLine("  phonenumber: " + reader["phonenumber"]);
                Console.WriteLine("  address: " + reader["address"]);
                Console.WriteLine("==================================================");
            }
            reader.Close();
            connection.Close();
        }

        public void DisplayRentalStatus(string userId)
        {
            Console.WriteLine("ESC를 눌러 돌아가기");
            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            string selectQuery = $"SELECT * FROM borrowlist"; //number 입력받아서 id=number인 행 찾기 
            MySqlCommand command = new MySqlCommand(selectQuery, connection);

            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("=================================================");
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
                Console.WriteLine("  rentpossible: " + reader["rentpossible"].ToString());
                Console.WriteLine("  borrowtime: " + reader["borrowtime"].ToString());
                Console.WriteLine("  userid: " + reader["userid"].ToString());
                Console.WriteLine("==================================================");
            }
            reader.Close();
            connection.Close();

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

        public void EnterInformation(string inputUserId, string inputValue, bool fine, bool check, string message, string query)
        {
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            FunctionInDAO crudInDAO = new FunctionInDAO();
            Console.WriteLine(message);
            while (fine)
            {
                inputValue=inputKeyUnlessEnter.SaveInputUnlessEnter(0, 16);
                fine = inputKeyUnlessEnter.CheckRegex(inputValue, RegexConstant.userPwRegex, 0, 16, 10, 16, "잘못된 입력입니다");
            }
            check = crudInDAO.InsertUpdateDelete(query);
            
        }

        public void ManageMember(string userId)
        {
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            APIConnection apiConnection = new APIConnection();
            FunctionInDAO crudInDAO = new FunctionInDAO();

            bool fine = true;
            string numberInput = "0";
            int intInputNumber;
            string inputUserId = "";
            Console.SetCursorPosition(0, 5);
            Console.WriteLine("수정할 회원의 userid를 입력하세요.");
            while (fine)
            {//numberInput 입력&예외처리
                inputUserId = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 6);
                fine = inputKeyUnlessEnter.CheckRegex(inputUserId, RegexConstant.userIdRegex, 0, 6, 10, 6, "잘못된 입력입니다");
            }

            Console.SetCursorPosition(0, 7);

            Console.WriteLine("============================================================");
            Console.WriteLine("어떤 정보를 수정하시겠습니까?");
            Console.WriteLine("① password");
            Console.WriteLine("② name");
            Console.WriteLine("③ age");
            Console.WriteLine("④ phonenumber");
            Console.WriteLine("⑤ address");
            fine = true;
            while (fine)
            {
                numberInput = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 14);
                fine = inputKeyUnlessEnter.CheckRegex(numberInput, RegexConstant.menuNumberRegex, 0, 14, 10, 14, "잘못된 입력입니다");
            }
            intInputNumber = int.Parse(numberInput);

            fine = true;
            bool check = true;
            string inputValue = "";
            Console.SetCursorPosition(0, 15);
            switch (intInputNumber)
            {
                case 1:     
                    EnterInformation(inputUserId, inputValue, fine, check, "새로운 password를 입력하세요.", $"UPDATE userconstructor SET password = '{inputValue}' WHERE userid = '{inputUserId}'");
                    break;
                case 2:
                    EnterInformation(inputUserId, inputValue, fine, check, "새로운 name을 입력하세요.", $"UPDATE userconstructor SET name ='{inputValue}'WHERE userid = '{inputUserId}'");
                    break;
                case 3:
                    EnterInformation(inputUserId, inputValue, fine, check, "새로운 age를 입력하세요.", $"UPDATE userconstructor SET age ='{inputValue}'WHERE userid = '{inputUserId}'");
                    break;
                case 4:
                    EnterInformation(inputUserId, inputValue, fine, check, "새로운 phonenumber를 입력하세요.", $"UPDATE userconstructor SET phonenumber ='{inputValue}'WHERE userid = '{inputUserId}'");
                    break;
                case 5:
                    EnterInformation(inputUserId, inputValue, fine, check, "새로운 address를 입력하세요.", $"UPDATE userconstructor SET address ='{inputValue}'WHERE userid = '{inputUserId}'");
                    break;
            }
            Console.Clear();
            if (check)
            {
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("회원 정보가 성공적으로 수정되었습니다.");
            }
            else
            {
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("회원 정보 수정에 실패했습니다.");
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

