using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Backups.Types.Service
{
    public class FileArchiveSystem : IRepository
    {
        public void CopyFilesToDirectory(List<FileInfo> jobObjects, DirectoryInfo directory)
        {
            int index = 1;
            foreach (FileInfo variant in jobObjects.Select(variable
                => variable.CopyTo(directory.FullName + "jobObject_" + index.ToString(), true))) index++;
        }

        public string CreateNewZipDirectoryName(BackupJob.BackupJob backupJob, BackupJob.Backup backup)
            => "\\" + backupJob.GetName() + "_" + backup.GetRestorePoints().Count.ToString() + ".zip";
        public string CreateNewZipDirectoryName(BackupJob.BackupJob backupJob, BackupJob.Backup backup, int index)
            => "\\" + backupJob.GetName() + "_" + index.ToString() + ".zip";
        public void DeleteDirectory(DirectoryInfo directory) => directory.Delete();
    }
}