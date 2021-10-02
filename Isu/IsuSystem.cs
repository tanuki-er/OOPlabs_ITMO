using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using Isu.Services;

namespace Isu
{
    public class IsuSystem : IIsuService
    { 
        private List<Student> SList { get; set; }
        private List<Group> GList { get; set; }
        private Dictionary<Group, Student> _isuList { get; }

    public IsuSystem()
    {
        _isuList = new Dictionary<Group, Student>();
        GList = new List<Group>();
        SList = new List<Student>();
    }
    

    public Group AddGroup(string name)
    {
        if (name.Length != 2) throw new Exception("invalid group number");
        var year = 2;
        if (year > 5) throw new Exception("invalid group name");
        var newGroup = new Group(year.ToString(), name);
        GList.Add(newGroup);
        return newGroup;
    }

    public Student AddStudent(Group group, string name)
    {
        var newStudent = new Student(name);

        foreach (var VARIABLE in _isuList)
        {
            if (VARIABLE.Key == group) continue;
            var count = 0;
            foreach (var VARIABLe in _isuList.Values)
            {
                if (VARIABLe != null && count < 30) 
                    count++;
                else if (count >= 30) 
                    throw new Exception("Countable limit of students in this group");
            }
        }        
        
        _isuList.Add(group, newStudent);
        SList.Add(newStudent);
        return newStudent;
    }

    public Student GetStudent(Guid id)
    {
        foreach (var VARIABLE in SList)
        {
            if (VARIABLE.GetId(VARIABLE) == id) return VARIABLE;
        }

        throw new Exception("Student can't be get");
    }

    public Student FindStudent(string name)
    {
        foreach (var VARIABLE in SList)
        {
            if (VARIABLE.GetName(VARIABLE) == name) return VARIABLE;
        }    
        throw new Exception("Student can't be find");
    }

    
        public List<Student> FindStudents(string groupName)
        {
            var ReturnList = new List<Student>();
            foreach (var VARIABLE in _isuList)
            {
                if (VARIABLE.Key.GetCourseNumber(VARIABLE.Key).GetCourse() + VARIABLE.Key.GetGroupNumber(VARIABLE.Key) == groupName)
                {
                    ReturnList.Add(VARIABLE.Value);
                }
            }
            return ReturnList;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            var ReturnList = new List<Student>();
            foreach (var VARIABLE in _isuList)
            {
                if (VARIABLE.Key.GetCourseNumber(VARIABLE.Key) == courseNumber)
                {
                    ReturnList.Add(VARIABLE.Value);
                }
            }
            return ReturnList;
        }
        
//        
      public List<Group> FindGroups(CourseNumber courseNumber)
      {
          var ReturnList = new List<Group>();
          foreach (var VARIABLE in _isuList)
          {
              if (VARIABLE.Key.GetCourseNumber(VARIABLE.Key) == courseNumber)
              {
                  ReturnList.Add(VARIABLE.Key);
              }
          }

          return ReturnList;
      }
      


      public void ChangeStudentGroup(Student student, Group newGroup)
      {
          foreach (var VARIABLE in _isuList)
          {
              if (VARIABLE.Value == student) continue;
              if (VARIABLE.Key == newGroup) throw new Exception("ERROR: old group == new group");
              _isuList.Remove(VARIABLE.Key);
              _isuList.Add(newGroup, student);
          }
      }
      
      public Group FindGroup(string groupName)
        {
            foreach (var VARIABLE in _isuList.Keys)
            {
                if ( VARIABLE.GetCourseNumber(VARIABLE).GetCourse() + VARIABLE.GetGroupNumber(VARIABLE) == groupName)
                {
                    return VARIABLE;
                }
            }
            throw new Exception("Group can't be find");
        }
    }
}

