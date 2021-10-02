using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

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
        

        public void ChangePrice(Product.Product product, float newPrice)
        {
            product.SetPrice(product, newPrice);
        }

        public void DeleteProduct(Product.Product product)
        {
            foreach (Product.Product variable in Dictionary.Values)
            {
                //if (Dictionary.ContainsValue(product)) Dictionary.Count();//
            }
            //можно не удалять, а счётчик поставить на 0
        }

        public void AddProducts(List<Product.Product> products)
        {
            
            // отсюда до эд, добавлять их поштучно
        }

        public void DeleteProducts(List<Product.Product> products)
        {
            foreach (Product.Product variable in products)
            {
                if (Dictionary.ContainsValue(variable))
                {
                    DeleteProduct(variable);
                }
            }
        }
    }
}