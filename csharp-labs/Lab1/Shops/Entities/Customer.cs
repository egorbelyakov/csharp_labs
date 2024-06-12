using Shops.Exceptions;

namespace Shops.Entities
{
    public class Customer
    {
        private double minBalance = 0;
        private double minPrice = 1;

        public Customer(string name, double balance)
        {
            ArgumentNullException.ThrowIfNull(balance);
            ArgumentNullException.ThrowIfNull(name);

            if (balance < minBalance)
                throw new NegativeBalanceException("Incorrect balance");

            Name = name;
            Balance = balance;
        }

        public string Name { get; }
        public double Balance { get; private set; }

        public void Payment(double price)
        {
            ArgumentNullException.ThrowIfNull(price);

            if (price <= minPrice)
                throw new NonPositivePriceException("Price must be positive");

            if (price > Balance)
                throw new InsufficientBalanceException("You do not have enough money to buy it");

            Balance -= price;
        }
    }
}
