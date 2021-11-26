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
        public List<Storage> CreateStorage(List<FileClass> jobObjects, Backup backup, BackupJob backupJob, FileArchiveSystem fileArchiveSystem)
        {
            string newDirectory = fileArchiveSystem.CreateNewZipDirectoryName(backupJob, backup);
            DirectoryInfo localDirectory = Directory.CreateDirectory(@"C:\Users\hagam\BackupTest\Zip");
            fileArchiveSystem.CopyFilesToDirectory(jobObjects, localDirectory);
            string directoryWay = localDirectory.FullName;
            ZipFile.CreateFromDirectory(directoryWay, fileArchiveSystem.GetArchiveFullWay() + @"\filename.zip");
            var storage = new List<Storage>();
            var newStorage = new Storage(newDirectory);
            storage.Add(newStorage);
            if (storage != null) return storage;
            throw new BackupsException("Storage hadn't any Files. Single storage was failed");
        }
    }
}