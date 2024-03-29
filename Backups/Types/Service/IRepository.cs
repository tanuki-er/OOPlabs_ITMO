﻿using System.Collections.Generic;
using System.IO;

namespace Backups.Types.Service
{
    public interface IRepository
    {
        public void CopyFilesToDirectory(List<FileClass> jobObjects, DirectoryInfo directory);
        public void DeleteDirectory(DirectoryInfo directory);
    }
}