using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.View;
using MySql.Data.MySqlClient;

namespace Library.Controller
{
    internal class MysqlConnecter // 글자 print랑 분리하기 
    {//insertdeleteupdate

        //쿼리문만 빼서 메소드 정리해야 한다 

        public bool InsertData(string insertQuery)
        {
            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowsAffected > 0;
        }


        public void SetQuery(string queryExpression)
        {
            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            string selectQuery = queryExpression;
            connection.Open();
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Close();
            connection.Close();
        }
        public bool SelectMysql(string userid, string inputPw) //회원 정보 검색
        {//로그인
            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            PasswordMasker getHiddenConsoleInput = new PasswordMasker();

            string selectQuery = $"SELECT * FROM userconstructor WHERE userid = '{userid}' AND password = '{inputPw}'";

            connection.Open();
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            MySqlDataReader reader = command.ExecuteReader();
            bool check = true;
            while (reader.Read())
            {
                //로그인 성공
                check = false;
            }


            reader.Close();
            connection.Close();
            return check;
        }

        public bool DeleteBooksql(int bookId)
        {
            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            string deleteQuery = $"DELETE FROM bookconstructor WHERE id = '{bookId}'";
            MySqlCommand command = new MySqlCommand(deleteQuery, connection);

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowsAffected > 0;
        }

        public bool DeleteMysql(string userid)
        {

            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            string deleteQuery = $"DELETE FROM userconstructor WHERE userid = '{userid}'";
            MySqlCommand command = new MySqlCommand(deleteQuery, connection);

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowsAffected > 0;
        }

        /*
        public void DeleteMysql() //회원 정보 삭제 
        {
            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            string userid = Console.ReadLine();

            string deleteQuery = $"DELETE FROM userconstructor WHERE userid = '{userid}'";

            connection.Open();
            MySqlCommand command = new MySqlCommand(deleteQuery, connection);

            // ExecuteNonQuery() 함수를 사용하여 데이터를 삭제하고 삭제된 행 수를 반환
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("삭제 성공");
            }
            else
            {
                Console.WriteLine("삭제 실패");
            }
            connection.Close();
        }

        public void UpdateMysql()
        {

        }
        */
    }

}
