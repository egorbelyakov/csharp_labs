using Shops.Entities;
using Shops.Exceptions;

namespace Shops.Tools
{
    public class ShopManager : IShopManager
    {
        private readonly List<Product> productsBase = new List<Product>();
        private readonly List<Shop> shopsBase = new List<Shop>();
        private int currentId = 0;
        private int minCount = 1;

        public Shop AddShop(string name, string address)
        {
            ArgumentNullException.ThrowIfNull(name);
            ArgumentNullException.ThrowIfNull(address);

            var shop = new Shop(currentId, name, address);
            currentId++;
            shopsBase.Add(shop);

            return shop;
        }

        public Product CreateProduct(string name)
        {
            ArgumentNullException.ThrowIfNull(name);

            var product = new Product(name);
            productsBase.Add(product);

            return product;
        }

        public void DeliverProductsToShop(Shop shop, List<OrderItem> order)
        {
            ArgumentNullException.ThrowIfNull(shop);
            ArgumentNullException.ThrowIfNull(order);

            foreach (OrderItem product in order)
            {
                if (product.Amount < minCount)
                    throw new IncorrectAmountException("Amount must be > 0");
            }

            shop.AddProductsToWarehouse(order);
        }

        public void Purchase(List<OrderItem> order, Shop shop, Customer customer)
        {
            ArgumentNullException.ThrowIfNull(shop);
            ArgumentNullException.ThrowIfNull(order);
            ArgumentNullException.ThrowIfNull(customer);

            if (!shopsBase.Exists(x => x.Id == shop.Id))
                throw new NonExistentShopException($"This shop does not exist");

            double sumPrice = 0;

            foreach (OrderItem product in order)
            {
                if (product.Amount < minCount)
                    throw new IncorrectAmountException("Negative amount error");

                if (!productsBase.Exists(x => x.Name == product.Product.Name))
                    throw new NonExistentProductException($"Product {product.Product.Name} does not exist");

                if (!shop.Contains(product.Product))
                    throw new ProductNotFoundException("Product is not found");

                if (product.Amount > shop.GetProductAmount(product.Product))
                    throw new LackOfProductException("Lack of product error");

                sumPrice += shop.GetProductPrice(product.Product) * product.Amount;
            }

            if (sumPrice > customer.Balance)
                throw new InsufficientBalanceException("You do not have enough money");

            shop.RemoveProductsFromWarehouse(order);
            customer.Payment(sumPrice);
        }

        public Shop FindShopWithMinPrice(List<OrderItem> products)
        {
            ArgumentNullException.ThrowIfNull(products);

            Shop res = null;
            double min = 1000000000;

            foreach (Shop shop in shopsBase.Where(shop => shop.ContainsList(products) && shop.SumPrice(products) < min))
            {
                min = shop.SumPrice(products);
                res = shop;
            }

            return res ?? throw new ProductNotFoundException($"Product list not found");
        }
    }
}