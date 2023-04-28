using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LTT.Controller;
namespace LTT.Model
{
    internal class LectureData
    {
        private List<LectureConstructor> interestedLectureList;
        public List<LectureConstructor> LectureList
        {
            get { return interestedLectureList; }
            set { interestedLectureList = value; }    
        }
        
        public LectureData()
        {
            interestedLectureList = new List<LectureConstructor>();
        }

        
    }
}
