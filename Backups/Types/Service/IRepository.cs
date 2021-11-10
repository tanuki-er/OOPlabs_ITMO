namespace Backups.Types.Service
{
    public interface IRepository
    {
        public void AddFilePath();
        public void ToZipDirectory();
        public void CopyFilesToDirectory();
        public void DeleteDirectory();

    }
}