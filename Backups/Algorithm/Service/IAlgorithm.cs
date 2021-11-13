using System.Collections.Generic;
using Backups.Types.Backup;
using Backups.Types.BackupJob;
using Backups.Types.JobObject;
using Backups.Types.Service;

namespace Backups.Algorithm.Service
{
    public interface IAlgorithm
    {
        public List<Storage> CreateStorage(List<NewFile> jobObjects, Backup backup, BackupJob backupJob, FileArchiveSystem fileArchiveSystem);
    }
}