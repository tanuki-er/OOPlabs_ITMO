using System.Collections.Generic;
using Shops.ShopCenter;

namespace Shops
{
    public class Service //: IService
    {
        private Dictionary<ShopCenter.Shop, Product.Product> _dictionary { get; set; }

        public Shop AddShop(string shopName, string address) => new Shop(shopName, address);

        
        public Product.Product AddProduct(string productName, float price)
        {
            throw new System.NotImplementedException();//если дают цену, ставим по ней
        }

        public Product.Product AddProduct(string productName)
        {
            throw new System.NotImplementedException(); // если цены нет, ставим 1.3 от цены поставки
        }

        public Product.Product AddPrice(float price)
        {
            throw new System.NotImplementedException(); // поменять цену
        }

        public Product.Product DeleteProduct()
        {
            throw new System.NotImplementedException(); // удалить продукт(купили/списали)
        }

        public void Deliver()
        {
            throw new System.NotImplementedException(); // доставка
        }

        public void DeleteProducts()
        {
            throw new System.NotImplementedException(); //  удалить/списать несколько товаров 
        }
    }
}