using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza.Models
{
   public class ProductModel
    {
        /// <summary>
        /// Defines the category
        /// </summary>
        public Guid Category { get; set; }
        public string Number { get; set; }
        /// <summary>
        /// Main title
        /// </summary>
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


    }
}
