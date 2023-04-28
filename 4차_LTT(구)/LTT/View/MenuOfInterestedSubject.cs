using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LTT.Constant;
using LTT.Controller;
using LTT.Model;

namespace LTT.View
{
    internal class MenuOfInterestedSubject
    {
        public void ViewMenuOfInterestedSubject(StudentData studentData)
        {
            Console.Clear();

            Console.WriteLine("            ┌-:*=.-.*:*-=*-.-:*-.-:*=.-.*:*-=*-.-:*=.-.*:*-=*-.-:*=.-**-.-:*=.-.-=*-.-:*:┐   ");
            Console.WriteLine("");
            Console.WriteLine("                                             < 관심과목>");
            Console.WriteLine("");
            Console.WriteLine("                                           1.  관심과목 담기                            ");
            Console.WriteLine("                                                   ");
            Console.WriteLine("                                                                           ");
            Console.WriteLine("                                           2.  관심과목 삭제                                      ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                               ");
            Console.WriteLine("                                           3.  관심과목 조회                      ");
            Console.WriteLine("                                          ");
            Console.WriteLine("                                           0을 눌러 돌아가기");
            Console.WriteLine("            ┗*-.-:*=.-.*:*-=*-.-:*-.-:*=.-.*:*-=*-.-:*=.-.*:*-=*-.-:*=.-**-.-:*=.-.-=*-.:┛    \n     ");

            SearchTimeTable searchTimeTable = new SearchTimeTable();
            InterestSubjectConstant interestSubjectInstant = new InterestSubjectConstant();
            MenuDisplay menuDisplay = new MenuDisplay();
            Regex regex = new Regex("^[0-3]$");

            bool interest = false;
            int inputnumber = 0;
            string inputNumberString = Console.ReadLine();
            

            if (!regex.IsMatch(inputNumberString))
            {
                Console.WriteLine("0-3 사이의 값을 입력해주세요");
            }

            else
            {
                inputnumber = int.Parse(inputNumberString);
            }

            interestSubjectInstant.SwitchInterestSubjectConstant(inputnumber,studentData);
           
        }

        
    }
}
