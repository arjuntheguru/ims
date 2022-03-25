using IMS.Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Identity.SeedData
{
    public class SeedDataService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<SeedDataService> _logger;

        public SeedDataService(IServiceProvider serviceProvider,
            ILogger<SeedDataService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Seed data service has started.");

            using (var scope = _serviceProvider.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

                await DefaultRoles.SeedAsync(userManager, roleManager);
                await DefaultRoleClaims.SeedAsync(roleManager);
                await DefaultSuperAdmin.SeedAsync(userManager, roleManager);
            }

            await StopAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Seed data serve has stopped.");
            return Task.CompletedTask;
        }
    }
}
