using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BmiApplication.Data;
using BmiApplication.Models;
using BmiClient;
using BmiClient.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]

    public class ApiController : ControllerBase
    {
        private readonly IConfiguration _config;
        private static string _dbConn;
        
        public ApiController(IConfiguration config)
        {
            _config = config;
            _dbConn = config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
        }


        [Route("Api/bmi")]
        [HttpPost]
        public async Task<ActionResult> CreateBmi([FromForm] BmiRequestModel body)
        {

            try
            {
                if(body.Heigth == null)
                    throw new NullReferenceException("heigth cannot be null");
                if (body.Weigth == null)
                    throw new NullReferenceException("weigth cannot be null");

                string name = @User.Claims.FirstOrDefault(claim => claim.Type.Equals(new UserModel().Name))?.Value;
                string id = @User.Claims.FirstOrDefault(claim => claim.Type.Equals(new UserModel().Id))?.Value;

                #region Be sure we always have decimal seperator for culture.

                double weigth = GetDouble(body.Weigth);

                double heigth = GetDouble(body.Heigth);


                if (!heigth.ToString(CultureInfo.InvariantCulture).Contains("."))
                    return BadRequest("Du har ikke angivet en rigtig højde. Det skal være et decimaltal - ex: 0.00");

                double bmi = weigth / (heigth * heigth);

                #endregion

                if (Math.Abs(heigth) < 1)
                    return BadRequest("Du skal angive en værdi højere end 0");
                if (Math.Abs(weigth) < 1)
                    return BadRequest("Du skal angive en værdi højere end 0");


                BmiResponseModel result = await new BmiHandler(_dbConn, id, name).CreateBmi(weigth, heigth, bmi);
                if (result.Text.Equals("Kunne ikke beregne - mangler du et decimal?"))
                    return BadRequest("Kunne ikke beregne - mangler du et decimal? - Tjek om højden indeholder et decimaltal - ex: 0.00");

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest("Der skete desværre en fejl. Prøv igen.");
            }
        }

        public static double GetDouble(string value)
        {
            return value.Contains(",") ? Parse(value.Replace(",", "."), CultureInfo.InvariantCulture) : Parse(value, CultureInfo.InvariantCulture);
        }

    }
}