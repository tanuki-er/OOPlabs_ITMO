using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Shops.People;

namespace Shops.ShopCenter
{
    public class Shop : IService
    {
        public Shop(string shopName, string address)
        {
            ShopId = Guid.NewGuid();
            ShopName = shopName;
            Address = address;
            Dictionary = new Dictionary<Shop, Product.Product>();
        }

        private Guid ShopId { get; set; }
        private string ShopName { get; set; }
        private string Address { get; set; }
        private Dictionary<Shop, Product.Product> Dictionary { get; }
        
        
        public void AddProduct(Shop shop, Product.Product product)
        {
            foreach (KeyValuePair<Shop, Product.Product> variable in Dictionary)
            {
                if ((variable.Key == shop) && (variable.Value.Equals(product)))
                {
                    variable.Value.SetCounter(variable.Value.GetCounter(variable.Value) + product.GetCounter(product)); // old+new
                    break;
                }
            }
            Dictionary.Add(shop, product);
        }
        public void AddProducts(Shop shop, List<Product.Product> products)
        { 
            foreach (Product.Product variable in products) 
            { 
                AddProduct(shop, variable);
            }
        }

        public void ChangePrice(Shop shop, Product.Product product, double newPrice)
        {
            foreach (KeyValuePair<Shop, Product.Product> variable in Dictionary)
            {
                if ((shop == variable.Key) && (variable.Value.Equals(product)))
                {
                    product.SetPrice(product, newPrice);
                }
            }
        }

        public void DeleteProduct(Shop shop,Product.Product product)
        {
            foreach (KeyValuePair<Shop, Product.Product> variable in Dictionary)
            {
                if ((variable.Key == shop) && (variable.Value.Equals(product))) product.SetCounter(0);
                else throw new Exception("Shop name is incorrect or this shop didnt equals product");
            }
        }
        public void DeleteProducts(Shop shop, List<Product.Product> products)
        {
            foreach (Product.Product variable in products)
            {
                DeleteProduct(shop, variable);
            }
        }

        public Shop FindProduct(Product.Product product)
        {
            var returnProduct = new Product.Product(null);
            var returnShop = new Shop(null, null);
            foreach (KeyValuePair<Shop, Product.Product> variable in Dictionary)
            {
                if (variable.Value.Equals(product) && returnProduct == null) returnProduct = variable.Value;
                if (variable.Value.Equals(product) && returnProduct != null)
                {
                    if (variable.Value.GetPrice(variable.Value) < returnProduct.GetPrice(returnProduct))
                    {
                        returnProduct = variable.Value;
                        returnShop = variable.Key;
                    }
                }
            }
            if (returnProduct != null) return returnShop;
                throw new Exception("this product isn't founded");
        }

        public Shop BuyProducts(Person person, Shop shop, Dictionary<Product.Product, int> products)
        {
            foreach (var VARIABLE in products)
            {
                //
            }
            return null;
        }
        
    }
}