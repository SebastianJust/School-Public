using System;
using System.Text;
using System.Threading.Tasks;
using PasswordHandler.Models;

namespace PasswordHandler
{
    public class PasswordGenerator : IPasswordGenerator
    {

        private readonly string _validCharacters;

        public PasswordGenerator(string validCharacters)
        {
            _validCharacters = validCharacters;
        }

        /// <summary>
        /// Creates a random password.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<PasswordResponseModel> CreatePasswordAsync(PasswordRequestModel request)
        { 
          
                StringBuilder res = new StringBuilder();
                Random rnd = new Random();
                while (0 < request.Length--)
                {
                    res.Append(_validCharacters[rnd.Next(_validCharacters.Length)]);
                }
                return await Task.FromResult(new PasswordResponseModel(res.ToString()));
            
        }

    }
}
