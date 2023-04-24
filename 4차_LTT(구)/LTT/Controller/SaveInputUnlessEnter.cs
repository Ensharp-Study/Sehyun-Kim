using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.Controller;
using LTT.View;
using LTT.Model;
using System.Text.RegularExpressions;
namespace LTT.Controller
{
    internal class SaveInputUnlessEnter
    {
        public void SaveIDIfNotEnter(string randomExpression, int entercase)

        { //ID는 숫자로 된 8자리 학번이다.
            DetermineWithRegularExpression determineWithRegularExpression = new DetermineWithRegularExpression();
            while (true)
            {
                
                ConsoleKeyInfo IDinput = Console.ReadKey();
                if (IDinput.Key == ConsoleKey.Enter) //입력한 값이 엔터면
                {
                    break;
                }
                else //입력한 값이 엔터가 아니면 
                {
                    Regex reg = new Regex(@"^-?[0-9]+$"); //입력값이 숫자인가
                    if (reg.IsMatch(IDinput.KeyChar.ToString())) //숫자이면
                    {
                        entercase++; //엔터 하나만 치는거면 entercase가 0이고 다른 문자 입력되면 entercase 1이상
                        randomExpression += IDinput.KeyChar;
                    }
                    else if (!reg.IsMatch(IDinput.KeyChar.ToString()))//숫자가 아니면
                    {
                        entercase = 0;
                        Console.Write("\b");
                        Console.SetCursorPosition(50, 25);
                        randomExpression = "";
                        SaveIDIfNotEnter(randomExpression, entercase);
                    }
                }
            }
            if (entercase >= 1)
            {
                int TypeCheck = 0;
                entercase = 0;
                determineWithRegularExpression.JudgeID(randomExpression, TypeCheck);
            }

        }

        public void SavePWIfNotEnter(string randomExpression, int entercase)

        { //pw는 영어+숫자+특수문자로 된 5~10자리 문자이다. 
            DetermineWithRegularExpression determineWithRegularExpression = new DetermineWithRegularExpression();
            while (true)
            {
                ConsoleKeyInfo PWinput = Console.ReadKey();
                if (PWinput.Key == ConsoleKey.Enter) //입력한 값이 엔터면
                {
                    break;
                }
                else //입력한 값이 엔터가 아니면 
                {
                    Regex reg = new Regex(@"^[a-zA-Z0-9]*$"); //입력값이 숫자나 영문자인가
                    if (reg.IsMatch(PWinput.KeyChar.ToString())) //조건 해당하면
                    {
                        entercase++; //엔터 하나만 치는거면 entercase가 0이고 다른 문자 입력되면 entercase 1이상
                        randomExpression += PWinput.KeyChar;
                    }
                    else if (!reg.IsMatch(PWinput.KeyChar.ToString()))//해당 안하면 
                    {
                        entercase = 0;
                        Console.Write("\b");
                        Console.SetCursorPosition(50, 27);
                        randomExpression = "";
                        SavePWIfNotEnter(randomExpression, entercase);
                    }
                }
            }
            if (entercase >= 1)
            {
                int TypeCheck = 0;
                entercase = 0;
                determineWithRegularExpression.JudgePW(randomExpression, TypeCheck);
            }

        }
    }
}
