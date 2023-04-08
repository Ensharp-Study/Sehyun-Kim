﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;


namespace tictactoe
{

    //페이지 나눠서 클래스 분할,  컴퓨터랑 상대하기ㅇ, 점수 조회 메뉴o
    // 네이밍 신경쓰기, 입력값 예외처리o 

    //1. 무승부 추가, 누가 승리했는지 알려주는 멘트 추가
    //2, 컴퓨터랑 상대하기 코드수정
    //3. 점수조회 오류난 이유  -> 전역변수로 PUBLIC **STATIC** 써야함

    public class tictactoe
    {
        public static void Main(String[] args) //메인함수
        {
            Menu menu = new Menu();
            menu.Display();
        }
    }

    public class Menu
    {

        public static int win1, win2, comwin, userwin;
        public void Display() //메뉴 디스플레이
        {
            Console.Clear();
            Console.WriteLine("★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★");
            Console.WriteLine(" *                          　                                  *");
            Console.WriteLine("★                                                              ★");
            Console.WriteLine("*                     Welcome to Tic Tac Toe!                   *");
            Console.WriteLine("★                                                              ★");
            Console.WriteLine(" *                          　                                  *");
            Console.WriteLine("★                                                              ★");
            Console.WriteLine(" *                 ①~④ 사이의 숫자를 입력하세요.              *");
            Console.WriteLine("★                                                              ★");
            Console.WriteLine(" *                        ① vs Computer                        *");
            Console.WriteLine("★                        ② vs User                            ★");
            Console.WriteLine(" *                        ③ Scoreboard                         *");
            Console.WriteLine("★                        ④ Quit                               ★");
            Console.WriteLine(" *                                                              *");
            Console.WriteLine("★                                                              ★");
            Console.WriteLine("★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★＊★");

            Number number = new Number();
            number.Numberinput();
        }
    }

    public class Number //메뉴에서 번호 선택
    {
        public int num = 0;

