using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.Model
{
    internal class LectureConstructor
    {
        public string grade { get; set; }
        public string credit { get; set; }
        public string schedule { get; set; }
        public string lectureRoom { get; set; }
        public string nameOfProfessor { get; set; }
        public string lectureLanguage { get; set; }

        public LectureConstructor()
        {

        }

        public LectureConstructor(string grade, string credit, string schedule, string lectureRoom, string nameOfProfessor, string lectureLanguage)
        {
            this.grade = grade;
            this.credit = credit;
            this.schedule = schedule;
            this.lectureRoom = lectureRoom; 
            this.nameOfProfessor = nameOfProfessor;
            this.lectureLanguage = lectureLanguage;

        }

    }
}
