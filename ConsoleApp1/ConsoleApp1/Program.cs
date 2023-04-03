using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace Ensharp
{
    class Printing_Star
    {
        static void Main(string[] args) //메인함수
        {
            Menu menu = new Menu(); //menu 클래스의 객체 생성
            menu.Display_menu(); //객체를 이용하여 display_menu 함수 호출하기 
        }
    }

    
    class Menu //메뉴를 표시하는 클래스
    {
        public void Display_menu() //메뉴를 표시하는 메소드
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------Menu-----------------------------");
            Console.WriteLine();
            Console.WriteLine("               1) 가운데 정렬 별 찍기 ");
            Console.WriteLine("               2) 1번의 반대로 찍기 ");
            Console.WriteLine("               3) 모래 시계 ");
            Console.WriteLine("               4) 다이아 ");
            Console.WriteLine("               5) 종료 ");
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();

            Num_input numInput = new Num_input(); // 객체 생성 
            numInput.Number_input(); // Num_input 클래스의 Number_input()함수 호출

        }
    }

    class Num_input //메뉴에서 수를 입력받는 클래스 
    {
        private int menu_num; //사용자가 메뉴에서 고를 번호를 저장
        private int line_num; //입력받을 줄 수 

        public void Number_input() //수를 입력받는 메소드
        {
            Printing_Midstar printing_Midstar = new Printing_Midstar();
            Printing_Midstar_Reverse printing_Midstar_Reverse = new Printing_Midstar_Reverse();

            Console.Write("             메뉴에서 번호를 선택해 주세요 : ");

            menu_num = int.Parse(Console.ReadLine()); //메뉴에서 번호 입력받기

            Console.WriteLine();

            Console.Write("                  줄 수를 입력해 주세요 : ");

            line_num = int.Parse(Console.ReadLine()); // 메뉴에서 줄 수 입력받기 

            //int.Parse로 Console.ReadLine으로 입력받은 문자열을 정수형으로 반환한다

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();

            if (menu_num == 1)
            {
                printing_Midstar.Midstar_Printing(line_num);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine();
                Num_input numInput = new Num_input(); // 객체 생성 
                numInput.Number_input(); // Num_input 클래스의 Number_input()함수 호출
            }

            else if (menu_num == 2)
            {
                printing_Midstar_Reverse.Mindstar_Printing_Reverse(line_num);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine();
                Num_input numInput = new Num_input(); // 객체 생성 
                numInput.Number_input(); // Num_input 클래스의 Number_input()함수 호출
            }

            else if (menu_num == 3)
            {
                printing_Midstar_Reverse.Mindstar_Printing_Reverse(line_num);
                printing_Midstar.Midstar_Printing(line_num);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine();
                Num_input numInput = new Num_input(); // 객체 생성 
                numInput.Number_input(); // Num_input 클래스의 Number_input()함수 호출
            }

            else if (menu_num == 4)
            {
                printing_Midstar.Midstar_Printing(line_num);
                printing_Midstar_Reverse.Mindstar_Printing_Reverse(line_num);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine();
                Num_input numInput = new Num_input(); // 객체 생성 
                numInput.Number_input(); // Num_input 클래스의 Number_input()함수 호출
                
            }

            else if (menu_num == 5) {
                Console.WriteLine("                   프로그램을 종료합니다.");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------------");
                return;
            }

            else
            {
                Console.WriteLine("숫자를 잘못 입력하였습니다. 1-5 사이의 숫자를 선택해 주세요.");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine();
                Num_input numInput = new Num_input(); // 객체 생성 
                numInput.Number_input(); // Num_input 클래스의 Number_input()함수 호출

            }
        }

    }
    class Printing_Midstar
    {
        public void Midstar_Printing(int NumOfLine)
        {
            int cnt = 0;
            for (int i = 1; i <= NumOfLine; i++)
            {
                while (cnt != NumOfLine - i)
                {
                    Console.Write(" ");
                    cnt++;
                }
                cnt = 0;
                
                while (cnt != i*2-1)
                {
                    Console.Write("*");
                    cnt++;
                }
                cnt = 0;

                while (cnt != NumOfLine - i)
                {
                    Console.Write(" ");
                    cnt++;
                }
                cnt = 0;
                Console.WriteLine();

            }
        }
    }

    class Printing_Midstar_Reverse
    {
        public void Mindstar_Printing_Reverse(int NumOfLine)
        {
            int cnt = 0;
            for (int i = 1; i <= NumOfLine; i++)
            {
                while (cnt != i-1)
                {
                    Console.Write(" ");
                    cnt++;
                }
                cnt = 0;

                while (cnt !=NumOfLine*2-(i*2-1))
                {
                    Console.Write("*");
                    cnt++;
                }
                cnt = 0;

                while (cnt != i - 1)
                {
                    Console.Write(" ");
                    cnt++;
                }
                cnt = 0;
                Console.WriteLine();

            }
        }
    }

    
}