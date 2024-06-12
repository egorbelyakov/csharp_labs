using Backups.Repositories;

namespace Backups.Algorithm
{
    public class SplitStorage : IAlgorithmType
    {
        public RestorePoint Backup(IRepository repository, List<BackupObject> files, string name)
        {
            var newPaths = new List<string>();

            foreach (BackupObject file in files)
            {
                string fn = Path.GetFileNameWithoutExtension(file.Path);
                string storage = repository.InitStorage(repository.Path, name.Split('.')[0] + "_" + fn);
                string newName = repository.AddToZip(storage, file);
                newPaths.Add(newName);
                repository.AddStorage(Path.GetFileName(storage));
            }

            return new RestorePoint(files);
        }
    }
}
