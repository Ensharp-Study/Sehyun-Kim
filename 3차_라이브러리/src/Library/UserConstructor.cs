﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;

namespace Library
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

        public UserConstructor()
        {
            rentedbooklist = new List<BookConstructor>();
            returnedbooklist = new List<BookConstructor>();
        }
        public UserConstructor(string userid, string password, string Name, int Age,
            int PhoneNumber, string Address)
        {
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


