using Backups.Algorithm;
using Backups.Exceptions;
using Backups.Repositories;

namespace Backups
{
    public class BackupTask
    {
        private List<BackupObject> _files;
        private List<RestorePoint> restorePoints = new List<RestorePoint>();

        public BackupTask(string name, List<BackupObject> files, IAlgorithmType type)
        {
            ArgumentNullException.ThrowIfNull(name);
            ArgumentNullException.ThrowIfNull(type);
            ArgumentNullException.ThrowIfNull(files);

            Type = type;
            _files = files;
            Name = name;
        }

        public IAlgorithmType Type { get; }
        public string Name { get; }

        public void AddBackupObject(BackupObject file) => _files.Add(file);

        public void RemoveBackupObject(BackupObject file)
        {
            if (!_files.Contains(file))
                throw new BackupsException();

            _files.Remove(file);
        }

        public void MakeBackup(IRepository repository) => restorePoints.Add(Type.Backup(repository, _files, restorePoints.Count.ToString()));

        public void RemoveRestorePoint(RestorePoint restorePoint) => restorePoints.Remove(restorePoint);

        public IReadOnlyList<BackupObject> ShowObjects() => _files;

        public IReadOnlyList<RestorePoint> ShowRestorePoints() => restorePoints;
    }
}
