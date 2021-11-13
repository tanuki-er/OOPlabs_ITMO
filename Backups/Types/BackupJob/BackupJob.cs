using System.Collections.Generic;
using Backups.Algorithm;
using Backups.Algorithm.Service;
using Backups.Tools;
using Backups.Types.Backup;
using Backups.Types.Service;

namespace Backups.Types.BackupJob
{
    public class BackupJob
    {
        public BackupJob(string name)
        {
            Name = name;
            SplitStorageAlgorithm = new SplitStorage();
            SingleStorageAlgorithm = new SingleStorage();
        }

        private Backup Backup { get; set; } = new Backup();
        private JobObject.JobObject JobObject { get; set; } = new JobObject.JobObject();
        private FileArchiveSystem FileSystem { get; set; } = new FileArchiveSystem();
        private SingleStorage SingleStorageAlgorithm { get; }
        private SplitStorage SplitStorageAlgorithm { get; }

        private string Name { get; set; }
        public string GetName() => Name;
        public void AddToJobObjects(JobObject.NewFile file) => JobObject.SetNewFile(file);
        public void DeleteFromJobObjects(JobObject.NewFile file) => JobObject.DeleteFileFromJobObjects(file);
        public void AddFileWay(JobObject.NewFile file, string fileWay) => file.SetFileWay(fileWay);
        public void CreateRestorePoint(int number, string algorithmType) => Backup.AddRestorePoint(number, ReturnStorages(algorithmType));
        public List<JobObject.NewFile> GetJobObjects() => JobObject.GetJobObjects();
        private List<Storage> ReturnStorages(string type) => type switch
        {
            "single" => SingleStorageAlgorithm.CreateStorage(JobObject.GetJobObjects(), Backup, this, FileSystem),
            "split" => SplitStorageAlgorithm.CreateStorage(JobObject.GetJobObjects(), Backup, this, FileSystem),
            _ => throw new BackupsException("Incorrect Algorithm method")
        };
    }
}