﻿using System.Collections.Generic;
using IsuExtra.NewData;
using IsuExtra.OGNP;
using IsuExtra.Tools;

namespace IsuExtra
{
    public class Executor : Isu.IsuSystem, Services.IIsuExtraService
    {
        private Dictionary<Groups, Students> GroupsList { get; set; } = new Dictionary<Groups, Students>();
        private Dictionary<OGNP.Ognp, Stream> OgnpGroups { get; set; } = new Dictionary<Ognp, Stream>();

        public void AddGroupsWithStudentsToList(Groups groups, Students students)
        {
            students.SetInTimeTable(groups.GetTimeTable());
            students.SetFacultyName(groups.GetFacultyName(groups));
            GroupsList.Add(groups, students);
        }

        public void AddNewOgnp(OGNP.Ognp ognp, OGNP.Stream stream)
        {
            OgnpGroups.Add(ognp, stream);
        }

        public void AddStudentToOgnp(OGNP.Ognp ognp, Stream stream, Students student)
        {
            int counter = 0;
            foreach (KeyValuePair<Ognp, Stream> variable in OgnpGroups)
            {
                if (variable.Value.GetStudentsList().Contains(student))
                {
                    counter++;
                }

                if (counter >= 2) throw new IsuExtraException("you had a counter limit of Ognp courses");
            }

            foreach (KeyValuePair<Ognp, Stream> variable in OgnpGroups)
            {
                if (variable.Key == ognp && variable.Value == stream && variable.Value.PlaceChecking())
                {
                    student.AddToTimeTable(stream.GetTimeTable());
                    variable.Value.SetStudent(student);
                }
            }
        }

        public void DeleteStudentFromOgnp(OGNP.Ognp ognp, Stream stream, Students student)
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
            var list = new List<Students>();
            foreach (KeyValuePair<Ognp, Stream> variable in OgnpGroups)
            {
                if (variable.Key == ognp && variable.Value == stream)
                {
                    if (variable.Value.GetStudentsList() == null) throw new IsuExtraException("This stream hadn't any students");
                    return variable.Value.GetStudentsList();
                }
            }

            throw new IsuExtraException("This Stream isn't founded");
        }

        public List<Students> GetStudentsListWithoutOgnp()
        {
            var list = new List<Students>();
            foreach (Students variable1 in GroupsList.Values)
            {
                foreach (Stream variable2 in OgnpGroups.Values)
                {
                    if (!variable2.GetStudentsList().Contains(variable1)) list.Add(variable1);
                }
            }

            return list;
        }
    }
}