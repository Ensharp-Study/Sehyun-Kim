using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            int inputnumber = 0;
            string inputNumberString = Console.ReadLine();
            SearchTimeTable searchTimeTable = new SearchTimeTable();
            MenuDisplay menuDisplay = new MenuDisplay();    
            bool interest = false;
            Regex regex = new Regex("^[0-3]$");

            if (!regex.IsMatch(inputNumberString))
            {
                Console.WriteLine("1-3 사이의 값을 입력해주세요");
            }

            else
            {
                inputnumber = int.Parse(inputNumberString);
            }

            switch (inputnumber)
            {
                case 0:
                    menuDisplay.DisplayMenu(studentData);
                    break;
                case 1:
                    bool judge = false;
                    searchTimeTable.SearchingTimeTable(studentData, judge);
                    break;
                case 2: //관심과목 삭제 
                    bool check = true;
                    NewArrayFromExcelcs newArrayFromExcelcs = new NewArrayFromExcelcs(studentData);
                    foreach(string[] row in studentData.StudentList[0].interestedLecture)
                    {
                        foreach (string col in row)
                        {
                            Console.Write(col + " ");
                        }
                        Console.WriteLine();
                    }
                    while (check == true)
                    {

                        Console.WriteLine("삭제할 강의 번호를 입력해 주세요. 0을 눌러 종료");
                        string inputExpression = Console.ReadLine();

                        if (inputExpression == "0") // 입력값이 "0"이면 메서드를 빠져나갑니다.
                        {
                            ViewMenuOfInterestedSubject(studentData);
                            break;
                        }

                        for (int i = 0; i < studentData.StudentList[0].interestedLecture.Count; i++)
                        {
                            if (studentData.StudentList[0].interestedLecture[i][0] == inputExpression)
                            {
                                studentData.StudentList[0].interestedLecture.RemoveAt(i);
                                break;
                            }
                        }
                        
                       







                        foreach (string[] row in studentData.StudentList[0].interestedLecture)
                        {
                            foreach (string col in row)
                            {
                                Console.Write(col + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    break;
                    
                case 3:
                    foreach (string[] row in studentData.StudentList[0].interestedLecture)
                    {
                        foreach (string col in row)
                        {
                            Console.Write(col + " ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("0을 눌러 돌아가기");
                    int Expression = int.Parse(Console.ReadLine());
                    if (Expression == 0)
                    {
                        ViewMenuOfInterestedSubject(studentData);
                    }
                    
                    break;
               

            }
        }

        
    }
}
