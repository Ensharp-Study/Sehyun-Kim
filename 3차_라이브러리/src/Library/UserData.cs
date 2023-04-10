using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;

namespace Library
{
    internal class UserData
     {
        public string userid { get; set; }
        public string password { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int PhoneNumber { get; set; }
        public int Address { get; set; }

        

        public UserData()
        {
        }
        public UserData(string userid, string password, string Name, int Age,
            int PhoneNumber, int Address )
        {
            this.userid = userid;
            this.password = password;
            this.Name = Name;
            this.Age = Age;
            this.PhoneNumber= PhoneNumber;
            this.Address = Address;
            
        }

       
    }
   
        

    }


