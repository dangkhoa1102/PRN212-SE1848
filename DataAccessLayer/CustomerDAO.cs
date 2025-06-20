using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using System.Collections.ObjectModel;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        static List<Customer> customers = new List<Customer>();
        public void GenerateSampleDataset()
        {
            customers.Add(new Customer { ID = 1, Name = "John Doe", Email = "Test@gmail.com", Phone = "1234567890" });
            customers.Add(new Customer { ID = 2, Name = "Jane Smith", Email = "Jane@gmail.com", Phone = "12345" });
            customers.Add(new Customer { ID = 3, Name = "Gege", Email = "gege@gmail.com", Phone = "1234567890" });
            customers.Add(new Customer { ID = 4, Name = "John", Email = "khoa@gmail.com", Phone = "1234567890" });
            customers.Add(new Customer { ID = 5, Name = "Jane", Email = "Jane2@gmail.com", Phone = "1234567890" });
        } 
        public List<Customer> GetCustomers() {
            if (customers.Count == 0)
            {
                GenerateSampleDataset();
            }
            return customers;
        }
    }
}
