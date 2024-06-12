namespace Backups
{
    public class RestorePoint
    {
        private List<BackupObject> _files;

        public RestorePoint(List<BackupObject> files, DateTime date = default)
        {
            ArgumentNullException.ThrowIfNull(files);

            Date = date == default ? DateTime.Now : date;

            _files = files;
        }

        public DateTime Date { get; }

        public void Add(BackupObject file) => _files.Add(file);

        public IReadOnlyList<BackupObject> ShowFiles() => _files;
    }
}
