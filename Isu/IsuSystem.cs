using System;
using System.Collections.Generic;
using Isu.Services;

namespace Isu
{
    public class IsuSystem : IIsuService
    {
        public IsuSystem()
        {
            IsuList = new Dictionary<Group, Student>();
            GList = new List<Group>();
            SList = new List<Student>();
        }

        private List<Student> SList { get; set; }
        private List<Group> GList { get; set; }
        private Dictionary<Group, Student> IsuList { get; }
        public Group AddGroup(string name)
        {
            if (name.Length != 2) throw new Exception("invalid group number");
            int year = 2;
            var newGroup = new Group(year.ToString(), name);
            GList.Add(newGroup);
            return newGroup;
        }

        public Student AddStudent(Group group, string name)
        {
            var newStudent = new Student(name);
            foreach (KeyValuePair<Group, Student> variable in IsuList)
            {
                if (variable.Key == group) continue;
                int count = 0;
                foreach (Student variabLe in IsuList.Values)
                {
                    if (variabLe != null && count < 30) count++;
                    else if (count >= 30) throw new Exception("Countable limit of students in this group");
                }
            }

            IsuList.Add(group, newStudent);
            SList.Add(newStudent);
            return newStudent;
        }

        public Student GetStudent(Guid id)
        {
            foreach (Student variable in SList)
            {
                if (variable.GetId(variable) == id) return variable;
            }

            throw new Exception("Student can't be get");
        }

        public Student FindStudent(string name)
        {
            foreach (Student variable in SList)
            {
                if (variable.GetName(variable) == name) return variable;
            }

            throw new Exception("Student can't be find");
        }

        public List<Student> FindStudents(string groupName)
        {
            var returnList = new List<Student>();
            foreach (KeyValuePair<Group, Student> variable in IsuList)
            {
                if (variable.Key.GetCourseNumber(variable.Key).GetCourse() + variable.Key.GetGroupNumber(variable.Key) == groupName)
                {
                    returnList.Add(variable.Value);
                }
            }

            return returnList;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            var returnList = new List<Student>();
            foreach (KeyValuePair<Group, Student> variable in IsuList)
            {
                if (variable.Key.GetCourseNumber(variable.Key) == courseNumber)
                {
                    returnList.Add(variable.Value);
                }
            }

            if (returnList == null) throw new Exception("This group hasn't students");
            return returnList;
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            var returnList = new List<Group>();
            foreach (KeyValuePair<Group, Student> variable in IsuList)
            {
                if (variable.Key.GetCourseNumber(variable.Key) == courseNumber)
                {
                    returnList.Add(variable.Key);
                }
            }

            return returnList;
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            foreach (KeyValuePair<Group, Student> variable in IsuList)
            {
                if (variable.Value == student) continue;
                if (variable.Key == newGroup) throw new Exception("ERROR: old group == new group");
                IsuList.Remove(variable.Key);
                IsuList.Add(newGroup, student);
            }
        }

        public Group FindGroup(string groupName)
        {
            foreach (Group variable in IsuList.Keys)
            {
                if (variable.GetCourseNumber(variable).GetCourse() + variable.GetGroupNumber(variable) == groupName)
                {
                    return variable;
                }
            }

            throw new Exception("Group can't be find");
        }
    }
}