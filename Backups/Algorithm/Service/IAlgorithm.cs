using System.Collections.Generic;
using Backups.Types.Backup;
using Backups.Types.BackupJob;
using Backups.Types.Service;

namespace Backups.Algorithm.Service
{
    public interface IAlgorithm
    {
        public List<Storage> CreateStorage(List<FileClass> jobObjects, Backup backup, BackupJob backupJob, FileArchiveSystem fileArchiveSystem);
    }
}