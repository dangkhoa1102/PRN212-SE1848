﻿using BusinessObject;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository iProductRepository;
        public ProductService()
        {
            iProductRepository = new ProductRepository();
        }
        public void GenerateSampleDataset()
        {
            iProductRepository.GenerateSampleDataset();
        }

        public List<Product> GetProducts()
        {
            return iProductRepository.GetProducts();
        }

        public bool SaveProduct(Product product)
        {
            return iProductRepository.SaveProduct(product);
        }
        public bool UpdateProduct(Product product)
        {
            return iProductRepository.UpdateProduct(product);
        }
        public Product GetProdct(int id)
        {
            return iProductRepository.GetProdct(id);
        }
        public bool DeleteProduct(int id)
        {
            return iProductRepository.DeleteProduct(id);
        }
        public bool DeleteProduct(Product product)
        {
            return iProductRepository.DeleteProduct(product);
        }
    }
}
