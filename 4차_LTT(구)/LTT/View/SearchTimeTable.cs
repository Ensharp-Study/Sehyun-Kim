using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.Model;
using LTT.Controller;


namespace LTT.View
{
    internal class SearchTimeTable
    {
        public void SearchingTimeTable()
        {
            ColorSetDisplay colorSetDisplay = new ColorSetDisplay();
            MenuControllcs menuControllcs = new MenuControllcs();
            Console.Clear();
            Console.SetWindowSize(103, 25);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("\n");
            Console.WriteLine("            ┌-:*=.-.*:*-=*-.-:*-.-:*=.-.*:*-=*-.-:*=.-.*:*-=*-.-:*=.-**-.-:*=.-.-=*-.-:*:┐   ");
            Console.WriteLine("            ┃  ○ 개설학과전공 │                                                         ┃                        ");
            Console.WriteLine("            ┃                  ┃                                                         ┃        ");
            Console.WriteLine("            ├────────────────────────────────────────────────────────────────────────────┤                                                                               ");
            Console.WriteLine("            ┃  ○ 이수구분     ┃                                                         ┃               ");
            Console.WriteLine("            ┃                  ┃                                                         ┃   ");
            Console.WriteLine("            ├────────────────────────────────────────────────────────────────────────────┤                                                                                 ");
            Console.WriteLine("            ┃  ○ 교과목명     ┃                                                         ┃                 ");
            Console.WriteLine("            ├────────────────────────────────────────────────────────────────────────────┤                                                                                  ");
            Console.WriteLine("            ┃  ○ 교수명       ┃                                                         ┃              ");
            Console.WriteLine("            ├────────────────────────────────────────────────────────────────────────────┤                                                                                  ");
            Console.WriteLine("            ┃  ○ 학년         ┃                                                         ┃            ");
            Console.WriteLine("            ├────────────────────────────────────────────────────────────────────────────┤                                                                                  ");
            Console.WriteLine("            ┃  ○ 학수번호     ┃                                                         ┃                ");
            Console.WriteLine("            ┗*-.-:*=.-.*:*-=*-.-:*-.-:*=.-.*:*-=*-.-:*=.-.*:*-=*-.-:*=.-**-.-:*=.-.-=*-.:┛    \n                                                                              ");

            Console.Write("                                             *-_.검색하기._-* ");

            Console.CursorVisible = false;
            bool check = true;
            int i = 0;
            int returnvariable = 0;

            string numberExpression = "NULL";
            string majorinput = "NULL";
            string randomExpression = "NULL";
            string ProfessorExpression = "NULL";
            string GradeExpression = "NULL";
            string divideinput = "NULL";
            while (check)
            {
               returnvariable= menuControllcs.controllMenu();
                menuControllcs.countCursor(returnvariable);
            }
            

        }



    }
}


