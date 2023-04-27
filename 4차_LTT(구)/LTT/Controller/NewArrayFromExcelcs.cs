using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.Constant;

namespace LTT.Controller
{
    internal class NewArrayFromExcelcs
    {
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
                    
                    Console.Write(excelData[row, col].PadRight(intervalCol.SetIntervalCol(col) - (Encoding.Default.GetByteCount(excelData[row, col].PadRight(intervalCol.SetIntervalCol(col))) - intervalCol.SetIntervalCol(col)) / 2));

                }
                Console.WriteLine();
            }

            return excelData;
        }
        

        public List<string[]> FindDataInExcel(string majorinput, string divideinput, string NameOfClass, string professor, string grade, string classnumber) //MakeNewArrayFromExcel을 통해서 만든 배열을 검사 
        {
            Console.Clear();
            List<string[]> interest = new List<string[]>();
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
            Console.Clear();
            for (int i = 0; i <= rowCount; i++)
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
                        row[j - 1] = excelData[i, j]; 
                    }
                    interest.Add(row);
                }
            }

            foreach (string[] row in interest) //이렇게 interest 리스트에 해당하는 데이터를 옮겨 놓았음.그렇다면 -> 그 리스트를 기반으로 데이터를 관리하면 된다.
            {
                for (int j = 0; j < colCount; j++)
                {
                    Console.Write(row[j].PadRight(intervalCol.SetIntervalCol(j + 1) - (Encoding.Default.GetByteCount(row[j].PadRight(intervalCol.SetIntervalCol(j + 1))) - intervalCol.SetIntervalCol(j + 1)) / 2));
                }
                Console.WriteLine();
                //여기까지 interest 리스트에 있다 그러면 interest 리스트를 돌려서 여기서 번호가 일치하는거를 골라서 lecturedata에 넣는다.
               

            }
            bool inputValid = false; 
            while (!inputValid) // 입력이 유효하지 않은 경우 반복
            {
                Console.Write(" 담을 강의의 번호를 입력하세요: ");
                string creditinput = Console.ReadLine();

                // 입력이 유효한 경우 검색 결과를 출력하고 반복을 종료
                if (interest.Any(row => row[3] == creditinput))
                {
                    Console.WriteLine("검색 결과:");
                    GetLectureDataByNumber(interest, creditinput);
                    inputValid = true;


                }
                // 입력이 유효하지 않은 경우 에러 메시지 출력 후 반복
                else
                {
                    Console.WriteLine("입력한 학수번호에 해당하는 강의가 없습니다. 다시 입력해주세요.");
                }
            }

            return interest;
        }


        public List<string[]> GetLectureDataByNumber(List<string[]> interest, string number)
        {
            List<string[]> lecturedData = new List<string[]>();

            foreach (string[] row in interest)
            {
                if (row[0] == number.ToString())
                {
                    lecturedData.Add(row);
                }
            }

            // do something with the `lecturedData` list, e.g. print the rows
            foreach (string[] row in lecturedData)
            {
                Console.WriteLine(string.Join(", ", row));
            }

            return lecturedData;
            
        }

        
    }
    
}