using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LTT.Model;
using LTT.Constant;

namespace LTT.View
{
    internal class MenuDisplay
    {
        public void DisplayMenu(StudentData studentData)
        {
            MenuOfInterestedSubject menuOfInterestedSubject = new MenuOfInterestedSubject();
            MenuOfRegisterLecture menuOfRegisterLecture = new MenuOfRegisterLecture();
            MenuInstantcs menuInstantcs = new MenuInstantcs();

            Console.CursorVisible = false;
            Console.Clear();
            Console.SetWindowSize(103, 23);

            Console.WriteLine("\n\n");
            Console.WriteLine("                            *-.-:*=.-.*:*-=*-.-:*=.-.*:*-=*-.-:*=.-*   \n\n\n");



            Console.WriteLine("                                      ○   강의 시간표 조회\n ");

            Console.WriteLine("                                      ○   관심과목 담기 \n");

            Console.WriteLine("                                      ○   수강 신청 \n");

            Console.WriteLine("                                      ○   수강 내역 조회 \n\n\n");


            Console.WriteLine("                                         ");
            Console.WriteLine("                            *-.-:*=.-.*:*-=*-.-:*=.-.*:*-=*-.-::*-=*");

            Console.SetCursorPosition(0, 7); //강의 시간표 조회
            menuInstantcs.CheckMenuInstant(studentData);
           

        }
        public void SetTextColorWhite(int xcooperation, int ycooperation, string text)
        {
            Console.SetCursorPosition(xcooperation, ycooperation);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text);

        }

        public void PrintTextColorWhite(int number)
        {
            switch (number)
            {
                case 0:
                    SetTextColorWhite(0, 9,  "                                      ○   관심과목 담기");
                    SetTextColorWhite(0, 11, "                                      ○   수강 신청");
                    SetTextColorWhite(0, 13, "                                      ○   수강 내역 조회");
                    break;

                case 1:
                    SetTextColorWhite(0,7,   "                                      ○   강의 시간표 조회");
                    SetTextColorWhite(0, 11, "                                      ○   수강 신청");
                    SetTextColorWhite(0, 13, "                                      ○   수강 내역 조회");
                    
                    break;
                case 2:
                    SetTextColorWhite(0, 7,  "                                      ○   강의 시간표 조회");
                    SetTextColorWhite(0, 9,  "                                      ○   관심과목 담기");
                    SetTextColorWhite(0, 13, "                                      ○   수강 내역 조회");
                    break;
                case 3:
                    SetTextColorWhite(0, 7,  "                                      ○   강의 시간표 조회");
                    SetTextColorWhite(0, 11, "                                      ○   수강 신청");
                    SetTextColorWhite(0, 9,  "                                      ○   관심과목 담기");
                    break;

            }
            
            
        }
    }
}
