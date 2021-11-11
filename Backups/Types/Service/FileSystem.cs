using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Backups.Types.Jobs;
using static System.IO.Path;

namespace Backups.Types.Service
{
    public class FileSystem : IRepository
    {
        private List<FileInfo> FileArchive { get; set; } = new List<FileInfo>();
        private FileInfo FileInfo { get; set; }
        public void CopyFilesToDirectory(List<JobObject> jobObjects, DirectoryInfo directory)
        {
            for (int index = 0; index < jobObjects.Count; index++)
            {
                JobObject variable = jobObjects[index];
                File.Copy(variable.GetFileWay(),
                    directory.Name + "\\jobObject_" + index.ToString() + GetExtension(variable.GetFileWay()));
            }
        }

        public DirectoryInfo CreateZipDir() => Directory.CreateDirectory("");
//todo add a place
        public void DeleteDirectory(DirectoryInfo directory) => directory.Delete();
        public override string ToString() => base.ToString();
    }
}