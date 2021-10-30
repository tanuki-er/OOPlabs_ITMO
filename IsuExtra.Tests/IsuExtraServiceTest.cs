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
            /*
            AddGroupsWithStudentsToList(Groups groups, Students students)
            var group = new Groups("2", "02");
            var student = new Students("Mika");
            var lesson1 = new TimeTableStruct(1, "Lection", "FITIP", "Khlopotov", 311);
            group.AddLessons(lesson1);
            var lesson2 = new TimeTableStruct(1, "Practic", "FNE", "Ovsenko", 415);
            _isuExtraService.AddGroupsWithStudentsToList(group, student);*/
        }

        [Test]
        public void FromTheSameFaculty_Exception()
        {
            Assert.Catch<IsuExtra.Tools.IsuExtraException>(() =>
            {
                
            });
        }

        [Test]
        public void InvalidLessonNumber_Exception()
        {
             Assert.Catch<IsuExtra.Tools.IsuExtraException>(() =>
             {
             });
        }

        [Test]
        public void GetStudentsListFromOneOgnp_Exception()
        {
            Assert.Catch<IsuExtra.Tools.IsuExtraException>(() =>
            {
            });
        }
    }
}