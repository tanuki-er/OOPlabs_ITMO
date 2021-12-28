using System;
using System.Collections.Generic;
using BackupsExtra.Service;
using RestorePoint = BackupsExtra.Service.RestorePoint;

namespace BackupsExtra.Algorithms
{
    public class CleaningByCounter : Algorithms
    {
        public override List<Service.RestorePoint> CleanRestorePoints(List<Service.RestorePoint> restorePoints, int counter, DateTime time)
        {
            int lenght = restorePoints.Count;
            DateTime newTime = DateTime.Now;
            NewStorage newStorage = null;
            foreach (RestorePoint variable in restorePoints)
            {
                if (lenght <= counter) continue;
                foreach ((NewStorage key, NewFileClass value) in variable.RestorePointDictionary)
                {
                    if (key.DateCreateTime >= newTime) continue;
                    newTime = key.DateCreateTime;
                    newStorage = key;
                }

                variable.RestorePointDictionary.Remove(newStorage!);
            }

            return restorePoints;
        }
    }
}