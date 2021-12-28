using System;
using System.Collections.Generic;

namespace BackupsExtra.Service
{
    public class RestorePoint
    {
        public DateTime CreatingTime { get; set; } = DateTime.Now;
        public Dictionary<NewStorage, NewFileClass> RestorePointDictionary { get => RestorePoints; set => RestorePoints = value; }
        private Dictionary<NewStorage, NewFileClass> RestorePoints { get; set; }
    }
}