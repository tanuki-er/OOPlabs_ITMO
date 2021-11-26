using System.Collections.Generic;
using System.IO;
using Backups.Types.Service;

namespace Backups.Types.JobObject
{
    public class JobObject
    {
        private List<FileClass> JobObjects { get; set; } = new List<FileClass>();
        public void SetNewFile(FileClass file) => JobObjects.Add(file);
        public List<FileClass> GetJobObjects() => JobObjects;
        public void DeleteFileFromJobObjects(FileClass file) => JobObjects.Remove(file);
        public string GetFileWay(FileInfo file) => file.DirectoryName;
    }
}