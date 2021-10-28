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
        private List<Stream> Streams { get; } = new List<Stream>();
        public void AddStream(double number) => Streams.Add(new Stream(number));
    }
}