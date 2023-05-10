using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLibrary.Constant;
using NewLibrary.Model;
using NewLibrary.Utility;

namespace NewLibrary.Controller.ManagerFunction
{
    internal class BookAdder
    {
        public void AddBook()
        {
            CRUDInDAO mysqlConnecter = new CRUDInDAO();
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();

            bool checkMysql = true;
            bool fine = true;
            string idInput = "0";
            string quantityValue = "0";
            string infoValue = "";
            int id = 0;

            while (true)
            {
                Console.WriteLine("추가할 도서의 isbn을 입력하세요.");
                while (fine)
                {
                    idInput = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 1);
                    fine = inputKeyUnlessEnter.CheckRegex(idInput, RegexConstant.onlyNumberRegex, 0, 1, 20, 1, "입력이 잘못되었습니다.");
                }
                id = int.Parse(idInput);
                bool check = mysqlConnecter.InsertUpdateDelete($"SELECT * FROM bookconstructor WHERE id='{id}'");
                if (check)
                {
                    Console.WriteLine("이미 존재하는 id입니다.");
                    continue;

                }
            }
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("추가할 도서 수량을 입력하세요.");
            while (fine)
            {
                quantityValue = inputKeyUnlessEnter.SaveInputUnlessEnter(0, 3);
                fine = inputKeyUnlessEnter.CheckRegex(quantityValue, RegexConstant.quantityRegex, 0, 3, 20, 3, "입력이 잘못되었습니다.");
            }
            int quantity = int.Parse(quantityValue);


           
        }
    }
}
