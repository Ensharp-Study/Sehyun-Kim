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

        //유저 업데이트 query
        public const string updatePassword = "UPDATE userconstructor SET password = '{0}' WHERE userid = '{1}'";
        public const string updateName = "UPDATE userconstructor SET name = '{0}' WHERE userid = '{1}'";
        public const string updateAge = "UPDATE userconstructor SET age = '{0}' WHERE userid = '{1}'";
        public const string updatePhone = "UPDATE userconstructor SET phoneNumber = '{0}' WHERE userid = '{1}'";
        public const string updateAddress = "UPDATE userconstructor SET address = '{0}' WHERE userid = '{1}'";

        //책 업데이트 query
        public const string UpdateBookQuery = "UPDATE bookconstructor SET {0} = '{1}' WHERE id = '{2}'";

        public const string insertBookQuery = "INSERT INTO bookconstructor(id, bookName, author, publisher, publicationDate, quantity, price, isbn, info, rentpossible) " +
                                   "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', {5}, '{6}', '{7}', '{8}', {9})";
        public const string selectFromApply = "SELECT * FROM appliedbooklist";
        public const string selectFromUser = $"SELECT * FROM userconstructor";
        public const string deleteUser = "DELETE FROM userconstructor WHERE userid='{0}'";
        public const string deleteBorrowList = "DELETE FROM borrowlist WHERE userid='{0}'";

        public const string insertBorrowList = @"INSERT INTO borrowlist(id, bookName, author, publisher, quantity, price, publicationDate, isbn, info, rentpossible, borrowtime, userid) 
                                        SELECT id, bookName, author, publisher, quantity, 0, publicationDate, isbn, info, rentpossible, '{0}', '{1}' 
                                        FROM bookconstructor 
                                        WHERE id = '{2}'";

        public const string selectBook = "SELECT * FROM bookconstructor";
        public const string deleteApplyList = "DELETE FROM appliedbooklist WHERE title='{0}' AND userid='{1}'";
        public const string selectInApply = "SELECT * FROM appliedbooklist";
        public const string selectApplyList = "SELECT * FROM appliedbooklist WHERE title='{0}'";
        public const string deleteBookBorrowList = "DELETE FROM borrowlist WHERE id = {0} AND userid = '{1}'";
        public const string selectId = "SELECT id FROM bookconstructor WHERE id = '{0}'";
        public const string selectBorrowList = "SELECT * FROM borrowlist WHERE userid = '{0}'";
        public const string updateRentPossibleIncrease = @"UPDATE bookconstructor SET rentpossible = rentpossible + 1
WHERE id = '{0}'";
        public const string selectUserWithId = "SELECT * FROM userconstructor WHERE userid = '{0}'";
        public const string updateRentPossibleDecrease = "UPDATE bookconstructor SET rentpossible = rentpossible - 1 WHERE id = '{0}'";

        public const string selectWithIsbn = "SELECT isbn FROM bookconstructor WHERE isbn = '{0}'";
        public const string deleteWithIsbn = "DELETE FROM bookconstructor WHERE isbn = '{0}'";
        public const string deleteBorrowListWithIsbn = "DELETE FROM borrowlist WHERE isbn='{0}'";
        public const string deleteReturnListWithIsbn = "DELETE FROM returnlist WHERE isbn='{0}'";
        public const string selectBookId = "SELECT id FROM bookconstructor WHERE id = '{0}'";




    }

    
}
