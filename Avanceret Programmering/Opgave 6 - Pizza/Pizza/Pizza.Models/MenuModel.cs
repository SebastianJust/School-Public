using System;
using System.Collections.Generic;

namespace Menu.Models
{
    public class MenuModel
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<ProductModel> Product { get; set; }

    }
}
