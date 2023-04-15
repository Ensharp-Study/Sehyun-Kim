﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class CheckInputIsEnter
    {
        public KeyValuePair<string, int> SaveIDIfNotEnter(string randomExpression, int isOrNot)
        //반환값 2개 이상이면 type 이름을 dynamic으로 쓸 수 있다.
        {
            ConsoleKeyInfo IDinput = Console.ReadKey();
            if (IDinput.Key == ConsoleKey.Enter) //입력한 값이 엔터면
            {
                return new KeyValuePair<string, int>(randomExpression, 1);
            }
            else //입력한 값이 엔터가 아니면 
            {
                randomExpression += IDinput.KeyChar;
               
                return new KeyValuePair<string, int>(randomExpression, 0);
            }

        }
    }
}

