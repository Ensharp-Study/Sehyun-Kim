using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.View;
using MySql.Data.MySqlClient;
using NewLibrary.Model.DAO;

namespace NewLibrary.Controller
{
    internal class FunctionInDAO 
    {
        public bool InsertUpdateDelete(string QueryExpression)
        {
            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            MySqlCommand command = new MySqlCommand(QueryExpression, connection);
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowsAffected > 0;
        }

        public bool ReadDataForCheck(string selectQuery)
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

