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
using static Library.Controller.Account;


namespace Library.Controller
{

    internal class NumberInputUser
    {
        

        public int CheckRegex()
        { 
            Regex regex = new Regex("^[0-7]$"); // 정규식 패턴
            int number;
            while (true)
            {
                number = int.Parse(Console.ReadLine());
                string str = Convert.ToString(number);
                if (!regex.IsMatch(str))
                {
                    Console.WriteLine("0-7 사이의 값을 입력해주세요");
                }
                else if (regex.IsMatch(str))
                {
                    return number;
                }
            }
        }
        


       

       

        
        
        
       
        
        
        
        
    }
}