using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.Controller;
using LTT.View;
using LTT.Model;
using LTT.Controller;
namespace LTT.View
{
    internal class DisplayLogin
    {
        private StudentData studentData;

        public void InitialDisplay() //첫 화면 출력하는 메소드 
        {
            SaveInputUnlessEnter saveInputUnlessEnter = new SaveInputUnlessEnter();
            this.studentData = new StudentData();
            studentData.InsertStudentData();
            LoginProcess loginProcess = new LoginProcess(studentData); 
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


            loginProcess.SetCursorAndLogin(); //로그인 프로세스
            menuDisplay.DisplayMenu(studentData); //다음 메뉴 표시
        }

    }
}
