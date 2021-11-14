using System.IO;
using Backups.Algorithm;
using Backups.Types.BackupJob;
using Backups.Types.Service;
using NUnit.Framework;

namespace Backups.Tests
{
    public class Tests
    {
        private BackupJob _backupJob;
        private FileArchiveSystem _fileArchiveSystem;

        [SetUp]
        public void Setup()
        {
            _backupJob = new BackupJob("name", new SingleStorage());
            _fileArchiveSystem = new FileArchiveSystem();
            var fileA = new FileInfo("1.txt");
            var fileB = new FileInfo("2.txt");
            _backupJob.AddToJobObjects(fileA);
            _backupJob.AddToJobObjects(fileB);
            _backupJob.CreateRestorePoint();
            _backupJob.DeleteFromJobObjects(fileB);
            _backupJob.CreateRestorePoint();

        }
       [Test]
        public void BackupTest()
        {
            if (_backupJob.GetRestorePoint() != null) Assert.Pass();
        }
    }
}