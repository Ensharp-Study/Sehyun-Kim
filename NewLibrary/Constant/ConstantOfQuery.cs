using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLibrary.Constant
{
    internal class ConstantOfQuery
    {

        public const string LoginUserQuery = "SELECT * FROM userconstructor WHERE userid = '{0}' AND password = '{1}'";
        public const string LoginManagerQuery = "SELECT * FROM managerconstructor WHERE managerid = '{0}' AND managerpw = '{1}'";
        public const string InsertInLogQuery = "INSERT INTO log(log_time, log_user, log_info, log_behave) VALUES('{0}', '{1}', '{2}', '{3}')";
        public const string InsertInSignUpQuery = "INSERT INTO userconstructor(userid, password, name, age, phonenumber, address) VALUES('{0}', '{1}', '{2}', {3}, '{4}', '{5}')";
        public const string selectBookNameQuery = "SELECT * FROM bookconstructor WHERE bookName = '{0}'";
        public const string selectauthorQuery = "SELECT * FROM bookconstructor WHERE author = '{0}'";
        public const string selectpublisherQuery = "SELECT * FROM bookconstructor WHERE publisher = '{0}'";
        public const string updatePassword = "UPDATE userconstructor SET password = '{0}' WHERE userid = '{1}'";
        public const string updateName = "UPDATE userconstructor SET name = '{0}' WHERE userid = '{1}'";
        public const string updateAge = "UPDATE userconstructor SET age = '{0}' WHERE userid = '{1}'";
        public const string updatePhone = "UPDATE userconstructor SET phoneNumber = '{0}' WHERE userid = '{1}'";
        public const string updateAddress = "UPDATE userconstructor SET address = '{0}' WHERE userid = '{1}'";


        public const string selectFromUser = $"SELECT * FROM userconstructor";
        public const string deleteUser = "DELETE FROM userconstructor WHERE userid='{0}'";
        public const string deleteBorrowList = "DELETE FROM borrowlist WHERE userid='{0}'";




    }
}
