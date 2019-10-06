using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Menu.Models;

namespace Menu.Handler
{
    public class MenuHandler : IMenuHandler
    {
        private readonly string _cnnString;

        public MenuHandler(string cnnString)
        {
            _cnnString = cnnString;
        }


     /// <summary>
     /// Get list of menu
     /// </summary>
     /// <param name="searchString">search string to get specific list</param>
     /// <returns></returns>
        public async Task<List<MenuModel>> GetMenuList(string searchString = null)
        {
            try
            {

                //Get list of Categories
                List<CategoryModel> categories = await GetCategories();
                List<MenuModel> menus = new List<MenuModel>();

                //We return an empty list
                if (categories.Count < 0) return new List<MenuModel>();

                foreach (CategoryModel c in categories)
                {
                    //Products
                    List<ProductModel> products = await GetProducts(c.CategoryId);
                    if (!string.IsNullOrEmpty(searchString))
                    {
                        searchString = searchString.ToLower();
                        products = products.FindAll(m => (m.Name != null && m.Name.ToLower().Contains(searchString) 
                                                          || (m.Description != null && m.Description.ToLower().Contains(searchString)) 
                                                          || (m.Price.ToString(CultureInfo.InvariantCulture).Equals(searchString))
                                                          || m.Number.Contains(searchString)));

                    }

                    menus.Add(new MenuModel
                    {
                        CategoryId = c.CategoryId,
                        CategoryName = c.CategoryName,
                        Product = products
                    }
                    );
                }

                if (!string.IsNullOrEmpty(searchString))
                  menus = menus.FindAll(m => m.Product.FindAll(model => model.Category == m.CategoryId).Count > 0);
                return await Task.FromResult(menus.OrderBy(m => m.CategoryName).ToList());

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        /// <summary>
        /// Gets products
        /// </summary>
        /// <param name="categoryId">Id of the category</param>
        /// <returns></returns>
        public async Task<List<ProductModel>> GetProducts(Guid categoryId)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_cnnString);
                string sql = "SELECT [Category] ,[Number] ,[Name] ,[Description] ,[Price] FROM [dbo].[Menu] where Category = @categoryId";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@categoryId", Value = categoryId });

                if (sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<ProductModel> products = new List<ProductModel>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetGuid(0)} {reader.GetString(1)}");
                        products.Add(new ProductModel
                        {
                            Category = reader.GetGuid(0),
                            Number = reader.GetString(1),
                            Name = reader.GetString(2),
                            Description = reader.GetString(3),
                            Price = reader.GetDecimal(4)
                        });

                    }
                    sqlConnection.Close();

                }
                return await Task.FromResult(products);



            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        /// <summary>
        /// Gets categories
        /// </summary>
        /// <returns></returns>
        public async Task<List<CategoryModel>> GetCategories()
        {
            try
            {

                SqlConnection sqlConnection = new SqlConnection(_cnnString);
                string sql = "SELECT [Id] ,[CategoryName] FROM [dbo].[MenuCategories]";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                if (sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                List<CategoryModel> categories = new List<CategoryModel>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetGuid(0)} {reader.GetString(1)}");
                        categories.Add(new CategoryModel
                        {
                            CategoryId = reader.GetGuid(0),
                            CategoryName = reader.GetString(1)
                        });

                    }

                    sqlConnection.Close();
                }

                return await Task.FromResult(categories);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
