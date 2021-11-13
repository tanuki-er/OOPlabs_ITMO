namespace Backups.Types.JobObject
{
    public class NewFile
    {
        public NewFile(string fileWay)
        {
            FileWay = fileWay;
        }

        private string FileWay { get; set; }
        public string GetFileWay() => FileWay;
        public void SetFileWay(string newString) => FileWay = newString;
    }
}