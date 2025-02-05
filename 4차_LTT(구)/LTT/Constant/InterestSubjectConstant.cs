﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.View;
using LTT.Model;
using LTT.Controller;

namespace LTT.Constant
{
    internal class InterestSubjectConstant
    {
        public void SwitchInterestSubjectConstant(int inputnumber, StudentData studentData)
        {
            NewArrayFromExcelcs newArrayFromExcelcs = new NewArrayFromExcelcs(studentData);
            MenuOfInterestedSubject menuOfInterestedSubject = new MenuOfInterestedSubject();
            SearchTimeTable searchTimeTable = new SearchTimeTable();
            InterestSubjectConstant interestSubjectInstant = new InterestSubjectConstant();
            MenuDisplay menuDisplay = new MenuDisplay();
            IntervalCol intervalCol = new IntervalCol();    

            switch (inputnumber)
            {
                case 0: //메뉴로 돌아가기 
                    Console.Clear();
                    menuDisplay.DisplayMenu(studentData);
                    break;

                case 1: //관심과목 담기 
                    Console.Clear();
                    bool judge = false;
                    searchTimeTable.SearchingTimeTable(studentData, judge);
                    break;

                case 2: //관심과목 삭제 
                    Console.Clear();
                    bool check = true; //check가 true일 동안 진행된다.

                    foreach (string[] row in studentData.StudentList[0].interestedLecture)
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
                        Console.WriteLine("삭제할 강의 번호를 입력해 주세요. 0을 눌러 종료");
                        string inputExpression = Console.ReadLine();
                        Console.Clear();
                        if (inputExpression == "0") // 입력값이 "0"이면 메서드를 빠져나간다.
                        {
                            menuOfInterestedSubject.ViewMenuOfInterestedSubject(studentData); //메뉴로 돌아가기
                            break;
                        }

                        for (int i = 0; i < studentData.StudentList[0].interestedLecture.Count; i++)
                        { //저장된 관심과목 리스트 돌기 
                            if (studentData.StudentList[0].interestedLecture[i][0] == inputExpression)
                            { // 만약 inputExpression이 강의 번호와 같다면 관심과목 리스트에서 해당 번호의 강의를 삭제한다.
                                studentData.StudentList[0].interestedLecture.RemoveAt(i);
                                break;
                            }
                        }
                        //결과 출력
                        foreach (string[] row in studentData.StudentList[0].interestedLecture)
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

                case 3: //관심과목 조회
                    Console.Clear();
                    foreach (string[] row in studentData.StudentList[0].interestedLecture)
                    {
                        string tempString = "";

                        for (int i = 0; i < 12; i++)
                        {
                            tempString += row[i].PadRight(intervalCol.SetIntervalCol(i) - (Encoding.Default.GetByteCount(row[i].PadRight(intervalCol.SetIntervalCol(i))) - intervalCol.SetIntervalCol(i)) / 2);
                        }


                        Console.WriteLine(tempString);
                    }

                    Console.WriteLine("0을 눌러 돌아가기");
                    int Expression = int.Parse(Console.ReadLine());
                    if (Expression == 0)
                    {
                        menuOfInterestedSubject.ViewMenuOfInterestedSubject(studentData);
                    }

                    break;


            }
        }
    }
}
