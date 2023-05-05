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
    internal class CRUDInDAO // create, read, upload, delete
    {//insertdeleteupdate

        //쿼리문만 빼서 메소드 정리해야 한다 
        //string selectQuery = $"SELECT * FROM userconstructor WHERE userid = '{userid}' AND password = '{inputPw}'";
        //string deleteQuery = $"DELETE FROM bookconstructor WHERE id = '{bookId}'";
        // string updateQuery = $"UPDATE userconstructor SET userpw='{newPw}' WHERE userid='{userid}'";

        public bool InsertUpdateDelete(string QueryExpression)
        {
            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            MySqlCommand command = new MySqlCommand(QueryExpression, connection);
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowsAffected > 0;
        }

        public bool SelectData(string selectQuery)//bool형 return 참조 1개밖에없는데 로그인할때밖에안쓰이는데 네이밍이 selectquery같음 위에짜논거랑 방향성이안맞음 패키징이잘못됨
        {
            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            PasswordMasker getHiddenConsoleInput = new PasswordMasker();
            connection.Open();
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            MySqlDataReader reader = command.ExecuteReader();
            bool check = true;
            while (reader.Read())
            {
                //조회 성공
                check = false;
            }


            reader.Close();
            connection.Close();
            return check;
        }

        public int ReadData(string columnName, string readQuery)
        {
            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            MySqlCommand command = new MySqlCommand(readQuery, connection);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            int columnValue = 0; // 변수를 루프 밖에서 초기화

            while (reader.Read())
            {
                columnValue = (int)reader[columnName]; // 변수에 값을 저장
            }

            reader.Close();
            connection.Close();

            return columnValue; // 변수를 반환
        }
    }
        
    }

