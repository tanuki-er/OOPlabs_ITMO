using System;

namespace Shops.Product
{
    public class Product
    {
        private Guid ProductId { get; set; }
        private string ProductName { get; set; }
        private double ProductCounter { get; set; }
        private float ProductPrice { get; set; }

        public Product(string productName, float productPrice)
        {
            ProductId = Guid.NewGuid();
            ProductName = productName;
            ProductCounter = 1;
            ProductPrice = productPrice;
        }
        
        public Product(string productName)
        {
            ProductId = Guid.NewGuid();
            ProductName = productName;
            ProductCounter = 1;
            ProductPrice = 0;
        }
        
        public void SetCounter(double counter)
        {
            ProductCounter += counter;
        }

        public void SetPrice(Product product, float newPrice)
        {
            product.ProductPrice = newPrice;
        }

        public float GetPrice(Product product) => product.ProductPrice;
        public string GetProductName(Product product) => product.ProductName;
        public double GetCounter(Product product) => product.ProductCounter;
    }
}