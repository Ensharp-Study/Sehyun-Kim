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
        public List<string[]> interestedLecture { get; set; }
        public List<string[]> registeredLecture { get; set; }

        public StudentConstructor()
        { 
            interestedLecture = new List<string[]>();
            registeredLecture = new List<string[]>(); 
            
        }
        public StudentConstructor(string userid, string password)
        {
            this.userid = userid;
            this.password = password;
            interestedLecture = new List<string[]>();
            registeredLecture = new List<string[]>();
        }
    }
}
