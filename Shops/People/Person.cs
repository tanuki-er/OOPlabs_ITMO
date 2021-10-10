﻿using System.Collections.Generic;

namespace Shops.People
{
    public class Person
    {
        public Person(string personName)
        {
            PersonName = personName;
            Gold = 500;
            ToBuyList = null;
        }

        private string PersonName { get; set; }
        private double Gold { get; set; }
        private List<Product.Product> ToBuyList { get; set; }
        public void AddToList(Product.Product product)
        {
            ToBuyList.Add(product);
        }

        public List<Product.Product> GetProductList() => ToBuyList;
        public double GetGold(Person person) => person.Gold;
        public void SetGold(double gold)
        {
            Gold = gold;
        }
    }
}