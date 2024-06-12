using Isu.Exceptions;

namespace Isu.Extra.Entities
{
    public class Ognp
    {
        private List<OgnpStream> streams = new List<OgnpStream>();

        public Ognp(string name, char faculty)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidNameException("Invalid name");

            ArgumentNullException.ThrowIfNull(faculty);

            streams = new List<OgnpStream>();
            Name = name;
            Faculty = faculty;
        }

        public string Name { get; }
        public char Faculty { get; }

        public void AddStream(OgnpStream ognpStream)
        {
            ArgumentNullException.ThrowIfNull(ognpStream);

            streams.Add(ognpStream);
        }

        public IReadOnlyList<OgnpStream> ShowStreams() => streams;
    }
}
