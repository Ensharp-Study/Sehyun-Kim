using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Library
{
    internal class DatabaseConnection
    {
        private static DatabaseConnection _instance = null;
        private MySqlConnection _connection = null;

        private DatabaseConnection()
        {
            string connectionString = "Server=localhost;Port=3306;Database=member1;Uid=root;Pwd=0000";
            _connection = new MySqlConnection(connectionString);
        }

        public static DatabaseConnection Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DatabaseConnection();
                }
                return _instance;
            }
        }

        public MySqlConnection Connection
        {
            get { return _connection; }
        }
    }
}
