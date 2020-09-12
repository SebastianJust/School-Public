using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VerasWeb.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(){}
        [PersonalData]
        public string FullName { get; set; }

    }
}
