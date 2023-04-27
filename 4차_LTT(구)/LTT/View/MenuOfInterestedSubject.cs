using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.Controller;
namespace LTT.View
{
    internal class MenuOfInterestedSubject
    {
        public void ViewMenuOfInterestedSubject()
        {
            Console.Clear();
            Console.WriteLine("            ┌-:*=.-.*:*-=*-.-:*-.-:*=.-.*:*-=*-.-:*=.-.*:*-=*-.-:*=.-**-.-:*=.-.-=*-.-:*:┐   ");
            Console.WriteLine("");
            Console.WriteLine("                                             < 관심과목>");
            Console.WriteLine("");
            Console.WriteLine("                                           1.  관심과목 담기                            ");
            Console.WriteLine("                                                   ");
            Console.WriteLine("                                                                           ");
            Console.WriteLine("                                           2.  관심과목 삭제                                      ");
            Console.WriteLine("                                                                ");
            Console.WriteLine("                                               ");
            Console.WriteLine("                                           3.  관심과목 조회                      ");
            Console.WriteLine("                                          ");
            Console.WriteLine("");
            Console.WriteLine("            ┗*-.-:*=.-.*:*-=*-.-:*-.-:*=.-.*:*-=*-.-:*=.-.*:*-=*-.-:*=.-**-.-:*=.-.-=*-.:┛    \n     ");
            int inputnumber = 0;
            inputnumber=int.Parse(Console.ReadLine());
            SearchTimeTable searchTimeTable = new SearchTimeTable();
            NewArrayFromExcelcs newArrayFromExcelcs = new NewArrayFromExcelcs();
            bool interest = false;
            switch (inputnumber)
            {
                case 1:
                    searchTimeTable.SearchingTimeTable();
                    break;
                case 2:
                    //추가한 리스트를 모두 호출
                    break;
                    
                case 3:
                    //추가한 리스트에서 학수번호 입력하라는 안내 메세지 출력하고 
                    // if 학수번호가 같으면 리스트에서 해당 삭제
                    break;
                case 4:
                    //리스트 모두 출력
                    break;

            }
        }

        
    }
}
