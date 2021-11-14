using System.Collections.Generic;
using System.IO;

namespace Backups.Types.JobObject
{
    public class JobObject
    {
        private List<FileInfo> JobObjects { get; set; } = new List<FileInfo>();
        public void SetNewFile(FileInfo file) => JobObjects.Add(file);
        public List<FileInfo> GetJobObjects() => JobObjects;
        public void DeleteFileFromJobObjects(FileInfo file) => JobObjects.Remove(file);
        public string GetFileWay(FileInfo file) => file.DirectoryName;
    }
}