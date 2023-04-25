using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.Controller;

namespace LTT.Constant
{
    internal class FourSideArrow
    {
        public void SetVariablewithArrow(ConsoleKeyInfo keyinput)
        {
            MenuControllcs menuControllcs = new MenuControllcs();   
            switch (keyinput.Key)
            {//majorVariable
                case ConsoleKey.DownArrow:
                    if (menuControllcs.majorVariable == 1 || menuControllcs.majorVariable == 3)
                    break;
            }
            if (keyinput.Key == ConsoleKey.DownArrow)
                        else if (keyinput.Key == ConsoleKey.UpArrow)
                        else if (keyinput.Key == ConsoleKey.RightArrow)
                        else if (keyinput.Key == ConsoleKey.LeftArrow)
                        else if (keyinput.Key == ConsoleKey.Enter)
        }
    }
}
