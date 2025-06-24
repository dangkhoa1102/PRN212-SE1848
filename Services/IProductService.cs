using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {
        public void GenerateSampleDataset();
        public List<Product> GetProducts();
        public bool SaveProduct(Product product);
        public bool UpdateProduct(Product product);
        public Product GetProdct(int id);
        public bool DeleteProduct(int id);
        public bool DeleteProduct(Product product);
    }
}
