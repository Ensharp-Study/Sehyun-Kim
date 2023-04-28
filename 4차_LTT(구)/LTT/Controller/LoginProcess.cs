using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.View;
using LTT.Model;
using LTT.Controller;

namespace LTT.Controller
{
    internal class LoginProcess
    {
        private StudentData studentData;

        public LoginProcess(StudentData studentData)
        {
            this.studentData = studentData;
        }
        public void ProcessOfLogin(string inputId, string inputPw) //로그인
        {
            MenuDisplay menu = new MenuDisplay();
            GetHiddenConsoleInput getHiddenConsoleInput = new GetHiddenConsoleInput();

            

            bool isLogin = false;
            
            int i = 0;
            int userlistnumber = 0;
            foreach (var user in this.studentData.StudentList)
            {
                i++;
                if (user.UserId == inputId && user.password == inputPw)
                {
                    Console.Clear();
                    Console.WriteLine("로그인 성공!");

                    isLogin = true;
                    userlistnumber = i - 1;
                    i = 0;

                    menu.DisplayMenu(studentData);
                    break;
                }
            }

            if (!isLogin)
            {
                Console.Clear();
                Console.WriteLine("로그인 실패. 아이디 또는 비밀번호가 일치하지 않습니다.");
                SetCursorAndLogin();

            }

            



        }

        public void SetCursorAndLogin()
        {
            SaveInputUnlessEnter saveInputUnlessEnter = new SaveInputUnlessEnter();
            Console.SetCursorPosition(50, 25);
            string randomExpression = "";
            int Entercase = 0;
            string inputId = "";
            inputId=saveInputUnlessEnter.SaveIDIfNotEnter(randomExpression, Entercase); //엔터를 칠 때까지 입력하기 (아이디 로그인)
            randomExpression = "";
            Entercase = 0;
            Console.SetCursorPosition(50, 27);
            GetHiddenConsoleInput getHiddenConsoleInput = new GetHiddenConsoleInput();
            string inputPw = getHiddenConsoleInput.HideConsoleInput(); //엔터를 칠 때까지 입력하기 (비밀번호 로그인)
            ProcessOfLogin(inputId, inputPw);

           
           
        }
    }
}
