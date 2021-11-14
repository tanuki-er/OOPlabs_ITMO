using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Backups.Algorithm.Service;
using Backups.Tools;
using Backups.Types.Backup;
using Backups.Types.BackupJob;
using Backups.Types.Service;

namespace Backups.Algorithm
{
    public class SplitStorage : IAlgorithm
    {
        public List<Storage> CreateStorage(List<FileInfo> jobObjects, Backup backup, BackupJob backupJob, FileArchiveSystem fileArchiveSystem)
        {
            var storage = new List<Storage>();
            for (int index = 1; index < jobObjects.Count; index++)
            {
                FileInfo variable = jobObjects[index];
                string newDirectory = fileArchiveSystem.CreateNewZipDirectoryName(backupJob, backup, index);
                var newStorage = new Storage(newDirectory);
                ZipFile.CreateFromDirectory(variable.DirectoryName, variable.DirectoryName + newDirectory);
                storage.Add(newStorage);
            }

            if (storage.Count == jobObjects.Count) return storage;
            throw new BackupsException("Incorrect file counter. Storage hadn't some Files. Split storage was failed");
        }
    }
}