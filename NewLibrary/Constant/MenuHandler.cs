using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLibrary.Constant
{
    internal class MenuHandler
    {
        public enum ModeSelect
        {
            Exit = 0,
            UserMode=1,
            ManagerMode=2

        }
        public enum UserMenuSelect 
        {
            None = 0,
            BookSearch = 1,
            BookLender = 2,
            BookReturn = 3,
            RentalConfirmation = 4,
            ReturnHistory = 5,
            UserInfoUpdate = 6,
            UserWithdrawal = 7,
            BookApplication = 8
        }
    }
}
