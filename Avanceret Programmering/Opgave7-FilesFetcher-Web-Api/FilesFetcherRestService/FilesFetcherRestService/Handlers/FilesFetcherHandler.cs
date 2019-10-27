using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FilesFetcherRestService.Controllers;
using FilesFetcherRestService.DatabaseContext;
using FilesModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FilesFetcherRestService.Handlers
{
    public class FilesFetcherHandler : IFilesFetcherHandler
    {
        private readonly ILogger<FilesController> _logger;
        private readonly FilesContext _dbContext;

        public FilesFetcherHandler(ILogger<FilesController> logger, FilesContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }


        /// <summary>
        /// Method to upload files
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public async Task<ResponseModel> UploadFiles(List<IFormFile> files)
        {
            try
            {
                foreach (var f in files)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await f.CopyToAsync(memoryStream);

                        FilesModel file = new FilesModel
                        {
                            Content = Convert.ToBase64String(memoryStream.ToArray()),
                            FileName = f.FileName,
                            ContentType = f.ContentType,
                        };
                        await _dbContext.Files.AddAsync(file);

                        await _dbContext.SaveChangesAsync();


                    }
                    return new ResponseModel(true);

                }

                return new ResponseModel(false)
                {
                    Message = "Couldn't upload"
                };

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Methods to get list
        /// </summary>
        /// <param name="id">Indicates if specific file should be returned</param>
        /// <returns></returns>
        public async Task<List<FilesModel>> GetFileList(Guid? id)

        {
            try
            {
                List<FilesModel> files = await _dbContext.Files.ToListAsync();
                if (id.HasValue)
                    files = files.FindAll(m => m.Id.Equals(id.Value));
                return files;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message, e);
                Console.WriteLine(e);
                throw;
            }
        }

    }
}