using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBuildWPFAPP.models
{
    public class SampleDataSet
    {
        public static Dictionary<int, Category> GenerateDataset()
        {
            Dictionary<int, Category> categories = new Dictionary<int, Category>();
            Category c1 = new Category() { Id = 1, Name = "Nước ngọt" };
            Category c2 = new Category() { Id = 2, Name = "Bia" };
            Category c3 = new Category() { Id = 3, Name = "Thức Ăn Nhanh" };
            categories.Add(c1.Id, c1);
            categories.Add(c2.Id, c2);
            categories.Add(c3.Id, c3);
            Product p1 = new Product() { Quantity = 10, Id = 1, Name = "Pepsi", Price = 10000 };
            Product p2 = new Product() { Quantity = 20, Id = 2, Name = "Coca Cola", Price = 12000 };
            Product p3 = new Product() { Quantity = 15, Id = 3, Name = "7Up", Price = 11000 };
            Product p4 = new Product() { Quantity = 5, Id = 4, Name = "Sting", Price = 15000 };
            Product p5 = new Product() { Quantity = 8, Id = 5, Name = "RedBull", Price = 20000 };
            Product p6 = new Product() { Quantity = 12, Id = 6, Name = "Sài Gòn", Price = 50000 };
            Product p7 = new Product() { Quantity = 6, Id = 7, Name = "Heiniken", Price = 60000 };
            Product p8 = new Product() { Quantity = 4, Id = 8, Name = "Tiger", Price = 55000 };
            Product p9 = new Product() { Quantity = 3, Id = 9, Name = "Strong Bow", Price = 70000 };
            Product p10 = new Product() { Quantity = 2, Id = 10, Name = "Lagger", Price = 75000 };
            Product p11 = new Product() { Quantity = 1, Id = 11, Name = "Hamburger", Price = 65000 };
            Product p12 = new Product() { Quantity = 9, Id = 12, Name = "Pizza", Price = 80000 };
            Product p13 = new Product() { Quantity = 7, Id = 13, Name = "Tacos", Price = 70000 };
            Product p14 = new Product() { Quantity = 11, Id = 14, Name = "Chicken", Price = 60000 };
            Product p15 = new Product() { Quantity = 13, Id = 15, Name = "Buritos", Price = 55000 };
            c1.Products.Add(p1.Id, p1);
            c1.Products.Add(p2.Id, p2);
            c1.Products.Add(p3.Id, p3);
            c1.Products.Add(p4.Id, p4);
            c1.Products.Add(p5.Id, p5);
            c2.Products.Add(p6.Id, p6);
            c2.Products.Add(p7.Id, p7);
            c2.Products.Add(p8.Id, p8);
            c2.Products.Add(p9.Id, p9);
            c2.Products.Add(p10.Id, p10);
            c3.Products.Add(p11.Id, p11);
            c3.Products.Add(p12.Id, p12);
            c3.Products.Add(p13.Id, p13);
            c3.Products.Add(p14.Id, p14);
            c3.Products.Add(p15.Id, p15);
            return categories;
        }
    }
}
