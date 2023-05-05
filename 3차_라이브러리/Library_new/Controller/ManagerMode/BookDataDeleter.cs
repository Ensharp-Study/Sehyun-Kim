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
    internal class BookDataDeleter
    {
        
        public void DeleteBookInfo()
        {
            Console.Clear();
            int i = 0;
            int booklistnumber = 0;
            BookUpdater bookUpdater = new BookUpdater();

            bookUpdater.DisplayAllBook(); //모든 책 표시

            Console.WriteLine("삭제할 책 id를 입력하세요.");
            int inputBookId = int.Parse(Console.ReadLine());

            CRUDInDAO mysqlConnecter = new CRUDInDAO();
            bool result = mysqlConnecter.InsertUpdateDelete($"DELETE FROM bookconstructor WHERE id = '{inputBookId}'");
            Console.Clear();
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
