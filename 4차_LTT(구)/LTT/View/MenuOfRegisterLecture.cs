﻿using System;
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
            IntervalCol intervalCol = new IntervalCol();
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
                    Console.Clear();
                    bool judge = true;
                    searchTimeTable.SearchingTimeTable(studentData, judge);
                    break;
                case 2:
                    Console.Clear();
                    bool judgement = true;
                    bool equalJudge = false;
                    //수강신청 강의 추가 -> 관심과목 담기에서 담은 리스트에서 수강신청 하기 -> interestLecture, registeredlecture
                    foreach (string[] row in studentData.StudentList[0].interestedLecture)
                    {
                        string tempString = "";

                        for (int i = 0; i < 12; i++)
                        {
                            tempString += row[i].PadRight(intervalCol.SetIntervalCol(i) - (Encoding.Default.GetByteCount(row[i].PadRight(intervalCol.SetIntervalCol(i))) - intervalCol.SetIntervalCol(i)) / 2);
                        }


                        Console.WriteLine(tempString);
                    }
                    
                    while (judgement == true)
                    {
                        Console.WriteLine("수강 신청할 강의 번호를 입력해 주세요. 0을 눌러 종료") ;
                        string numberExpression=Console.ReadLine();

                        foreach (string[] row in studentData.StudentList[0].interestedLecture)
                        {
                            if (numberExpression == "0")
                            {
                                ViewMenuOfRegisterLecture(studentData);
                                break;
                            }

                            else if (row[0].Equals(numberExpression))
                            {
                                studentData.StudentList[0].registeredLecture.Add(row);
                                equalJudge = true;
                                break;
                            }
                        }
                        if (!equalJudge)

                        {
                            Console.WriteLine("일치하는 강의 번호가 없습니다.");
                        }
                    }
                    foreach (string[] row in studentData.StudentList[0].registeredLecture)
                    {
                        string tempString = "";

                        for (int i = 0; i < 12; i++)
                        {
                            tempString += row[i].PadRight(intervalCol.SetIntervalCol(i) - (Encoding.Default.GetByteCount(row[i].PadRight(intervalCol.SetIntervalCol(i))) - intervalCol.SetIntervalCol(i)) / 2);
                        }


                        Console.WriteLine(tempString);
                    }
                    
                    break;
                case 3: //강의 삭제 
                    Console.Clear();
                    bool check = true;
                    foreach (string[] row in studentData.StudentList[0].registeredLecture)
                    {
                        string tempString = "";

                        for (int i = 0; i < 12; i++)
                        {
                            tempString += row[i].PadRight(intervalCol.SetIntervalCol(i) - (Encoding.Default.GetByteCount(row[i].PadRight(intervalCol.SetIntervalCol(i))) - intervalCol.SetIntervalCol(i)) / 2);
                        }


                        Console.WriteLine(tempString);
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
                    Console.Clear();
                    bool check1 = true;
                    
                    foreach (string[] row in studentData.StudentList[0].registeredLecture)
                    {
                        string tempString = "";

                        for (int i = 0; i < 12; i++)
                        {
                            tempString += row[i].PadRight(intervalCol.SetIntervalCol(i) - (Encoding.Default.GetByteCount(row[i].PadRight(intervalCol.SetIntervalCol(i))) - intervalCol.SetIntervalCol(i)) / 2);
                        }


                        Console.WriteLine(tempString);
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
                            string tempString = "";

                            for (int i = 0; i < 12; i++)
                            {
                                tempString += row[i].PadRight(intervalCol.SetIntervalCol(i) - (Encoding.Default.GetByteCount(row[i].PadRight(intervalCol.SetIntervalCol(i))) - intervalCol.SetIntervalCol(i)) / 2);
                            }


                            Console.WriteLine(tempString);
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
