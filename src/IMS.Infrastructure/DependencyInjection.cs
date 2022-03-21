using IMS.Application.Common.Interfaces;
using IMS.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using IMS.Application.Common.Settings;
using IMS.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {          
            services.AddScoped<IMongoDbContext, MongoDbContext>();           
        }
    }
}
