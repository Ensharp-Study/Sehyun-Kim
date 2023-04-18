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
    internal class DeleteInfo
    {
        private BookData bookData;
        private UserData userData;

        public DeleteInfo(BookData bookData, UserData userData)
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
        public void deleteuserinfo()
        {
            Console.Clear();
            HomeDisplay display = new HomeDisplay();
            List<UserConstructor> userList = new List<UserConstructor>();
            // 사용자가 대여한 도서가 있는지 확인
            bool hasRentedBooks = userData.UserList[userlistnumber].rentedbooklist.Any(book => book.id > 0);

            if (hasRentedBooks)
            {
                Console.WriteLine("대여중인 도서가 있어 탈퇴할 수 없습니다.");
            }
            else
            {
                userData.UserList.RemoveAt(userlistnumber);
                Console.WriteLine("회원 탈퇴되었습니다.");
                display.InitialDisplay();

            }
        }
    }
}
