using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Product
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int ProductCount { get; set; }
        public DateTime ExpirationDate { get; set; }

        public Product(string name, float price, int productCount, DateTime expirationDate)
        {
            Name = name;
            Price = price;
            ProductCount = productCount;
            ExpirationDate = expirationDate;
        }
    }

    public class SortProducts
    {
        private delegate void SortDelegate(List<Product> products);
        private Dictionary<string, SortDelegate> sortings;

        public SortProducts()
        {
            sortings = new Dictionary<string, SortDelegate>
            {
                { "name",  SortByName},
                { "price",  SortByPrice},
                { "productCount",  SortByProductCount},
                { "expirationDate",  SortByExpirationDate}
            };
        }

        private void SortByName(List<Product> products)
        {
            for (var i = 0; i < products.Capacity - 1; i++)
            {
                for (var j = i + 1; j < products.Capacity; j++)
                {
                    if (products[i].Name.Length < products[j].Name.Length)
                    {
                        var tmp = products[i];
                        products[i] = products[j];
                        products[j] = tmp;
                    }
                }
            }
        }

        private void SortByPrice(List<Product> products)
        {
            for (var i = 0; i < products.Capacity - 1; i++)
            {
                for (var j = i + 1; j < products.Capacity; j++)
                {
                    if (products[i].Price < products[j].Price)
                    {
                        var tmp = products[i];
                        products[i] = products[j];
                        products[j] = tmp;
                    }
                }
            }
        }

        private void SortByProductCount(List<Product> products)
        {
            for (var i = 0; i < products.Capacity - 1; i++)
            {
                for (var j = i + 1; j < products.Capacity; j++)
                {
                    if (products[i].ProductCount < products[j].ProductCount)
                    {
                        var tmp = products[i];
                        products[i] = products[j];
                        products[j] = tmp;
                    }
                }
            }
        }
        private void SortByExpirationDate(List<Product> products)
        {
            for (var i = 0; i < products.Capacity - 1; i++)
            {
                for (var j = i + 1; j < products.Capacity; j++)
                {
                    if (products[i].ExpirationDate < products[j].ExpirationDate)
                    {
                        var tmp = products[i];
                        products[i] = products[j];
                        products[j] = tmp;
                    }
                }
            }
        }

        public void PerformSorting(string op, List<Product> products)
        {
            if (!sortings.ContainsKey(op))
                throw new ArgumentException($"Operation {op} is invalid");

            sortings[op](products);
            ShowSortedProducts(products, op);
        }

        private void ShowSortedProducts(List<Product> products, string sortedBy)
        {
            Console.WriteLine($"Products sorted by {sortedBy}");
            foreach (var product in products)
            {
                Console.WriteLine(
                    $"Product name: {product.Name}, product price: {product.Price}, product count: {product.ProductCount}, product expiration date: {product.ExpirationDate}");
            }

            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Product("paper", 23, 2, new DateTime(2020, 11, 3)),
                new Product("milk", 15, 6, new DateTime(2020, 9, 11)),
                new Product("bread", 30, 10, new DateTime(2020, 6, 2)),
                new Product("meat", 100, 7, new DateTime(2020, 10, 4))
            };
            SortProducts sortProducts = new SortProducts();
            sortProducts.PerformSorting("name", products);
            sortProducts.PerformSorting("price", products);
            sortProducts.PerformSorting("productCount", products);
            sortProducts.PerformSorting("expirationDate", products);

            Console.ReadKey();
        }
    }
}
