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
            //이거 따로빼기 dao안에서하는게맞다 controller에 database와 연계되어있느애를생성하면안되고알고있어도안된다
            //dao에 정의되어있으니까 dao안에서 하기

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
            //직접적인 쿼리문 컨트롤러에서는 유저아이디라던가 네임인풋 에이지인풋 이런 인자들만 dao에다가 넘겨주고 dao에서 mysql이랑 관련된 객체를 커넥션이라던가 커맨드라던가
            //dao에서 관리하고 인자를 받은걸 바탕으로 쿼리를 날리는 식으로 하는게 지금 짜논 형식에 맞다
            //menu이동재귀식 -> 고치기 
            //crudindao 
            //ui 패키징
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
