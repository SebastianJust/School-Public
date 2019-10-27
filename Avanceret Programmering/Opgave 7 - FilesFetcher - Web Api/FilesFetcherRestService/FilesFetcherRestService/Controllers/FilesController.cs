using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FilesFetcherRestService.DatabaseContext;
using FilesFetcherRestService.Handlers;
using FilesFetcherRestService.Utilities;
using FilesModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FilesFetcherRestService.Controllers
{
    [Authorize]
    [ApiController]
    public class FilesController : ControllerBase
    {

        private static ILogger<FilesController> _logger;
        private static FilesContext _dbContext;


        public FilesController(ILogger<FilesController> logger, FilesContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        // **WARNING!**
        // This api, the file is saved without
        // scanning the file's contents. In most production
        // scenarios, an anti-virus/anti-malware scanner API
        // is used on the file before making the file available
        // for download or for use by other systems. 
        [HttpPost]
        [Route("api/upload")]
        public async Task<ActionResult> Upload([FromForm] List<IFormFile> files)
        {
            try
            {

                if (!MultipartRequestHelper.IsMultipartContentType(Request.ContentType))
                {
                    ModelState.AddModelError("File",
                        $"The request couldn't be processed (Error 1).");
                    // Log error
                    _logger.LogError("1", $"The request couldn't be processed (Error 1).", Request.ContentType);
                    return BadRequest(ModelState);
                }

                ResponseModel uploaded = await new FilesFetcherHandler(_logger, _dbContext).UploadFiles(files);
                if (!uploaded.Succeeded) return BadRequest(uploaded.Message);

                string text = "file";
                if (files.Count > 1)
                    text = text + "s";
                return Ok($"Uploaded {files.Count} {text}");


            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message, e);
                Console.WriteLine(e);
                throw;
            }
        }


        [HttpGet]
        [Route("api/files")]
        public async Task<ActionResult> GetFiles(Guid? id)
        {
            try
            {

                return Ok(await GetFileList(id));

            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message, e);
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        [Route("api/showFile/{id}")]
        public async Task<ActionResult> ShowFile(Guid id, bool download = false)
        {
            try
            {
                List<FilesModel> files = await GetFileList(id);
                FilesModel file = files[0];
                byte[] bytes = Convert.FromBase64String(file.Content);

                FileContentResult result = new FileContentResult(bytes, file.ContentType)
                {
                    FileContents = bytes,
                    EnableRangeProcessing = true,
                };

                if(download)
                    result.FileDownloadName = file.FileName;

                return result;


            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message, e);
                Console.WriteLine(e);
                throw;
            }
        }


        private static async Task<List<FilesModel>> GetFileList(Guid? id)

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

        [HttpGet]
        [Route("api/status")]
        public async Task<ActionResult> Status()
        {
            try
            {
                bool canConnect = await _dbContext.Database.CanConnectAsync();
                return canConnect ? (ActionResult)Ok("Connected to database") : NotFound("Cannot connect to database");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
