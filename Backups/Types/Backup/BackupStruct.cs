using System.Collections.Generic;

namespace Backups.Types.Backup
{
    public class BackupStruct
    {
        private List<RestorePoint> RestorePoints { get; set; } = new List<RestorePoint>();
        public void AddRestorePointToStorages(List<Storage> storages) => RestorePoints.Add(new RestorePoint(storages));
        public List<RestorePoint> GetRestorePoints() => RestorePoints;
    }
}