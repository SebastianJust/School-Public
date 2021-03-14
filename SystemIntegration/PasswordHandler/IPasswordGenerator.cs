using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordHandler.Models;

namespace PasswordHandler
{
    public interface IPasswordGenerator
    {
        /// <summary>
        /// Creates a random password.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<PasswordResponseModel> CreatePasswordAsync(PasswordRequestModel request);
    }
}
