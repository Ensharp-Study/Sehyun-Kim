using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.View;
using NewLibrary.Constant;
using NewLibrary.Utility;
using NewLibrary.View;

namespace NewLibrary.Controller.UserFunction
{
    internal class UserDataUpdater
    {//y+12
        public int SetCursorWhenUpdate(string userId)
        {
             
            ModeSelectView modeSelectView = new ModeSelectView();
            TextPrinterWithCursor textPrinterWithCursor = new TextPrinterWithCursor();
            UserAccountView userAccountView = new UserAccountView();
            ManagerAccountView managerAccountView = new ManagerAccountView();
            ListWithColoredIndexPrinter listWithColoredIndexPrinter = new ListWithColoredIndexPrinter();
            bool exit = true;
            List<string> strList = new List<string>() { "PW", "Name", "Age", "PhoneNumber", "Address"};

            Console.CursorVisible = false; //커서 안 보이게

            bool fine = true;
            int keyNumber = 1;

            while (fine) //keyNumber은 초기값이 1인 상태로 fine이 true일 동안 계속 반복
            {

                switch (keyNumber)
                {
                    case 0:
                        return keyNumber; //esc가 눌렸으면 keyNumber 0
                    case 1:
                        listWithColoredIndexPrinter.PrintListWithColoredIndex(strList, 0,6, 17);
                        break;
                    case 2:
                        listWithColoredIndexPrinter.PrintListWithColoredIndex(strList, 1, 6, 17);
                        break;
                    case 3:
                        listWithColoredIndexPrinter.PrintListWithColoredIndex(strList, 2, 6, 17);
                        break;
                    case 4:
                        listWithColoredIndexPrinter.PrintListWithColoredIndex(strList, 3, 6, 17);
                        break;
                    case 5:
                        listWithColoredIndexPrinter.PrintListWithColoredIndex(strList, 4, 6, 17);
                        break;

                }
                //tuple의 반환값은 keyNumber, check -> check는 엔터 누르면 false가 됨
                var tuple = textPrinterWithCursor.SetColorByUpDownArrow(1, 5, keyNumber);
                if (tuple.Item2 == false) //만약 check가 false이면 반복문 정지하고 keyNumber문으로 이동
                {                       //check가 false 다 = 엔터가 눌렸다
                    fine = false;
                }
                else //엔터가 안 눌렸다 그래서 반환된 값을 다시 keyNumber에 넣어서 또 반복한다.
                {
                    keyNumber = tuple.Item1;
                }
            }
            //엔터 입력시 여기로 나옴 
            return keyNumber;
        }

        public string UpdateUserData(string userId,int number)
        {

            CRUDInDAO crudInDAO = new CRUDInDAO();
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            string inputPw = "";
            string inputName = "";
            int inputAge = 0;
            string inputPhone = "";
            string inputAddress = "";
            bool fine = true;
            Console.CursorVisible = true;
            switch (number)
            {
                case 0:
                    break;
                case 1: //pw
                    while (fine)
                    {
                        Console.SetCursorPosition(16, 22);
                        Console.Write("PW -> 영어 또는 숫자 6-12자리");
                        inputPw = inputKeyUnlessEnter.SaveInputUnlessEnter(10, 17);
                        if (inputPw == null) // esc 키가 눌리면 즉시 종료
                            return userId;
                        fine = inputKeyUnlessEnter.CheckRegex(inputPw, RegexConstant.userPwRegex, 10, 17, 0, 0, "");
                    }
                    crudInDAO.InsertUpdateDelete($"UPDATE userconstructor SET password = '{inputPw}' WHERE userid = '{userId}'");
                    break;
                case 2://name
                    while (fine)
                    {
                        Console.SetCursorPosition(20, 22);
                        Console.Write("Name -> 한글 2-4자리");
                        inputName = inputKeyUnlessEnter.SaveInputUnlessEnter(12, 18);
                        if (inputName == null) // esc 키가 눌리면 즉시 종료
                            return userId;
                        fine = inputKeyUnlessEnter.CheckRegex(inputName, RegexConstant.userNameRegex, 12, 16, 0, 0, " ");
                    }
                    crudInDAO.InsertUpdateDelete($"UPDATE userconstructor SET name = '{inputName}' WHERE userid = '{userId}'");
                    break;
                case 3://age
                    while (fine)
                    {
                        string bowl;
                        Console.SetCursorPosition(23, 22);
                        Console.Write("Age -> 1에서 200 사이 정수");
                        bowl = inputKeyUnlessEnter.SaveInputUnlessEnter(12, 19);
                        if (bowl == null) // esc 키가 눌리면 즉시 종료
                            return userId;
                        fine = inputKeyUnlessEnter.CheckRegex(bowl, RegexConstant.userAgeRegex, 12, 17, 0, 0, " ");
                        inputAge = int.Parse(bowl);
                    }
                    crudInDAO.InsertUpdateDelete($"UPDATE userconstructor SET age = '{inputAge}' WHERE userid = '{userId}'");
                    break;
                case 4://phoneNumber
                    while (fine)
                    {
                        Console.SetCursorPosition(16, 22);
                        Console.Write("PhoneNumber -> 01x-xxxx-xxxx");
                        inputPhone = inputKeyUnlessEnter.SaveInputUnlessEnter(22, 20);
                        if (inputPhone == null) // esc 키가 눌리면 즉시 종료
                            return userId;
                        fine = inputKeyUnlessEnter.CheckRegex(inputPhone, RegexConstant.userPhoneNumberRegex, 22, 18, 0, 0, " ");
                    }
                    crudInDAO.InsertUpdateDelete($"UPDATE userconstructor SET phoneNumber = '{inputPhone}' WHERE userid = '{userId}'");
                    break;
                case 5://Address
                    while (fine)
                    {
                        Console.SetCursorPosition(15, 22);
                        Console.Write("Address -> 도로명 주소 or 지번 주소 or 동/호수까지");
                        inputAddress = inputKeyUnlessEnter.SaveInputUnlessEnter(20, 21);
                        if (inputAddress == null) // esc 키가 눌리면 즉시 종료
                            return userId;
                        fine = inputKeyUnlessEnter.CheckRegex(inputAddress, RegexConstant.userAddressRegex, 22, 19, 0, 0, " ");
                    }
                    crudInDAO.InsertUpdateDelete($"UPDATE userconstructor SET address = '{inputAddress}' WHERE userid = '{userId}'");
                    break;
            }
            Console.SetCursorPosition(16, 28);
            Console.WriteLine("회원 정보가 수정되었습니다.");
            while (true)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Escape) //esc 입력됐을 경우
                {
                    Console.Clear();
                    return userId;
                }
                else
                {
                    continue;
                }
            }
            return userId;
        }
    }
}
