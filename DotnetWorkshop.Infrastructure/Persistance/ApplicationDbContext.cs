using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;
using DotnetWorkshop.Application.Interfaces.Repositories;
using DotnetWorkshop.Domain.Entity;

namespace DotnetWorkshop.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext , IApplicationDbContext
    {


        public ApplicationDbContext() : base(new DbContextOptions<ApplicationDbContext>())
        {

        }

        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options ) : base(options)
        {
        }
        public DbSet<WeatherForecast> Settings => Set<WeatherForecast>();

    }
}
