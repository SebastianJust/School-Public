using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace CosmosDbService
{
    public interface ICosmosDbService
    {
        /// <summary>
        /// Adds a given item to the database.
        /// </summary>
        /// <typeparam name="T">Specify the model</typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<ItemResponse<T>> AddItemAsync<T>(T item);
        /// <summary>
        /// Returns a given item by its provided id.
        /// </summary>
        /// <typeparam name="T">Specify the model</typeparam>
        /// <param name="partitionKey"></param>
        /// <returns></returns>
        Task<T> GetItemAsync<T>(string id, PartitionKey partitionKey);

        /// <summary>
        /// Returns a list of the given item.
        /// </summary>
        /// <typeparam name="T">Specify the model</typeparam>
        /// <returns></returns>
        Task<IEnumerable<T>> GetItemsAsync<T>();

        /// <summary>
        /// Updates a given item to the database.
        /// </summary>
        /// <typeparam name="T">Specify the model</typeparam>
        /// <param name="item"></param>
        /// <param name="partitionKey"></param>
        /// <returns></returns>
        Task<ItemResponse<T>> UpdateItemAsync<T>(T item, PartitionKey partitionKey);

        /// <summary>
        /// Deletes the specified id from the database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="partitionKey"></param>
        /// <returns></returns>
        Task<ItemResponse<T>> DeleteItemAsync<T>(string id, PartitionKey partitionKey);
    }
}
