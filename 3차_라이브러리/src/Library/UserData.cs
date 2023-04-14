using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class UserData
    {
        public static List<UserConstructor> UserList = new List<UserConstructor>();
        
        public static void userData()
        {
            UserList.Add(new UserConstructor()
            {
                userid = "sehyun",
                password = "1234",
                Name = "김세현",
                Age = 21,
                PhoneNumber = 01040244794,
                Address = "서울시 광진구 화양동",
                
            });

            UserList.Add(new UserConstructor()
            {
                userid = "id",
                password = "0000",
                Name = "정재현",
                Age = 21,
                PhoneNumber = 01020032003,
                Address = "서울시 광진구 군자동"
            });
        }
    }
}