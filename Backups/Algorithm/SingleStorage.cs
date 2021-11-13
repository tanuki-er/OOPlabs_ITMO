using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Backups.Algorithm.Service;
using Backups.Tools;
using Backups.Types.Backup;
using Backups.Types.BackupJob;
using Backups.Types.JobObject;
using Backups.Types.Service;

namespace Backups.Algorithm
{
    public class SingleStorage : IAlgorithm
    {
        public List<Storage> CreateStorage(List<NewFile> jobObjects, Backup backup, BackupJob backupJob, FileArchiveSystem fileArchiveSystem)
        {
            string newDirectory = fileArchiveSystem.CreateNewDirectoryName(fileArchiveSystem, backupJob, backup);
            DirectoryInfo localDirectory = fileArchiveSystem.CreateZipDirectory();
            fileArchiveSystem.CopyFilesToDirectory(jobObjects, localDirectory);
            ZipFile.CreateFromDirectory(localDirectory.FullName, newDirectory);
            fileArchiveSystem.DeleteDirectory(localDirectory);
            var storage = new List<Storage>();
            var newStorage = new Storage(newDirectory);
            storage.Add(newStorage);
            if (storage != null)
            {
                return storage;
            }

            throw new BackupsException("Storage hadn't any Files. Single storage was failed");
        }
    }
}