namespace Backups.Repositories
{
    public interface IRepository
    {
        string Path { get; }
        void AddStorage(string storage);
        IReadOnlyList<string> GetStorage();
        string AddToZip(string path, BackupObject file);
        string InitStorage(string path, string name);
    }
}