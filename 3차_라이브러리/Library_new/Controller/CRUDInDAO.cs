﻿using System;
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

        public bool SelectData(string selectQuery)
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
    }
        
    }

