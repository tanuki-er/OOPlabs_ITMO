using System;
using System.Collections.Generic;
using System.Linq;

namespace Isu
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var dictionary = new IsuSystem();
            Group newGroup = dictionary.AddGroup("01");
            Console.WriteLine("TASK1:\tGroup " + newGroup.GetGroupNumber(newGroup) + " was created.");
            Student newStudent = dictionary.AddStudent(newGroup, "mika");
            Console.WriteLine("TASK2:\tStudent " + newStudent.GetName(newStudent).ToString() + " added to group " + newGroup.ToString());
            Student findStudent = dictionary.FindStudent("mika");
            Console.WriteLine("TASK3:\tStudent " + findStudent.GetName(findStudent).ToString() + " was founded.");
            Student getOneStudent = dictionary.GetStudent(findStudent.GetId(findStudent));
            Console.WriteLine("TASK4:\tStudent with id '" + getOneStudent.GetId(getOneStudent).ToString() + "' was founded.");
            List<Student> findStudentsByGroup = dictionary.FindStudents("01");
            Console.WriteLine("TASK5:\tStudents was founded:\n\t" + findStudentsByGroup.ToArray());
            List<Student> findStudentsByCourse = dictionary.FindStudents(newGroup.GetCourseNumber(newGroup));
            Console.WriteLine("TASK6:\tStudents was founded by Course number:\n\t" + findStudentsByCourse.ToArray());
            Group findGroup = dictionary.FindGroup("M3201");
            Console.WriteLine("TASK7:\tGroup was founded by group number");
            List<Group> findGroups = dictionary.FindGroups(newGroup.GetCourseNumber(newGroup));
            Console.WriteLine("TASK8:\tGroup list of this Course was founded:\n\t" + findGroups.ToArray());
            Group secondGroup = dictionary.AddGroup("02");
            dictionary.ChangeStudentGroup(newStudent, secondGroup);
            Console.WriteLine("TASK9:\tStudent " + newStudent.GetName(newStudent) + " changed group to " + secondGroup.GetGroupNumber(secondGroup));
        }
    }
}
