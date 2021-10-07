using System.Collections.Generic;

namespace Shops.People
{
    public class Person
    {
        private string PersonName { get; set; }
        private float Gold { get; set; }
        
        private Dictionary<Product.Product, int> ToBuyList { get; set; }

        public Person(string personName)
        {
            PersonName = personName;
            Gold = 500;
            ToBuyList = null;
        }

        public void AddToList(Product.Product product, int counter)
        {
            ToBuyList.Add(product, counter);
        }

        public Dictionary<Product.Product, int> GetProductList() => ToBuyList;
    }
}