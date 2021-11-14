using System.Collections.Generic;
using System.IO;
using Backups.Types.Backup;
using Backups.Types.BackupJob;
using Backups.Types.Service;

namespace Backups.Algorithm.Service
{
    public interface IAlgorithm
    {
        public List<Storage> CreateStorage(List<FileInfo> jobObjects, Backup backup, BackupJob backupJob, FileArchiveSystem fileArchiveSystem);
    }
}