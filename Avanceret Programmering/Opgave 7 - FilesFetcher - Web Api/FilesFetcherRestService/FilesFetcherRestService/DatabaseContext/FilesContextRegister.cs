using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilesModels;
using Microsoft.EntityFrameworkCore;

namespace FilesFetcherRestService.DatabaseContext
{
    public class FilesContext : DbContext
    {
        public FilesContext(DbContextOptions<FilesContext> options)
            : base(options)
        {
        }

        public DbSet<FilesModel> Files { get; set; }
    }
}
