using System;
using System.IO;
using Backups.Types.Service;
using BackupsExtra.Algorithms;
using BackupsExtra.Service;
using NUnit.Framework;

namespace BackupsExtra.Tests
{
    public class BackupsExtraTests
    {
        private NewBackupJob _backupJob;
        private FileArchiveSystem _fileArchiveSystem;
        private DirectoryInfo _directoryInfo = new DirectoryInfo(@"C:\Users\hagam\RiderProjects\Extra");

        [SetUp]
        public void Setup()
        {
            _directoryInfo.Create();
            _backupJob = new NewBackupJob();
            _fileArchiveSystem = new FileArchiveSystem();
            var fileA = new FileInfo("1.txt");
            fileA.Create();
            var fileB = new FileInfo("2.txt");
            fileB.Create();
            RestorePoint point1 = _backupJob.CreateRestorePoint(new CleaningByDate(), _directoryInfo);
            fileA.MoveTo(_directoryInfo.FullName);
            RestorePoint point2 = _backupJob.CreateRestorePoint(new CleaningByCounter(), _directoryInfo);
            fileB.MoveTo(_directoryInfo.FullName);
            RestorePoint point3 = _backupJob.CreateRestorePoint(new CleaningByCounter(), _directoryInfo);
            /*___*/
            _backupJob.MergeRestorePoints(_directoryInfo, point2, point3);
            _backupJob.CleanRestorePoint(new CleaningByCounter(), 1, DateTime.Now);
        }
    }
}