        public void Numberinput()
        {//입력방법 수정 -> 예외처리를 위해서

            //num 변수명 교체 (number)
            //Console.ReadLine()메서드는 사용자가 엔터를 누를때까지 입력 받아들임
            // ctrl+c : 일반적으로 프로그램이 종료되게 함 따라서 예외처리할 것 

            int number = 0;

            Game game = new Game();
            bool isNumber = false;
            Menu menu = new Menu();
            while (!isNumber)
            {

                string input = Console.ReadLine();
                
                if (int.TryParse(input, out number))
                {
                    isNumber = true;
                }


                
                if (number >= 1 && number <= 4)
                {
                    switch (number)
                    {

                        case 1:
                            game.Display1();
                            break;

                        case 2:

                            game.Display2();
                            break;

                        case 3:
                            Console.Clear();
                            game.Score();
                            break;

                        case 4:
                            return;
                            break;

                    }
                }

                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력하세요.");
                    isNumber = false;
                }

            }

        }






    }
    public class Game
    {

        Menu menu = new Menu();

        //틱택토 화면 실제로 나오는 부분
        private string a1 = "   ", b1 = "   ", c1 = "   ", d1 = "   ", e1 = "   ", f1 = "   ", g1 = "   ", h1 = "   ", i1 = "   ";
        private string a2 = "   ", b2 = "   ", c2 = "   ", d2 = "   ", e2 = "   ", f2 = "   ", g2 = "   ", h2 = "   ", i2 = "   ";
        private int cnt = 1;

        Random random = new Random();

        /// /////////////////////////////////
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        //1~9 들어가는 리스트 
        List<int> selectedNumbers = new List<int>();
        //유저가 고른 + 컴퓨터가 고른 숫자 저장

        public void Display1() ///////////////////////////버전1
        {

            Console.Clear();
            cnt++;
            Judge1();
            Console.WriteLine("        <Scoreboard>\n");
            Console.WriteLine(" ★*user*★  ★*Computer*★   ");
            Console.WriteLine("     " + Menu.userwin + "             " + Menu.comwin);
            Console.WriteLine(" ★＊★＊★  ★＊★＊★＊★   \n\n");

            Console.WriteLine("  press ①~⑨");
            Console.WriteLine("press zero to quit\n");

            Console.WriteLine("----------------");
            Console.WriteLine("l ① I ② I ③ I");
            Console.WriteLine("----------------");
            Console.WriteLine("l ④ I ⑤ I ⑥ I");
            Console.WriteLine("----------------");
            Console.WriteLine("l ⑦ I ⑧ I ⑨ I");
            Console.WriteLine("----------------");

            Console.WriteLine("----------------");
            Console.WriteLine("l" + a1 + "I" + b1 + " I" + c1 + " I");
            Console.WriteLine("----------------");
            Console.WriteLine("l" + d1 + "I" + e1 + " I" + f1 + " I");
            Console.WriteLine("----------------");
            Console.WriteLine("l" + g1 + "I" + h1 + " I" + i1 + " I");
            Console.WriteLine("----------------");



            if (cnt % 2 == 0)
            {
                ver1user();
            }


            else if (cnt % 2 == 1)
            {
                ver1com();

            }


        }

        public void ver1user()
        {
            int essence;

            essence = int.Parse(ReadLine());
            if (selectedNumbers.Contains(essence))
            {
                Console.WriteLine("이미 선택한 영역입니다.");
                Console.WriteLine("다른 영역을 선택하세요.");
                ver1user();
            }
            selectedNumbers.Add(essence);
            numbers.Remove(essence);
            switch (essence)
            {
                case 0:
                    Menu menu = new Menu();
                    menu.Display();
                    break;

                case 1:
                    a1 = " O ";
                    break;

                case 2:
                    b1 = " O ";
                    break;
                case 3:
                    c1 = " O ";
                    break;
                case 4:
                    d1 = " O ";
                    break;
                case 5:
                    e1 = " O ";
                    break;
                case 6:
                    f1 = " O ";
                    break;
                case 7:
                    g1 = " O ";
                    break;
                case 8:
                    h1 = " O ";
                    break;
                case 9:
                    i1 = " O ";
                    break;

            }

            //유저의 입력값에 따라서 a~i 변수에 'O' 를 넣어주고, 바로 틱택토 화면에 적용되도록 display 메소드 호출

            Display1();
        }

        private ReadOnlySpan<char> ReadLine()
        {
            throw new NotImplementedException();
        }
        public void ver1com()
        {//컴퓨터

            //<알고리즘> 
            // 우선 e1(중앙) 비었을 경우 중앙에부터 돌 놓기 
            // 1. 유저의 가로 세로 대각선이 2개 차있을 때 -> 수비
            // 2. 컴퓨터의 가로 세로 대각선이 2개 차있을 때 -> 공격
            // 3. 다른 경우 : 랜덤 선택 

            if (e1 == "   ")
            {
                e1 = " X ";
                numbers.Remove(5);
                selectedNumbers.Add(5);
                Display1();

            }
            else
            {
                //수비ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                if (b1.Trim() == "O" && c1.Trim() == "O" && a1 == "   " ||
                        d1.Trim() == "O" && g1.Trim() == "O" && a1 == "   " ||
                        i1.Trim() == "O" && e1.Trim() == "O" && a1 == "   ")
                {
                    a1 = " X ";
                    numbers.Remove(1);
                    selectedNumbers.Add(1);
                    Display1();
                }
                if (h1.Trim() == "O" && e1.Trim() == "O" && b1 == "   " ||
                    a1.Trim() == "O" && c1.Trim() == "O" && b1 == "   ")
                {
                    b1 = " X ";
                    numbers.Remove(2);
                    selectedNumbers.Add(2);
                    Display1();
                }
                if (a1.Trim() == "O" && b1.Trim() == "O" && c1 == "   " ||
                    i1.Trim() == "O" && f1.Trim() == "O" && c1 == "   " ||
                    g1.Trim() == "O" && e1.Trim() == "O" && c1 == "   ")
                {
                    c1 = " X ";
                    numbers.Remove(3);
                    selectedNumbers.Add(3);
                    Display1();
                }
                if (e1.Trim() == "O" && f1.Trim() == "O" && d1 == "   " ||
                    a1.Trim() == "O" && g1.Trim() == "O" && d1 == "   ")
                {
                    d1 = " X ";
                    numbers.Remove(4);
                    selectedNumbers.Add(4);
                    Display1();
                }

                if (d1.Trim() == "O" && e1.Trim() == "O" && f1 == "   " ||
                    c1.Trim() == "O" && i1.Trim() == "O" && f1 == "   ")
                {
                    f1 = " X ";
                    numbers.Remove(6);
                    selectedNumbers.Add(6);
                    Display1();
                }

                if (h1.Trim() == "O" && i1.Trim() == "O" && g1 == "   " ||
                    a1.Trim() == "O" && d1.Trim() == "O" && g1 == "   " ||
                    c1.Trim() == "O" && e1.Trim() == "O" && g1 == "   ")
                {
                    g1 = " X ";
                    numbers.Remove(7);
                    selectedNumbers.Add(7);
                    Display1();
                }

                if (b1.Trim() == "O" && e1.Trim() == "O" && h1 == "   " ||
                    h1.Trim() == "O" && i1.Trim() == "O" && h1 == "   ")
                {
                    h1 = " X ";
                    numbers.Remove(8);
                    selectedNumbers.Add(8);
                    Display1();
                }
                if (g1.Trim() == "O" && h1.Trim() == "O" && i1 == "   " ||
                    c1.Trim() == "O" && f1.Trim() == "O" && i1 == "   " ||
                    a1.Trim() == "O" && e1.Trim() == "O" && i1 == "   ")
                {
                    i1 = " X ";
                    numbers.Remove(9);
                    selectedNumbers.Add(9);
                    Display1();
                }
                //공격ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                if (b1.Trim() == "X" && c1.Trim() == "X" && a1 == "   " ||
                        d1.Trim() == "X" && g1.Trim() == "X" && a1 == "   " ||
                        i1.Trim() == "X" && e1.Trim() == "X" && a1 == "   ")
                {
                    a1 = " X ";
                    numbers.Remove(1);
                    selectedNumbers.Add(1);
                    Display1();
                }
                if (h1.Trim() == "X" && e1.Trim() == "X" && b1 == "   " ||
                    a1.Trim() == "X" && c1.Trim() == "X" && b1 == "   ")
                {
                    b1 = " X ";
                    numbers.Remove(2);
                    selectedNumbers.Add(2);
                    Display1();
                }
                if (a1.Trim() == "X" && b1.Trim() == "X" && c1 == "   " ||
                    i1.Trim() == "X" && f1.Trim() == "X" && c1 == "   " ||
                    g1.Trim() == "X" && e1.Trim() == "X" && c1 == "   ")
                {
                    c1 = " X ";
                    numbers.Remove(3);
                    selectedNumbers.Add(3);
                    Display1();
                }
                if (e1.Trim() == "X" && f1.Trim() == "X" && d1 == "   " ||
                    a1.Trim() == "X" && g1.Trim() == "X" && d1 == "   ")
                {
                    d1 = " X ";
                    numbers.Remove(4);
                    selectedNumbers.Add(4);
                    Display1();
                }

                if (d1.Trim() == "X" && e1.Trim() == "X" && f1 == "   " ||
                    a1.Trim() == "X" && g1.Trim() == "X" && d1 == "   ")
                {
                    f1 = " X ";
                    numbers.Remove(6);
                    selectedNumbers.Add(6);
                    Display1();
                }

                if (h1.Trim() == "X" && i1.Trim() == "X" && g1 == "   " ||
                    a1.Trim() == "X" && d1.Trim() == "X" && g1 == "   " ||
                    c1.Trim() == "X" && e1.Trim() == "X" && g1 == "   ")
                {
                    g1 = " X ";
                    numbers.Remove(7);
                    selectedNumbers.Add(7);
                    Display1();
                }

                if (b1.Trim() == "X" && e1.Trim() == "X" && h1 == "   " ||
                    h1.Trim() == "X" && i1.Trim() == "X" && h1 == "   ")
                {
                    h1 = " X ";
                    numbers.Remove(8);
                    selectedNumbers.Add(8);
                    Display1();
                }
                if (g1.Trim() == "X" && h1.Trim() == "X" && i1 == "   " ||
                    c1.Trim() == "X" && f1.Trim() == "X" && i1 == "   " ||
                    a1.Trim() == "X" && e1.Trim() == "X" && i1 == "   ")
                {
                    i1 = " X ";
                    numbers.Remove(9);
                    selectedNumbers.Add(9);
                    Display1();
                }

                //랜덤 선택ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ
                else
                {
                    int randomNumber = random.Next(1, 10); // 1부터 9까지의 숫자 중 랜덤 선택

                    if (!selectedNumbers.Contains(randomNumber)) // 선택한 수가 이전에 선택된 적이 없으면
                    {
                        selectedNumbers.Add(randomNumber); // 선택한 수를 리스트에 추가
                        numbers.Remove(randomNumber); // 선택한 수를 리스트에서 제거

                    }
                    else // 선택한 수가 이전에 선택된 적이 있으면
                    {
                        randomNumber = random.Next(1, 10); // 다시 선택
                    }

                    switch (randomNumber)
                    {
                        case 1:
                            a1 = " X ";
                            break;

                        case 2:
                            b1 = " X ";
                            break;
                        case 3:
                            c1 = " X ";
                            break;
                        case 4:
                            d1 = " X ";
                            break;
                        case 5:
                            e1 = " X ";
                            break;
                        case 6:
                            f1 = " X ";
                            break;
                        case 7:
                            g1 = " X ";
                            break;
                        case 8:
                            h1 = " X ";
                            break;
                        case 9:
                            i1 = " X ";
                            break;
                    }

                    Display1();
                }
            }


        }



        public void Judge1() //틱택토 화면에서 빙고가 나왔는지 판단하는 메소드
                             // 빙고가 나왔다면 resetting 메소드로 a~i 변수의 값을 공백으로 초기화하고, 이긴 유저의 점수 하나 올리기
        {
            //가로빙고

            if (a1.Trim() == "O" && b1.Trim() == "O" && c1.Trim() == "O" || d1.Trim() == "O" && e1.Trim() == "O" && f1.Trim() == "O" || g1.Trim() == "O" && h1.Trim() == "O" && i1.Trim() == "O")
            {  //Trim -> 양쪽 공백을 제거                                                                                                          
                Menu.userwin++;
                Console.WriteLine("User win!\n");
                resetting1();
                List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                selectedNumbers.Clear();


            }
            if (a1.Trim() == "X" && b1.Trim() == "X" && c1.Trim() == "X" || d1.Trim() == "X" && e1.Trim() == "X" && f1.Trim() == "X" || g1.Trim() == "X" && h1.Trim() == "X" && i1.Trim() == "X")
            {
                Menu.comwin++;
                Console.WriteLine("Computer win!\n");
                resetting1();
                List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                selectedNumbers.Clear();

            }
            //세로빙고
            if (a1.Trim() == "O" && d1.Trim() == "O" && g1.Trim() == "O" || b1.Trim() == "O" && e1.Trim() == "O" && h1.Trim() == "O" || c1.Trim() == "O" && f1.Trim() == "O" && i1.Trim() == "O")
            {
                Menu.userwin++;
                Console.WriteLine("User win!\n");
                resetting1();
                List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                selectedNumbers.Clear();

            }

            if (a1.Trim() == "X" && d1.Trim() == "X" && g1.Trim() == "X" || b1.Trim() == "X" && e1.Trim() == "X" && h1.Trim() == "X" || c1.Trim() == "X" && f1.Trim() == "X" && i1.Trim() == "X")
            {
                Menu.comwin++;
                Console.WriteLine("Computer win!\n");
                resetting1();
                List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                selectedNumbers.Clear();

            }

            //대각선빙고

            if (a1.Trim() == "O" && e1.Trim() == "O" && i1.Trim() == "O" || c1.Trim() == "O" && e1.Trim() == "O" && g1.Trim() == "O")
            {
                Menu.userwin++;
                Console.WriteLine("User win!\n");
                resetting1();
                List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                selectedNumbers.Clear();

            }

            if (a1.Trim() == "X" && e1.Trim() == "X" && i1.Trim() == "X" || c1.Trim() == "X" && e1.Trim() == "X" && g1.Trim() == "X")
            {
                Menu.comwin++;
                Console.WriteLine("Computer win!\n");
                resetting1();
                List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                selectedNumbers.Clear();

            }

            //무승부
            if (a1 != "   " && b1 != "   " && c1 != "   " && d1 != "   " && e1 != "   " && f1 != "   " && g1 != "   " && h1 != "   " && i1 != "   ")
            {
                Console.WriteLine("Draw\n");
                resetting1();
                List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                selectedNumbers.Clear();
            }

        }


        /// //////////////////////////////////

        public void Display2()
        { ///////////////////////////////////버전2

            Console.Clear();

            cnt++;
            Judge2();
            Console.WriteLine("        <Scoreboard>\n");
            Console.WriteLine(" ★*user1*★  ★*user2*★   ");
            Console.WriteLine("     " + Menu.win1 + "           " + Menu.win2);
            Console.WriteLine(" ★＊★＊★  ★＊★＊★   \n\n");


            Console.WriteLine("  press ①~⑨");
            Console.WriteLine("press zero to quit\n");

            Console.WriteLine("----------------");
            Console.WriteLine("l ① I ② I ③ I");
            Console.WriteLine("----------------");
            Console.WriteLine("l ④ I ⑤ I ⑥ I");
            Console.WriteLine("----------------");
            Console.WriteLine("l ⑦ I ⑧ I ⑨ I");
            Console.WriteLine("----------------");

            Console.WriteLine("----------------");
            Console.WriteLine("l" + a2 + "I" + b2 + " I" + c2 + " I");
            Console.WriteLine("----------------");
            Console.WriteLine("l" + d2 + "I" + e2 + " I" + f2 + " I");
            Console.WriteLine("----------------");
            Console.WriteLine("l" + g2 + "I" + h2 + " I" + i2 + " I");
            Console.WriteLine("----------------");
            if (cnt % 2 == 0)
            {
                user1();
            }

            else if (cnt % 2 == 1)
            {
                user2();
            }


        }

        //유저 대 유저 게임에서 유저1의 입력값 저장
        public void user1()
        {
            int essence;
            essence = int.Parse(ReadLine());
            if (selectedNumbers.Contains(essence))
            {
                Console.WriteLine("이미 선택한 영역입니다.");
                Console.WriteLine("다른 영역을 선택하세요!");
                user1();
            }
            selectedNumbers.Add(essence);
            numbers.Remove(essence);

            switch (essence)
            {
                case 0:
                    Menu menu = new Menu();
                    menu.Display();
                    break;

                case 1:
                    a2 = " O ";
                    break;

                case 2:
                    b2 = " O ";
                    break;
                case 3:
                    c2 = " O ";
                    break;
                case 4:
                    d2 = " O ";
                    break;
                case 5:
                    e2 = " O ";
                    break;
                case 6:
                    f2 = " O ";
                    break;
                case 7:
                    g2 = " O ";
                    break;
                case 8:
                    h2 = " O ";
                    break;
                case 9:
                    i2 = " O ";
                    break;

            }

            //유저의 입력값에 따라서 a~i 변수에 'O' 를 넣어주고, 바로 틱택토 화면에 적용되도록 display 메소드 호출

            Display2();
        }

        //유저 대 유저 게임에서 유저2의 입력값 저장 
        public void user2()
        {
            int essence;
            essence = int.Parse(ReadLine());
            if (selectedNumbers.Contains(essence))
            {
                Console.WriteLine("이미 선택한 영역입니다.");
                Console.WriteLine("다른 영역을 선택하세요!");
                user2();
            }
            selectedNumbers.Add(essence);
            numbers.Remove(essence);

            switch (essence)
            {
                case 0:
                    Menu menu = new Menu();
                    menu.Display();
                    break;

                case 1:
                    a2 = " X ";
                    break;

                case 2:
                    b2 = " X ";
                    break;
                case 3:
                    c2 = " X ";
                    break;
                case 4:
                    d2 = " X ";
                    break;
                case 5:
                    e2 = " X ";
                    break;
                case 6:
                    f2 = " X ";
                    break;
                case 7:
                    g2 = " X ";
                    break;
                case 8:
                    h2 = " X ";
                    break;
                case 9:
                    i2 = " X ";
                    break;
            }

            //유저의 입력값에 따라서 a~i 변수에 'X' 를 넣어주고, 바로 틱택토 화면에 적용되도록 display 메소드 호출

            Display2();
        }

        public void Judge2() //틱택토 화면에서 빙고가 나왔는지 판단하는 메소드
                             // 빙고가 나왔다면 resetting 메소드로 a~i 변수의 값을 공백으로 초기화하고, 이긴 유저의 점수 하나 올리기
        {
            //가로빙고

            if (a2.Trim() == "O" && b2.Trim() == "O" && c2.Trim() == "O" || d2.Trim() == "O" && e2.Trim() == "O" && f2.Trim() == "O" || g2.Trim() == "O" && h2.Trim() == "O" && i2.Trim() == "O")
            {  //Trim -> 양쪽 공백을 제거                                                                                                          
                Menu.win1++;
                Console.WriteLine("User1 win!\n");
                resetting2();
                List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                selectedNumbers.Clear();
            }
            if (a2.Trim() == "X" && b2.Trim() == "X" && c2.Trim() == "X" || d2.Trim() == "X" && e2.Trim() == "X" && f2.Trim() == "X" || g2.Trim() == "X" && h2.Trim() == "X" && i2.Trim() == "X")
            {
                Menu.win2++;
                Console.WriteLine("User2 win!\n");
                resetting2();
                List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                selectedNumbers.Clear();
            }
            //세로빙고
            if (a2.Trim() == "O" && d2.Trim() == "O" && g2.Trim() == "O" || b2.Trim() == "O" && e2.Trim() == "O" && h2.Trim() == "O" || c2.Trim() == "O" && f2.Trim() == "O" && i2.Trim() == "O")
            {
                Menu.win1++;
                Console.WriteLine("User1 win!\n");
                resetting2();
                List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                selectedNumbers.Clear();
            }

            if (a2.Trim() == "X" && d2.Trim() == "X" && g2.Trim() == "X" || b2.Trim() == "X" && e2.Trim() == "X" && h2.Trim() == "X" || c2.Trim() == "X" && f2.Trim() == "X" && i2.Trim() == "X")
            {
                Menu.win2++;
                Console.WriteLine("User2 win!\n");
                resetting2();
                List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                selectedNumbers.Clear();
            }

            //대각선빙고

            if (a2.Trim() == "O" && e2.Trim() == "O" && i2.Trim() == "O" || c2.Trim() == "O" && e2.Trim() == "O" && g2.Trim() == "O")
            {
                Menu.win1++;
                Console.WriteLine("User1 win!\n");
                resetting2();
                List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                selectedNumbers.Clear();
            }

            if (a2.Trim() == "X" && e2.Trim() == "X" && i2.Trim() == "X" || c2.Trim() == "X" && e2.Trim() == "X" && g2.Trim() == "X")
            {
                Menu.win2++;
                Console.WriteLine("User2 win!\n");
                resetting2();
                List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                selectedNumbers.Clear();
            }

            //무승부
            if (a2 != "   " && b2 != "   " && c2 != "   " && d2 != "   " && e2 != "   " && f2 != "   " && g2 != "   " && h2 != "   " && i2 != "   ")
            {
                Console.WriteLine("Draw\n");
                resetting2();
                List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                selectedNumbers.Clear();
            }
        }



        public void Score() //점수판을 보여주는 메소드
        {

            Console.WriteLine("        <Scoreboard>\n\n\n");
            Console.WriteLine("① ★*user*★  ★*Computer*★   ");
            Console.WriteLine("       " + Menu.userwin + "             " + Menu.comwin);
            Console.WriteLine("   ★＊★＊★  ★＊★＊★＊★   \n\n");



            Console.WriteLine("② ★*user1*★  ★*user2*★   ");
            Console.WriteLine("       " + Menu.win1 + "            " + Menu.win2);
            Console.WriteLine("   ★＊★＊★   ★＊★＊★   \n\n\n");
            Console.WriteLine("    Press 0 to back menu");

            int essence;
            essence = int.Parse(ReadLine());

            if (essence == 0)
            {
                Console.Clear();
                Menu menu = new Menu();
                menu.Display();
            }
        }

        public void resetting1() //변수 a~i의 값을 초기화하는 메소드
        {
            a1 = "   ";
            b1 = "   ";
            c1 = "   ";
            d1 = "   ";
            e1 = "   ";
            f1 = "   ";
            g1 = "   ";
            h1 = "   ";
            i1 = "   ";
            cnt = 0;

        }


        public void resetting2() //변수 a~i의 값을 초기화하는 메소드
        {
            a2 = "   ";
            b2 = "   ";
            c2 = "   ";
            d2 = "   ";
            e2 = "   ";
            f2 = "   ";
            g2 = "   ";
            h2 = "   ";
            i2 = "   ";
            cnt = 0;

        }

    }



}
