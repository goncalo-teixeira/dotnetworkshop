using DotnetWorkshop.Application.Interfaces.Repositories;
using DotnetWorkshop.Infrastructure.Persistance;
using DotnetWorkshop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetWorkshop.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    $"Data Source={System.IO.Path.GetFullPath(@"..\")}{configuration.GetConnectionString("DefaultConnection")}"
                   ));

            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }

    }
}
