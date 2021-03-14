using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PasswordHandler;
using PasswordHandler.Attributes;
using PasswordHandler.Models;

namespace PasswordGenerator.Controllers
{
    [ApiController]
    [Route("api/password/random")]
    public class PasswordController : ControllerBase
    {

        private readonly ILogger<PasswordController> _logger;
        private readonly IPasswordGenerator _passwordGenerator;
        private const int PasswordLength = 16;
        public PasswordController(ILogger<PasswordController> logger, IPasswordGenerator passwordGenerator)
        {
            _logger = logger;
            _passwordGenerator = passwordGenerator;
        }


        /// <summary>
        /// Generates a random password.
        /// </summary>
        /// <returns>A newly created password</returns>
        /// <response code="200">Returns the newly created password</response>
        /// <response code="400">If something got wrong</response>  
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetPassword()
        {
            try
            {
                PasswordResponseModel result = await _passwordGenerator.CreatePasswordAsync(new PasswordRequestModel
                {
                    Length = PasswordLength
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while generating random password - {ex}", ex.Message);
                return BadRequest("Please try again.");
            }
        }

        /// <summary>
        /// Generates a random based on <paramref name="request"/>
        /// </summary>
        /// <param name="request">The length of the given request must be at least 5.</param>
        /// <returns>A newly created password</returns>
        /// <response code="200">Returns the newly created password</response>
        /// <response code="400">If something got wrong</response>  
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateRandomPassword(PasswordRequestModel request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }


                PasswordResponseModel result = await _passwordGenerator.CreatePasswordAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while generating random password - {ex}", ex.Message);
                return BadRequest("Please try again.");
            }
        }
    }
}
