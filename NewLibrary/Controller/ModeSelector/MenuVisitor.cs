using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLibrary.Controller.Function;
using NewLibrary.Controller.UserFunction;
using NewLibrary.View;
using NewLibrary.View.FunctionView;
using NewLibrary.View.MenuView;

namespace NewLibrary.Controller.ModeSelector
{
    internal class MenuVisitor
    {
        public void SearchBooks(string userId, FunctionView userFunctionView, DataDisplayer dataDisplayer, BookSearcher bookSearcher)
        {
            Console.Clear();
            userFunctionView.ViewBookSearcher();
            Console.SetCursorPosition(0, 14);
            dataDisplayer.DisplayAllBook();
            bookSearcher.SearchBook(userId);
        }

        public void RentOutBook(string userId, FunctionView userFunctionView, DataDisplayer dataDisplayer, BookService bookservice)
        {
            Console.Clear();
            userFunctionView.ViewBookLenderTop();
            dataDisplayer.DisplayAllBook();
            bookservice.RentOutBook(userId);
        }

        public void ReturnBook(string userId, FunctionView userFunctionView, BookService bookservice)
        {
            bool check = false;
            Console.Clear();
            userFunctionView.ViewBookReturnerTop();
            bookservice.RentalList(userId, check);
            bookservice.ReturnBook(userId);
        }

        public void ShowRentalList(string userId, BookService bookservice)
        {
            Console.Clear();
            bool check = true;
            bookservice.RentalList(userId, check);
        }

        public void ShowReturnList(string userId, BookService bookservice)
        {
            Console.Clear();
            bookservice.ReturnList(userId);
        }

        public void UpdateUserData(string userId, FunctionView userFunctionView, DataDisplayer dataDisplayer, UserDataService userDataService)
        {
            Console.Clear();
            userFunctionView.ViewUserDataUpdaterTop();
            bool check = false;
            bool fine = true;
            dataDisplayer.DisplayUserInformation(userId, check);
            userFunctionView.ViewUserDataUpdaterBottom();
            int number = userDataService.SetCursorWhenUpdate(userId);
            userDataService.UpdateUserData(userId, number);
        }

        public void DeleteUserData(string userId, FunctionView userFunctionView, UserDataService userDataService)
        {
            Console.Clear();
            userFunctionView.ViewUserDataDeleter();
            userDataService.DeleteUserData(userId);
        }

        public void ApplyBook(string userId, FunctionView userFunctionView, BookApplier bookApplier)
        {
            Console.Clear();
            userFunctionView.ViewApplyBook();
            bookApplier.ApplyBook(userId);
        }

        public int HandleLogin(ModeSelectView modeSelectView, AccountView userAccountView, Account userModeAccount, UserMenu userMenu)
        {
            UserModeSelector userModeSelector = new UserModeSelector();
            Console.Clear();
            Console.CursorVisible = true;
            modeSelectView.ViewLibraryLogo();
            userAccountView.ViewLogin();
            userModeSelector.userId = userModeAccount.Login(1);
            if (userModeSelector.userId == null)
            {
                Console.CursorVisible = false;
                return 1;
            }

            while (true)
            {
                Console.Clear();
                Console.SetWindowSize(62, 27);
                modeSelectView.ViewLibraryLogo();
                userMenu.ViewUserMenu();
                int selectedNumber = userModeSelector.SelectInUserMenu();
                userModeSelector.userId = userModeSelector.MethodInUserMenu(selectedNumber, userModeSelector.userId);
                if (userModeSelector.userId == null)
                {
                    break;
                }
            }

            return 1;
        }

        public int HandleSignUp(ModeSelectView modeSelectView, AccountView userAccountView, Account userModeAccount)
        {
            Console.Clear();
            Console.SetWindowSize(62, 27);
            modeSelectView.ViewLibraryLogo();
            userAccountView.ViewSignUp();
            bool checker = userModeAccount.UserSignUp();
            if (!checker)
            {
                Console.CursorVisible = false;
                return 1;
            }

            return 1;
        }
    }
}
