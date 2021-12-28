using System.IO;

namespace BackupsExtra.Service
{
    public class NewFileClass
    {
        public NewFileClass(string pathPlusName)
        {
            FileInfo = new FileInfo(pathPlusName);
        }

        public NewFileClass(string path, string name)
        {
            FileInfo = new FileInfo(path + name);
        }

        public FileInfo FileInfo { get => Info; set => Info = value; }
        private FileInfo Info { get; set; }
    }
}