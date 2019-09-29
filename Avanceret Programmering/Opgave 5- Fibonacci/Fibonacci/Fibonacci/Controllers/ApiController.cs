using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fibonacci.Client;
using Fibonacci.Client.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Fibonacci.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {

        private readonly ILogger<ApiController> _logger;

        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
        }

        [Route("/Api/GetFibonacci")]
        [HttpGet]
        public async Task<ResponseModel> GetFibonacci(long? maxValue = 4000000)
        {
            try
            {
                _logger.LogInformation($"Started calculation...");
                FibonacciHandler handler = new FibonacciHandler();
                return await handler.Calculate(maxValue);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while calculating {e}");

                Console.WriteLine(e);
                throw;
            }
        }
    }
}
