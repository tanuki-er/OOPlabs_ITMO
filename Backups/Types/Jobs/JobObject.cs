namespace Backups.Types.Jobs
{
    public abstract class JobObject
    {
        protected JobObject(string fileWay)
        {
            FileWay = fileWay;
        }

        private string FileWay { get; set; }
        public string GetFileWay() => FileWay;
    }
}