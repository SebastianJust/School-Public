using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilesFetcherRestService.DatabaseContext;
using FilesModels;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace FilesFetcherUnitTest
{
    public class Tests
    {
        public readonly string SqlString =
            "Server=(localdb)\\mssqllocaldb;Database=Files;Trusted_Connection=True;MultipleActiveResultSets=true";
        private FilesContext _dbContext;

        [SetUp]
        public void Setup()
        {
            DbContextOptions<FilesContext> options = new DbContextOptionsBuilder<FilesContext>().UseSqlServer(SqlString).Options;
            FilesContext databaseContext = new FilesContext(options);
            databaseContext.Database.EnsureCreated();
            _dbContext = databaseContext;
        }


        [Test(Description = "Test to connect")]
        public async Task CanConnectToDatabase_OK()
        {

            try
            {
                Setup();
                bool canConnect = await _dbContext.Database.CanConnectAsync();
                Assert.AreEqual(true, canConnect);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
        }

        [Test (Description = "Test to insert")]
        public async Task CanInsertInDatabase_Ok()
        {

            try
            {
                Setup();

                var sevenItems = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
                var bytes = new byte[64493];
                var base64String = Convert.ToBase64String(sevenItems);
                var file = new FilesModel()
                {
                    Content = base64String,
                    FileName = "test",
                    ContentType = "application/json"
                };
                await _dbContext.Files.AddAsync(file);

                await _dbContext.SaveChangesAsync();
                Assert.Pass();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
         
        }


        [Test(Description = "Test to get list of files")]
        public async Task CanGetListOfFiles_Ok()
        {

            try
            {
                Setup();

                List<FilesModel> files = _dbContext.Files.ToList();

                Assert.AreNotEqual(0, files.Count);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}