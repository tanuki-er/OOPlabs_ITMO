namespace Isu
{
    public class CourseNumber
    {
        public CourseNumber(string faculty, string courseNumber)
        {
            Faculty = faculty;
            Course = courseNumber;
        }

        private string Faculty { get; set; }
        private string Course { get; set; }
        public string GetCourse() => Faculty + Course;
        public override string ToString() => Faculty + Course;
    }
}