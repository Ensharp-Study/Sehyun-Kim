using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.View;
using LTT.Model;

namespace LTT.Controller
{
    internal class MenuControllcs
    {
        public string numberExpression = "NULL";
        public string majorinput = "NULL";
        public string randomExpression = "NULL";
        public string ProfessorExpression = "NULL";
        public string GradeExpression = "NULL";
        public string divideinput = "NULL";
        public bool check = true;

        public void controllMenu()
        {
            Console.CursorVisible = false;
            int i = 0;
            SearchTimeTable searchTimeTable = new SearchTimeTable();
            
            while (check == true)
            {
                switch (i)
                {
                    case 0:
                        Console.SetCursorPosition(15, 3);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("● 개설학과전공");
                        searchTimeTable.setwhite(i);
                        Console.SetCursorPosition(15, 3);
                        break;
                    case 1:
                        Console.SetCursorPosition(15, 7);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("● 이수구분");
                        searchTimeTable.setwhite(i);
                        Console.SetCursorPosition(15, 7);
                        break;
                    case 2:
                        Console.SetCursorPosition(15, 11);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("● 교과목명");
                        searchTimeTable.setwhite(i);
                        Console.SetCursorPosition(15, 11);
                        break;
                    case 3:
                        Console.SetCursorPosition(15, 14);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("● 교수명");
                        searchTimeTable.setwhite(i);
                        Console.SetCursorPosition(15, 14);
                        break;
                    case 4:
                        Console.SetCursorPosition(15, 17);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("● 학년");
                        searchTimeTable.setwhite(i);
                        Console.SetCursorPosition(15, 17);
                        break;
                    case 5:
                        Console.SetCursorPosition(15, 20);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("● 학수번호");
                        searchTimeTable.setwhite(i);
                        Console.SetCursorPosition(15, 20);
                        break;
                    case 6:
                        Console.SetCursorPosition(0, 23);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("                                             *-_.검색하기._-* ");

                        searchTimeTable.setwhite(i);
                        Console.SetCursorPosition(0, 23);
                        break;
                }
                countCursor(i);
            }
        }

