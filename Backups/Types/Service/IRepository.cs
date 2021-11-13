using System.Collections.Generic;
using System.IO;

namespace Backups.Types.Service
{
    public interface IRepository
    {
        public DirectoryInfo CreateZipDirectory();
        public void CopyFilesToDirectory(List<JobObject.NewFile> jobObjects, DirectoryInfo directory);
        public void DeleteDirectory(DirectoryInfo directory);
    }
}