using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.Constant;
using LTT.Model;
using LTT.View;

namespace LTT.Controller
{
    internal class NewArrayFromExcelcs
    {
        private StudentData studentData;

        public NewArrayFromExcelcs(StudentData studentData)
        {
            this.studentData = studentData;
        }
        public string[,] MakeNewArrayFromExcel() //엑셀을 열어서 새로운 배열에 엑셀 데이터를 저장하는 메소드
        {
            DataInExcel dataInExcel = new DataInExcel();
            IntervalCol intervalCol = new IntervalCol();
            
            string[,] excelData = dataInExcel.GetAllExcelData(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\2023년도 1학기 강의시간표.xlsx", "Sheet1");
            int rowCount = 184;
            int cols = excelData.GetLength(1);

            // 각 열에서 가장 긴 문자열의 길이를 구함                                                               
            int[] colWidths = new int[cols];
            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row <= rowCount; row++)
                {
                    colWidths[col] = Math.Max(colWidths[col], excelData[row, col].Length);
                }
            }

            // 열을 맞춰서 출력
            for (int row = 0; row <= rowCount; row++)
            {
                int interval = 0; // 열 사이 간격
                for (int col = 0; col <cols; col++)
                {
                    //Console.WriteLine(excelData[row, col]);
                    Console.Write(excelData[row, col].PadRight(intervalCol.SetIntervalCol(col) - (Encoding.Default.GetByteCount(excelData[row, col].PadRight(intervalCol.SetIntervalCol(col))) - intervalCol.SetIntervalCol(col)) / 2));

                }
                Console.WriteLine();
            }

            return excelData;
        }


        public List<string[]> FindDataInExcel(string majorinput, string divideinput, string NameOfClass, string professor, string grade, string classnumber) //MakeNewArrayFromExcel을 통해서 만든 배열을 검사 
        {
            
            List<string[]> searchResult = new List<string[]>();
            List<string[]> interest = new List<string[]>();
            MenuOfInterestedSubject menuOfInterestedSubject = new MenuOfInterestedSubject();
            string[,] excelData = MakeNewArrayFromExcel();
            IntervalCol intervalCol = new IntervalCol();
            int rowCount = 184;//행
            int colCount = 12; //열
            bool majorbool = false;
            bool classificationbool = false;
            bool classbool = false;
            bool professorbool = false;
            bool gradebool = false;
            bool classnumberbool = false;
            Console.SetWindowSize(213, 50);
            for (int i = 1; i <= rowCount; i++)
            {
                majorbool = false;
                classificationbool = false;
                classbool = false;
                professorbool = false;
                gradebool = false;
                classnumberbool = false;

                if (excelData[i, 1] == majorinput || majorinput == "")//컴공, 소웨, 지기전, 기항
                {
                    majorbool = true;
                }
                if (excelData[i, 5] == divideinput || divideinput == "")//이수구분
                {
                    classificationbool = true;
                }
                if (excelData[i, 4].Contains(NameOfClass) || NameOfClass == "")
                {
                    classbool = true;
                }
                if (excelData[i, 10].Contains(professor) || professor == "")
                {
                    professorbool = true;
                }
                if (excelData[i, 6] == grade || grade == "")
                {
                    gradebool = true;
                }
                if (excelData[i, 2] == classnumber || classnumber == "")
                {
                    classnumberbool = true;
                }
                if (majorbool && classificationbool && classbool && professorbool && gradebool && classnumberbool)
                {
                    string[] row = new string[colCount];
                    for (int j = 1; j <= colCount; j++)
                    {
                        row[j - 1] = excelData[i, j - 1];
                    }
                    searchResult.Add(row);
                }
            }
            
            bool check = true;
            while (check == true)
            {
                
                Console.WriteLine("담을 강의 번호를 입력해 주세요. 0을 눌러 종료");
                string inputExpression = Console.ReadLine();

                foreach (string[] row in searchResult)
                {
                    if (inputExpression == "0") // 입력값이 "0"이면 while문 종료
                    {
                        check = false;
                        menuOfInterestedSubject.ViewMenuOfInterestedSubject(studentData);
                        break;
                    }

                    else if (row[0].Equals(inputExpression))
                    {
                        studentData.StudentList[0].interestedLecture.Add(row);

                    }

                }

                foreach(string[] row in studentData.StudentList[0].interestedLecture)
                {
                    foreach ( string col in row)
                    {
                        Console.Write(col + " ");
                    }
                    Console.WriteLine();
                }
            }
            




            return interest;
        }


       
    }

}