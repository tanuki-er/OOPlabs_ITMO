using System.Collections.Generic;
using Shops.ShopCenter;

namespace Shops
{
    internal class Program
    {
        private static void Main()
        { 
            var Shop = new Shop("","");

            var product1 = new Product.Product("name1");
            var product2 = new Product.Product("name2", 2);
            var product3 = new Product.Product("name3", 3);

            var list = new List<Product.Product>();
            list.Add(product1);
            list.Add(product2);
            list.Add(product3);
            var Product = new Product.Product("");
            Shop.AddProduct(Shop, Product);
            Shop.ChangePrice(Product, 12);
            Shop.DeleteProducts(list);
            Shop.AddProducts(list);
        }
    }
}
