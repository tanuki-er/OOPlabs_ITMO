using System.Collections.Generic;
using IsuExtra.NewData;
using NUnit.Framework;

namespace IsuExtra.Tests
{
    public class Tests
    {
        private IsuExtra.Services.IIsuExtraService _isuExtraService;

        [SetUp]
        public void Setup()
        {
            _isuExtraService = new Executor();
        }

        [Test]
        public void AddNewGroup_StudentsWasAddedToOgnp()
        {
            var group = new Groups("2", "02");
            var student = new Students("Mika");
            var lesson1 = new TimeTableStruct(1, "Lection", "FITIP", "Khlopotov", 311);
            group.AddLessons(lesson1);
            var lesson2 = new TimeTableStruct(2, "Practic", "FNE", "Ovsenko", 415);
            var ognp = new OGNP.Ognp("FNE");
            var stream = new OGNP.Stream(1);
            stream.AddNewLessonToStream(lesson2);
            _isuExtraService.AddNewOgnp(ognp, stream);
            _isuExtraService.AddGroupsWithStudentsToList(group, student);
            _isuExtraService.AddStudentToOgnp(ognp, stream, student);
            List<Students> list = _isuExtraService.GetStudentsListFromOneOgnp(ognp, stream);
            if (list != null) Assert.Pass();
        }

        [Test]
        public void FromTheSameFaculty_Exception()
        {
            Assert.Catch<IsuExtra.Tools.IsuExtraException>(() =>
            {
                var group = new Groups("2", "02");
                var student = new Students("Mika");
                var lesson1 = new TimeTableStruct(1, "Lection", "FITIP", "Khlopotov", 311);
                group.AddLessons(lesson1);
                var lesson2 = new TimeTableStruct(2, "Practic", "FITIP", "Khvastunov", 415);
                var ognp = new OGNP.Ognp("FITIP");
                var stream = new OGNP.Stream(1);
                stream.AddNewLessonToStream(lesson2);
                _isuExtraService.AddNewOgnp(ognp, stream);
                _isuExtraService.AddGroupsWithStudentsToList(group, student);
                _isuExtraService.AddStudentToOgnp(ognp, stream, student);
            });
        }

        [Test]
        public void InvalidLessonNumber_Exception()
        {
             Assert.Catch<IsuExtra.Tools.IsuExtraException>(() =>
             {
                 var lesson1 = new TimeTableStruct(0, "Lection", "FITIP", "Khlopotov", 311);
             });
        }

        [Test]
        public void GetStudentsWithoutOgnp()
        {
            var group = new Groups("2", "02");
            var student = new Students("Mika");
            var lesson2 = new TimeTableStruct(2, "Practic", "FNE", "Ovsenko", 415);
            var ognp = new OGNP.Ognp("FNE");
            var stream = new OGNP.Stream(1);
            stream.AddNewLessonToStream(lesson2);
            _isuExtraService.AddNewOgnp(ognp, stream);
            _isuExtraService.AddGroupsWithStudentsToList(group, student);
            List<Students> list = _isuExtraService.GetStudentsListWithoutOgnp();
            if (list != null) Assert.Pass();
        }
    }
}