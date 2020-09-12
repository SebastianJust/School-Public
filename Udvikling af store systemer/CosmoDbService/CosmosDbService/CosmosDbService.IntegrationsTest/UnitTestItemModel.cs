using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CosmosDbService.Models;
using Newtonsoft.Json;

namespace CosmosDbService.IntegrationsTest
{
    public class UnitTestItemModel
    {
        [JsonProperty(PropertyName = "fullName")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "id")] 
        public string Id { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
