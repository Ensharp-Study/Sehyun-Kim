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
    internal class MenuConstant
    {
        private BookData bookData;
        private UserData userData;

        public MenuConstant(BookData bookData, UserData userData)
        {
            this.bookData = bookData;
            this.userData = userData;
        }
        public void ConstantOfManagerMenu(int num)
        {
            HomeDisplay display = new HomeDisplay();
            ManagerMode managerMode = new ManagerMode(bookData, userData);
            ModifyInfo modifyBookInfo = new ModifyInfo(bookData, userData);
            DeleteInfo deleteBookinfo = new DeleteInfo(bookData, userData);
            SearchBookInfo searchBookInfo = new SearchBookInfo(bookData, userData);
            AppendBookInfo appendBookInfo = new AppendBookInfo(bookData, userData);
            

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

        public void ConstantOfUserMenu(int num)
        {
            HomeDisplay display = new HomeDisplay();
            ShowAllBook showAllBook = new ShowAllBook(bookData, userData);
            SearchBookInfo searchBookInfo = new SearchBookInfo(bookData, userData);
            ViewMenu viewMenu = new ViewMenu();
            BorrowBook borrowBook = new BorrowBook(bookData, userData);
            CheckInBook checkInBook = new CheckInBook(bookData, userData);
            ModifyInfo modifyInfo = new ModifyInfo(bookData, userData);
            DeleteInfo deleteInfo = new DeleteInfo(bookData, userData);
            MenuConstant menuConstant = new MenuConstant(bookData, userData);
            switch (num)
            {

                case 0:
                    Console.Clear();
                    display.InitialDisplay();
                    break;

                case 1:
                    Console.Clear();
                    showAllBook.allBook();
                    searchBookInfo.searchBookUserMode();
                    viewMenu.ViewUserMenu();
                    num = int.Parse(Console.ReadLine());
                    menuConstant.ConstantOfUserMenu(num);
                    break;

                case 2:
                    Console.Clear();
                    showAllBook.allBook();
                    borrowBook.RentOutBook();
                    viewMenu.ViewUserMenu();
                    num = int.Parse(Console.ReadLine());
                    menuConstant.ConstantOfUserMenu(num);
                    break;

                case 3:
                    Console.Clear();
                    checkInBook.returnBook();
                    viewMenu.ViewUserMenu();
                    num = int.Parse(Console.ReadLine());
                    menuConstant.ConstantOfUserMenu(num);
                    break;

                case 4:
                    Console.Clear();
                    borrowBook.borrowhistory();
                    viewMenu.ViewUserMenu();
                    num = int.Parse(Console.ReadLine());
                    menuConstant.ConstantOfUserMenu(num);
                    break;
                case 5:
                    Console.Clear();
                    checkInBook.returnhistory();
                    viewMenu.ViewUserMenu();
                    num = int.Parse(Console.ReadLine());
                    menuConstant.ConstantOfUserMenu(num);
                    break;
                case 6:
                    Console.Clear();
                    modifyInfo.modifyuserinfo();
                    viewMenu.ViewUserMenu();
                    num = int.Parse(Console.ReadLine());
                    menuConstant.ConstantOfUserMenu(num);
                    break;
                case 7:
                    Console.Clear();
                    deleteInfo.deleteuserinfo();
                    num = int.Parse(Console.ReadLine());
                    menuConstant.ConstantOfUserMenu(num);

                    break;
            }
        }
    }
}
