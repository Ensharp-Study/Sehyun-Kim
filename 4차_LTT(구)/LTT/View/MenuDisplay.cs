using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LTT.Model;

namespace LTT.View
{
    internal class MenuDisplay
    {
        public void DisplayMenu(StudentData studentData)
        {
            MenuOfInterestedSubject menuOfInterestedSubject = new MenuOfInterestedSubject();

            Console.CursorVisible = false;
            Console.Clear();
            Console.SetWindowSize(103, 23);
            Console.WriteLine("\n\n");
            Console.WriteLine("                            *-.-:*=.-.*:*-=*-.-:*=.-.*:*-=*-.-:*=.-*   \n\n\n");



            Console.WriteLine("                                      ○   강의 시간표 조회\n ");

            Console.WriteLine("                                      ○   관심과목 담기 \n");

            Console.WriteLine("                                      ○   수강 신청 \n");

            Console.WriteLine("                                      ○   수강 내역 조회 \n\n\n");



            Console.WriteLine("                            *-.-:*=.-.*:*-=*-.-:*=.-.*:*-=*-.-::*-=*");

            Console.SetCursorPosition(0, 7); //강의 시간표 조회

            
            bool check = true;
            int i = 0;
            while (check==true)
            {
                
                
                if (i == 0)
                {
                    Console.SetCursorPosition(0, 7);
                    
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("                                      ●   강의 시간표 조회");
                    setwhite(i);
                    Console.SetCursorPosition(38, 7);
                }
                else if (i == 1)
                {
                    Console.SetCursorPosition(0, 9);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("                                      ●   관심과목 담기");
                    setwhite(i);
                    Console.SetCursorPosition(38, 9);
                }
                else if (i == 2)
                {
                    Console.SetCursorPosition(0, 11);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("                                      ●   수강 신청");
                    setwhite(i);
                    Console.SetCursorPosition(38, 11);
                }

                else if (i == 3)
                {
                    Console.SetCursorPosition(0, 13);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("                                      ●   수강 내역 조회");
                    setwhite(i);
                    Console.SetCursorPosition(38, 13);
                }
                ConsoleKeyInfo keyinput = Console.ReadKey();
                SearchTimeTable searchTimeTable = new SearchTimeTable();    
                if (keyinput.Key == ConsoleKey.Enter)
                {
                    bool interest = true;
                    switch (i)
                    {
                        case 0:
                            searchTimeTable.SearchingTimeTable(studentData);
                            break;
                        case 1:
                            menuOfInterestedSubject.ViewMenuOfInterestedSubject(studentData);
                            break;
                        case 2:
                            //수강신청
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

        public void setwhite(int i)
        {
            if (i == 0)
            {
                Console.SetCursorPosition(0, 9);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("                                      ○   관심과목 담기");
                Console.SetCursorPosition(0, 11);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("                                      ○   수강 신청");
                Console.SetCursorPosition(0, 13);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("                                      ○   수강 내역 조회");
            }
            else if (i== 1)
            {
                Console.SetCursorPosition(0, 7);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("                                      ○   강의 시간표 조회");
                Console.SetCursorPosition(0, 11);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("                                      ○   수강 신청");
                Console.SetCursorPosition(0, 13);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("                                      ○   수강 내역 조회");
            }
            else if (i == 2)
            {
                Console.SetCursorPosition(0, 7);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("                                      ○   강의 시간표 조회");
                Console.SetCursorPosition(0, 9);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("                                      ○   관심과목 담기");
                Console.SetCursorPosition(0, 13);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("                                      ○   수강 내역 조회");
            }
            else if (i == 3)
            {
                Console.SetCursorPosition(0, 7);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("                                      ○   강의 시간표 조회");
                Console.SetCursorPosition(0, 9);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("                                      ○   관심과목 담기");
                Console.SetCursorPosition(0, 11);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("                                      ○   수강 신청");
            }
            
        }
    }
}
