using System.IO.Compression;

namespace Backups.Repositories
{
    public class Repository : IRepository
    {
        private List<string> storages = new List<string>();

        public Repository(string path)
        {
            Path = path;
        }

        public string Path { get; }

        public string AddToZip(string path, BackupObject file)
        {
            string newName = System.IO.Path.GetFileNameWithoutExtension(file.Path) + "_" + file.Name + System.IO.Path.GetExtension(file.Path);
            using ZipArchive archive = ZipFile.Open(path, ZipArchiveMode.Update);
            archive.CreateEntryFromFile(file.Path, newName);
            string newPath = path + "\\" + newName;

            return newPath;
        }

        public string InitStorage(string path, string name)
        {
            string outputFile = path + "\\" + name + ".zip";
            using ZipArchive archive = ZipFile.Open(outputFile, ZipArchiveMode.Create);

            return outputFile;
        }

        public IReadOnlyList<string> GetStorage() => storages;

        public void AddStorage(string storage) => storages.Add(storage);
    }
}