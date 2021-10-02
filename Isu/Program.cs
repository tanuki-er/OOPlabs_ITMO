using System;
using System.Collections.Generic;
using System.Linq;

namespace Isu
{
    class Program
    {
        public void Main(string[] args)
        {

            IsuSystem dictionary = new IsuSystem();
            
            var newGroup = dictionary.AddGroup("01");
            Console.WriteLine("TASK1:\tGroup " + newGroup.GetGroupNumber(newGroup) + " was created.");
            //--------------------------------------------------------------------------
            var newStudent = dictionary.AddStudent(newGroup, "mika");
            Console.WriteLine("TASK2:\tStudent " + newStudent.GetName(newStudent).ToString() + " added to group " + newGroup.ToString());
            //--------------------------------------------------------------------------
            var findStudent = dictionary.FindStudent("mika");
            Console.WriteLine("TASK3:\tStudent " + findStudent.GetName(findStudent).ToString() + " was founded.");
            //--------------------------------------------------------------------------
            var getOneStudent = dictionary.GetStudent(findStudent.GetId(findStudent));
            Console.WriteLine("TASK4:\tStudent with id '" + getOneStudent.GetId(getOneStudent).ToString() + "' was founded.");
            //--------------------------------------------------------------------------
            var findStudentsByGroup = dictionary.FindStudents("01");
            Console.WriteLine("TASK5:\tStudents was founded:\n\t" + findStudentsByGroup.ToArray()); //
            //----------------------
            var findStudentsByCourse = dictionary.FindStudents(newGroup.GetCourseNumber(newGroup));
            Console.WriteLine("TASK6:\tStudents was founded by Course number:\n\t" + findStudentsByCourse.ToArray()); //
            //----------------------
            var findGroup = dictionary.FindGroup("M3201");
            Console.WriteLine("TASK7:\tGroup was founded by group number");//ok
            //----------------------
            var findGroups = dictionary.FindGroups(newGroup.GetCourseNumber(newGroup));
            Console.WriteLine("TASK8:\tGroup list of this Course was founded:\n\t" + findGroups.ToArray());
            //----------------------
            var secondGroup = dictionary.AddGroup("02");
            dictionary.ChangeStudentGroup(newStudent,secondGroup);
            Console.WriteLine("TASK9:\tStudent " + newStudent.GetName(newStudent) + " changed group to " + secondGroup.GetGroupNumber(secondGroup));


        }
    }
}
