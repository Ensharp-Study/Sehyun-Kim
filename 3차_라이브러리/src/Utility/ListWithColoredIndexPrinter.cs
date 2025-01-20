using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLibrary.Utility
{
    internal class ListWithColoredIndexPrinter
    {
        //문자열 리스트, 인덱스(정수형변수) 입력하면 색 바꿔서 출력해주는 메소드 
        public void PrintListWithColoredIndex(List<string> strList, int index, int xCoordinate, int yCoordinate)
        {
            for (int i = 0; i < strList.Count; i++)
            {
                if (i == index)
                {
                    Console.SetCursorPosition(xCoordinate, yCoordinate + i);
                    Console.ForegroundColor = ConsoleColor.Green; // 해당 인덱스 색깔 변경
                    Console.WriteLine(strList[i]); // 단어 출력 후 엔터
                    Console.ResetColor(); // 색깔 초기화
                }
                else
                {
                    Console.SetCursorPosition(xCoordinate, yCoordinate + i);
                    Console.Write(strList[i]);
                }
            }
        }
    }
}
