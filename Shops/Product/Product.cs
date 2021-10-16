using System;

namespace Shops.Product
{
    public class Product
    {
        public Product(string productName, double productPrice, double productCounter)
        {
            ThisProduct = new Product(productName, productCounter);
            ProductPrice = productPrice;
        }

        public Product(string productName, double productCounter)
        {
            ThisProduct = new Product(productName);
            ProductCounter = productCounter;
        }

        public Product(string productName)
        {
            ProductId = Guid.NewGuid();
            ProductName = productName;
            ProductCounter = 1;
            ProductPrice = 0;
        }

        private Guid ProductId { get; set; }
        private string ProductName { get; set; }
        private double ProductCounter { get; set; }
        private double ProductPrice { get; set; }
        private Product ThisProduct { get; set; }

        public void SetCounter(double counter)
        {
            ProductCounter += counter;
        }

        public void SetPrice(Product product, double newPrice)
        {
            product.ProductPrice = newPrice;
        }

        public double GetPrice(Product product) => product.ProductPrice;
        public string GetProductName(Product product) => product.ProductName;
        public double GetCounter(Product product) => product.ProductCounter;
    }
}