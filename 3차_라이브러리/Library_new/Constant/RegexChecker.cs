using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Library.Constant
{
    internal class RegexChecker
    {
        public int CheckRegexWhenValueIsNumber(int firstNumber, int lastNumber, string stringRegex) //숫자 정규식
        {
            int number;
            while (true)
            {
                number = int.Parse(Console.ReadLine()); //숫자 입력
                Regex regex = new Regex(stringRegex);
                string str = Convert.ToString(number); //정규식 판단을 위해 숫자를 문자로 바꾸기

                if (regex.IsMatch(str))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine(firstNumber+"부터"+ lastNumber+"사이의 값을 입력해 주세요.");
                }
            }

        }
    }
}
