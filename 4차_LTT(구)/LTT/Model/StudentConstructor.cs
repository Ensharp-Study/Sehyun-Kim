using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.Model
{
    internal class StudentConstructor
    {
        private string userid;

        public string UserId
        {
            get { return userid; }
            set { userid = value; }
        }

        public string password { get; set; }

        public StudentConstructor()
        { 
        }
            public StudentConstructor(string userid, string password)
        {
            this.userid = userid;
            this.password = password;
        }
    }
}
