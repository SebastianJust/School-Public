using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BmiApplication.Data;
using BmiClient;
using BmiClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using static System.Double;

namespace BmiApplication.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IConfiguration _config;
        private static readonly CultureInfo _culture = CultureInfo.CreateSpecificCulture("da-DK");

        public ApiController(IConfiguration config)
        {
            _config = config;
        }


        [Route("Api/bmi")]
        [HttpPost]
        public async Task<ActionResult> CreateBmi([FromBody] BmiRequestModel body)
        {

            try
            {
                #region Be sure we always have decimal seperator for culture.

                double weigth = GetDouble(body.Weigth);

                double heigth = GetDouble(body.Heigth);


                if (!heigth.ToString(CultureInfo.InvariantCulture).Contains("."))
                    return BadRequest("Du har ikke angivet en rigtig højde. Det skal være decimaltal - ex: 0.00");

                double bmi = weigth / (heigth * heigth);

                #endregion

                if (Math.Abs(heigth) < 1)
                    return BadRequest("Du skal angive en værdi højere end 0");
                if (Math.Abs(weigth) < 1)
                    return BadRequest("Du skal angive en værdi højere end 0");

                ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
                IEnumerable<Claim> claims = identity.Claims;


                string dbConn = _config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;

                BmiResponseModel result = await new BmiHandler(dbConn, "test", "test").CreateBmi(weigth, heigth, bmi);

                if (result.Text.Equals("Kunne ikke beregne"))
                    return BadRequest("Kunne ikke beregne - prøv igen");

               if (result != null)
                   return Ok(result);
                return BadRequest($"Der skette desværre en fejl. Prøv igen.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return NotFound("Der skete desværre en fejl. Prøv igen.");
            }
        }

        public static double GetDouble(string value)
        {
            
            return value.Contains(",") ? Parse(value.Replace(",", "."), CultureInfo.InvariantCulture) : Parse(value, CultureInfo.InvariantCulture);

        }
    }
}