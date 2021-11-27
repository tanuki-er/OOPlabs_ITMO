namespace Backups.Types.Service
{
    public class FileClass
    {
        public FileClass(string path)
        {
            Path = path;
        }

        private string Path { get; set; }
        public string ReturnFileName() => Path;
    }
}