using System.Collections.Generic;
using System.IO;
using Backups.Types.Jobs;

namespace Backups.Types.Service
{
    public interface IRepository
    {
        public DirectoryInfo CreateZipDir();
        public void CopyFilesToDirectory(List<JobObject> jobObjects, DirectoryInfo directory);
        public void DeleteDirectory(DirectoryInfo directory);
    }
}