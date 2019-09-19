using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using FeetToInchesApplication.Handlers;
using FeetToInchesApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FeetToInchesApplication.Controllers
{


    [ApiController]
    public class CalculateController : ControllerBase
    {
        [Route("Api/FeetInches/{type}")]
        [HttpPost]
        public async Task<ActionResult> CalculateFeetToInches([FromForm] FeetInchesRequestModel body, Types type)
        {
            try
            {
                if (type == Types.Feet)
                {
                    if (string.IsNullOrEmpty(body.Feet))
                        return BadRequest($"{nameof(body.Feet)} is required");
                }
                else
                {
                    if (string.IsNullOrEmpty(body.Inches)) //Alternative: !ModelState.IsValid
                        return BadRequest($"{nameof(body.Inches)} is required");

                }
               
                //Validation
               ObjectResult val = Validations(body);
               if (val.StatusCode.Equals(400))
                   return BadRequest(val.Value);


                try
                {
                    if (type == Types.Feet)
                    {
                        //We convert
                        double feet = GetDouble(body.Feet);
                        double result = await CalculateHandler.CalculateFeetToInches(feet);
                        return Ok($"{result} feet");
                    }
                    else
                    {
                        //We convert
                        double inches = GetDouble(body.Inches);
                        double result = await CalculateHandler.CalculateInchesToFeet(inches);
                        return Ok($"{result} inches");
                    }
                    
                }
                catch (Exception e)
                {
                    return BadRequest($"We couldn't calculate with value of: {body.Feet}");
                }

            }
            catch (Exception e)
            {
                return BadRequest("Couldn't calculate");
            }
        }

        private ObjectResult Validations(FeetInchesRequestModel body)
        {
            try
            {
                bool negative = false;
                string zeroValue = null;

                if (body.Feet != null)
                {
                    double feet = GetDouble(body.Feet);

                    if (feet.Equals(0))
                        zeroValue = $"{nameof(body.Feet)} cannot be 0";
                    negative = Convert.ToInt32(feet) < 0;
                }

                if (body.Inches != null)
                {
                    double inches = GetDouble(body.Inches);

                    if (inches.Equals(0))
                        zeroValue = $"{nameof(body.Inches)} cannot be 0";
                    negative = Convert.ToInt32(inches) < 0;

                }

                if (negative)
                    return BadRequest("Please enter a postive number - fx: 1");

                if(!string.IsNullOrEmpty(zeroValue))
                    return BadRequest(zeroValue);

                return new OkObjectResult(null);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static double GetDouble(string value)
        {
            return value.Contains(",") ? double.Parse(value.Replace(",", "."), CultureInfo.InvariantCulture) : double.Parse(value, CultureInfo.InvariantCulture);
        }


    }
}