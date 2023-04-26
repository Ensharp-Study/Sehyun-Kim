using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.Constant;

namespace LTT.Model
{
    internal class NewArrayFromExcelcs
    {
        public string[,] MakeNewArrayFromExcel()
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
                for (int col = 0; col < cols; col++)
                {
                    
                    Console.Write(excelData[row, col].PadRight(intervalCol.SetIntervalCol(col) - (Encoding.Default.GetByteCount(excelData[row, col].PadRight(intervalCol.SetIntervalCol(col))) - intervalCol.SetIntervalCol(col)) / 2));

                }
                Console.WriteLine();
            }

            return excelData;
        }
    }

}