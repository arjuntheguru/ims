using IMS.Application.Common.Models;
using IMS.Domain.Constants;
using IMS.Infrastructure.Persistence.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Persistence.SeedData
{
    public static class DefaultRoleClaims
    {
        public static async Task SeedAsync(RoleManager<ApplicationRole> roleManager)
        {
            await roleManager.SeedClaimsForSuperAdmin();     
        }

        private static async Task SeedClaimsForSuperAdmin(this RoleManager<ApplicationRole> roleManager)
        {
            var superAdminRole = await roleManager.FindByNameAsync(Roles.SUPERADMIN);
            var moduleList = SuperAdminModules.GetSuperAdminModules();
            await roleManager.AddPermissionClaim(superAdminRole, moduleList);
        }

        //Extension Method
        public static async Task AddPermissionClaim(this RoleManager<ApplicationRole> roleManager, ApplicationRole role, List<string> moduleList)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);

            foreach (var module in moduleList)
            {
                var allPermissions = Permissions.GenerateAllPermissionsForModule(module);

                foreach (var permission in allPermissions)
                {
                    if (!allClaims.Any(a => a.Type == ClaimTypes.AuthorizationDecision && a.Value == permission))
                    {
                        await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
                    }
                }
            }

        }
    }

}
