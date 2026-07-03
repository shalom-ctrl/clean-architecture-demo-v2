using Demo.Domain.Interface;
using Demo.Infrastructure.Data;
using Demo.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure
{
    public static class ConfigurationService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
            options.UseSqlite(configuration.GetConnectionString("ApplicationDbContext") ?? 
                throw new InvalidOperationException("Connection string 'ApplicationDbContext' is not found.")
            );
        });

            services.AddTransient<IBlogRepository, BlogRepository>();
            return services;
        }
    }
}
