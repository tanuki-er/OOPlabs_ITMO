namespace IsuExtra.Services
{
    public interface IIsuExtraService : Isu.Services.IIsuService
    {
        public void AddGroupsWithStudentsToList(NewData.Groups groups, NewData.Students students);
        public void AddNewOgnp(string facultyName, double number);
        public void AddStudentToOgnp(OGNP.Ognp ognp, OGNP.Stream stream, NewData.Students student);
        public void DeleteStudentFromOgnp(OGNP.Ognp ognp, OGNP.Stream stream, NewData.Students student);
        public System.Collections.Generic.List<OGNP.Stream> GetStreamsFromOgnp(OGNP.Ognp ognp);
        public System.Collections.Generic.List<NewData.Students> GetStudentsListFromOneOgnp(OGNP.Ognp ognp, OGNP.Stream stream);
        public System.Collections.Generic.List<NewData.Students> GetStudentsListWithoutOgnp();
    }
}