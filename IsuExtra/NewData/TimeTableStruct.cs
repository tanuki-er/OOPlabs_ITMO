using IsuExtra.Tools;

namespace IsuExtra.NewData
{
    public class TimeTableStruct
    {
        public TimeTableStruct(int number, string name, string fac, string teacherName, int classNumber)
        {
            Number = number;
            Time = Timetable(number);
            Name = name;
            FacultyName = fac;
            TeacherName = teacherName;
            ClassNumber = classNumber;
        }

        private int Number { get; set; }
        private string Time { get; set; }
        private string Name { get; set; }
        private string FacultyName { get; set; }
        private string TeacherName { get; set; }
        private int ClassNumber { get; set; }
        public string GetFacultyName() => FacultyName;
        public int GetLessonNumber() => Number;
        private static string Timetable(int number)
        {
            return number switch
            {
                1 => "08:15__09:45",
                2 => "10:00__11:30",
                3 => "11:40__13:10",
                4 => "13:30__15:00",
                5 => "15:20__16:50",
                6 => "17:00__18:30",
                7 => "18:40__20:10",
                8 => "20:20__21:50",
                _ => throw new IsuExtraException("Invalid lesson number")
            };
        }
    }
}