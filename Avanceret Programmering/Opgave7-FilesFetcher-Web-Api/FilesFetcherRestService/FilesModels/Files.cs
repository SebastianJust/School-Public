using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilesModels
{
    public class FilesModel
    {

        /// <summary>
        /// Primary Key - if not set it creates new id by default.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// ContentType is required
        /// </summary>
        [Required]
        public string ContentType { get; set; }

        /// <summary>
        /// Content is required
        /// </summary>
        [Required]
        public string Content { get; set; }

        /// <summary>
        /// If not set default is now
        /// </summary>
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        /// <summary>
        /// Filename
        /// </summary>
        public string FileName { get; set; }


    }

}
