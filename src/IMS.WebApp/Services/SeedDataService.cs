using IMS.Application.Common.Models;
using IMS.Infrastructure.Persistence.SeedData;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.WebApp.Services
{
    public class SeedDataService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;     

        public SeedDataService(IServiceProvider serviceProvider)
        {        
            _serviceProvider = serviceProvider;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

                await DefaultRoles.SeedAsync(userManager, roleManager);
                await DefaultRoleClaims.SeedAsync(roleManager);
                await DefaultSuperAdmin.SeedAsync(userManager, roleManager);
            }           
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Seed data service stopped");
            return Task.CompletedTask;
        }
    }
}
