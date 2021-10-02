using System;

namespace Isu
{
    public class Group
    {
        private string groupNumber { get; set; }
        private CourseNumber courseNumber { get; set; }



        public Group(string year, string groupNumber)
        {

            courseNumber = new CourseNumber("M3", year);
            this.groupNumber = groupNumber;
        }

        public string GetGroupNumber(Group group) => group.groupNumber;

        public CourseNumber GetCourseNumber(Group group) => group.courseNumber;
    }
}