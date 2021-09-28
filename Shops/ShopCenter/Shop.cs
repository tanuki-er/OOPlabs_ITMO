using System;
using System.Collections.Generic;
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


        public Shop AddShop(string shopName, string address) => new Shop(shopName, address);


        public Product.Product AddProduct(string productName, float price)
        {
            throw new NotImplementedException();
        }

        public Product.Product AddProduct(string productName)
        {
            throw new NotImplementedException();
        }

        public Product.Product AddPrice(float price)
        {
            throw new NotImplementedException();
        }

        public Product.Product DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public void Deliver()
        {
            throw new NotImplementedException();
        }

        public void DeleteProducts()
        {
            throw new NotImplementedException();
        }
    }
}