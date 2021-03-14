using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordHandler.Models
{
    public class PasswordResponseModel
    {


        public PasswordResponseModel(){}

        public PasswordResponseModel(string password)
        {
            Password = password;
        }
        public string Password { get; set; }

    }
}
