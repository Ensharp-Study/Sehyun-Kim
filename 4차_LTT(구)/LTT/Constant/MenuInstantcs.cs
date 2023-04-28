using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.Model;
using LTT.View;

namespace LTT.Constant
{
    internal class MenuInstantcs
    {
        public void CheckMenuInstant(StudentData studentData)
        {
            Console.SetCursorPosition(0, 7); //강의 시간표 조회

            MenuDisplay menuDisplay = new MenuDisplay();
            bool check = true;
            int i = 0;
            while (check == true)
            {


                if (i == 0)
                {
                    Console.SetCursorPosition(0, 7);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("                                      ●   강의 시간표 조회");
                    menuDisplay.PrintTextColorWhite(i);
                    Console.SetCursorPosition(38, 7);
                }
                else if (i == 1)
                {
                    Console.SetCursorPosition(0, 9);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("                                      ●   관심과목 담기");
                    menuDisplay.PrintTextColorWhite(i);
                    Console.SetCursorPosition(38, 9);
                }
                else if (i == 2)
                {
                    Console.SetCursorPosition(0, 11);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("                                      ●   수강 신청");
                    menuDisplay.PrintTextColorWhite(i);
                    Console.SetCursorPosition(38, 11);
                }

                else if (i == 3)
                {
                    Console.SetCursorPosition(0, 13);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("                                      ●   수강 내역 조회");
                    menuDisplay.PrintTextColorWhite(i);
                    Console.SetCursorPosition(38, 13);
                }
                ConsoleKeyInfo keyinput = Console.ReadKey();
                SearchTimeTable searchTimeTable = new SearchTimeTable();
                MenuOfInterestedSubject menuOfInterestedSubject = new MenuOfInterestedSubject();
                MenuOfRegisterLecture menuOfRegisterLecture = new MenuOfRegisterLecture();
                if (keyinput.Key == ConsoleKey.Enter)
                {
                    bool interest = true;
                    switch (i)
                    {
                        case 0:
                            bool judge = false;
                            searchTimeTable.SearchingTimeTable(studentData, judge);
                            break;
                        case 1:
                            menuOfInterestedSubject.ViewMenuOfInterestedSubject(studentData);
                            break;
                        case 2:
                            //수강신청
                            menuOfRegisterLecture.ViewMenuOfRegisterLecture(studentData);
                            break;
                        case 3:
                            //수강내역조회
                            break;
                    }
                    check = false;
                }
                if (i >= 0 && i <= 2 && keyinput.Key == ConsoleKey.DownArrow)
                {
                    i++;
                }
                else if (i >= 1 && i <= 3 && keyinput.Key == ConsoleKey.UpArrow)
                {
                    i--;
                }


            }
            Console.CursorVisible = true;
        }
    }
}
