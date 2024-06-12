using Shops.Exceptions;

namespace Shops.Entities
{
    public class Shop
    {
        private Dictionary<Product, OrderItem> warehouse = new Dictionary<Product, OrderItem>();
        private double minPrice = 0;

        public Shop(int id, string name, string address)
        {
            ArgumentNullException.ThrowIfNull(id);
            ArgumentNullException.ThrowIfNull(name);
            ArgumentNullException.ThrowIfNull(address);

            if (string.IsNullOrWhiteSpace(name))
                throw new IncorrectNameException("Invalid name");

            Id = id;
            Name = name;
            Address = address;
        }

        public int Id { get; }
        public string Name { get; }
        public string Address { get; }

        public void AddProductsToWarehouse(List<OrderItem> order)
        {
            ArgumentNullException.ThrowIfNull(order);

            foreach (OrderItem item in order)
            {
                if (!warehouse.ContainsKey(item.Product))
                    warehouse.Add(item.Product, item);
                else
                    warehouse[item.Product].ChangeProductAmount(item.Amount);
            }
        }

        public void RemoveProductsFromWarehouse(List<OrderItem> productsList)
        {
            ArgumentNullException.ThrowIfNull(productsList);

            foreach (OrderItem item in productsList)
            {
                if (!warehouse.ContainsKey(item.Product))
                    throw new NonExistentProductException("This product does not exist");

                if (warehouse[item.Product].Amount < item.Amount)
                    throw new LackOfProductException("Not enough product in warehouse");

                warehouse[item.Product].ChangeProductAmount(-item.Amount);
            }
        }

        public void ChangeProductPrice(Product product, double price)
        {
            ArgumentNullException.ThrowIfNull(product);
            ArgumentNullException.ThrowIfNull(price);

            if (price <= minPrice)
                throw new NonPositivePriceException("Price must be positive");

            if (!warehouse.ContainsKey(product))
                throw new NonExistentProductException("This product does not exist");

            warehouse[product].SetProductPrice(price);
        }

        public bool Contains(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);

            return warehouse.ContainsKey(product);
        }

        public bool ContainsList(List<OrderItem> products)
        {
            ArgumentNullException.ThrowIfNull(products);

            return products.All(p => warehouse.ContainsKey(p.Product));
        }

        public double SumPrice(List<OrderItem> products)
        {
            ArgumentNullException.ThrowIfNull(products);

            return products.Sum(p => p.Amount * warehouse[p.Product].Price);
        }

        public double GetProductPrice(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);

            if (!warehouse.ContainsKey(product))
                throw new NonExistentProductException("This product does not exist");

            return warehouse[product].Price;
        }

        public int GetProductAmount(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);

            if (!warehouse.ContainsKey(product))
                throw new NonExistentProductException("This product does not exist");

            return warehouse[product].Amount;
        }
    }
}
