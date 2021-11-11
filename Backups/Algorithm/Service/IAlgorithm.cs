using System.Collections.Generic;
using Backups.Types.Backup;

namespace Backups.Algorithm.Service
{
    public interface IAlgorithm
    {
        public List<Storage> CreateStorage(/*name,list<jobobject>,filesystem,backup*/);
    }
}