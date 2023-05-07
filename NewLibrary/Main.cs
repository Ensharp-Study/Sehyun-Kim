using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using NewLibrary.Controller;
using NewLibrary.View;

namespace NewLibrary
{
    public class NewLibrary
    {
        public static void Main(String[] args)
        {
            
            ModeSelector modeSelector = new ModeSelector();
            modeSelector.SelectMode();
        }
    }
}