        public void countCursor(int i)
            {
                ConsoleKeyInfo keyinput = Console.ReadKey();
                if (i >= 0 && i <= 5 && keyinput.Key == ConsoleKey.DownArrow)
                {
                    i++;
                }

                else if (i >= 1 && i <= 6 && keyinput.Key == ConsoleKey.UpArrow)
                {
                    i--;
                }

                else if (keyinput.Key == ConsoleKey.Enter)
                {
                    switch (i)
                    {
                        case 0:
                            bool checkmajor = true;
                            int j = 1;
                            while (checkmajor == true)
                            {

                                if (j == 1)
                                {
                                    Console.SetCursorPosition(38, 3);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("● 컴퓨터공학과");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("      ○ 소프트웨어학과 ");
                                    Console.SetCursorPosition(38, 4);
                                    Console.WriteLine("○ 지능기전공학부    ○ 기계항공우주공학부 ");
                                }
                                else if (j == 2)
                                {
                                    Console.SetCursorPosition(38, 3);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("○ 컴퓨터공학과");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("      ● 소프트웨어학과 ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.SetCursorPosition(38, 4);
                                    Console.WriteLine("○ 지능기전공학부    ○ 기계항공우주공학부 ");

                                }
                                else if (j == 3)
                                {
                                    Console.SetCursorPosition(38, 3);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("○ 컴퓨터공학과      ○ 소프트웨어학과 ");
                                    Console.SetCursorPosition(38, 4);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("● 지능기전공학부");
                                    Console.SetCursorPosition(59, 4);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("○ 기계항공우주공학부 ");
                                }
                                else if (j == 4)
                                {
                                    Console.SetCursorPosition(38, 3);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("○ 컴퓨터공학과      ○ 소프트웨어학과 ");
                                    Console.SetCursorPosition(38, 4);
                                    Console.WriteLine("○ 지능기전공학부");
                                    Console.SetCursorPosition(59, 4);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("● 기계항공우주공학부 ");
                                    Console.ForegroundColor = ConsoleColor.White;

                                }
                                ConsoleKeyInfo inputkey = Console.ReadKey();

                                if (j == 1)
                                {
                                    if (inputkey.Key == ConsoleKey.RightArrow)
                                        j++;

                                    else if (inputkey.Key == ConsoleKey.DownArrow)
                                        j += 2;
                                }
                                if (j == 2)
                                {
                                    if (inputkey.Key == ConsoleKey.LeftArrow)
                                        j--;
                                    else if (inputkey.Key == ConsoleKey.DownArrow)
                                        j += 2;
                                }
                                if (j == 3)
                                {
                                    if (inputkey.Key == ConsoleKey.RightArrow)
                                        j++;
                                    else if (inputkey.Key == ConsoleKey.UpArrow)
                                        j -= 2;
                                }
                                if (j == 4)
                                {
                                    if (inputkey.Key == ConsoleKey.LeftArrow)
                                        j--;
                                    else if (inputkey.Key == ConsoleKey.UpArrow)
                                        j -= 2;
                                }

                                if (inputkey.Key == ConsoleKey.Enter)
                                {

                                    checkmajor = false;
                                    if (j == 0)
                                    {
                                        majorinput = "NULL";
                                    }
                                    else if (j == 1)
                                    {
                                        majorinput = "컴퓨터공학과";
                                    }
                                    else if (j == 2)
                                    {
                                        majorinput = "소프트웨어학과";
                                    }
                                    else if (j == 3)
                                    {
                                        majorinput = "지능기전공학부";
                                    }
                                    else if (j == 4)
                                    {
                                        majorinput = "기계항공우주공학부";
                                    }
                                }

                            }

                            break;
                        case 1:
                            bool checkdivide = true;
                            int z = 1;
                            while (checkdivide == true)
                            {

                                if (z == 1)
                                {
                                    Console.SetCursorPosition(38, 7);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("● 교양필수");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("           ○ 전공필수 ");
                                    Console.SetCursorPosition(38, 8);
                                    Console.WriteLine("○ 전공선택");
                                }
                                else if (z == 2)
                                {
                                    Console.SetCursorPosition(38, 7);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("○ 교양필수");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("           ● 전공필수 ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.SetCursorPosition(38, 8);
                                    Console.WriteLine("○ 전공선택 ");

                                }
                                else if (z == 3)
                                {
                                    Console.SetCursorPosition(38, 7);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("○ 교양필수           ○ 전공필수 ");
                                    Console.SetCursorPosition(38, 8);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("● 전공선택");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }

                                ConsoleKeyInfo inputkey = Console.ReadKey();

                                if (z == 1)
                                {
                                    if (inputkey.Key == ConsoleKey.RightArrow)
                                        z++;

                                    else if (inputkey.Key == ConsoleKey.DownArrow)
                                        z += 2;
                                }
                                if (z == 2)
                                {
                                    if (inputkey.Key == ConsoleKey.LeftArrow)
                                        z--;
                                    else if (inputkey.Key == ConsoleKey.DownArrow)
                                        z++;
                                }
                                if (z == 3)
                                {
                                    if (inputkey.Key == ConsoleKey.RightArrow)
                                        z--;
                                    else if (inputkey.Key == ConsoleKey.UpArrow)
                                        z -= 2;
                                }


                                if (inputkey.Key == ConsoleKey.Enter)
                                {




                                    if (z == 1)
                                    {
                                        divideinput = "공통교양필수";
                                    }
                                    else if (z == 2)
                                    {
                                        divideinput = "전공필수";
                                    }
                                    else if (z == 3)
                                    {
                                        divideinput = "전공선택";
                                    }
                                    checkdivide = false;
                                }

                            }
                            break;
                        case 2:
                            //교과목명

                            while (true)
                            {

                                ConsoleKeyInfo classinput = Console.ReadKey();
                                if (classinput.Key == ConsoleKey.Enter) //입력한 값이 엔터면
                                {
                                    break;
                                }
                                else //입력한 값이 엔터가 아니면 
                                {

                                    randomExpression += classinput.KeyChar;
                                }
                            }
                            //RANDOMEXPRESSION 넣기 
                            break;
                        case 3:
                            //교수명

                            while (true)
                            {

                                ConsoleKeyInfo Professorinput = Console.ReadKey();
                                if (Professorinput.Key == ConsoleKey.Enter) //입력한 값이 엔터면
                                {
                                    break;
                                }
                                else //입력한 값이 엔터가 아니면 
                                {

                                    ProfessorExpression += Professorinput.KeyChar;
                                }
                            }
                            break;
                        case 4:
                            //학년

                            while (true)
                            {

                                ConsoleKeyInfo Gradeinput = Console.ReadKey();
                                if (Gradeinput.Key == ConsoleKey.Enter) //입력한 값이 엔터면
                                {
                                    break;
                                }
                                else //입력한 값이 엔터가 아니면 
                                {

                                    GradeExpression += Gradeinput.KeyChar;
                                }
                            }
                            break;
                        case 5:

                            while (true)
                            {

                                ConsoleKeyInfo numberinput = Console.ReadKey();
                                if (numberinput.Key == ConsoleKey.Enter) //입력한 값이 엔터면
                                {
                                    break;
                                }
                                else //입력한 값이 엔터가 아니면 
                                {

                                    numberExpression += numberinput.KeyChar;
                                }
                            }
                            //학수번호
                            break;
                        case 6:
                            //검색하기
                            DataInExcel dataInExcel = new DataInExcel();
                            ConsoleKeyInfo search = Console.ReadKey();
                            if (search.Key == ConsoleKey.Enter)
                            {
                                dataInExcel.OpenExcel(majorinput, divideinput, randomExpression, ProfessorExpression, GradeExpression, numberExpression);
                                check = false;
                            }

                            break;
                    }
                }

            }
                
                

                
               
                
                

            }
        }
    
    

