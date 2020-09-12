using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmosDbService.Models;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;
using static System.Console;

namespace CosmosDbService.IntegrationsTest
{
    public class UnitTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        private const string DatabaseId = "MyDatabaseNameId";
        private const string ContainerId = "MyDatabaseNameId";
        // The Azure Cosmos DB endpoint for running this unitTest.
        private const string EndPointUri = "xxxx";
        // The primary key for the Azure Cosmos account.
        private const string PrimaryKey = "xxxxx";
        private ICosmosDbService _cosmosDb;

        public UnitTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        public void CosmosDbService()
        {
            _cosmosDb = new CosmosDbService(new CosmosDbServiceConfiguration(EndPointUri, PrimaryKey, ContainerId, DatabaseId, "/id"));
        }

        [Fact]
        public async Task CanAddItem_OK()
        {

            CosmosDbService();
            
            var request = new UnitTestItemModel()
            {
                UserId = Guid.NewGuid().ToString(),
                FullName = "teeest",
                Id = Guid.NewGuid().ToString()
            };
            _testOutputHelper.WriteLine(request.Id);
            await _cosmosDb.AddItemAsync(request);
        }


        [Fact]
        public async Task CanGetItem_OK()
        {

            CosmosDbService();
           var result = await _cosmosDb.GetItemAsync<UnitTestItemModel>("5117791c-8321-49f5-8e2c-d241053b8f20", new PartitionKey("0435eb07-035a-42c8-a4f7-94d664c712f4"));
           _testOutputHelper.WriteLine(JsonConvert.SerializeObject(result));
           Assert.NotNull(result);
        }



        [Fact]
        public async Task CanGetItemList_OK()
        {

            CosmosDbService();
            var result = await _cosmosDb.GetItemsAsync<UnitTestItemModel>();
            _testOutputHelper.WriteLine(JsonConvert.SerializeObject(result.ToList()));
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CanUpdateItem_OK()
        {

            CosmosDbService();
            var request = new UnitTestItemModel()
            {
                UserId = "5117791c-8321-49f5-8e2c-d241053b8f20",
                FullName = "updated",
                Id = "0435eb07-035a-42c8-a4f7-94d664c712f4"
            };
            var result = await _cosmosDb.UpdateItemAsync(request, new PartitionKey("0435eb07-035a-42c8-a4f7-94d664c712f4"));
            _testOutputHelper.WriteLine(JsonConvert.SerializeObject(result));
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CanDelete_OK()
        {

            CosmosDbService();
            var result = await _cosmosDb.DeleteItemAsync<UnitTestItemModel>("0435eb07-035a-42c8-a4f7-94d664c712f4", new PartitionKey("0435eb07-035a-42c8-a4f7-94d664c712f4"));
            _testOutputHelper.WriteLine(JsonConvert.SerializeObject(result));
            Assert.NotNull(result);
        }

    }
}
