using DotnetWorkshop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetWorkshop.Domain.Entity
{
    public class WeatherForecast : AuditableEntity
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int Id { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
