using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTT.Model
{
    internal class LectureData
    {
        private List<LectureConstructor> lectureList;
        public List<LectureConstructor> LectureList
        {
            get { return lectureList; }
            set { lectureList = value; }    
        }
        
        public LectureData()
        {
            lectureList = new List<LectureConstructor>();
        }

        public void AddInterest()
        {
            lectureList.Add(new LectureConstructor());
        }
    }
}
