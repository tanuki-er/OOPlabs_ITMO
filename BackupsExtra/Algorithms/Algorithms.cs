using System;
using System.Collections.Generic;
using System.IO;
using BackupsExtra.Service;

namespace BackupsExtra.Algorithms
{
    public abstract class Algorithms
    {
        public RestorePoint CreateRestorePoint(DirectoryInfo directoryInfo)
        {
            var restorePoint = new RestorePoint();
            restorePoint.CreatingTime = DateTime.Now;
            foreach (string variable in Directory.GetFiles(directoryInfo.FullName))
            {
                restorePoint.RestorePointDictionary.Add(new NewStorage(variable), new NewFileClass(variable));
            }

            return restorePoint;
        }

        public abstract List<RestorePoint> CleanRestorePoints(List<RestorePoint> restorePoints, int counter, DateTime time);
    }
}