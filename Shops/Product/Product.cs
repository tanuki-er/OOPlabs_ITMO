using System;

namespace Shops.Product
{
    public class Product
    {
        
        public Product(string productName, double productPrice) 
        { 
            ProductId = Guid.NewGuid(); 
            ProductName = productName; 
            ProductCounter = 1; 
            ProductPrice = productPrice;
        }
        public Product(string productName, double productPrice, double productCounter)
        {
            ProductId = Guid.NewGuid(); 
            ProductName = productName; 
            ProductCounter = productCounter; 
            ProductPrice = productPrice;
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