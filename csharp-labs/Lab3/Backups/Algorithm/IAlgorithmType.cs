using Backups.Repositories;

namespace Backups.Algorithm
{
    public interface IAlgorithmType
    {
        RestorePoint Backup(IRepository repository, List<BackupObject> files, string name);
    }
}
