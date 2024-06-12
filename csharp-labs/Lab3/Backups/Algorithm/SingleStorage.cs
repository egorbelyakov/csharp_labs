using Backups.Repositories;

namespace Backups.Algorithm
{
    public class SingleStorage : IAlgorithmType
    {
        public RestorePoint Backup(IRepository repository, List<BackupObject> files, string name)
        {
            var newPaths = new List<string>();
            string storage = repository.InitStorage(repository.Path, name);

            foreach (BackupObject file in files)
            {
                string newName = repository.AddToZip(storage, file);
                newPaths.Add(newName);
            }

            repository.AddStorage(Path.GetFileName(storage));

            return new RestorePoint(files);
        }
    }
}
