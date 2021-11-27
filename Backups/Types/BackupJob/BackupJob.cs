using System.Collections.Generic;
using Backups.Algorithm.Service;
using Backups.Types.Backup;
using Backups.Types.Service;

namespace Backups.Types.BackupJob
{
    public class BackupJob
    {
        public BackupJob(string name, IAlgorithm algorithm)
        {
            Name = name;
            Algorithm = algorithm;
        }

        private Backup Backup { get; set; } = new Backup();
        private JobObject.JobObject JobObject { get; set; } = new JobObject.JobObject();
        private FileArchiveSystem FileSystem { get; set; } = new FileArchiveSystem();
        private IAlgorithm Algorithm { get; set; }

        private string Name { get; set; }
        public string GetName() => Name;
        public void AddToJobObjects(FileClass file) => JobObject.SetNewFile(file);
        public void CreateRestorePoint() => Backup.AddRestorePoint(Algorithm.CreateStorage(JobObject.GetJobObjects(), Backup, this, FileSystem));
        public List<RestorePoint> GetRestorePoint() => Backup.GetRestorePoints();
        public void DeleteFromJobObjects(FileClass file) => JobObject.DeleteFileFromJobObjects(file);
    }
}