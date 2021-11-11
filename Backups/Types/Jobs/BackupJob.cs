using System.Collections.Generic;
using Backups.Algorithm.Service;
using Backups.Types.Backup;
using Backups.Types.Service;

namespace Backups.Types.Jobs
{
    public class BackupJob
    {
        public BackupJob(string name)
        {
            Name = name;
            //??
        }

        private IAlgorithm Algorithm { get; set; }//??
        private string Name { get; set; }
        private BackupStruct BackupStruct { get; set; } = new BackupStruct();
        private List<JobObject> JobObject { get; set; } = new List<JobObject>();
        private FileSystem FileSystem { get; set; } = new FileSystem();
        public void AddJob(JobObject jobObject) => JobObject.Add(jobObject);
        public void DeleteJob(JobObject jobObject) => JobObject.Remove(jobObject);
        //public void AddFileWay(string fileWay) => throw new Exception();
        public void CreateRestorePoint() => BackupStruct.AddRestorePointToStorages(ReturnStorages());
        private List<Storage> ReturnStorages() => Algorithm.CreateStorage( /*??*/);
//todo add things to algorithm
        public List<JobObject> GetJobObjects() => JobObject;
    }
}