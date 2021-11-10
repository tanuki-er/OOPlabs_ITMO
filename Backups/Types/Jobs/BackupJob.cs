using System;
using System.Collections.Generic;
using Backups.Types.Backup;

namespace Backups.Types.Jobs
{
    public class BackupJob
    {
        public BackupJob(string name)
        {
            Name = name;
        }

        private string Name { get; set; }
        private List<RestorePoint> RestorePoints { get; set; } = new List<RestorePoint>();
        //private List<Files> FilesList { get; set; } = new List<Files>();
        

        
        //todo init job. create directory
        //todo add file
        //todo delete file.     index, name or object
        //todo run job
        public void AddJob() => throw new Exception();
        public void DeleteJob() => throw new Exception();
        public void AddFile() => throw new Exception();
        public void AddRestorePoint() => throw new Exception();



    }
}