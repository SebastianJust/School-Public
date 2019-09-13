using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmiApplication.Models
{
    public class UserModel
    {
        public string Name { get; set; } = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
        public string Id { get; set; } = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";

    }
}
