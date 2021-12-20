using System;
using System.Collections.Generic;
using System.IO;
using BackupsExtra.Algorithms;

namespace BackupsExtra.Service
{
    public class NewBackupJob
    {
        private List<RestorePoint> RestorePoints { get; set; } = new List<RestorePoint>();

        public void LogFile(DirectoryInfo directoryInfo, string message)
        {
            var fileStream = new FileStream(directoryInfo + "\\logs.log", FileMode.OpenOrCreate);
            byte[] array = System.Text.Encoding.Default.GetBytes(message);
            fileStream.Write(array, 0, array.Length);
            fileStream.Close();
        }

        public RestorePoint CreateRestorePoint(Algorithms.Algorithms algorithms, DirectoryInfo directoryInfo)
        {
            RestorePoint rPoint = algorithms.CreateRestorePoint(directoryInfo);
            RestorePoints.Add(rPoint);
            return rPoint;
        }

        public void CleanRestorePoint(Algorithms.Algorithms algorithms, int counter, DateTime time)
        {
            algorithms.CleanRestorePoints(RestorePoints, counter, time);
        }

        public void MergeRestorePoints(DirectoryInfo directoryInfo, RestorePoint restorePoint, RestorePoint secondRestorePoint)
        {
            foreach (KeyValuePair<NewStorage, NewFileClass> oldValues in restorePoint.RestorePointDictionary)
            {
                foreach ((NewStorage key, NewFileClass value) in secondRestorePoint.RestorePointDictionary)
                {
                    if (oldValues.Key.DateCreateTime < key.DateCreateTime && oldValues.Value.FileInfo == value.FileInfo)
                    {
                        oldValues.Key.DateCreateTime = key.DateCreateTime;
                        value.FileInfo.MoveTo(directoryInfo.FullName);
                    }

                    if (!value.FileInfo.Equals(oldValues.Value.FileInfo)) oldValues.Value.FileInfo.MoveTo(directoryInfo.FullName);
                }
            }
        }

        public void GetFileTree(DirectoryInfo directoryInfo)
        {
            Algorithms.Algorithms algorithms = new CleaningByCounter();
            string[] allFiles = Directory.GetFiles(directoryInfo.FullName);
            foreach (string filename in allFiles)
            {
                RestorePoints.Add(CreateRestorePoint(algorithms, directoryInfo));
                Console.WriteLine(filename);
            }
        }

        public void RecoveryFromRestorePoint(DirectoryInfo directoryInfo, RestorePoint restorePoint)
        {
            foreach (RestorePoint variable in RestorePoints)
            {
                if (variable != restorePoint) continue;
                directoryInfo.Delete();
                directoryInfo.Create();
                foreach ((NewStorage key, NewFileClass value) in variable.RestorePointDictionary)
                {
                    value.FileInfo.Create();
                    value.FileInfo.MoveTo(directoryInfo.FullName);
                }
            }
        }
    }
}