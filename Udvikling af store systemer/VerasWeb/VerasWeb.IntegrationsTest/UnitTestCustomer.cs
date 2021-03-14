using System;
using System.Linq;
using System.Threading.Tasks;
using CosmosDbService.Models;
using Newtonsoft.Json;
using VerasWeb.Handlers;
using VerasWeb.Handlers.Models;
using Xunit;
using Xunit.Abstractions;

namespace VerasWeb.IntegrationsTest
{
    public class UnitTestCustomer
    {
        private readonly ITestOutputHelper _testOutputHelper;

        private ICustomerHandler _customerHandler;
        private const string DatabaseId = "VerasWeb";
        private const string ContainerId = "VerasWeb";
        // The Azure Cosmos DB endpoint for running this unitTest.
        private const string EndPointUri = "https://verasweb.documents.azure.com:443/";
        // The primary key for the Azure Cosmos account.
        private const string PrimaryKey = "65PIg4ywMasSRYh3bUVWqxSfKdTzaJwFt3tgo6XHawsCYsQBJl5MMhplGtQwizwvsE6pvrp9Jvc3dBv94Rky3A==";
        private readonly CosmosDbServiceConfiguration _cosmosDbServiceConfiguration = new CosmosDbServiceConfiguration(EndPointUri, PrimaryKey, ContainerId, DatabaseId, "/id");

        public UnitTestCustomer(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }


        private void InitializeCustomerHandler()
        {
            _customerHandler = new CustomerHandler(new CosmosDbService.CosmosDbService(_cosmosDbServiceConfiguration));
        }

        [Fact]
        public async Task CanGetCustomers_OK()
        {
            InitializeCustomerHandler();
            var customers = await _customerHandler.GetCustomersAsync();
            _testOutputHelper.WriteLine(JsonConvert.SerializeObject(customers, Formatting.Indented));
            Assert.True(customers.Any());
        }

        [Fact]
        public async Task CanCreateNewCustomer_OK()
        {
            InitializeCustomerHandler();
            var created = await _customerHandler.CreateCustomerAsync(new Customer()
            {
                CprNumber = "12341231",
                CreatedById = "unitTest",
                Id = "UnitTest",
                UserId = Guid.NewGuid().ToString(),
                CreatedOn = DateTime.Now,
                FullName = "Test",
                Result = Results.NotProven
            });
            _testOutputHelper.WriteLine(JsonConvert.SerializeObject(await _customerHandler.GetCustomersAsync(), Formatting.Indented));

            Assert.True(created);
        }


        [Fact]
        public async Task CanGetCustomerByCprNumber_OK()
        {
            InitializeCustomerHandler();
            var customer = await _customerHandler.GetCustomerAsync("12341231");
            Assert.True(customer != null);
        }

        [Fact]
        public async Task CanUpdateCustomer_OK()
        {
            InitializeCustomerHandler();
            var updated = await _customerHandler.UpdateCustomerAsync(new Customer()
            {
                CprNumber = "12341231",
                CreatedById = "unitTest",
                Id = "UnitTest",
                UserId = Guid.NewGuid().ToString(),
                CreatedOn = DateTime.Now,
                FullName = "Test updated",
                Result = Results.Pending,
                ModifiedById = "UnitTest",
                ModifiedOn = DateTime.Now
            });

            _testOutputHelper.WriteLine(JsonConvert.SerializeObject(await _customerHandler.GetCustomersAsync(), Formatting.Indented));

            Assert.True(updated);
        }
        [Fact]
        public async Task CanDeleteCustomer_OK()
        {
            InitializeCustomerHandler();
            var customers = await _customerHandler.GetCustomersAsync();
            var customersBeforeDeleteCount = customers.Count();
            await _customerHandler.DeleteCustomerAsync("UnitTest");
            var customersAfterDelete = await _customerHandler.GetCustomersAsync();
            var customersAfterDeleteCount = customersAfterDelete.Count();
            _testOutputHelper.WriteLine(JsonConvert.SerializeObject(await _customerHandler.GetCustomersAsync(), Formatting.Indented));
            
            Assert.True(customersAfterDeleteCount < customersBeforeDeleteCount);
        }

    }
}
