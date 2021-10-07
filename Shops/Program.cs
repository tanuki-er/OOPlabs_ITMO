using System.Collections.Generic;
using Shops.People;
using Shops.ShopCenter;

namespace Shops
{
    internal class Program
    {
        private static void Main()
        { 
            var Shop = new Shop("ToyShop","");

            var product1 = new Product.Product("name1");
            var product2 = new Product.Product("name2", 2);
            var product3 = new Product.Product("name3", 3);
            var Product = new Product.Product("");
            
            
            var list = new List<Product.Product>(
                new []
                {
                    new Product.Product("",100,2),
                    new Product.Product("", 110, 3),
                }
            );

            var person = new Person("");
            person.AddToList(product1, 3);
            // = new Dictionary<Product.Product, int>();
            
            //buyingList.Add(product1, 4);
            //buyingList.Add(product2, 5);
            //buyingList.Add(product3, 1);
            //
            list.Add(product1);
            list.Add(product2);
            list.Add(product3);
            
            Shop.AddProduct(Shop, Product);
            Shop.ChangePrice(Shop, Product, 12);
            //Shop.DeleteProducts( Shop, list);
            Shop.AddProducts(Shop, list);

            Shop.BuyProducts(person, Shop, person.GetProductList());
        }
    }
}
