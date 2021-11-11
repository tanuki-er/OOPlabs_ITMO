using System;

namespace Backups.Types.Backup
{
    public abstract class Storage
    {
        protected Storage(string zFileWay)
        {
            ZFileWay = zFileWay;
            DateTime = DateTime.Now;
        }
        private string ZFileWay { get; set; }
        private DateTime DateTime { get; set; }
    }
}