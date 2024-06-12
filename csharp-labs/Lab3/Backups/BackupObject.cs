namespace Backups
{
    public class BackupObject
    {
        public BackupObject(string name, string path)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            Name = name;
            Path = path;
        }

        public string Name { get; }
        public string Path { get; }
    }
}
