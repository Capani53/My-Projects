using Microsoft.AspNetCore.Identity;
using System;

namespace HiFiAppClient.Data
{
    public class AppUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }        
    }
}
