namespace Backups.Repositories
{
    public class MockRepository : IRepository
    {
        private List<string> storages = new List<string>();

        public MockRepository(string path)
        {
            Path = path;
        }

        public string Path { get; }

        public void AddStorage(string storage) => storages.Add(storage);

        public IReadOnlyList<string> GetStorage() => storages;

        public string AddToZip(string path, BackupObject file)
        {
            string newName = System.IO.Path.GetFileNameWithoutExtension(file.Path) + "_" + file.Name + System.IO.Path.GetExtension(file.Path);
            string newPath = path + "\\" + newName;

            return newPath;
        }

        public string InitStorage(string path, string name)
        {
            string outputFile = path + "\\" + name + ".zip";

            return outputFile;
        }
    }
}