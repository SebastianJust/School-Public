using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BmiApplication.Models;
using BmiClient.Models;
using Microsoft.Extensions.Configuration;

namespace BmiApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;


        public IActionResult Index()
        {
            return View();
        }

   

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
