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

        public void InsertUserData()
        {
            UserList.Add(new UserConstructor()
            {
                UserId = "sehyun",
                password = "1234",
                Name = "김세현",
                Age = 21,
                PhoneNumber = 01040244794,
                Address = "서울시 광진구 화양동",
                
            });

            UserList.Add(new UserConstructor()
            {
                UserId = "id",
                password = "0000",
                Name = "정재현",
                Age = 21,
                PhoneNumber = 01020032003,
                Address = "서울시 광진구 군자동"
            });
        }
    }
}