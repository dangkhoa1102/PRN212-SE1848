using DataAccessLayer;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {   
        CustomerDAO customerDAO = new CustomerDAO();
        public void GenerateSampleDataset()
        {
            customerDAO.GenerateSampleDataset();
        }
        public List<BusinessObject.Customer> GetCustomers()
        {
            return customerDAO.GetCustomers();
        }
    }
}
