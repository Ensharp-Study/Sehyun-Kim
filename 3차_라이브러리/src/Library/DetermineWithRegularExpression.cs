using System;
using System.Collections.Generic;
using System.Diagnostics; //Debug
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; //정규식 쓸 때 넣는 코드 
using System.Threading.Tasks;
namespace Library
{
    internal class DetermineWithRegularExpression
    {
        public void JudgeBookID(string IDValue) //아이디 정규식 검사 
        {
            if (IDValue == null) { 
                //잘 입력함
            }
            //요기서 정규식 사용
            Regex reg = new Regex(@"^(\d)+$");

            if (reg.IsMatch(IDValue))
            {
                //이거면 잘 입력한거
            }

            else
            {
                int variablelength = IDValue.Length;
                for (int reckon = 0; reckon < variablelength; reckon++)
                {
                    Console.Write("\b");
                }
                Console.Write("잘못된 형식을 입력했습니다.");
                //잘못 입력
            }

            
        }
    }
}
