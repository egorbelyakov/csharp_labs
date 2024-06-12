using Shops.Entities;

namespace Shops.Tools
{
    public interface IShopManager
    {
        Shop AddShop(string name, string address);
        Product CreateProduct(string name);
        void Purchase(List<OrderItem> order, Shop shop, Customer customer);
        void DeliverProductsToShop(Shop shop, List<OrderItem> order);
        Shop FindShopWithMinPrice(List<OrderItem> products);
    }
}
