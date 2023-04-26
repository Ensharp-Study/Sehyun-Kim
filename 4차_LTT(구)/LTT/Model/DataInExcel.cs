using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace LTT.Constant
{
    internal class DataInExcel
    {
        public string[,] GetAllExcelData(string filePath, string sheetName)
        {
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                // Workbook 객체 생성 및 파일 오픈
                workbook = application.Workbooks.Open(filePath);

                // sheets에 읽어온 엑셀값을 넣기 (한 workbook 내의 모든 sheet 가져옴)
                Excel.Sheets sheets = workbook.Sheets;

                // 특정 sheet의 값 가져오기
                worksheet = sheets[sheetName] as Excel.Worksheet;

                // 범위 설정 (좌측 상단, 우측 하단)
                Excel.Range cellRange = worksheet.UsedRange;

                // 설정한 범위만큼 데이터 담기 (Value2 -셀의 기본 값 제공)
                object[,] data = cellRange.Value2;

                int rows = data.GetLength(0);
                int cols = data.GetLength(1);
                string[,] result = new string[rows, cols];

                // 데이터를 새로운 배열에 저장
                for (int row = 1; row <= rows; row++)
                {
                    for (int col = 1; col <= cols; col++)
                    {
                        result[row - 1, col - 1] = GetStringFromNullValue(data[row, col]);
                    }
                }

                return result;
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                // 모든 워크북 닫기
                workbook?.Close();

                // application 종료
                application.Quit();

                // COM 개체 해제
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(application);
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
    }

}