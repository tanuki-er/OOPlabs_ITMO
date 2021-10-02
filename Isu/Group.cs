using System;

namespace Isu
{
    public class Group
    {
        public Group(string year, string groupNumber)
        {
            CourseNumber = new CourseNumber("M3", year);
            this.GroupNumber = groupNumber;
        }

        private string GroupNumber { get; set; }
        private CourseNumber CourseNumber { get; set; }
        public string GetGroupNumber(Group group) => group.GroupNumber;
        public CourseNumber GetCourseNumber(Group group) => group.CourseNumber;
    }
}