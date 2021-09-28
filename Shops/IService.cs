namespace Shops
{
    public interface IService
    {
        ShopCenter.Shop AddShop(string shopName, string address);
        Product.Product AddProduct(string productName, float price);
        Product.Product AddProduct(string productName);
        
        Product.Product AddPrice(float price);
        Product.Product DeleteProduct();

        void Deliver();
//        void BuyProduct();
        void DeleteProducts();
        
    }
}