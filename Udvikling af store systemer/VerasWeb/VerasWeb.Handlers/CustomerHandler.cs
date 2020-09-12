using System;
using System.Threading.Tasks;
using CosmosDbService;
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
    }
}
