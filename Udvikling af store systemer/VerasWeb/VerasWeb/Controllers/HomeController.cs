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
    [Authorize]
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


        /// <summary>
        /// The index (Home) which returns all customers
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            Trace.Write("Reaching customers...");
            var customers = await _customerHandler.GetCustomersAsync();
            return View(customers ?? new List<Customer>() );
        }

        #region Customer


        /// <summary>
        /// The view for 'CreateNewCustomer'
        /// </summary>
        /// <returns></returns>

        [Authorize(Roles = "Administrator")]
        public IActionResult CreateCustomer()
        {
            return View();
        }


        /// <summary>
        /// Creates an given customer
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        [Authorize(Roles = "Administrator")]
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
            _logger.LogInformation($"customer is created: {input.UserId}");
            return RedirectToAction("Customer", new {cprNumber = input.CprNumber});
        }

        /// <summary>
        /// Gets a given customer and show information
        /// </summary>
        /// <param name="cprNumber"></param>
        /// <returns></returns>
        [ImportModelState]
        [HttpGet("/customer/{cprNumber}")]
        public async Task<IActionResult> Customer(string cprNumber)
        {
            return View(await _customerHandler.GetCustomerAsync(cprNumber));
        }


        /// <summary>
        /// Deletes an given customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            await _customerHandler.DeleteCustomerAsync(id);
            _logger.LogInformation($"customer is deleted: {id}");

            return RedirectToAction("Index");
        }

        #endregion

        /// <summary>
        /// Updates an given customer
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateCustomer([FromForm] Customer input)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(Customer));
                }

                //Now we generate the ids 
                input.ModifiedById = User?.Identity?.Name;
                input.ModifiedOn = DateTime.Now;

                await _customerHandler.UpdateCustomerAsync(input);
                _logger.LogInformation($"customer is updated: {input.UserId}");

                return RedirectToAction("Customer", new { cprNumber = input.CprNumber });
            }
            catch (Exception e)
            {
                //Prevent failure
                return RedirectToAction(nameof(Customer));

            }

        }
        [HttpPost("/logout")]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
