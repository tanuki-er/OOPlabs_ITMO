using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Isu
{
    public class Student // abstract?
    {

        private Guid id { get; set; }
        private string studentName { get; set; }
        //private List<Student> _studentsList { get; set; }
        
        public Student(string studentName)
        {
            id = Guid.NewGuid();
            this.studentName = studentName;
        }

        public Guid GetId(Student student) => student.id;
        
        public string GetName(Student student) => student.studentName;
        
    }
}