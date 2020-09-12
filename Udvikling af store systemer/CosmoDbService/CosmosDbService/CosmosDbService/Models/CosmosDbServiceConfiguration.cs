using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosDbService.Models
{
    public class CosmosDbServiceConfiguration
    {
        public CosmosDbServiceConfiguration(string endpointUri, string key, string containerId, string databaseId, string partitionKeyPath)
        {
            EndpointUri = endpointUri;
            Key = key;
            ContainerId = containerId;
            DatabaseId = databaseId;
            PartitionKeyPath = partitionKeyPath;
        }

        public string EndpointUri { get; set; }
        public string Key { get; set; }
        public string ContainerId { get; set; }
        public string DatabaseId { get; set; }
        public string PartitionKeyPath { get; set; }

    }
}
