﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.Model;
using LTT.Constant;
namespace LTT.View
{
    internal class SearchTimeTable
    {
        public void SetTextColorWhite(int xcoordinate, int ycoordinate, string text)
        {
            Console.SetCursorPosition(xcoordinate, ycoordinate);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
        }
        public void SetTextColorGreen(int xcoordinate, int ycoordinate, string text)
        {
            Console.SetCursorPosition(xcoordinate, ycoordinate);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text);
        }
        public void SearchingTimeTable(StudentData studentData, bool judge)
        {
            Console.Clear();
            Console.SetWindowSize(103, 25);
            Console.SetCursorPosition(0, 0);

            Console.WriteLine("\n");
            Console.WriteLine("            ┌-:*=.-.*:*-=*-.-:*-.-:*=.-.*:*-=*-.-:*=.-.*:*-=*-.-:*=.-**-.-:*=.-.-=*-.-:*:┐   ");
            Console.WriteLine("            ┃  ○ 개설학과전공 │                                                         ┃  ");
            Console.WriteLine("            ┃                  ┃                                                         ┃  ");
            Console.WriteLine("            ├────────────────────────────────────────────────────────────────────────────┤                                                                               ");
            Console.WriteLine("            ┃  ○ 이수구분     ┃                                                         ┃   ");
            Console.WriteLine("            ┃                  ┃                                                         ┃   ");
            Console.WriteLine("            ├────────────────────────────────────────────────────────────────────────────┤                                                                                 ");
            Console.WriteLine("            ┃  ○ 교과목명     ┃                                                         ┃   ");
            Console.WriteLine("            ├────────────────────────────────────────────────────────────────────────────┤                                                                                  ");
            Console.WriteLine("            ┃  ○ 교수명       ┃                                                         ┃              ");
            Console.WriteLine("            ├────────────────────────────────────────────────────────────────────────────┤                                                                                  ");
            Console.WriteLine("            ┃  ○ 학년         ┃                                                         ┃            ");
            Console.WriteLine("            ├────────────────────────────────────────────────────────────────────────────┤                                                                                  ");
            Console.WriteLine("            ┃  ○ 학수번호     ┃                                                         ┃                ");
            Console.WriteLine("            ┗*-.-:*=.-.*:*-=*-.-:*-.-:*=.-.*:*-=*-.-:*=.-.*:*-=*-.-:*=.-**-.-:*=.-.-=*-.:┛    \n                                                                              ");

            Console.Write("                                             *-_.검색하기._-* ");

            Console.CursorVisible = false;
            CallMenu(studentData, judge);
        }
        public void CallMenu(StudentData studentData, bool judge)
        {
            string numberExpression = "NULL";
            string majorinput = "NULL";
            string randomExpression = "NULL";
            string ProfessorExpression = "NULL";
            string GradeExpression = "NULL";
            string divideinput = "NULL";

            
            int number = 0;
            TextColorNumber textColorNumber = new TextColorNumber();
            TextColorWhite textColorWhite = new TextColorWhite();
            if (judge == false)
            {
                textColorNumber.CallNumberAndColorMenu(studentData);
            }
            
            if (judge == true)
            {
                textColorNumber.CallNumberAndColorMenuForRegister(studentData);
            }
           
        }

    }
    
   

    }



