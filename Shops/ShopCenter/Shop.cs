using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Shops.ShopCenter
{
    public class Shop : IService
    {
        private Guid ShopId { get; set; }
        private string ShopName { get; set; }
        private string Address { get; set; }
        private Dictionary<Shop, Product.Product> Dictionary { get; }

        public Shop(string shopName, string address)
        {
            ShopId = Guid.NewGuid();
            ShopName = shopName;
            Address = address;
            Dictionary = new Dictionary<Shop, Product.Product>();
        }

        public void AddShop(Shop shop)
        {
            Dictionary.Add(shop, null);
        }

        public void AddProduct(Shop shop, Product.Product product)
        {

            foreach (var VARIABLE in Dictionary)
            {
                if (shop == VARIABLE.Key)
                    Dictionary.Add(shop, product);
            }

            //throw new Exception("Shop wasn't add to dictionary");
            // try|catch . . .  
        }
        

        public void ChangePrice(Product.Product product, float newPrice)
        {
            product.ChangePrice(product, newPrice);
        }

        public void DeleteProduct(Product.Product product)
        {
            foreach (var VARIABLE in Dictionary.Values)
            {
                if (Dictionary.ContainsValue(product)) Dictionary.Count();//
            }
            
        }

        public void AddProducts(List<Product.Product> products)
        {
            
            // отсюда до эд, добавлять их поштучно
        }

        public void DeleteProducts(List<Product.Product> products)
        {
            foreach (var VARIABLE in products)
            {
                if (Dictionary.ContainsValue(VARIABLE))
                {
                    DeleteProduct(VARIABLE);
                }
            }
        }
    }
}