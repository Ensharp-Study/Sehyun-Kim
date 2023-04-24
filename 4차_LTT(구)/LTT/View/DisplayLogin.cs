using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.Controller;
using LTT.View;
using LTT.Model;
namespace LTT.View
{
    internal class DisplayLogin
    {
        public void InitialDisplay()
        {
            SaveInputUnlessEnter saveInputUnlessEnter = new SaveInputUnlessEnter();
            MenuDisplay menuDisplay = new MenuDisplay();
            Console.SetWindowSize(103, 30);
            Console.WriteLine("");
            Console.WriteLine("               __        _____     _____  ._________. __    __   .______     ______ ");
            Console.WriteLine("              |  |      |    _|   /     | |        | |  |  |  |  |   _ ＼   |  ___|");
            Console.WriteLine("              |  |      |  |__   |  ,---' `--|  |--` |  |  |  |  |  |_) |   |__|__ ");
            Console.WriteLine("              |  |      |   __|  |  |        |  |    |  |  |  |  |      /   |   __|   ");
            Console.WriteLine("              |  `----. |  |___  |  `---.    |  |    |  `--'  |  |  |＼ ＼  |  |___    ");
            Console.WriteLine("           :  |_______| |_____|   ＼_____|   |__|    ＼______/   | _| `.__| |______| :");
            Console.WriteLine("          * .                                                                       - * .");
            Console.WriteLine("             - *              ._________.  __  .___  ___.  ______             -. : * ");
            Console.WriteLine("                              |         | |  | |  ＼/   | |   ___| ");
            Console.WriteLine("                              `--|  |--`  |  | | ＼  /  | |  |__   ");
            Console.WriteLine("                                 |  |     |  | |  |--|  | |   __| ");
            Console.WriteLine("                                 |  |     |  | |  |  |  | |  |___ ");
            Console.WriteLine("                                 |__|     |__| |__|  |__| |______| ");
            Console.WriteLine("");
            Console.WriteLine("                       ._________.    ___      .______     __       _____ ");
            Console.WriteLine("                       |         |   /   ＼    |   _  ＼  |  |     |   __|");
            Console.WriteLine("                       `--|  |--`   /  ^  ＼   |  |_)  |  |  |     |  |__  ");
            Console.WriteLine("                          |  |     /  /_＼ ＼  |   _  <   |  |     |   __|  ");
            Console.WriteLine("                    *     |  |    /  _____  ＼ |  |_)  |  |  `----.|  |___   *");
            Console.WriteLine("                      *   |__|   /__/     ＼_＼|______/   |_______||______| *  : .");
            Console.WriteLine("                   *                                                    _    .-"); 
            Console.WriteLine("                       _.   * .                                       .  * ");
            Console.WriteLine("                         ");
            Console.WriteLine("                                *-.-*-.-*-.-*-.-*-.-*-.-*-.-*-.-.*");
            Console.WriteLine("                                |    ID     |                    |");
            Console.WriteLine("                                ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            Console.WriteLine("                                | PASSWORD) |                    |");
            Console.WriteLine("                                *-.-*-.-*-.-*-.-*-.-*-.-*-.-*-.-.*");

            Console.SetCursorPosition(50, 25);
            string randomExpression = "";
            int Entercase = 0;
            int TypeCheck = 0;
            saveInputUnlessEnter.SaveIDIfNotEnter(randomExpression, Entercase);
            randomExpression = "";
            Entercase = 0;
            TypeCheck = 0;
            Console.SetCursorPosition(50, 27);
            GetHiddenConsoleInput getHiddenConsoleInput = new GetHiddenConsoleInput();
            string inputPw = getHiddenConsoleInput.HideConsoleInput();

            bool isLogin = false;
            saveInputUnlessEnter.SavePWIfNotEnter(randomExpression, Entercase);

            menuDisplay.DisplayMenu();
        }

    }
}
