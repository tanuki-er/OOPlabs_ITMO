using System.Collections.Generic;
using System.IO;
using Backups.Types.JobObject;
using static System.IO.Path;

namespace Backups.Types.Service
{
    public class FileArchiveSystem : IRepository
    {
        private string FileWay { get; set; }
        public void CopyFilesToDirectory(List<JobObject.NewFile> jobObjects, DirectoryInfo directory)
        {
            for (int index = 0; index < jobObjects.Count; index++)
            {
                JobObject.NewFile variable = jobObjects[index];
                File.Copy(
                    variable.GetFileWay(), directory.Name + "\\jobObject_" + index.ToString() + GetExtension(variable.GetFileWay()));
            }
        }

        public DirectoryInfo CreateZipDirectory() => Directory.CreateDirectory("C:\\Users\\hagam\\RiderProjects\\tanuki-er\\Backups\\bin\\Debug\\ToZip");
        public string CreateNewDirectoryName(FileArchiveSystem archiveSystem, BackupJob.BackupJob backupJob, BackupJob.Backup backup)
            => archiveSystem.GetFileWay() + "\\" + backupJob.GetName() + "_" + backup.GetRestorePoints().Count.ToString() + ".zip";
        public string CreateNewDirectoryName(FileArchiveSystem archiveSystem, BackupJob.BackupJob backupJob, BackupJob.Backup backup, int index)
            => archiveSystem.GetFileWay() + "\\" + backupJob.GetName() + "_" + index.ToString() + ".zip";
        public void DeleteDirectory(DirectoryInfo directory) => directory.Delete();
        public string GetFileWay() => FileWay;
    }
}