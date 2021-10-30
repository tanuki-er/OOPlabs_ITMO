using System.Collections.Generic;
using IsuExtra.NewData;
using IsuExtra.Tools;

namespace IsuExtra.OGNP
{
    public class Stream
    {
        public Stream(double streamNumber)
        {
            StreamNumber = streamNumber;
        }

        private double StreamNumber { get; set; }
        private TimeTableStruct StreamTimetable { get; set; }
        private List<Students> StudentsList { get; set; } = new List<Students>();
        public void SetStudent(Students student) => StudentsList.Add(student);
        public void DeleteStudent(Students student) => StudentsList.Remove(student);
        public List<Students> GetStudentsList() => StudentsList;
        public bool PlaceChecking() => StudentsList.Count > 70 ? throw new IsuExtraException("This stream hadn't free places") : true;
        public void AddNewLessonToStream(TimeTableStruct lesson) => StreamTimetable = lesson;
        public TimeTableStruct GetTimeTable() => StreamTimetable;
    }
}