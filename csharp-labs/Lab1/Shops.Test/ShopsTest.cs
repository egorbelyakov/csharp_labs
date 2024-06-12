using Shops.Entities;
using Shops.Tools;
using Xunit;

namespace Shops.Test
{
    public class ShopsTest
    {
        private ShopManager shopManager = new ShopManager();

        [Fact]
        public void AddProductsToShopTest()
        {
            Shop shop = shopManager.AddShop("Bebra", "SPB");
            Product product1 = shopManager.CreateProduct("ifon");
            Product product2 = shopManager.CreateProduct("chapman red");

            var item1 = new OrderItem(product1, 5);
            var item2 = new OrderItem(product2, 10);

            var products = new List<OrderItem> { item1, item2 };

            const double price1 = 10000.0;
            const double price2 = 220.0;
            shopManager.DeliverProductsToShop(shop, products);
            shop.ChangeProductPrice(product1, price1);
            shop.ChangeProductPrice(product2, price2);

            double result1 = shop.GetProductPrice(product1);
            double result2 = shop.GetProductPrice(product2);

            Assert.True(shop.ContainsList(products));
            Assert.Equal(price2, result2);
            Assert.Equal(price1, result1);
        }

        [Fact]
        public void BuyProductsTest()
        {
            const double startBalance = 20000.0;
            var customer = new Customer("Person", startBalance);

            Shop shop = shopManager.AddShop("Bebra", "SPB");
            Product product1 = shopManager.CreateProduct("ifon");
            Product product2 = shopManager.CreateProduct("chapman red");

            var item1 = new OrderItem(product1, 5);
            var item2 = new OrderItem(product2, 10);
            var products = new List<OrderItem> { item1, item2 };

            const double price1 = 10000.0;
            const double price2 = 220.0;
            shopManager.DeliverProductsToShop(shop, products);
            shop.ChangeProductPrice(product1, price1);
            shop.ChangeProductPrice(product2, price2);
            int startAmount1 = shop.GetProductAmount(product1);
            int startAmount2 = shop.GetProductAmount(product2);

            var orderItem1 = new OrderItem(product1, 1);
            var orderItem2 = new OrderItem(product2, 3);
            var order = new List<OrderItem> { orderItem1, orderItem2 };

            shopManager.Purchase(order, shop, customer);

            int resultAmount1 = shop.GetProductAmount(product1);
            int resultAmount2 = shop.GetProductAmount(product2);
            double result = startBalance - (shop.GetProductPrice(product1) * orderItem1.Amount) + (shop.GetProductPrice(product2) * orderItem2.Amount);

            Assert.NotEqual(startBalance, result);
            Assert.NotEqual(startAmount1, resultAmount1);
            Assert.NotEqual(startAmount2, resultAmount2);
        }

        [Fact]
        public void ChangePriceTest()
        {
            Shop shop = shopManager.AddShop("Bebra", "SPB");
            Product product = shopManager.CreateProduct("ifon");
            var item = new OrderItem(product, 5);
            var products = new List<OrderItem> { item };
            const double price1 = 10000.0;
            const double price2 = 12000.0;

            shopManager.DeliverProductsToShop(shop, products);
            shop.ChangeProductPrice(product, price1);
            shop.ChangeProductPrice(product, price2);

            Assert.NotEqual(price1, price2);
        }

        [Fact]
        public void FindCheapestShop()
        {
            Shop shop1 = shopManager.AddShop("Bebra", "SPB");
            Shop shop2 = shopManager.AddShop("Magaz", "SPB");
            Product product1 = shopManager.CreateProduct("p1");
            Product product2 = shopManager.CreateProduct("p2");

            var item1 = new OrderItem(product1, 5);
            var item2 = new OrderItem(product2, 5);
            var item3 = new OrderItem(product1, 6);
            var item4 = new OrderItem(product2, 6);

            var order1 = new List<OrderItem> { item1, item2 };
            var order2 = new List<OrderItem> { item3, item4 };

            const double price1 = 12000.0;
            const double price2 = 9000.0;
            const double price3 = 13000.0;

            shopManager.DeliverProductsToShop(shop1, order1);
            shopManager.DeliverProductsToShop(shop2, order2);
            shop1.ChangeProductPrice(product1, price1);
            shop1.ChangeProductPrice(product2, price1);
            shop2.ChangeProductPrice(product1, price2);
            shop2.ChangeProductPrice(product2, price3);

            var testList = new List<OrderItem>();
            var testOrder1 = new OrderItem(product1, 2);
            var testOrder2 = new OrderItem(product2, 3);

            testList.Add(testOrder1);
            testList.Add(testOrder2);

            Shop result = shopManager.FindShopWithMinPrice(testList);
            Assert.Equal(result.Id, shop2.Id);
        }
    }
}
