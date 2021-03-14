using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordHandler.Attributes;

namespace PasswordHandler.Models
{
    public class PasswordRequestModel
    {

        [Required]
        [MinimumLength(5, ErrorMessage = "The length must be at least 5")]
        public int Length { get; set; }
    }
}
