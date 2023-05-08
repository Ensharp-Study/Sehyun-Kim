using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLibrary.Constant;
using NewLibrary.Model;
using NewLibrary.Utility;

namespace NewLibrary.Controller.UserFunction
{
    internal class BookApplier
    {
        public void ApplyBook(string userId)
        {
            Console.CursorVisible = true;
            string inputBookWord="";
            string inputBookQuantity="0";
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            bool fine = true;
            while (fine)
            {
                inputBookWord = inputKeyUnlessEnter.SaveInputUnlessEnter(12, 6);
                fine=inputKeyUnlessEnter.CheckRegex(inputBookQuantity, RegexConstant.englishKoreanNumberRegex, 10, 6, 10, 9, "잘못된 입력입니다");
            }
            fine = true;
            while (fine)
            {
                inputBookQuantity = inputKeyUnlessEnter.SaveInputUnlessEnter(12, 7);
                fine = inputKeyUnlessEnter.CheckRegex(inputBookQuantity, RegexConstant.onlyNumberRegex, 10, 7, 10, 9, "잘못된 입력입니다");
            }
            int quantity = int.Parse(inputBookQuantity);
            APIConnection apiConnection = new APIConnection();
            apiConnection.ConnectApi(quantity, inputBookWord, userId);

        }
    }
}
