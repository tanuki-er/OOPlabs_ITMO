using System.Collections.Generic;
using System.IO;

namespace Backups.Types.Service
{
    public class FileArchiveSystem : IRepository
    {
        private const string ArchiveFullWay = @"C:\Users\hagam\BackupTest";
        public void CopyFilesToDirectory(List<FileClass> jobObjects, DirectoryInfo directory)
        {
            int index = 1;
            foreach (FileClass variant in jobObjects)
            {
                File.Copy(variant.ReturnFileName(), directory.FullName + @"\testFileObject_" + index.ToString() + Path.GetExtension(variant.ReturnFileName()), true);
                index++;
            }
        }

        public string CreateNewZipDirectoryName(BackupJob.BackupJob backupJob, BackupJob.Backup backup)
            => @"\" + backupJob.GetName() + "_" + backup.GetRestorePoints().Count.ToString() + ".zip";
        public string CreateNewZipDirectoryName(BackupJob.BackupJob backupJob, BackupJob.Backup backup, int index)
            => @"\" + backupJob.GetName() + "_" + index.ToString() + ".zip";
        public void DeleteDirectory(DirectoryInfo directory) => directory.Delete();
        public string GetArchiveFullWay() => ArchiveFullWay;
    }
}