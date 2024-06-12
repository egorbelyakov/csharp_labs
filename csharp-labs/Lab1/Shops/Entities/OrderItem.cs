using Shops.Exceptions;

namespace Shops.Entities
{
    public class OrderItem
    {
        private double minPrice = 1;
        private int minAmount = 1;

        public OrderItem(Product product, int amount)
        {
            ArgumentNullException.ThrowIfNull(product);

            if (amount < minAmount)
                throw new IncorrectAmountException("Negative amount error");

            Product = product;
            Amount = amount;
        }

        public Product Product { get; }
        public int Amount { get; private set; }
        public double Price { get; private set; }

        public void ChangeProductAmount(int amount)
        {
            ArgumentNullException.ThrowIfNull(amount);

            Amount += amount;
        }

        public void SetProductPrice(double price)
        {
            ArgumentNullException.ThrowIfNull(price);

            if (price < minPrice)
                throw new NonPositivePriceException("Price must be positive");

            Price = price;
        }
    }
}
