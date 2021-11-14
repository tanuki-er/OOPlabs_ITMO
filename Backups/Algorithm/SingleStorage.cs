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
    public class SingleStorage : IAlgorithm
    {
        public List<Storage> CreateStorage(List<FileInfo> jobObjects, Backup backup, BackupJob backupJob, FileArchiveSystem fileArchiveSystem)
        {
            string newDirectory = fileArchiveSystem.CreateNewZipDirectoryName(backupJob, backup);
            DirectoryInfo localDirectory = Directory.CreateDirectory("C:\\Users\\hagam\\RiderProjects\\tanuki-er\\Backups\\bin\\Debug\\netcoreapp3.1\\Zipzip");
            string directoryWay = localDirectory.FullName;
            ZipFile.CreateFromDirectory(directoryWay, directoryWay + newDirectory);
            fileArchiveSystem.CopyFilesToDirectory(jobObjects, localDirectory);
            fileArchiveSystem.DeleteDirectory(localDirectory);
            var storage = new List<Storage>();
            var newStorage = new Storage(newDirectory);
            storage.Add(newStorage);
            if (storage != null) return storage;
            throw new BackupsException("Storage hadn't any Files. Single storage was failed");
        }
    }
}