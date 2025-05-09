using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using HiFiAppClient.Models.HiFiAppClient.Models.ViewModels;

namespace HiFiAppClient.Services
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterUserAsync(RegisterViewModel model);
    }
}