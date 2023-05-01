using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;
using Library.Model;
using Library.View;
using Library.Controller;
namespace Library.Model
{
    internal class BookConstructor
    {
        public int id { get; set; }
        public string bookName { get; set; }
        public string author { get; set; }
        public string publisher { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public string publicationDate { get; set; }
        public string isbn { get; set; }
        public string info { get; set; }

        public int rentpossible { get; set; }
        public BookConstructor()
        {
        }
        public BookConstructor(int id, string bookName, string author, string publisher,
            int quantity, int price, string publicationDate, string isbn, string info, int rentpossible)
        {
            this.id = id;
            this.bookName = bookName;
            this.publisher = publisher;
            this.author = author;
            this.price = price;
            this.quantity = quantity;
            this.isbn = isbn;
            this.info = info;
            this.rentpossible = rentpossible;
        }







    }

    
}
