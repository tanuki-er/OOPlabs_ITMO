using System;
using System.Collections.Generic;
using BackupsExtra.Service;
using RestorePoint = BackupsExtra.Service.RestorePoint;

namespace BackupsExtra.Algorithms
{
    public class CleaningByDate : Algorithms
    {
        public override List<Service.RestorePoint> CleanRestorePoints(List<Service.RestorePoint> restorePoints, int counter, DateTime time)
        {
            NewStorage newStorage = null;
            foreach (RestorePoint variable in restorePoints)
            {
                foreach ((NewStorage key, NewFileClass value) in variable.RestorePointDictionary)
                {
                    if (key.DateCreateTime < time) newStorage = key;
                    variable.RestorePointDictionary.Remove(newStorage!);
                }
            }

            return restorePoints;
        }
    }
}