using System.Collections.Generic;
using Backups.Types.Backup;

namespace Backups.Types.BackupJob
{
    public class Backup
    {
        private List<RestorePoint> RestorePoints { get; set; } = new List<RestorePoint>();
        public void AddRestorePoint(List<Storage> storages) => RestorePoints.Add(new RestorePoint(storages));
        public List<RestorePoint> GetRestorePoints() => RestorePoints;
    }
}