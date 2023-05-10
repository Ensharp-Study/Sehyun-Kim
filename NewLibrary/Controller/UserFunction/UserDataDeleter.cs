using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using NewLibrary.Model.DAO;

namespace NewLibrary.Controller.UserFunction
{
    internal class UserDataDeleter
    {
        public string DeleteUserData(string userId)
        {
            
            CRUDInDAO mysqlConnecter = new CRUDInDAO();
            MySqlConnection connection = DatabaseConnection.Instance.Connection;

            string query = $"SELECT COUNT(*) FROM borrowlist WHERE userid='{userId}'";
            MySqlCommand command = new MySqlCommand(query, connection);

            connection.Open();
            int count = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            bool fine=true;
            if (count > 0)
            {
                Console.WriteLine();
                Console.WriteLine(    "      대여중인 도서가 있어 회원 탈퇴가 불가능합니다.");
                fine = true;
            }
            else
            {
                // borrowlist 테이블에서 해당 유저의 대여 기록 삭제
                fine = mysqlConnecter.InsertUpdateDelete($"DELETE FROM userconstructor WHERE userid='{userId}'");
                mysqlConnecter.InsertUpdateDelete($"DELETE FROM borrowlist WHERE userid='{userId}'");
                if (!fine)
                {
                    Console.WriteLine();
                    Console.WriteLine("               회원 탈퇴가 완료되었습니다.");
                    
                }
            }

            Console.WriteLine(        "                   ESC를 눌러 돌아가기");
            while (true)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Escape) //esc 입력됐을 경우
                {
                    Console.Clear();
                    if (!fine)
                    {
                        return null;
                    }
                    else
                    {
                        return userId;
                    }
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
