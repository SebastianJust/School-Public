using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Menu.Handler;
using Menu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MenuApplication.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace MenuApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<AppSettings> config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config, IOptions<AppSettings> config1)
        {
            _logger = logger;
            this.config = config1;

        }

        public async Task<IActionResult> Index(string searchString)
        {

            _logger.LogInformation($"Getting menuList...");
            List<MenuModel> menus = await MenuList(searchString);

            return View(menus);
        }



        private async Task<List<MenuModel>> MenuList(string searchString)
        {
            MenuHandler handler = new MenuHandler(config.Value.ConnectionString);
            List<MenuModel> menus = await handler.GetMenuList(searchString);

            return menus;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
