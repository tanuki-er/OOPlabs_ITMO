using System.Collections.Generic;

namespace Backups.Types.JobObject
{
    public class JobObject
    {
        private List<NewFile> JobObjects { get; set; } = new List<NewFile>();
        public void SetNewFile(string fileWay) => JobObjects.Add(new NewFile(fileWay));
        public void SetNewFile(NewFile file) => JobObjects.Add(file);
        public List<NewFile> GetJobObjects() => JobObjects;
        public void DeleteFileFromJobObjects(NewFile file) => JobObjects.Remove(file);
        public string GetFileWay(NewFile file) => file.GetFileWay();
    }
}