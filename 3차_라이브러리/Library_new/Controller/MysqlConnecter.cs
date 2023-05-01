﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.View;
using MySql.Data.MySqlClient;

namespace Library.Model
{
    internal class MysqlConnecter // 글자 print랑 분리하기 
    {//insertdeleteupdate
     //"INSERT INTO userconstructor(userid,password,name,age,phonenumber,address) VALUES('sehyun','1234','김세현', 21, '01040244794', '서울시 광진구')"
        public void InsertMysql() //회원 정보 추가
        {
            MySqlConnection connection = DatabaseConnection.Instance.Connection;

            Console.Write("아이디를 입력하세요: ");
            string userid = Console.ReadLine();
            Console.Write("비밀번호를 입력하세요: ");
            string password = Console.ReadLine();
            Console.Write("이름을 입력하세요: ");
            string name = Console.ReadLine();
            Console.Write("나이를 입력하세요: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("전화번호를 입력하세요: ");
            string phonenumber = Console.ReadLine();
            Console.Write("주소를 입력하세요: ");
            string address = Console.ReadLine();

            string insertQuery = $"INSERT INTO userconstructor(userid, password, name, age, phonenumber, address) VALUES('{userid}', '{password}', '{name}', {age}, '{phonenumber}', '{address}')";

            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        public bool  SelectMysql() //회원 정보 검색
        {
            MySqlConnection connection = DatabaseConnection.Instance.Connection;
            PasswordMasker getHiddenConsoleInput = new PasswordMasker();
            Console.Write("아이디를 입력하세요.");
            string userid = Console.ReadLine();
            Console.WriteLine("비밀번호를 입력하세요.");
            string inputPw = getHiddenConsoleInput.HideConsoleInput();
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

