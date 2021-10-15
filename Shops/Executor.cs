using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Shops.People;
using Shops.ShopCenter;

namespace Shops
{
    public class Executor : IService
    {
        private Guid ShopId { get; set; }
        private string ShopName { get; set; }
        private string Address { get; set; }
        private Dictionary<Shop, Product.Product> Dictionary { get; } = new Dictionary<Shop, Product.Product>();
        public void AddProduct(Shop shop, Product.Product product)
        {
            foreach (KeyValuePair<Shop, Product.Product> variable in Dictionary)
            {
                if (variable.Key == shop && variable.Value.Equals(product))
                {
                    variable.Value.SetCounter(variable.Value.GetCounter(variable.Value) +
                                              product.GetCounter(product)); // old+new
                }
                else if (variable.Key == shop && !variable.Value.Equals(product))
                {
                    Dictionary.Add(shop, product);
                }
            }
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
                if (shop == variable.Key && variable.Value.Equals(product))
                {
                    product.SetPrice(product, newPrice);
                }
            }
        }

        public double GetPrice(Product.Product product)
        {
            foreach (KeyValuePair<Shop, Product.Product> variable in Dictionary)
            {
                if (variable.Value == product)
                    return variable.Value.GetPrice(variable.Value);
            }

            return 0;
        }

        public void DeleteProduct(Shop shop, Product.Product product)
        {
            foreach (KeyValuePair<Shop, Product.Product> variable in Dictionary)
            {
                if (variable.Key == shop && variable.Value.Equals(product)) variable.Value.SetCounter(0);
                else throw new Exception("Shop name is incorrect or this shop didnt equals product");
            }
        }

        public Shop FindProduct(Product.Product product)
        {
            var returnProduct = new Product.Product(" ", 0);
            var returnShop = new Shop(null, null);
            foreach (KeyValuePair<Shop, Product.Product> variable in Dictionary)
            {
                if (variable.Value.Equals(product) && product.GetCounter(product) > variable.Value.GetCounter(variable.Value))
                    throw new Exception("not enough products");
                if (variable.Value.Equals(product) && returnProduct == null)
                    returnProduct = variable.Value;
                if (variable.Value.Equals(product) && returnProduct != null)
                {
                    if (variable.Value.GetPrice(variable.Value) < returnProduct.GetPrice(returnProduct))
                    {
                        returnProduct = variable.Value;
                        returnShop = variable.Key;
                    }
                }
            }

            if (returnProduct.GetCounter(returnProduct) != 0)
                return returnShop;
            throw new Exception("this product isn't founded");
        }

        public void BuyProducts(Person person, Shop shop, List<Product.Product> products)
        {
            double totalPrice = 0;
            foreach (Product.Product v1 in products)
            {
                foreach (KeyValuePair<Shop, Product.Product> v2 in Dictionary)
                {
                    if ((shop == v2.Key) && (v1 == v2.Value) && (v1.GetCounter(v1) <= v2.Value.GetCounter(v2.Value)))
                    {
                        totalPrice += v2.Value.GetPrice(v2.Value);
                    }
                }
            }

            if (totalPrice > person.GetGold(person)) throw new Exception("We don't have much money ");
            foreach (Product.Product v1 in products)
            {
                foreach (KeyValuePair<Shop, Product.Product> v2 in Dictionary)
                {
                    if ((shop == v2.Key) && (v1 == v2.Value) && (v1.GetCounter(v1) <= v2.Value.GetCounter(v2.Value)))
                    {
                        DeleteProduct(shop, v1);
                    }
                }
            }

            person.SetGold(person.GetGold(person) - totalPrice);
        }
    }
}