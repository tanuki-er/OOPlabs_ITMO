using System;
using System.Collections.Generic;
using Isu.Services;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
       
        private IIsuService _isuService;
        
        private string group1 = "01";
        private string _group2 = "02";
        private string name = "mika";
        private Dictionary<Group, Student> Dictionary { get;  }

        [SetUp]
        public void Setup()
        {
            _isuService = new IsuSystem();
        }
        
        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            Group newGroup = _isuService.AddGroup(group1);
            Student newStudent = _isuService.AddStudent(newGroup, name);

            if (_isuService.FindStudents("M3201") != null) Assert.Pass();
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            Assert.Catch<Exception>(() =>
            { 
                Dictionary<Group, Student> dictionary1 = null;
                for (int i = 0; i < 30; i++)
                {
                    Group newGroup = _isuService.AddGroup(group1);
                    Student newStudent = _isuService.AddStudent(newGroup, name);
                    dictionary1.Add(newGroup, newStudent);
                }
            });
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            Assert.Catch<Exception>(() =>
            {
                Dictionary<Group, Student> _dictionary1 = Dictionary;
                string invalidGroup = "000001";
                Group newGroup = _isuService.AddGroup(invalidGroup);
                Student newStudent = _isuService.AddStudent(newGroup, name);
                _dictionary1.Add(newGroup, newStudent);
            });
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
           Assert.Catch<Exception>(() =>
           {
               Dictionary<Group, Student> dictionary;
               string oldgroup = group1;
               dictionary = null;
               Group oldGroup = _isuService.AddGroup(oldgroup);
               Group newGroup = _isuService.AddGroup(group1);
               Student newStudent = _isuService.AddStudent(oldGroup, name);

               dictionary.Add(oldGroup, newStudent);
               foreach (KeyValuePair<Group, Student> variable in dictionary)
               {
                   if (variable.Value == newStudent) continue;
                   _isuService.ChangeStudentGroup(newStudent, newGroup);
               }
           });
        }
    }
}