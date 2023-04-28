using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.Constant;
using LTT.Controller;
using LTT.Model;

namespace LTT.View
{
    internal class MenuOfRegisterLecture
    {
        public void ViewMenuOfRegisterLecture(StudentData studentData)
        {
            SearchTimeTable searchTimeTable = new SearchTimeTable();
            NewArrayFromExcelcs newArrayFromExcelcs = new NewArrayFromExcelcs( studentData);
            TextColorNumber textColorNumber = new TextColorNumber();
            Console.Clear();
            Console.WriteLine("            ┌-:*=.-.*:*-=*-.-:*-.-:*=.-.*:*-=*-.-:*=.-.*:*-=*-.-:*=.-**-.-:*=.-.-=*-.-:*:┐   ");
            Console.WriteLine("");
            Console.WriteLine("                                             < 수강신청 >");
            Console.WriteLine("");
            Console.WriteLine("                                           1.  강의 검색                            ");
            Console.WriteLine("                                                   ");
            Console.WriteLine("                                           2.  수강신청 강의 추가                                 ");
            Console.WriteLine("                                                                              ");
            Console.WriteLine("                                           3. 수강신청 강의 삭제                     ");
            Console.WriteLine("                                               ");
            Console.WriteLine("                                           4. 수강신청 강의 조회                      ");
            Console.WriteLine("                                          ");
            Console.WriteLine("                                           5. 시간표  ");
            Console.WriteLine("            ┗*-.-:*=.-.*:*-=*-.-:*-.-:*=.-.*:*-=*-.-:*=.-.*:*-=*-.-:*=.-**-.-:*=.-.-=*-.:┛    \n     ");

            int inputnumber = 0;
            inputnumber = int.Parse(Console.ReadLine());
            
            switch (inputnumber)
            { 
                case 1:
                    bool judge = true;
                    searchTimeTable.SearchingTimeTable(studentData, judge);
                    break;
                case 2:
                    bool judgement = true;
                    //수강신청 강의 추가 -> 관심과목 담기에서 담은 리스트에서 수강신청 하기 -> interestLecture, registeredlecture
                    foreach (string[] row in studentData.StudentList[0].interestedLecture)
                    {
                        foreach (string col in row)
                        {
                            Console.Write(col + " ");
                        }
                        Console.WriteLine();
                    }
                    while (judgement == true)
                    {
                        Console.WriteLine("수강 신청할 강의 번호를 입력해 주세요. 0을 눌러 종료") ;
                        string numberExpression=Console.ReadLine();

                        foreach (string[] row in studentData.StudentList[1].interestedLecture)
                        {
                            if (numberExpression == "0")
                            {
                                ViewMenuOfRegisterLecture(studentData);
                                break;
                            }

                            else if (row[0].Equals(numberExpression))
                            {
                                studentData.StudentList[0].registeredLecture.Add(row);
                            }

                            else
                            {
                                Console.WriteLine("일치하는 강의 번호가 없습니다.");
                            }
                            
                        }
                    }
                    foreach (string[] row in studentData.StudentList[0].registeredLecture)
                    {
                        foreach (string col in row)
                        {
                            Console.Write(col + " ");
                        }
                        Console.WriteLine();
                    }
                    break;
                case 3: //강의 삭제 
                    bool check = true;
                    foreach (string[] row in studentData.StudentList[0].registeredLecture)
                    {
                        foreach (string col in row)
                        {
                            Console.Write(col + " ");
                        }
                        Console.WriteLine();
                    }
                    
                    while (check == true)
                    {
                        bool deleteLecture = true;
                        Console.WriteLine("삭제할 강의 번호를 입력해 주세요. 0을 눌러 종료");
                        string Expression = Console.ReadLine();

                        if (Expression == "0") // 입력값이 "0"이면 메서드를 빠져나갑니다.
                        {
                            ViewMenuOfRegisterLecture(studentData);
                            break;
                        }
                        for (int i = 0; i < studentData.StudentList[0].registeredLecture.Count; i++)
                        {
                            if (studentData.StudentList[0].registeredLecture[i][0] == Expression)
                            {
                                deleteLecture = false;
                                studentData.StudentList[0].registeredLecture.RemoveAt(i);
                                break;
                            }
                        }
                        if (deleteLecture)
                        {
                            Console.WriteLine("해당하는 강의 번호가 없습니다.");
                        }
                    }
                    break;
                case 4:
                    bool check1 = true;
                    
                    foreach (string[] row in studentData.StudentList[0].registeredLecture)
                    {
                        foreach (string col in row)
                        {
                            Console.Write(col + " ");
                        }
                        Console.WriteLine();
                    }
                    while (check1 == true)
                    {

                        Console.WriteLine("0을 눌러 돌아가기");
                        string inputExpression = Console.ReadLine();

                        if (inputExpression == "0") // 입력값이 "0"이면 메서드를 빠져나갑니다.
                        {
                            ViewMenuOfRegisterLecture(studentData);
                            break;
                        }

                        for (int i = 0; i < studentData.StudentList[0].registeredLecture.Count; i++)
                        {
                            if (studentData.StudentList[0].registeredLecture[i][0] == inputExpression)
                            {
                                studentData.StudentList[0].registeredLecture.RemoveAt(i);
                                break;
                            }
                        }

                        foreach (string[] row in studentData.StudentList[0].registeredLecture)
                        {
                            foreach (string col in row)
                            {
                                Console.Write(col + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    break;
                    break;
                
                case 5:
                    break;

            }
        }

        
    }
}
