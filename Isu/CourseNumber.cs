namespace Isu
{
    public class CourseNumber
    {
        private string faculty { get; set; }
        private string courseNumber { get; set; }

        public CourseNumber(string faculty, string courseNumber)
        {
            this.faculty = faculty;
            this.courseNumber = courseNumber;
        }

        public string GetCourse() => faculty + courseNumber;
        
        public override string ToString()
        {
            return faculty + courseNumber;
        }

    }
}