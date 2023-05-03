using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;
using Library;
using System.Text.RegularExpressions;
using Library.Model;
using Library.View;
using Library.Controller;
using static Library.Controller.Account;

namespace Library.Controller
{
    internal class UserDataDeleter
    {
        private BookData bookData;
        private UserData userData;

        public UserDataDeleter(BookData bookData, UserData userData)
        {
            this.bookData = bookData;
            this.userData = userData;
        }
        

        /*
            * string userid = "testuser";
bool result = DeleteMysql(userid);

if (result)
{
   Console.WriteLine("삭제 성공");
}
else
{
   Console.WriteLine("삭제 실패");
}
          */

        
        public void deleteuserinfo()
        {
            Account account = new Account(bookData, userData);
            MysqlConnecter mysqlConnecter = new MysqlConnecter();
            if (account.Userid == null) // null 체크
            {
                Console.WriteLine("삭제할 사용자 정보가 없습니다.");
                return;
            }

            bool result = mysqlConnecter.DeleteMysql(account.Userid);
            
            if (result)
            {
                Console.WriteLine("삭제 성공");
            }
            else
            {
                
                Console.WriteLine("삭제 실패");
            }

        }
    }
}
