using System;
using System.Collections.Generic;

namespace Backups.Types.Backup
{
    public class RestorePoint
    {
        public RestorePoint(int number, List<Storage> storages)
        {
            Number = number;
            Storages = storages;
            CreatingTime = DateTime.Now;
        }

        private int Number { get; set; }
        private DateTime CreatingTime { get; set; }
        private List<Storage> Storages { get; set; }
        public List<Storage> GetStorages() => Storages;
    }
}