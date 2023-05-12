using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLibrary.Constant;
using NewLibrary.Controller.Function;
using NewLibrary.Model.DAO;
using NewLibrary.Utility;

namespace NewLibrary.Controller
{
    internal class BookSearcher
    {
        public string SearchBook(string userId)
        {
            FunctionInDAO mysqlConnecter = new FunctionInDAO();
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            DataDisplayer bookDisplayer = new DataDisplayer();
            TextPrinterWithCursor textPrinterWithCursor = new TextPrinterWithCursor();
            ListWithColoredIndexPrinter listWithColoredIndexPrinter = new ListWithColoredIndexPrinter();
            List<string> strList = new List<string>() { "ⓛ 제목으로 찾기", "② 작가명으로 찾기", "③ 출판사명으로 찾기"};

            Console.CursorVisible = false; //커서 안 보이게
            Console.SetWindowSize(62, 27);

            bool fine = true;
            int keyNumber = 1;
            string returnTimeString = "";
            DateTime returnTime;

            while (fine) //keyNumber은 초기값이 1인 상태로 fine이 true일 동안 계속 반복
            {
                
                switch (keyNumber)
                {
                    case 0:
                        break; //esc가 눌렸으면 keyNumber 0
                    case 1:
                        listWithColoredIndexPrinter.PrintListWithColoredIndex(strList, 0, 23, 6);
                        break;
                    case 2:
                        listWithColoredIndexPrinter.PrintListWithColoredIndex(strList, 1, 23, 6);
                        break;
                    case 3:
                        listWithColoredIndexPrinter.PrintListWithColoredIndex(strList, 2, 23, 6);
                        break;
                   
                }
                //tuple의 반환값은 keyNumber, check -> check는 엔터 누르면 false가 됨
                var tuple = textPrinterWithCursor.SetColorByUpDownArrow(1, 3, keyNumber);
                if (tuple.Item2 == false) //만약 check가 false이면 반복문 정지하고 keyNumber문으로 이동
                {                       //check가 false 다 = 엔터가 눌렸다
                    fine = false;
                }
                else //엔터가 안 눌렸다 그래서 반환된 값을 다시 keyNumber에 넣어서 또 반복한다.
                {
                    keyNumber = tuple.Item1;
                }
            }
            //엔터 입력시 여기로 나옴 
            Console.CursorVisible = true;
            switch (keyNumber)
            {
                case 0:
                    userId = null;
                    return userId;
                case 1:
                    Console.SetCursorPosition(18, 11);
                    Console.Write("                                              ");
                    Console.SetCursorPosition(10, 12);
                    Console.Write("제목을 입력하세요 :                   ");
                    
                    string inputTitle = inputKeyUnlessEnter.SaveInputUnlessEnter(31, 12);
                    if (inputTitle == null) // esc 키가 눌리면 즉시 종료
                    {
                        break; 
                    }
                    Console.Clear();
                    bookDisplayer.DisplayBookInformation(string.Format(ConstantOfQuery.selectBookNameQuery, inputTitle));
                    break;
                case 2:
                    Console.SetCursorPosition(18, 11);
                    Console.Write("                                             ");
                    Console.SetCursorPosition(10, 12);
                    Console.Write("작가명을 입력하세요 :                  ");
                    string authorname = inputKeyUnlessEnter.SaveInputUnlessEnter(31, 12);
                    if (authorname == null) // esc 키가 눌리면 즉시 종료
                    {
                        break;
                    }
                    Console.Clear();
                    bookDisplayer.DisplayBookInformation(string.Format(ConstantOfQuery.selectauthorQuery, authorname));
                    break;
                case 3:
                    Console.SetCursorPosition(18, 11);
                    Console.Write("                                             ");
                    Console.SetCursorPosition(10, 12);
                    Console.Write("출판사명을 입력하세요 :                  ");
                    string publishername = inputKeyUnlessEnter.SaveInputUnlessEnter(31, 12);
                    if (publishername == null) // esc 키가 눌리면 즉시 종료
                    {
                        break; 
                    }
                    Console.Clear();
                    bookDisplayer.DisplayBookInformation(string.Format(ConstantOfQuery.selectpublisherQuery, publishername));
                    
                    
                    break;
            }
            returnTime = DateTime.Now;
            returnTimeString = returnTime.ToString("yyyy-MM-dd HH:mm:ss"); //현재시각측정
            mysqlConnecter.InsertUpdateDelete(string.Format(ConstantOfQuery.InsertInLogQuery, returnTimeString, "유저", "성공", "도서 검색"));
            Console.Write("ESC 키를 눌러 돌아가기");
            while (true)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Escape) //esc 입력됐을 경우
                {
                    Console.Clear();
                    return userId;
                }
                else
                {
                    continue;
                }
            }
            return userId;

        }
    }
}
