using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Threading.Tasks;
using Library;
using System.Text.RegularExpressions;
using Library.Model;
using Library.View;
using Library.Controller;
using Library.Constant;
using static Library.Controller.LoginOrNewmember;

namespace Library.Constant
{
    internal class ManagerMenuConstant
    {
        private BookData bookData;
        private UserData userData;

        public ManagerMenuConstant(BookData bookData, UserData userData)
        {
            this.bookData = bookData;
            this.userData = userData;
        }
        public void ConstantOfManagerMenu(int num)
        {
            HomeDisplay display = new HomeDisplay();
            ManagerMode managerMode = new ManagerMode(bookData, userData);
            ModifyBookInfo modifyBookInfo = new ModifyBookInfo(bookData, userData);
            DeleteBookInfo deleteBookinfo = new DeleteBookInfo(bookData, userData);
            SearchBookInfo searchBookInfo = new SearchBookInfo(bookData, userData);
            AppendBookInfo appendBookInfo = new AppendBookInfo(bookData, userData);

            switch (num)
            {
                case 0:
                    Console.Clear();
                    display.InitialDisplay();
                    break;
                case 1:

                    searchBookInfo.searchBook();
                    managerMode.modOfManager();
                    break;
                case 2:
                    appendBookInfo.appendbook();
                    managerMode.modOfManager();
                    break;
                case 3:
                    deleteBookinfo.deletebookinfo();
                    managerMode.modOfManager();
                    break;
                case 4:
                    modifyBookInfo.modifyBookInfo();
                    managerMode.modOfManager();
                    break;


            }
        }
    }
}
