using System.Collections.Generic;
using System.IO.Compression;
using Backups.Algorithm.Service;
using Backups.Tools;
using Backups.Types.Backup;
using Backups.Types.BackupJob;
using Backups.Types.JobObject;
using Backups.Types.Service;

namespace Backups.Algorithm
{
    public class SplitStorage : IAlgorithm
    {
        public List<Storage> CreateStorage(List<NewFile> jobObjects, Backup backup, BackupJob backupJob, FileArchiveSystem fileArchiveSystem)
        {
            var storage = new List<Storage>();
            for (var index = 0; index < jobObjects.Count; index++)
            {
                NewFile variable = jobObjects[index];
                var newFile = new NewFile(variable.GetFileWay());
                var newDirectory = fileArchiveSystem.CreateNewDirectoryName(fileArchiveSystem, backupJob, backup, index);
                var newStorage = new Storage(newDirectory);
                ZipFile.CreateFromDirectory(newFile.GetFileWay(), newDirectory);
                storage.Add(newStorage);
            }

            if (storage.Count == jobObjects.Count) return storage;
            throw new BackupsException("Incorrect file counter. Storage hadn't some Files. Split storage was failed");
        }
    }
}