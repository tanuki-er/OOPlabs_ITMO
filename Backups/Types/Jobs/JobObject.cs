namespace Backups.Types.Jobs
{
    public class JobObject
    {
        public JobObject(string filepath)
        {
            FilePath = filepath;
        }

        private string FilePath { get; set; }
        
    }
}