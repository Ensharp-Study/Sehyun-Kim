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
    internal class UserConstructor
     {
       
        public string userid { get; set; }
        public string password { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }

        public List<BookConstructor> rentedbooklist { get; set; }
        public List<BookConstructor> returnedbooklist { get; set; }

        public UserConstructor(string userid, string password, string Name, int Age,
            int PhoneNumber, string Address)
        { // 매개변수가 있는 생성자. 인자를 받아 해당 인자들을 사용하여 클래스를 인스턴스화함
            this.userid = userid;
            this.password = password;
            this.Name = Name;
            this.Age = Age;
            this.PhoneNumber= PhoneNumber;
            this.Address = Address;
            rentedbooklist = new List<BookConstructor>();
            returnedbooklist = new List<BookConstructor>();

             
        }

       
    }
   
        

    }


