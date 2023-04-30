using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.View;
using Library.Controller;
using Library.Constant;
namespace Library.Model
{
   
    internal class BookData
    {

        private List<BookConstructor> bookList;

        public List<BookConstructor> BookList
        {
            get { return bookList; }
            set { bookList = value; }
        }

        public BookData()
        {
            bookList = new List<BookConstructor>();
        }

        public void InsertBookData()
        {
            BookList.Add(new BookConstructor()
            {
                id = 1,
                bookName = "자료구조",
                author = "나중채",
                publisher = "세종대학교",
                quantity = 3,
                price = 20000,
                publicationDate = "2010-07-18",
                isbn = "123456789",
                info = "코딩",
                rentpossible = 3
            }) ;

            BookList.Add(new BookConstructor()
            {
                id = 4,
                bookName = "디지털시스템",
                author = "김용국",
                publisher = "컴공",
                quantity = 5,
                price = 17000,
                publicationDate = "2018-09-24",
                isbn = "798504657",
                info = "회로",
                rentpossible = 5
            });

            BookList.Add(new BookConstructor()
            {
                id = 78,
                bookName = "문제해결",
                author = "김세현",
                publisher = "교양",
                quantity = 3,
                price = 20000,
                publicationDate = "2021-11-22",
                isbn = "342534092",
                info = "글쓰기",
                rentpossible = 3
            });

            BookList.Add(new BookConstructor()
            {
                id = 12,
                bookName = "화학의이해",
                author = "신재은",
                publisher = "서울",
                quantity = 1,
                price = 32000,
                publicationDate = "2014-01-13",
                isbn = "123432478",
                info = "화학",
                rentpossible = 1
            });

            BookList.Add(new BookConstructor()
            {
                id = 45,
                bookName = "간호학실습",
                author = "김채린",
                publisher = "전주",
                quantity = 4,
                price = 20000,
                publicationDate = "2004-06-12",
                isbn = "243223478",
                info = "간호",
                rentpossible = 4
            });

            BookList.Add(new BookConstructor()
            {
                id = 687,
                bookName = "C프로그래밍",
                author = "정동원",
                publisher = "컴퓨터",
                quantity = 2,
                price = 14000,
                publicationDate = "2022-08-05",
                isbn = "985641778",
                info = "코딩",
                rentpossible = 2
            });

        }
    }
}
