using AspNetCore.Identity.MongoDB.Model;
using Blazored.SessionStorage;
using IMS.Application.Common.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace IMS.WebApp.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorageService;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;       

        public CustomAuthenticationStateProvider(
            ISessionStorageService sessionStorageService,
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _sessionStorageService = sessionStorageService;
            _roleManager = roleManager;
            _userManager = userManager;           
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var userName = await _sessionStorageService.GetItemAsync<string>("userName");
            ClaimsIdentity identity;

            if (userName != null)
            {
                identity = await GetClaimsIdentity(userName);
            }
            else
            {
                identity = new ClaimsIdentity();
            }            

            var claimsPrincipal = new ClaimsPrincipal(identity);

            return new AuthenticationState(claimsPrincipal);
        }

        public async Task StateChangedAsync()
        {
            var authState = Task.FromResult(await GetAuthenticationStateAsync());

            NotifyAuthenticationStateChanged(authState);

        }

        public async Task MarkUserAsAuthenticatedAsync(string username)
        {
            await _sessionStorageService.SetItemAsync("userName", username);
            await StateChangedAsync();
        }

        public async Task MarkUserAsLoggedOut()
        {
            await _sessionStorageService.RemoveItemAsync("userName");
            await StateChangedAsync();
        }

        public async Task<ClaimsPrincipal> GetAuthenticationStateProviderUserAsync()
        {
            var state = await this.GetAuthenticationStateAsync();
            var authenticationStateProviderUser = state.User;
            return authenticationStateProviderUser;
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, [Optional] ApplicationUser user)
        {
            if (user is null)
            {
                user = await _userManager.FindByNameAsync(userName);
            }

            var claims = new List<Claim>();
            if (user.UserRoles.Count > 0)
            {
                var role = await _roleManager.FindByNameAsync(user.UserRoles.FirstOrDefault().Name);
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
                claims.AddRange(role.RoleClaims?.Select(p => new Claim(p.ClaimType, p.ClaimValue)));
            }                
            claims.Add(new Claim(ClaimTypes.Name, user.UserName)); 

            claims.AddRange(user.UserClaims?.Select(p => new Claim(p.ClaimType, p.ClaimValue)));

            return new ClaimsIdentity(claims,"custom_authentication");
        }
    }
}
