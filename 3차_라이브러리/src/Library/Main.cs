﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;
using Library.Controllers;


namespace Library
{
   public class Library
    {
        public static void Main(String[] args) //메인함수
        {

            Display display = new Display();
            UserData.userData();
            BookData.bookData();
            display.InitialDisplay();

            TestController testController = new TestController();
            
            
        }
    }
        
}