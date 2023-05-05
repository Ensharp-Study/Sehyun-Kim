using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLibrary.View;

namespace NewLibrary
{
    public class NewLibrary
    {
        public static void Main(String[] args)
        {
            ModeSelectView modeSelectView = new ModeSelectView();
            modeSelectView.ViewModeSelect();
        }
    }
}