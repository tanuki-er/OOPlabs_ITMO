using System;
using System.Collections.Generic;
using Shop;
using Shops.People;
using Shops.ShopCenter;

namespace Shops
{
    public class Executor : IService
    {
        private Guid ShopId { get; set; }
        private string ShopName { get; set; }
        private string Address { get; set; }
        private Dictionary<ShopCenter.Shop, Product.Product> Dictionary { get; } = new Dictionary<ShopCenter.Shop, Product.Product>();

        public void AddProduct(ShopCenter.Shop shop, Product.Product product)
        {
            foreach (KeyValuePair<ShopCenter.Shop, Product.Product> variable in Dictionary)
            {
                if (variable.Key == shop && variable.Value.Equals(product))
                {
                    variable.Value.SetCounter(variable.Value.GetCounter(variable.Value) +
                                              product.GetCounter(product));
                }
                else if (variable.Key == shop && !variable.Value.Equals(product))
                {
                    Dictionary.Add(shop, product);
                }
            }
        }

        public void AddProducts(ShopCenter.Shop shop, List<Product.Product> products)
        {
            foreach (Product.Product variable in products)
            {
                AddProduct(shop, variable);
            }
        }

        public void ChangePrice(ShopCenter.Shop shop, Product.Product product, double newPrice)
        {
            foreach (KeyValuePair<ShopCenter.Shop, Product.Product> variable in Dictionary)
            {
                if (shop == variable.Key && variable.Value.Equals(product))
                {
                    product.SetPrice(product, newPrice);
                }
            }
        }

        public double GetPrice(Product.Product product)
        {
            foreach (KeyValuePair<ShopCenter.Shop, Product.Product> variable in Dictionary)
            {
                if (variable.Value.Equals(product))
                    return variable.Value.GetPrice(variable.Value);
            }

            return 0;
        }

        public void DeleteProduct(ShopCenter.Shop shop, Product.Product product)
        {
            foreach (KeyValuePair<ShopCenter.Shop, Product.Product> variable in Dictionary)
            {
                if (variable.Key == shop && variable.Value.Equals(product)) variable.Value.SetCounter(0);
                else throw new ShopException("Shop name is incorrect or this shop didnt equals product");
            }
        }

        public ShopCenter.Shop FindProduct(Product.Product product)
        {
            var returnProduct = new Product.Product(" ", 0);
            var returnShop = new ShopCenter.Shop(null, null);
            foreach (KeyValuePair<ShopCenter.Shop, Product.Product> variable in Dictionary)
            {
                if (variable.Value.Equals(product) && product.GetCounter(product) > variable.Value.GetCounter(variable.Value))
                    throw new ShopException("not enough products");
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
            throw new ShopException("this product isn't founded");
        }

        public void BuyProducts(Person person, ShopCenter.Shop shop, List<Product.Product> products)
        {
            double totalPrice = 0;
            foreach (Product.Product v1 in products)
            {
                foreach (KeyValuePair<ShopCenter.Shop, Product.Product> v2 in Dictionary)
                {
                    if ((shop == v2.Key) && (v1 == v2.Value) && (v1.GetCounter(v1) <= v2.Value.GetCounter(v2.Value)))
                    {
                        totalPrice += v2.Value.GetPrice(v2.Value);
                    }
                }
            }

            if (totalPrice > person.GetGold(person)) throw new ShopException("We don't have much money ");
            foreach (Product.Product v1 in products)
            {
                foreach (KeyValuePair<ShopCenter.Shop, Product.Product> v2 in Dictionary)
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