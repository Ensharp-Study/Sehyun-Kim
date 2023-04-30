using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;
using Library.Model;
using Library.View;
using Library.Controller;

namespace Library.Controller
{
   public class Library
    {
        public static void Main(String[] args) //메인함수
        {

            ModeSelector modeSelector = new ModeSelector();
            modeSelector.SelectMode();
            
            
        }
    }
        
}