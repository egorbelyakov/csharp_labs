using Shops.Exceptions;

namespace Shops.Entities
{
    public class Product
    {
        public Product(string name)
        {
            ArgumentNullException.ThrowIfNull(name);

            if (string.IsNullOrWhiteSpace(name))
                throw new IncorrectNameException("Invalid name");

            Name = name;
        }

        public string Name { get; }
    }
}
