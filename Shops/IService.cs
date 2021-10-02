using System.Collections.Generic;

namespace Shops
{
    public interface IService
    {
        //void AddShop(ShopCenter.Shop shop);
        //ShopCenter.Shop CreateShop(string name, string address);
        void AddProduct(ShopCenter.Shop shop, Product.Product product);
        //Product.Product AddProduct(string productName);
        
        void ChangePrice(Product.Product product, float newPrice);
        
        
        void DeleteProduct(Product.Product product);
        void AddProducts(List<Product.Product> products);
//        void BuyProduct(); 
        void DeleteProducts(List<Product.Product> products);
        
    }
}
