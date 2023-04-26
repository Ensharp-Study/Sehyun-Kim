using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.Constant
{
    internal class IntervalCol
    {
        public int SetIntervalCol(int col)
        {
            int interval = 0;
            switch (col)
            {
                case 0:
                    interval = 5;
                    break;
                case 1:
                    interval = 25;
                    break;
                case 2:
                    interval = 10;
                    break;
                case 3:
                    interval = 6;
                    break;
                case 4:
                    interval = 40;
                    break;
                case 5:
                    interval = 14;
                    break;
                case 6:
                    interval = 5;
                    break;
                case 7:
                    interval = 5;
                    break;
                case 8:
                    interval = 35;
                    break;
                case 9:
                    interval = 20;
                    break;
                case 10:
                    interval = 26;
                    break;
                case 11:
                    interval = 10;
                    break;
            }
            return interval;
        }
    }
}
