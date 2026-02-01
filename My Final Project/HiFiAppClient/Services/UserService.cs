
using HiFiAppClient.Data;
using HiFiAppClient.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace HiFiAppClient.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserService(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterViewModel model)
        {
            var user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                try
                {
                    using (var httpClient = new System.Net.Http.HttpClient())
                    {
                        await httpClient.PostAsync($"http://localhost:5500/api/Carts/initialize/{user.Id}", null);
                    }
                }
                catch
                {
                }

                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return result;
        }
    }
}