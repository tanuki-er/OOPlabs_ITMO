using System;
using System.Collections.Generic;

namespace Backups.Types.Backup
{
    public class RestorePoint
    {
        public RestorePoint(int pointNumber)
        {
            PointNumber = pointNumber;
            CreatingTime = DateTime.Now;
        }

        private int PointNumber{get; set;}
        private DateTime CreatingTime { get; set; }

        private List<Storage> Storages { get; set; } = new List<Storage>();
        //todo private dictionary<>/list<> with file information = new..;
    }
}