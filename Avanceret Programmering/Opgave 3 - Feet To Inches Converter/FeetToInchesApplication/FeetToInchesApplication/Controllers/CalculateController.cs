using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeetToInchesApplication.Handlers;
using FeetToInchesApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeetToInchesApplication.Controllers
{


    [ApiController]
    public class CalculateController : ControllerBase
    {
        [Route("Api/FeetToInches")]
        [HttpPost]
        public async Task<ActionResult> CalculateFeetToInches([FromForm] FeetInchesRequestModel body)
        {
            try
            {
                if (body.Feet.Equals(0))
                    return BadRequest("Feet is required - please try again");

                try
                {
                    //We convert
                    double feet = Convert.ToDouble(body.Feet);

                    bool negative = feet < 0;

                    if (negative)
                        return BadRequest("Please enter a postive number - fx: 1");


                    double result = await CalculateHandler.CalculateFeetToInches(feet);
                    return Ok(result);
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
    }
}