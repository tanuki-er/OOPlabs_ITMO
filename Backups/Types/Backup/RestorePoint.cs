using System;
using System.Collections.Generic;

namespace Backups.Types.Backup
{
    public class RestorePoint
    {
        public RestorePoint( List<Storage> storages)
        {
            Storages = storages;
            CreatingTime = DateTime.Now;
        }

        private DateTime CreatingTime { get; set; }
        private List<Storage> Storages { get; set; }
        public List<Storage> GetStorages() => Storages;
    }
}