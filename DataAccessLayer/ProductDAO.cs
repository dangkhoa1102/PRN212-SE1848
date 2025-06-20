using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject; // Assuming BusinessObject namespace contains Customer class
namespace DataAccessLayer
{
    public class ProductDAO
    {
        static List<Product> products = new List<Product>();
        public void GenerateSampleDataset()
        {
            products.Add(new Product { Id = 1, Name = "Laptop", Quantity = 10, Price = 999.99 });
            products.Add(new Product { Id = 2, Name = "Smartphone", Quantity = 20, Price = 499.99 });
            products.Add(new Product { Id = 3, Name = "Tablet", Quantity = 15, Price = 299.99 });
            products.Add(new Product { Id = 4, Name = "Monitor", Quantity = 5, Price = 199.99 });
            products.Add(new Product { Id = 5, Name = "Keyboard", Quantity = 30, Price = 49.99 });
        }
        public List<Product> GetProducts()
        {
            if (products.Count == 0)
            {
                GenerateSampleDataset();
            }
            return products;
        }
        public bool SaveProduct(Product product)
        {
            Product old = products.FirstOrDefault(p => p.Id == product.Id);
            if (old != null)
            {
                return false; // Product with the same ID already exists
            }
            else
            {
                products.Add(product);
            }
            return true; // Product added successfully
        }
    }
}
