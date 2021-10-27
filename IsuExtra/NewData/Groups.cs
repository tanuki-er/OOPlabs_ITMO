using System.Collections.Generic;
using Isu;

namespace IsuExtra.NewData
{
    public class Groups : Group
    {
        public Groups(string year, string groupNumber) : base(year, groupNumber)
        { 
        }

        private List<TimeTableStruct> List { get; set; } = new List<TimeTableStruct>();
        private List<Students> StudentsList { get; set; } = new List<Students>();

    }
}