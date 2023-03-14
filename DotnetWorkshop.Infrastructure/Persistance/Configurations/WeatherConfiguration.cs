using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotnetWorkshop.Domain.Entity;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DotnetWorkshop.Infrastructure.Persistance.Configurations
{

    public class WeatherConfiguration : IEntityTypeConfiguration<WeatherForecast>
    {
        public void Configure(EntityTypeBuilder<WeatherForecast> builder)
        {

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Summary).HasMaxLength(100).IsRequired(true);

            builder.Property(e => e.TemperatureC).IsRequired(true).HasDefaultValue(false).ValueGeneratedNever();

            builder.Ignore(e => e.TemperatureF);

            builder.Property(e => e.CreatedBy).IsRequired(false);

            builder.Property(e => e.Created).IsRequired(false);

            builder.Property(e => e.LastModifiedBy).IsRequired(false);

            builder.Property(e => e.LastModified).IsRequired(false);

        }
    }
}
