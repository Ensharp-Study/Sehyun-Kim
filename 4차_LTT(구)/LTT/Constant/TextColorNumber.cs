using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.View;
using LTT.Controller;
using LTT.Model;

namespace LTT.Constant
{
    internal class TextColorNumber
    {
        public void CallNumberAndColorMenu(StudentData studentData)
        {
            int number = 0;
            Console.CursorVisible = false;
            bool check = true;
            bool checkMajor = true;
            string majorinput = "";
            string divideinput = "";
            string randomExpression = "";
            string ProfessorExpression = "";
            string GradeExpression = "";
            string numberExpression = "";
            TextColorWhite textColorWhite = new TextColorWhite();
            SearchTimeTable searchTimeTable = new SearchTimeTable();
            TextColorNumber textColorNumber = new TextColorNumber();

            while (check == true)
            {
                //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ넘버 ㅡㅡㅡㅡㅡㅡㅡㅡ
                switch (number)
                {
                    case 0:
                        searchTimeTable.SetTextColorGreen(15, 3, "● 개설학과전공");
                        textColorWhite.setTextColorWhite(number);
                        break;
                    case 1:
                        searchTimeTable.SetTextColorGreen(15, 7, "● 이수구분");
                        textColorWhite.setTextColorWhite(number);
                        break;
                    case 2:
                        searchTimeTable.SetTextColorGreen(15, 11, "● 교과목명");
                        textColorWhite.setTextColorWhite(number);
                        break;
                    case 3:
                        searchTimeTable.SetTextColorGreen(15, 14, "● 교수명");
                        textColorWhite.setTextColorWhite(number);
                        break;
                    case 4:
                        searchTimeTable.SetTextColorGreen(15, 17, "● 학년");
                        textColorWhite.setTextColorWhite(number);
                        break;
                    case 5:
                        searchTimeTable.SetTextColorGreen(15, 20, "● 학수번호");
                        textColorWhite.setTextColorWhite(number);
                        break;
                    case 6:
                        searchTimeTable.SetTextColorGreen(0, 23, "                                             *-_.검색하기._-* ");
                        textColorWhite.setTextColorWhite(number);
                        break;

                }

                ConsoleKeyInfo keyinput = Console.ReadKey();
                
                if (number >= 0 && number <= 5 && keyinput.Key == ConsoleKey.DownArrow)
                {
                    number++;
                }

                else if (number >= 1 && number <= 6 && keyinput.Key == ConsoleKey.UpArrow)
                {
                    number--;
                }

                else if (keyinput.Key == ConsoleKey.Enter)
                {
                    //ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ넘버 ㅡㅡㅡㅡㅡㅡㅡㅡ
                    switch (number)
                    {
                        case 0:
                            bool checkmajor = true;
                            int countCursor = 1;
                            while (checkMajor == true)
                            {
                                switch (countCursor)
                                {
                                    case 1:
                                        searchTimeTable.SetTextColorGreen(38, 3, "● 컴퓨터공학과");
                                        searchTimeTable.SetTextColorWhite(59, 3, "○ 소프트웨어학과");
                                        searchTimeTable.SetTextColorWhite(38, 4, "○ 지능기전공학부    ○ 기계항공우주공학부 ");
                                        break;
                                    case 2:
                                        searchTimeTable.SetTextColorWhite(38, 3, "○ 컴퓨터공학과");
                                        searchTimeTable.SetTextColorGreen(59, 3, "● 소프트웨어학과");
                                        searchTimeTable.SetTextColorWhite(38, 4, "○ 지능기전공학부    ○ 기계항공우주공학부 ");
                                        break;
                                    case 3:
                                        searchTimeTable.SetTextColorWhite(38, 3, "○ 컴퓨터공학과      ○ 소프트웨어학과 ");
                                        searchTimeTable.SetTextColorGreen(38, 4, "● 지능기전공학부");
                                        searchTimeTable.SetTextColorWhite(59, 4, "○ 기계항공우주공학부 ");
                                        break;
                                    case 4:
                                        searchTimeTable.SetTextColorWhite(38, 3, "○ 컴퓨터공학과      ○ 소프트웨어학과 ");
                                        searchTimeTable.SetTextColorWhite(38, 4, "○ 지능기전공학부");
                                        searchTimeTable.SetTextColorGreen(59, 4, "● 기계항공우주공학부 ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        break;

                                }
                                ConsoleKeyInfo inputkey = Console.ReadKey();


                                if (countCursor == 1)
                                {
                                    if (inputkey.Key == ConsoleKey.RightArrow)
                                        countCursor++;

                                    else if (inputkey.Key == ConsoleKey.DownArrow)
                                        countCursor += 2;
                                }
                                if (countCursor == 2)
                                {
                                    if (inputkey.Key == ConsoleKey.LeftArrow)
                                        countCursor--;
                                    else if (inputkey.Key == ConsoleKey.DownArrow)
                                        countCursor += 2;
                                }
                                if (countCursor == 3)
                                {
                                    if (inputkey.Key == ConsoleKey.RightArrow)
                                        countCursor++;
                                    else if (inputkey.Key == ConsoleKey.UpArrow)
                                        countCursor -= 2;
                                }
                                if (countCursor == 4)
                                {
                                    if (inputkey.Key == ConsoleKey.LeftArrow)
                                        countCursor--;
                                    else if (inputkey.Key == ConsoleKey.UpArrow)
                                        countCursor -= 2;
                                }

                                if (inputkey.Key == ConsoleKey.Enter)
                                {
                                    checkmajor = false;
                                    if (countCursor == 0)
                                    {
                                        majorinput = "NULL";
                                    }
                                    else if (countCursor == 1)
                                    {
                                        majorinput = "컴퓨터공학과";
                                    }
                                    else if (countCursor == 2)
                                    {
                                        majorinput = "소프트웨어학과";
                                    }
                                    else if (countCursor == 3)
                                    {
                                        majorinput = "지능기전공학부";
                                    }
                                    else if (countCursor == 4)
                                    {
                                        majorinput = "기계항공우주공학부";
                                    }
                                    break;

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
                            Console.SetCursorPosition(38, 11);
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
                            Console.SetCursorPosition(38, 14);
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
                            Console.SetCursorPosition(38, 17);
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
                            Console.SetCursorPosition(38, 20);
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
                            //DataInExcel dataInExcel = new DataInExcel();
                            ConsoleKeyInfo search = Console.ReadKey();
                            if (search.Key == ConsoleKey.Enter)
                            {
                                NewArrayFromExcelcs newArrayFromExcelcs = new NewArrayFromExcelcs(studentData);
                                Console.Clear();
                                if (check == true/*관심과목이면*/)
                                {

                                    newArrayFromExcelcs.FindDataInExcel(majorinput, divideinput, randomExpression, ProfessorExpression, GradeExpression, numberExpression);
                                }
                                else if (check == false)
                                {

                                }
                                Console.ReadKey();
                                //dataInExcel.OpenExcel(majorinput, divideinput, randomExpression, ProfessorExpression, GradeExpression, numberExpression);
                                randomExpression = "";
                                ProfessorExpression = "";
                                GradeExpression = "";
                                numberExpression = "";

                            }

                            break;
                    }
                }

            }
        }
        
        
        public string CountArrowKey(int countCursor, string majorinput)
        {
            bool check = true;

            while (check==true)
            {
                ConsoleKeyInfo inputkey = Console.ReadKey();

                if (countCursor == 1)
                {
                    if (inputkey.Key == ConsoleKey.RightArrow)
                        countCursor++;

                    else if (inputkey.Key == ConsoleKey.DownArrow)
                        countCursor += 2;
                }
                if (countCursor == 2)
                {
                    if (inputkey.Key == ConsoleKey.LeftArrow)
                        countCursor--;
                    else if (inputkey.Key == ConsoleKey.DownArrow)
                        countCursor += 2;
                }
                if (countCursor == 3)
                {
                    if (inputkey.Key == ConsoleKey.RightArrow)
                        countCursor++;
                    else if (inputkey.Key == ConsoleKey.UpArrow)
                        countCursor -= 2;
                }
                if (countCursor == 4)
                {
                    if (inputkey.Key == ConsoleKey.LeftArrow)
                        countCursor--;
                    else if (inputkey.Key == ConsoleKey.UpArrow)
                        countCursor -= 2;
                }

                if (inputkey.Key == ConsoleKey.Enter)
                {
                    if (countCursor == 0)
                    {
                        majorinput = "NULL";
                    }
                    else if (countCursor == 1)
                    {
                        majorinput = "컴퓨터공학과";
                    }
                    else if (countCursor == 2)
                    {
                        majorinput = "소프트웨어학과";
                    }
                    else if (countCursor == 3)
                    {
                        majorinput = "지능기전공학부";
                    }
                    else if (countCursor == 4)
                    {
                        majorinput = "기계항공우주공학부";
                    }
                    check = false;
                }
            }

            return majorinput;
        }


    }
}
