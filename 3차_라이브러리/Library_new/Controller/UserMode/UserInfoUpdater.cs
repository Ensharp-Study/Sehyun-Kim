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
    internal class UserInfoUpdater
    {

        public void DisplayUserInformation(string Userid)
        {
            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            string selectQuery = $"SELECT * FROM userconstructor WHERE userid = '{Userid}'";
            MySqlCommand command = new MySqlCommand(selectQuery, connection);

            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine("현재 회원님의 정보를 표시합니다.");
                Console.WriteLine("=================================================");
                Console.WriteLine("  userid: " + reader["userid"]);
                Console.WriteLine("  Name: " + reader["name"]);
                Console.WriteLine("  Age: " + reader["age"]);
                Console.WriteLine("  PhoneNumber: " + reader["phonenumber"]);
                Console.WriteLine("  Address: " + reader["address"]);
                Console.WriteLine("==================================================");
            }
            else
            {
                Console.WriteLine("회원 정보가 없습니다.");
            }

            reader.Close();
            connection.Close();
        }
        public bool Modifyuserinfo(string Userid)
        {
            DisplayUserInformation(Userid);
            PasswordMasker passwordMasker = new PasswordMasker();
            Console.WriteLine("어떤 정보를 수정하시겠습니까?");

            Console.WriteLine("1. password");
            Console.WriteLine("2. Name");
            Console.WriteLine("3. Age");
            Console.WriteLine("4. PhoneNumber");
            Console.WriteLine("5. Address");
            string updateQuery;
            int number = int.Parse(Console.ReadLine());
            Console.Clear();
            CRUDInDAO crudInDAO = new CRUDInDAO();
            bool check = true;
            switch (number)
            {
                case 1:
                    Console.WriteLine("새로운 패스워드를 입력하세요.");
                    string pwinput = passwordMasker.HideConsoleInput(0, 15);
                    check=crudInDAO.InsertUpdateDelete($"UPDATE userconstructor SET password = '{pwinput}' WHERE userid = '{Userid}'");
                    break;
                    
                case 2:
                    Console.WriteLine("새로운 이름을 입력하세요.");
                    string nameinput = Console.ReadLine();
                    check = crudInDAO.InsertUpdateDelete($"UPDATE userconstructor SET name ='{nameinput}'WHERE userid = '{Userid}'");
                    break;
                case 3:
                    Console.WriteLine("새로운 나이를 입력하세요.");
                    int ageinput = int.Parse(Console.ReadLine());
                    check = crudInDAO.InsertUpdateDelete($"UPDATE userconstructor SET name ='{ageinput}'WHERE userid = '{Userid}'");
                    break;
                case 4:
                    Console.WriteLine("새로운 전화번호를 입력하세요.");
                    int phoneinput = int.Parse(Console.ReadLine());
                    check = crudInDAO.InsertUpdateDelete($"UPDATE userconstructor SET name ='{phoneinput}'WHERE userid = '{Userid}'");
                    break;
                case 5:
                    Console.WriteLine("새로운 주소를 입력하세요.");
                    string addressinput = Console.ReadLine();
                    check = crudInDAO.InsertUpdateDelete($"UPDATE userconstructor SET name ='{addressinput}'WHERE userid = '{Userid}'");
                    break;
            }
            Console.Clear();
            if (check)
            {
                Console.WriteLine("회원 정보가 성공적으로 수정되었습니다.");
                return true;
            }
            else
            {
                Console.WriteLine("회원 정보 수정에 실패했습니다.");
                return false;
            }
        }

        
    }
}
