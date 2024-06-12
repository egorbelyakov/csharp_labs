using Backups.Algorithm;
using Backups.Repositories;
using Xunit;

namespace Backups.Test
{
    public class BackupsTest
    {
        private IRepository repository = new MockRepository("C:\\Users\\HP\\OneDrive\\Рабочий стол\\test");

        [Fact]
        public void Test1()
        {
            var obj1 = new BackupObject("test1", "C:\\Users\\HP\\OneDrive\\Документы\\Source\\test1.txt");
            var obj2 = new BackupObject("test2", "C:\\Users\\HP\\OneDrive\\Документы\\Source\\test2.txt");
            var testList = new List<BackupObject> { obj1, obj2 };
            IAlgorithmType algorithm = new SplitStorage();
            var backupTask = new BackupTask("name", testList, algorithm);

            backupTask.MakeBackup(repository);
            backupTask.RemoveBackupObject(testList[0]);
            backupTask.MakeBackup(repository);

            int actual1 = backupTask.ShowRestorePoints().Count;
            const int expected1 = 2;
            int actual2 = repository.GetStorage().Count;
            const int expected2 = 3;
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
        }

        [Fact]
        public void Test2()
        {
            var obj1 = new BackupObject("test1", "C:\\Users\\HP\\OneDrive\\Документы\\Source\\test1.txt");
            var obj2 = new BackupObject("test2", "C:\\Users\\HP\\OneDrive\\Документы\\Source\\test2.txt");
            var testList = new List<BackupObject> { obj1, obj2 };
            IAlgorithmType algorithm = new SingleStorage();
            var backupTask = new BackupTask("name", testList, algorithm);
            backupTask.MakeBackup(repository);
        }
    }
}
