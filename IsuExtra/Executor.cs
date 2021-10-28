using System;
using System.Collections.Generic;
using IsuExtra.NewData;
using IsuExtra.OGNP;
using IsuExtra.Tools;

namespace IsuExtra
{
    public class Executor : Isu.IsuSystem, Services.IIsuExtraService
    {
        private Dictionary<Groups, Students> GroupsList { get; set; } = new Dictionary<Groups, Students>();
        private Dictionary<OGNP.Ognp, Stream> OgnpGroups { get; set; } = new Dictionary<Ognp, Stream>();

        public void AddNewOgnp(string facultyName, double number)
        {
            if (number != 0) OgnpGroups.Add(new Ognp(facultyName), new Stream(number));
            else throw new IsuExtraException("Please, also add a new stream");
        }

        public void AddStudentToOgnp(OGNP.Ognp ognp, Students student)
        {
            foreach (KeyValuePair<Ognp, Stream> variable in OgnpGroups)
            {
                if (variable.Key == ognp)
                {
                    variable.Value.SetStudent(student);
                }
            }
        }

        public void DeleteStudentFromOgnp(OGNP.Ognp ognp, Students student)
        {
            foreach (KeyValuePair<Ognp, Stream> variable in OgnpGroups)
            {
                if (variable.Key == ognp)
                {
                    variable.Value.DeleteStudent(student);
                }
            }
        }

        public List<Stream> GetStreamsFromOgnp(OGNP.Ognp ognp)
        {
            var streams = new List<Stream>();
            foreach (KeyValuePair<Ognp, Stream> variable in OgnpGroups)
            {
                if (variable.Key == ognp) streams.Add(variable.Value);
            }

            return streams;
        }

        public List<Students> GetStudentsListFromOneOgnp(OGNP.Ognp ognp, Stream stream)
        {
            var streams = new List<Stream>();
            foreach (KeyValuePair<Ognp, Stream> variable in OgnpGroups)
            {
                if (variable.Key == ognp && variable.Value == stream) return variable.Value.GetStudentsList();
            }

            throw new IsuExtraException("This stream hadn't any students");
        }

        public List<Students> GetStudentsListWithoutOgnp()
        {
            var list = new List<Students>();
            foreach (Students variable1 in GroupsList.Values)
            {
                foreach (Stream variable2 in OgnpGroups.Values)
                {
                    if (variable2.GetStudentsList().Contains(variable1))
                    {
                        list.Add(variable1);
                    }
                }
            }

            return list;
        }
    }
}