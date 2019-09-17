using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FeetToInchesApplication.Models;

namespace FeetToInchesApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult FeetToInches()
        {
            return View();
        }


        public IActionResult InchesToFeet()
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
