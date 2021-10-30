using System.Collections.Generic;
using Isu;
using IsuExtra.Tools;

namespace IsuExtra.NewData
{
    public class Students : Student
    {
        public Students(string name)
            : base(name)
        {
        }

        private List<TimeTableStruct> List { get; set; } = new List<TimeTableStruct>();
        private string FacultyName { get; set; }
        public string GetFacultyName() => FacultyName;
        public void SetFacultyName(string fac) => FacultyName = fac;
        public void SetInTimeTable(List<TimeTableStruct> lessons) => List = lessons;

        public void AddToTimeTable(TimeTableStruct lesson)
        {
            foreach (TimeTableStruct variable in List)
            {
                if (variable.GetFacultyName() == lesson.GetFacultyName())
                    throw new IsuExtraException("Choose another Ognp. Student is from the same faculty");
                if (variable.GetLessonNumber() == lesson.GetLessonNumber())
                    throw new IsuExtraException("Timetable become incorrect, you can't add the second lesson to this time");
            }

            List.Add(lesson);
        }
    }
}