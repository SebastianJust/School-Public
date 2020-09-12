using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VerasWeb.Handlers.Models;

namespace VerasWeb.Handlers
{
    public interface ICustomerHandler
    {
        Task<bool> CreateCustomerAsync(Customer customer);
        Task<Customer> GetCustomerAsync(string cprNumber);
    }
}
