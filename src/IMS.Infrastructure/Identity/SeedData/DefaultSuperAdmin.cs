using IMS.Application.Common.Models;
using IMS.Domain.Constants;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Identity.SeedData
{
    public static class DefaultSuperAdmin
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "superadmin",
                Email = "superadmin@superadmin.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var user = await userManager.FindByNameAsync(defaultUser.UserName);

            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "Superadmin@123");
                await userManager.AddToRoleAsync(defaultUser, Roles.SUPERADMIN);
            }
        }

    }

}
