using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using HiFiAppClient.Models;

namespace HiFiAppClient.Services
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterUserAsync(RegisterViewModel model);
    }
}