using System.Collections.Generic;
using Isu;

namespace IsuExtra.NewData
{
    public class Groups : Group
    {
        public Groups(string year, string groupNumber)
            : base(year, groupNumber)
        {
        }

        private List<TimeTableStruct> List { get; set; } = new List<TimeTableStruct>();

        public void AddLessons(TimeTableStruct lesson) => List.Add(lesson);
        public List<TimeTableStruct> GetTimeTable() => List;
        public string GetFacultyName(Groups groups)
        {
            string str = groups.GetCourseNumber(groups).GetCourse().ToCharArray()[0].ToString();
            return str switch
            {
                "M" => "FITIP",
                "N" => "FBIT",
                "T" => "FBT",
                "K" => "FIKT",
                "L" => "FNE",
                "P" => "FPIIKT",
                "R" => "FSUIP",
                "W" => "FEIET",
                _ => throw new IsuExtra.Tools.IsuExtraException("Invalid faculty name")
            };
        }
    }
}