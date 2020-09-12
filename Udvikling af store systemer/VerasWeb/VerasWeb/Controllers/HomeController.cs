using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VerasWeb.Handlers;
using VerasWeb.Handlers.Models;
using VerasWeb.Infrastructure.ErrorHandling;
using VerasWeb.Models;
using VerasWeb.Models.Identity;

namespace VerasWeb.Controllers
{
    //TODO: Add Authorize
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ICustomerHandler _customerHandler;
        [TempData]
        public string StatusMessage { get; set; }

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ICustomerHandler customerHandler)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _customerHandler = customerHandler;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customerHandler.GetCustomersAsync();
            return View(customers ?? new List<Customer>() );
        }

        #region Customer


        public IActionResult CreateCustomer()
        {
            return View();
        }


        [ExportModelState]
        [HttpPost("/customer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNewCustomer([FromForm] Customer input)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Customer));
            }

            //Now we generate the ids 
            input.UserId = Guid.NewGuid().ToString();
            input.Id = Guid.NewGuid().ToString();
            input.CreatedById = User?.Identity?.Name;
            input.CreatedOn = DateTime.Now;
            
            await _customerHandler.CreateCustomerAsync(input);

            return RedirectToAction("Customer", new {cprNumber = input.CprNumber});
        }

        [ImportModelState]
        [HttpGet("/customer/{cprNumber}")]
        public async Task<IActionResult> Customer(string cprNumber)
        {

            return View(await _customerHandler.GetCustomerAsync(cprNumber));
        }

        [HttpDelete("/customer/{id}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            await _customerHandler.DeleteCustomerAsync(id);
            return RedirectToAction("Index");
        }

        #endregion

        public IActionResult Privacy()
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
