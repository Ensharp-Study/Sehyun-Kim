using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Library.Model
{
    internal class MysqlConnecter
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

            if (command.ExecuteNonQuery() == 1)
            {
                Console.WriteLine("인서트 성공");
            }
            else
            {
                Console.WriteLine("인서트 실패");
            }
        }

    }
        /*
        public void SelectMysql()
        {
            using (MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=coding32;Uid=root;Pwd=1111"))
            {
                try//예외 처리
                {
                    connection.Open();
                    string sql = "SELECT * FROM Co32table";

                    //ExecuteReader를 이용하여
                    //연결 모드로 데이타 가져오기
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    MySqlDataReader table = cmd.ExecuteReader();

                    while (table.Read())
                    {
                        Console.WriteLine("{0} {1}", table["idx"], table["header"], table["body"]);
                    }
                    table.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("실패");
                    Console.WriteLine(ex.ToString());
                }

            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            // MySQL 데이타베이스를 연결하기 위해서는 MySqlConnection 클래스를 사용한다. 
            // 이 클래스를 생성할 때, Connection String을 넣어 주어야 하는데, 여기에는 datasource명, port번호, 사용자명, 암호을 지정해 준다.
            string myConnection = "datasource = localhost; port=3306; username=root; password=root";
            string Query = "delete from test.student where no = '" + this.tb_no.Text + "' ;";

            MySqlConnection myConn = new MySqlConnection(myConnection);

            // MySqlCommand에 해당 SQL문을 지정하여 실행한다
            MySqlCommand SelectCommand = new MySqlCommand(Query, myConn);

            // MySqlDataReader는 연결모드로 데이타를 서버에서 가져온다.
            MySqlDataReader myReader;

            try
            {
                myConn.Open();

                //ExecuteReader를 이용하여 연결 모드로 데이타 가져오기
                myReader = SelectCommand.ExecuteReader();
                MessageBox.Show("삭제됨");

                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        */
    }

