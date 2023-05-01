using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.View;
using Library.Controller;
namespace Library.Model
{
    internal class UserData
    {
        public List<UserConstructor> UserList;
        
        public UserData()
        {
            this.UserList = new List<UserConstructor>();
        }

        public void SetUserData()
        {
            UserList.Add(new UserConstructor("sehyun", "1234", "김세현", 21, 01040244794, "서울시 광진구 화양동"));

            UserList.Add(new UserConstructor("id", "0000", "정재현", 21, 01020032003, "서울시 광진구 군자동"));
        }
    }
}