using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Repositories;

namespace Repositories
{
    public interface IProductRepository
    {
        public void GenerateSampleDataset();
        public List<Product> GetProducts();
        public bool SaveProduct(Product product);
    }
}
