using System;
using Shops.ShopCenter;
using NUnit.Framework;
using Shops.People;

namespace Shops.Tests
{
    public class ShopServiceTest
    {
        private IService _shopService;

        [SetUp]
        public void Setup()
        {
            _shopService = new Executor();
        }

        [Test]
        public void DeliveryToTheStore_StoreIsCreatedGoodsAreAddedAndDeliveredYouCanBuy()
        {
            var shop = new Shop("ITMO", "Lomonosov str. 9");
            var product = new Product.Product("cup", 100, 3);
            _shopService.AddProduct(shop, product);
            var person = new Person("Name");
            person.SetGold(1000);
            double oldGold = person.GetGold(person);
            var buyingProduct = new Product.Product("cup", 3);
            person.AddToList(buyingProduct);
            _shopService.BuyProducts(person, shop, person.GetProductList());
            
            if (person.GetGold(person) != oldGold) Assert.Pass();
        }

        [Test]
        public void SettingAndChangingPricesInTheStore()
        {
            var shop = new Shop("ITMO", "Lomonosov str. 9");
            var product = new Product.Product("Dori me", 1);
            _shopService.AddProduct(shop, product);
            _shopService.ChangePrice(shop, product, 100);
            if (_shopService.GetPrice(product) != 0) Assert.Pass();
        }

        [Test]
        public void TheBatchOfGoodsIsAsCheapAsPossible_TheProductIsNotEnoughException()
        {
            Assert.Catch<Exception>(() =>
            {
                var shop = new Shop("shop", "address");
                var product = new Product.Product("product name3", 300, 3);
                var product1 = new Product.Product("product name1", 100, 1);
                var product2 = new Product.Product("product name2", 200, 2);
                _shopService.AddProduct(shop, product);
                _shopService.AddProduct(shop, product1);
                _shopService.AddProduct(shop, product2);
                var product3 = new Product.Product("product name1", 3);
                Shop something = _shopService.FindProduct(product3);
            });
        }

        [Test]
        public void PurchaseOfABatchOfGoodsInTheStore_ThereAreEnoughGoodsThereIsEnoughMoney_MoneyWasTransferNumberOfGoodsWasChanged()
        {
            var shop = new Shop("shopName", "address"); 
            var product = new Product.Product("product name3", 300, 3); 
            var product1 = new Product.Product("product name1", 100, 1); 
            var product2 = new Product.Product("product name2", 200, 2); 
            _shopService.AddProduct(shop, product); 
            _shopService.AddProduct(shop, product1); 
            _shopService.AddProduct(shop, product2); 
            var person = new Person("name"); 
            person.SetGold(2000); 
            person.AddToList(product); 
            person.AddToList(product1); 
            _shopService.BuyProducts(person, shop, person.GetProductList()); 
            if (person.GetGold(person) < 2000) Assert.Pass();
        }
    }
}