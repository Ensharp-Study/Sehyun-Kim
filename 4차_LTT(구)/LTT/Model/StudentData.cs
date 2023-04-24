using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.Model
{
    internal class StudentData
    {
        public List<StudentConstructor> StudentList;

        public StudentData()
        {
            this.StudentList = new List<StudentConstructor>();
        }

        public void InsertStudentData()
        {
            StudentList.Add(new StudentConstructor()
            {
                UserId = "22011658",
                password = "pw12345"

            });
        }
    }
}
