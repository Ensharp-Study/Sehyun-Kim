using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLibrary.Constant;
using NewLibrary.Utility;

namespace NewLibrary.Controller
{
    internal class UserModeAccount
    {
        public void UserLogin() //로그인
        {
            //loginFine은 로그인 성공 시 값이 true가 된다
            Console.Clear();
            InputKeyUnlessEnter inputKeyUnlessEnter = new InputKeyUnlessEnter();
            inputKeyUnlessEnter.SaveInputUnlessEnter(RegexConstant.koreanChar, 22, 14);
            
        }

        public void UserSignUp() //회원가입
        {

        }
    }
}
