using System.Collections.Generic;
using IsuExtra.NewData;

namespace IsuExtra.OGNP
{
    public class Stream
    {
        public Stream(double streamNumber)
        {
            StreamNumber = streamNumber;
        }

        private double StreamNumber { get; set; }
        private List<Students> StudentsList { get; set; } = new List<Students>();
        public void SetStudent(Students student) => StudentsList.Add(student);
        public void DeleteStudent(Students student) => StudentsList.Remove(student);
        public List<Students> GetStudentsList() => StudentsList;
    }
}