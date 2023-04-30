using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.View;
using Library.Controller;

namespace Library.View
{
    internal class BookUpdateView
    {
        private BookData bookData;
        private UserData userData;

        public BookUpdateView(BookData bookData, UserData userData)
        {
            this.bookData = bookData;
            this.userData = userData;
        }
        public void ViewForUpdateBookInfo(int booklistnumber)
        {
            Console.WriteLine("현재 해당 도서의 정보입니다.");


            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("  ID: " + bookData.BookList[booklistnumber].id);
            Console.WriteLine("  Title: " + bookData.BookList[booklistnumber].bookName);
            Console.WriteLine("  Author: " + bookData.BookList[booklistnumber].author);
            Console.WriteLine("  Publisher: " + bookData.BookList[booklistnumber].publisher);
            Console.WriteLine("  price: " + bookData.BookList[booklistnumber].price);
            Console.WriteLine("  quantity: " + bookData.BookList[booklistnumber].quantity);
            Console.WriteLine("  publicationDate: " + bookData.BookList[booklistnumber].publicationDate);
            Console.WriteLine("  isbn: " + bookData.BookList[booklistnumber].isbn);
            Console.WriteLine("  info: " + bookData.BookList[booklistnumber].info);
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("  ID: ");
            Console.WriteLine("  Title: ");
            Console.WriteLine("  Author: ");
            Console.WriteLine("  Publisher: ");
            Console.WriteLine("  price: ");
            Console.WriteLine("  quantity: ");
            Console.WriteLine("  publicationDate: ");
            Console.WriteLine("  isbn: ");
            Console.WriteLine("  info: ");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■");
        }
    }
}
