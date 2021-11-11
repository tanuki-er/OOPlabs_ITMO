namespace Backups.Types.Service
{
    public abstract class FileInfo
    {
        protected FileInfo(string fileWay)
        {
            FileWay = fileWay;
        }

        private string FileWay { get; set; }
        public void SetFileWay(string newString) => FileWay = newString;
        public string GetFileWay() => FileWay;
    }
}