using System.Collections.Generic;

namespace Shops.ShopCenter
{
    public interface IService
    {
        void AddProduct(ShopCenter.Shop shop, Product.Product product);
        void AddProducts(ShopCenter.Shop shop, List<Product.Product> products);
        void DeleteProduct(ShopCenter.Shop shop,Product.Product product);
        void DeleteProducts(ShopCenter.Shop shop, List<Product.Product> products);
        
        void ChangePrice(Shop shop, Product.Product product, double newPrice);
        
    }
}
