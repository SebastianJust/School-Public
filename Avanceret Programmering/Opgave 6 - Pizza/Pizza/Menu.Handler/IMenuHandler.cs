using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Menu.Models;

namespace Menu.Handler
{
    interface IMenuHandler
    {
        Task<List<MenuModel>> GetMenuList(string searchString = null);
        Task<List<ProductModel>> GetProducts(Guid categoryId);
        Task<List<CategoryModel>> GetCategories();
    }
}
