using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace VerasWeb.Handlers.Models
{
    public class Customer
    {
        [StringLength(10, ErrorMessage = "The {0} must be at max {1} characters long.")]
        [JsonProperty(PropertyName = "cprNumber")]
        public string CprNumber { get; set; }

        [JsonProperty(PropertyName = "fullName")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "result")]
        public string Result { get; set; }
    }
}
