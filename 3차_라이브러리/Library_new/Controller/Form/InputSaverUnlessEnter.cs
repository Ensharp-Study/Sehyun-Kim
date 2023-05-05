using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Library.View;

namespace Library.Controller.Form
{
    internal class InputSaverUnlessEnter
    {
        
        //순서 : SaveInputUnlessEnter ->  CheckRegex -> SwitchValueOfRegex
        public string SaveInputUnlessEnter(string regexExpression, int xcooperation, int ycooperation) //호출할 때 정규식을 같이 써서 보내야 한다.
        {
            string randomExpression = ""; //keyinput으로 입력받은 값을 저장할 곳
            string resultExpression = "";
            int entercase = 0;
            

            while (true)
            {
                //입력한 값이 값+엔터면 정규식 검사하고 오로지 엔터면 그냥 넘어가는 코드
                ConsoleKeyInfo input = Console.ReadKey(); //pwinput은 key, 한글자씩 입력받는다
                if (input.Key == ConsoleKey.Enter) //입력한 값이 엔터면
                {
                    break; //멈추고 randomExpression 정규식 검사
                }
                if (input.Key == ConsoleKey.Backspace)
                {
                    Console.SetCursorPosition(xcooperation - 1, ycooperation);
                    Console.Write(" ");
                    Console.SetCursorPosition(xcooperation - 1, ycooperation);
                    randomExpression.Substring(0,randomExpression.Length - 2);
                }
                else if (input.Key!=ConsoleKey.Enter)//입력한 값이 엔터가 아니면 
                {
                    xcooperation++;
                    entercase = 1; //값이 아니라 엔터만 눌렸으면 정규식 검사 안 하도록 entercase 값 설정
                    randomExpression += input.Key; //randomExpression에 저장
                    
                }
            }
            if (entercase == 1) //엔터만 눌린게 아니면 정규식 검사하기 
            {
                //randomExpression을 기반으로 정규식 검사해야 함
                resultExpression=CheckRegex(randomExpression, regexExpression, xcooperation, ycooperation);
                //이 정규식은 case문으로 따로 빼놓기
            }
            return resultExpression;
                 
            }

        //비밀번호 입력할 때 CheckRegex 따로 파기. 비밀번호는 '*'표 처리되기 때문에 다른 입력 함수를 쓰므로 정규식도 다른 함수 이용
        public string CheckPwRegex(string expression, string regexExpression, int xcooperation, int ycooperation)
        {
            PasswordMasker getHiddenConsoleInput = new PasswordMasker();
            Regex regex = new Regex(regexExpression);

            if (!regex.IsMatch(expression)) //정규식 안만족하면
            {
                Console.SetCursorPosition(xcooperation , ycooperation);
                Console.Write("                                        ");
                Console.SetCursorPosition(xcooperation+40, ycooperation);
                Console.WriteLine("입력이 잘못되었습니다.");
                getHiddenConsoleInput.HideConsoleInput(xcooperation, ycooperation); //다시 입력받기
            }
            
            return expression; //정규식 만족하면 반환
        }
        public string CheckRegex(string expression, string regexExpression, int xcooperation, int ycooperation)
        {
            // inputRegex = 정규식 매개변수
            // expression = 임의의 문자열 매개변수
            Regex regex = new Regex(regexExpression);

            if (!regex.IsMatch(expression)) //정규식 안만족하면
            {
                Console.SetCursorPosition(xcooperation, ycooperation);
                Console.Write("                                        ");
                Console.SetCursorPosition(xcooperation + 40, ycooperation);
                Console.WriteLine("입력이 잘못되었습니다.");
                Console.SetCursorPosition(xcooperation, ycooperation);
                SaveInputUnlessEnter(regexExpression, xcooperation, ycooperation); //다시 입력받기
            }

            return expression; //정규식 만족하면 반환

        }

        

            }
        }
