using Microsoft.AspNetCore.Identity;

namespace HiFiAppClient.Data
{
    public class AppRole: IdentityRole
    {
        public string Description { get; set; }
    }
}
