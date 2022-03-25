using IMS.Application.Common.Models;
using IMS.Domain.Constants;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Persistence.SeedData
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            var userRoles = new List<ApplicationRole>()
                {
                     new ApplicationRole(Roles.SUPERADMIN),
                     new ApplicationRole(Roles.COMPANY_ADMIN),
                     new ApplicationRole(Roles.COMPANY_SALESPERSON),
                     new ApplicationRole(Roles.WAREHOUSE_ADMIN),
                     new ApplicationRole(Roles.WAREHOUSE_SALESPERSON)
                };

            foreach (var role in userRoles)
            {
                if (!await roleManager.RoleExistsAsync(role.Name))
                {
                    await roleManager.CreateAsync(role);
                }
            }
        }

    }
}
