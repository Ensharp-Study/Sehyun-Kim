using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace LTT.Controller
{
    internal class DetermineWithRegularExpression
    {
        public void JudgeID(string EssenceValue, int TypeCheck) //아이디 정규식 검사 
        {
            SaveInputUnlessEnter saveInputUnlessEnter = new SaveInputUnlessEnter();


            Regex reg = new Regex(@"^[0-9]{8}$");//숫자로만 이루어져 있는가?

            if (!reg.IsMatch(EssenceValue))
            {
                int variablelength = EssenceValue.Length;
                for (int reckon = 0; reckon < variablelength; reckon++)
                {
                    Console.Write("\b");
                }

                string randomExpression = "";
                int Entercase = 0;
                Console.SetCursorPosition(50, 25);
                saveInputUnlessEnter.SaveIDIfNotEnter(randomExpression, Entercase);

            }
            else
            {
                //bookData.BookList[booklistnumber].id = Int32.Parse(EssenceValue);

            }
        }

        public void JudgePW(string EssenceValue, int TypeCheck) //비밀번호 정규식 검사 
        {//비밀번호 영문 숫자 조합으로 8-20자리 : /^(?=.*[a-zA-Z])(?=.*[0-9]).{8,25}$/
            SaveInputUnlessEnter saveInputUnlessEnter = new SaveInputUnlessEnter();

            Regex reg = new Regex(@"^(?=.*[a-zA-Z])(?=.*[0-9]).{8,25}$");//영문,숫자로만 이루어져 있는가?

            if (!reg.IsMatch(EssenceValue))
            {
                int variablelength = EssenceValue.Length;
                for (int reckon = 0; reckon < variablelength; reckon++)
                {
                    Console.Write("\b");
                }
                string randomExpression = "";
                int Entercase = 0;
                Console.SetCursorPosition(50, 27);
                saveInputUnlessEnter.SavePWIfNotEnter(randomExpression, Entercase);

            }
            else
            {
                //bookData.BookList[booklistnumber].id = Int32.Parse(EssenceValue);

            }
        }
    }
}
