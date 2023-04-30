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
namespace Library.Controller
{
    internal class NumberInputManager
    {
        static int booklistnumber;
        private BookData bookData;
        private UserData userData;

        public NumberInputManager(BookData bookData, UserData userData)
        {
            this.bookData = bookData;
            this.userData = userData;
        }
        public void modOfManager()
        {
            
            ManagerMenu managerMenu = new ManagerMenu(bookData, userData);
            managerMenu.viewManagermenu();

            Regex regex = new Regex("^[0-4]$"); // 정규식 패턴
            int num;
            while (true)
            {
                num = int.Parse(Console.ReadLine());
                string str = Convert.ToString(num);
                if (!regex.IsMatch(str))
                {
                    Console.WriteLine("0-4 사이의 값을 입력해주세요.");
                }
                else if (regex.IsMatch(str))
                {
                    managerMenuConstant.ConstantOfManagerMenu(num);
                    break;
                }
            }

        }
      
    }
    }

