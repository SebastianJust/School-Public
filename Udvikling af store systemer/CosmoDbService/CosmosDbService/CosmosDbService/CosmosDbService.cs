using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CosmosDbService.Models;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CosmosDbService
{
    public class CosmosDbService : ICosmosDbService
    {
        private readonly Container _container;

        /// <summary>
        /// CosmosDbService
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="throughput"> (Optional) The throughput provisioned for a container in measurement of Request Units per second in the Azure Cosmos DB service.</param>
        public CosmosDbService(CosmosDbServiceConfiguration configuration, int? throughput = null)
        {
            CosmosClient cosmosClient = new CosmosClient(configuration.EndpointUri, configuration.Key);
                
            DatabaseResponse database = cosmosClient.CreateDatabaseIfNotExistsAsync(configuration.DatabaseId).Result;
            
            _ = database.Database.CreateContainerIfNotExistsAsync(configuration.DatabaseId, configuration.PartitionKeyPath, throughput).Result;

            _container = cosmosClient.GetContainer(configuration.DatabaseId, configuration.ContainerId);
        }

        public async Task<ItemResponse<T>> AddItemAsync<T>(T item)
        {
            try
            {
                return await _container.CreateItemAsync(item);
            }
            catch (CosmosException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<T> GetItemAsync<T>(string id, PartitionKey partitionKey)
        {
            try
            {
                ItemResponse<T> response = await _container.ReadItemAsync<T>(id, partitionKey);
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return default;
            }

        }

        public async Task<IEnumerable<T>> GetItemsAsync<T>()
        {
            try
            {
                FeedIterator<T> query = _container.GetItemQueryIterator<T>("SELECT * FROM c"); //Static to get all items
                List<T> results = new List<T>();
                while (query.HasMoreResults)
                {
                    FeedResponse<T> response = await query.ReadNextAsync();
                    results.AddRange(response.ToList());
                }

                return results;
            }
            catch (CosmosException e)
            {
                Console.WriteLine(e);
                throw;
            }
 
        }

        public async Task<ItemResponse<T>> UpdateItemAsync<T>(T item, PartitionKey partitionKey)
        {
            try
            {
                return await _container.UpsertItemAsync(item, partitionKey);
            }
            catch (CosmosException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ItemResponse<T>> DeleteItemAsync<T>(string id, PartitionKey partitionKey)
        {
            try
            {
                return await _container.DeleteItemAsync<T>(id, partitionKey);
            }
            catch (CosmosException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
