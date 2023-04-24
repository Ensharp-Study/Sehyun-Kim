using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;
using LTT.View;
using LTT.Model;


namespace LTT.Controller
{
    public class LTT
    {
        public static void Main(String[] args)
        {
            DisplayLogin displayLogin = new DisplayLogin();
            MenuDisplay menuDisplay = new MenuDisplay();
            SearchTimeTable searchTimeTable = new SearchTimeTable();
            //DataInExcel dataInExcel = new DataInExcel();
            //dataInExcel.OpenExcel();
            searchTimeTable.SearchingTimeTable();
            //menuDisplay.DisplayMenu();
            //displayLogin.InitialDisplay();

        }
    }
}
