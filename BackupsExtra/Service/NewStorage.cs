using System;

namespace BackupsExtra.Service
{
    public class NewStorage
    {
        public NewStorage(string fileWay)
        {
            FilePath = fileWay;
        }

        public DateTime DateCreateTime { get => DateTime; set => DateTime = value; }
        public string Path { get => FilePath; set => FilePath = value; }
        private DateTime DateTime { get; set; } = DateTime.Now;
        private string FilePath { get; set; }
    }
}