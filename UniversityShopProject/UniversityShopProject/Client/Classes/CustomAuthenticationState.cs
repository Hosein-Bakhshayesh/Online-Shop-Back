using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Security.Claims;
using UniversityShopProject.Client.Pages.Admin.AdminControll;
using UniversityShopProject.Shared.ViewModels.Admin;
using UniversityShopProject.Shared.ViewModels.User;
using UniversityShopProjectModels.Models;

namespace UniversityShopProject.Client.Classes
{
    public class CustomAuthenticationState : AuthenticationStateProvider
    {
        private HttpClient _httpClient;
        public CustomAuthenticationState(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            UserInfoViewModel currentUser = await _httpClient.GetFromJsonAsync<UserInfoViewModel>("User/GetCurrentUser");
            if(currentUser != null && currentUser.UserName != null) 
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, currentUser.UserName),
                    new Claim(ClaimTypes.Role, "User"),
                };
                var claimIdentity = new ClaimsIdentity(claims, "ServerAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimIdentity);

                return new AuthenticationState(claimsPrincipal);
            }
            else
            {
                AdminInfoViewModel admin = await _httpClient.GetFromJsonAsync<AdminInfoViewModel>("Admins/IsAdmin");
                if (admin != null && admin.UserName != null)
                {
                    var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, admin.UserName),
                    new Claim(ClaimTypes.Role, "Admin"),
                };
                    var claimIdentity = new ClaimsIdentity(claims, "ServerAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimIdentity);

                    return new AuthenticationState(claimsPrincipal);
                }
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }
    }
}
