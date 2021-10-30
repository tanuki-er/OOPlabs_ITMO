using System.Collections.Generic;
using System.Net.Http;
using IsuExtra.NewData;

namespace IsuExtra.OGNP
{
    public class Ognp
    {
        public Ognp(string facultyName)
        {
            FacultyName = facultyName;
        }

        private string FacultyName { get; set; }
    }
}