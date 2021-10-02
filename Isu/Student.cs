using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Isu
{
    public class Student
    {
        public Student(string studentName)
        {
            Id = Guid.NewGuid();
            StudentName = studentName;
        }

        private Guid Id { get; set; }
        private string StudentName { get; set; }
        public Guid GetId(Student student) => student.Id;
        public string GetName(Student student) => student.StudentName;
    }
}