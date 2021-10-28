using System.Collections.Generic;
using Isu;

namespace IsuExtra.NewData
{
    public class Students : Student
    {
        public Students(string name)
            : base(name)
        {
        }

        private List<TimeTableStruct> List { get; set; } = new List<TimeTableStruct>();
    }
}