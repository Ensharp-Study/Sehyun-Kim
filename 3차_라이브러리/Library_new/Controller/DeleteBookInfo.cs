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
using static Library.Controller.LoginOrNewmember;

namespace Library.Controller
{
    internal class DeleteBookInfo
    {
        private BookData bookData;
        private UserData userData;

        public DeleteBookInfo(BookData bookData, UserData userData)
        {
            this.bookData = bookData;
            this.userData = userData;
        }
        public void deletebookinfo()
        {
            ShowAllBook showAllBook = new ShowAllBook(bookData, userData);
            Console.Clear();
            int i = 0;
            int booklistnumber = 0;
            showAllBook.allBook();
            Console.WriteLine("삭제할 책 id를 입력하세요.");
            int inputBookId = int.Parse(Console.ReadLine());

            foreach (BookConstructor book in bookData.BookList)
            {
                i++;
                if (book.id == inputBookId)
                {
                    booklistnumber = i - 1;

                    bookData.BookList.RemoveAt(booklistnumber);
                    i = 0;
                    Console.Clear();
                    Console.WriteLine("도서가 삭제되었습니다.");



                    break;
                }
            }
        }
    }
}
