using System;

namespace Backups.Types.Backup
{
    public class Storage
    {
        public Storage(string fileWay)
        {
            FileWay = fileWay;
            _dateTime = DateTime.Now;
        }
        private string FileWay { get; set; }
        private DateTime _dateTime { get; }
    }
}