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

        public void SetCounter(double counter)
        {
            ProductCounter += counter;
        }
        
    }
}