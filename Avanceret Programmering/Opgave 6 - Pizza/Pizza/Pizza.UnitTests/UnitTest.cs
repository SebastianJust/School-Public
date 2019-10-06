using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Menu.Handler;
using Menu.Models;
using NUnit.Framework;

namespace Menu.UnitTests
{
    public class Tests
    {
        private readonly string _cnnString = "Server=tcp:schoolazure.database.windows.net,1433;Initial Catalog=School;Persist Security Info=False;User ID=school;Password=Su9db3gyrnkKKXYL;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task GetCategories_OK()
        {

            //Get list of Categories
            List<CategoryModel> categories = await GetCategories();
            Assert.AreNotEqual(0, categories.Count);
        }

        [Test]
        public async Task GetMenuWithCategory_InUnitTest_OK()
        {

            //Get list of Categories
            List<CategoryModel> categories = await GetCategories();
            List<MenuModel> menus = new List<MenuModel>();
            foreach (var c in categories)
            {
                menus.Add(new MenuModel()
                    {
                        CategoryId = c.CategoryId,
                        CategoryName = c.CategoryName,
                        Product = await GetProducts(c.CategoryId)
                    }
                );
            }



            Assert.AreNotEqual(0, menus.Count);
        }


        [Test]
        public async Task GetMenuWithCategory_MenuHandler_OK()
        {
            MenuHandler handler = new MenuHandler(_cnnString);
            //Get list of Categories
            List<MenuModel> menus = await handler.GetMenuList();




            Assert.AreNotEqual(0, menus.Count);
        }

        private async Task<List<ProductModel>> GetProducts(Guid categoryId)
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
                List<ProductModel> product = new List<ProductModel>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetGuid(0)} {reader.GetString(1)}");
                        product.Add(new ProductModel
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
                return await Task.FromResult(product);



            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }



        private async Task<List<CategoryModel>> GetCategories()
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