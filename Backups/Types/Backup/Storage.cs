using System;

namespace Backups.Types.Backup
{
    public class Storage
    {
        public Storage(string zippedFileWay)
        {
            ZippedFileWay = zippedFileWay;
            DateTime = DateTime.Now;
        }

        private string ZippedFileWay { get; set; }
        private DateTime DateTime { get; set; }
    }
}