using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmosDbService;
using Microsoft.Azure.Cosmos;
using VerasWeb.Handlers.Models;

namespace VerasWeb.Handlers
{
    public class CustomerHandler : ICustomerHandler
    {
        private readonly ICosmosDbService _cosmosDb;

        public CustomerHandler(ICosmosDbService cosmosDb)
        {
            _cosmosDb = cosmosDb;
        }

        public async Task<bool> CreateCustomerAsync(Customer customer)
        {
            try
            {
                await _cosmosDb.AddItemAsync(customer);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Customer> GetCustomerAsync(string cprNumber)
        {
            try
            {
                IEnumerable<Customer> items = await GetCustomersAsync();
                return items?.FirstOrDefault(c => string.Equals(c.CprNumber, cprNumber, StringComparison.CurrentCultureIgnoreCase));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            try
            {
                IEnumerable<Customer> items = await _cosmosDb.GetItemsAsync<Customer>();
                return items;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task DeleteCustomerAsync(string id)
        {
            try
            {
                await _cosmosDb.DeleteItemAsync<Customer>(id, new PartitionKey(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
