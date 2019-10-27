using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilesModels;
using Microsoft.AspNetCore.Http;

namespace FilesFetcherRestService.Handlers
{
    interface IFilesFetcherHandler
    {
        Task<ResponseModel> UploadFiles(List<IFormFile> files);
        Task<List<FilesModel>> GetFileList(Guid? id);
    }
}
