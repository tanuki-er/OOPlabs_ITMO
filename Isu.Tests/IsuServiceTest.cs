using System;
using System.Collections.Generic;
using Isu.Services;
using Isu.Tools;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
       
        private IIsuService _isuService;
        
        private string group1 = "01";
        private string group2 = "02";
        private string name = "mika";
        private Dictionary<Group, Student> _dictionary { get;  }

        [SetUp]
        public void Setup()
        {
            _isuService = new IsuSystem();
        }
        
        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            
            var newGroup = _isuService.AddGroup(group1);
            var newStudent = _isuService.AddStudent(newGroup, name);

            _dictionary.Add(newGroup, newStudent);
        
          
            foreach (var VARIABLE in _dictionary)
            {
                if (VARIABLE.Value == newStudent && VARIABLE.Key != null) Assert.Pass();
            }

            foreach (var VARIABLE in _dictionary)
            {
                if (VARIABLE.Key == newGroup && VARIABLE.Value.Equals(newStudent)) Assert.Pass();
            }
            
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            //private Dictionary<Group, Student> _dictionary;
            Assert.Catch<IsuException>(() =>
            { 
                Dictionary<Group, Student> _dictionary1 = null;
                for (int i = 0; i < 30; i++)
                {
                    var newGroup = _isuService.AddGroup(group1);
                    var newStudent = _isuService.AddStudent(newGroup, name);
                    //_dictionary1.Add(newGroup, newStudent);
                    
                }
               
            });
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                Dictionary<Group, Student> _dictionary1 = _dictionary;
                string invalidGroup = "000001";
                var newGroup = _isuService.AddGroup(invalidGroup);
                var newStudent = _isuService.AddStudent(newGroup, name);
                _dictionary1.Add(newGroup, newStudent);
            });
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
           Assert.Catch<IsuException>(() =>
           {
               Dictionary<Group, Student> _dictionary;

               var Oldgroup = group1;
               _dictionary = null;
               var oldGroup = _isuService.AddGroup(Oldgroup);
               var newGroup = _isuService.AddGroup(group1);
               var newStudent = _isuService.AddStudent(oldGroup, name);

               _dictionary.Add(oldGroup, newStudent);
               foreach (var VARIABLE in _dictionary)
               {
                   if (VARIABLE.Value == newStudent) continue;
                   _isuService.ChangeStudentGroup(newStudent, newGroup);
               }
           });
        }
    }
}