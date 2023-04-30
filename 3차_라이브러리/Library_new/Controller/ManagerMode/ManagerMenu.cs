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
using static Library.Controller.Account;

namespace Library.Constant
{
    internal class ManagerMenu
    {
        private BookData bookData;
        private UserData userData;

        public ManagerMenu(BookData bookData, UserData userData)
        {
            this.bookData = bookData;
            this.userData = userData;
        }
        public void ConstantOfManagerMenu(int num)
        {
            HomeDisplay display = new HomeDisplay();
            NumberInputManager managerMode = new NumberInputManager(bookData, userData);
            UserInfoUpdater modifyBookInfo = new UserInfoUpdater(bookData, userData);
            UserDataDeleter deleteBookinfo = new UserDataDeleter(bookData, userData);
            BookSearcher searchBookInfo = new BookSearcher(bookData, userData);
            BookDataAdder appendBookInfo = new BookDataAdder(bookData, userData);
            

            switch (num)
            {
                case 0:
                    Console.Clear();
                    display.InitialDisplay();
                    break;
                case 1:
                    Console.Clear();
                    searchBookInfo.searchBookManagerMode();
                    managerMode.modOfManager();
                    break;
                case 2:
                    Console.Clear();
                    appendBookInfo.appendbook();
                    managerMode.modOfManager();
                    break;
                case 3:
                    Console.Clear();
                    deleteBookinfo.deletebookinfo();
                    managerMode.modOfManager();
                    break;
                case 4:
                    Console.Clear();
                    modifyBookInfo.modifyBookInfo();
                    managerMode.modOfManager();
                    break;


            }
        }

        
    }
}
