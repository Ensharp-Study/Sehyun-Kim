using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.View
{
    internal class MenuOfRegisterLecture
    {
        public void ViewMenuOfRegisterLecture()
        {
            Console.Clear();
            Console.WriteLine("            ┌-:*=.-.*:*-=*-.-:*-.-:*=.-.*:*-=*-.-:*=.-.*:*-=*-.-:*=.-**-.-:*=.-.-=*-.-:*:┐   ");
            Console.WriteLine("");
            Console.WriteLine("                                             < 수강신청 >");
            Console.WriteLine("");
            Console.WriteLine("                                           1.  강의 검색                            ");
            Console.WriteLine("                                                   ");
            Console.WriteLine("                                           2.  수강신청 강의 추가                                 ");
            Console.WriteLine("                                                                              ");
            Console.WriteLine("                                           3. 수강신청 강의 삭제                     ");
            Console.WriteLine("                                               ");
            Console.WriteLine("                                           4. 수강신청 강의 조회                      ");
            Console.WriteLine("                                          ");
            Console.WriteLine("                                           5. 시간표  ");
            Console.WriteLine("            ┗*-.-:*=.-.*:*-=*-.-:*-.-:*=.-.*:*-=*-.-:*=.-.*:*-=*-.-:*=.-**-.-:*=.-.-=*-.:┛    \n     ");

            int inputnumber = 0;
            inputnumber = int.Parse(Console.ReadLine());

            switch (inputnumber)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;

            }
        }

        
    }
}
