using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace LTT.Model
{
    internal class DataInExcel
    {
        public void OpenExcel(string major, string classification, string NameOfClass, string professor, string grade, string classnumber)
        {
            Console.Clear();

            try
            {
                // Excel Application 객체 생성
                Excel.Application application = new Excel.Application();

                // Workbook 객체 생성 및 파일 오픈 (바탕화면에 있는 excelStudy.xlsx 가져옴)
                Excel.Workbook workbook = application.Workbooks.Open(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\2023년도 1학기 강의시간표.xlsx");

                // sheets에 읽어온 엑셀값을 넣기 (한 workbook 내의 모든 sheet 가져옴)
                Excel.Sheets sheets = workbook.Sheets;

                // 특정 sheet의 값 가져오기
                Excel.Worksheet worksheet = sheets["Sheet1"] as Excel.Worksheet;

                // 범위 설정 (좌측 상단, 우측 하단)
                Excel.Range cellRange = worksheet.get_Range("A1", "L185") as Excel.Range;

                // 설정한 범위만큼 데이터 담기 (Value2 -셀의 기본 값 제공)
                Array data = cellRange.Cells.Value2;

                // 데이터 출력
                int rowCount = 184; //행
                int colCount = worksheet.UsedRange.Columns.Count; //열
                bool majorbool = false;
                bool classificationbool = false;
                bool classbool = false;
                bool professorbool = false;
                bool gradebool = false;
                bool classnumberbool = false;
                Console.SetWindowSize(145, 30);
                //함수 string input 매개변수
                for (int i = 1; i <= rowCount; i++)
                {
                    // B칸의 값을 읽어서 비교
                    Excel.Range cell = worksheet.Cells[i, 2];
                    string value = GetStringFromNullValue(cell.Value2);
                    if (value == major || major == "NULL")//컴공, 소웨, 지기전, 기항
                    {
                        majorbool = true;
                    }
                    cell = worksheet.Cells[i, 6];
                    value = GetStringFromNullValue(cell.Value2);
                    if (value == classification || classification == "NULL")//이수구분
                    {
                        classificationbool = true;
                    }
                    cell = worksheet.Cells[i, 5]; //교과목명
                    value = GetStringFromNullValue(cell.Value2);
                    if (value == NameOfClass || NameOfClass == "NULL")
                    {
                        classbool = true;
                    }
                    cell = worksheet.Cells[i, 11]; //교수명
                    value = GetStringFromNullValue(cell.Value2);
                    if (value == professor || professor == "NULL")
                    {
                        professorbool = true;
                    }
                    cell = worksheet.Cells[i, 7];
                    value = GetStringFromNullValue(cell.Value2);
                    if (value == grade || grade == "NULL")
                    {
                        gradebool = true;
                    }
                    cell = worksheet.Cells[i, 3];
                    value = GetStringFromNullValue(cell.Value2);
                    if (value == classnumber || classnumber == "NULL")
                    {
                        classnumberbool = true;
                    }
                    if (majorbool && classificationbool && classbool && professorbool && gradebool && classnumberbool)
                    {
                        Excel.Range dataCell = worksheet.Cells[i, 1];
                        string dataValue = GetStringFromNullValue(dataCell.Value2);
                        Console.Write(dataValue.PadRight(sortList(dataValue, 10)));
                        
                        dataCell = worksheet.Cells[i, 2];
                        dataValue = GetStringFromNullValue(dataCell.Value2);
                        Console.Write(dataValue.PadRight(sortList(dataValue, 32)));

                        dataCell = worksheet.Cells[i, 3];
                        dataValue = GetStringFromNullValue(dataCell.Value2);
                        Console.Write(dataValue.PadRight(sortList(dataValue, 20)));

                        dataCell = worksheet.Cells[i,4];
                        dataValue = GetStringFromNullValue(dataCell.Value2);
                        Console.Write(dataValue.PadRight(sortList(dataValue, 12)));

                        dataCell = worksheet.Cells[i, 5];
                        dataValue = GetStringFromNullValue(dataCell.Value2);
                        Console.Write(dataValue.PadRight(sortList(dataValue, 40)));

                        dataCell = worksheet.Cells[i, 6];
                        dataValue = GetStringFromNullValue(dataCell.Value2);
                        Console.Write(dataValue.PadRight(sortList(dataValue, 30)));

                        dataCell = worksheet.Cells[i, 7];
                        dataValue = GetStringFromNullValue(dataCell.Value2);
                        Console.Write(dataValue.PadRight(sortList(dataValue, 10)));

                        dataCell = worksheet.Cells[i, 8];
                        dataValue = GetStringFromNullValue(dataCell.Value2);
                        Console.Write(dataValue.PadRight(sortList(dataValue, 10)));

                        dataCell = worksheet.Cells[i, 9];
                        dataValue = GetStringFromNullValue(dataCell.Value2);
                        Console.Write(dataValue.PadRight(sortList(dataValue, 50)));

                        dataCell = worksheet.Cells[i, 10];
                        dataValue = GetStringFromNullValue(dataCell.Value2);
                        Console.Write(dataValue.PadRight(sortList(dataValue, 30)));

                        dataCell = worksheet.Cells[i, 11];
                        dataValue = GetStringFromNullValue(dataCell.Value2);
                        Console.Write(dataValue.PadRight(sortList(dataValue, 40)));

                        dataCell = worksheet.Cells[i, 12];
                        dataValue = GetStringFromNullValue(dataCell.Value2);
                        Console.Write(dataValue.PadRight(sortList(dataValue, 30)));
                        /*for (int j = 1; j <= 12; j++)
                        {
                            Excel.Range dataCell = worksheet.Cells[i, j];
                            string dataValue = GetStringFromNullValue(dataCell.Value2);
                            //출력
                            sortList(dataValue, dataValue.Length);
                            Console.Write(dataValue + "\t");

                            //다 false로 초기화
                            majorbool = false;
                            classificationbool = false;
                            classbool = false;
                            professorbool = false;
                            gradebool = false;
                            classnumberbool = false;
                        }
                        */
                        majorbool = false;
                        classificationbool = false;
                        classbool = false;
                        professorbool = false;
                        gradebool = false;
                        classnumberbool = false;
                        Console.WriteLine();
                    }

                }

                Console.ReadKey(true);

                // 모든 워크북 닫기
                application.Workbooks.Close();

                // application 종료
                application.Quit();
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private string GetStringFromNullValue(object obj)
        {
            if (obj == null)
            {
                return "";
            }

            return obj.ToString();

        }

        public int sortList(string str, int length)
        {
            int byteLength = Encoding.Default.GetByteCount(str.PadRight(length));
             return length - (byteLength - length);
        }
    }
}

