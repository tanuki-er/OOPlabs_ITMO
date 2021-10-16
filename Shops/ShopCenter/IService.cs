using System.Collections.Generic;

namespace Shops.ShopCenter
{
    public interface IService
    {
        void AddProduct(ShopCenter.Shop shop, Product.Product product);
        void AddProducts(ShopCenter.Shop shop, List<Product.Product> products);
        void DeleteProduct(ShopCenter.Shop shop, Product.Product product);
        void ChangePrice(ShopCenter.Shop shop, Product.Product product, double newPrice);
        double GetPrice(Product.Product product);
        public Shop FindProduct(Product.Product product);
        public void BuyProducts(People.Person person, Shop shop, List<Product.Product> products);
    }
}
