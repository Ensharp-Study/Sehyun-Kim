using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLibrary.Constant
{
    internal class MenuHandler
    {
        public enum SelectModeByCursor
        {
            UserMode = 1,
            ManagerMode = 2
        }

        public enum SelectLoginOrSignUp
        {
            Login = 1,
            SignUp = 2
        }
        public enum ModeSelect
        {
            Exit = 0,
            UserMode = 1,
            ManagerMode = 2

        }
        public enum UserMenuSelect
        {
            None = 0,
            BookSearch = 1,
            BookLender = 2,
            BookReturn = 3,
            RentalConfirmation = 4,
            ReturnList = 5,
            UserInfoUpdate = 6,
            UserWithdrawal = 7,
            BookApplication = 8
        }

        public enum ManagerMenuSelect
        {
            None = 0,
            BookSearch = 1,
            BookAdder = 2,
            BookDeleter = 3,
            BookModifier = 4,
            MemberUpdater = 5,
            RentalStatus = 6,
            LogDownloader = 7,
            AppliedBookManager = 8


        }

    }
}
