using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace NewLibrary.Model.DAO
{
    internal class DatabaseConnection
    {
        private static DatabaseConnection instance = null;
        private MySqlConnection connection = null;

        private DatabaseConnection()
        {
            string connectionString = "Server=localhost;Port=3306;Database=member1;Uid=root;Pwd=0000";
            connection = new MySqlConnection(connectionString);
        }

        public static DatabaseConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseConnection();
                }
                return instance;
            }
        }

        public MySqlConnection Connection
        {
            get { return connection; }
        }
    }
}

