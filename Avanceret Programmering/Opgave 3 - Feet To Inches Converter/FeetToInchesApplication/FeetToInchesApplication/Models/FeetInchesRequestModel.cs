using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeetToInchesApplication.Models
{
    public class FeetInchesRequestModel
    {
        [Required]
        public string Feet { get; set; }
        [Required]
        public string Inches { get; set; }
    }

}
