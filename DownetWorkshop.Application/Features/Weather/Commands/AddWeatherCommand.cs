using AspNetCoreHero.Results;
using DotnetWorkshop.Application.DTO;
using DotnetWorkshop.Application.Interfaces.Repositories;
using DotnetWorkshop.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetWorkshop.Application.Features.Weather.Commands
{



        public partial class AddWeatherCommand : IRequest<Result<WeatherDTO>>
        {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }

        public AddWeatherCommand(
                DateOnly date
                , int temperatureC
                , string summary
                )
            {
             Date = date;
            TemperatureC = temperatureC;
            Summary = summary;
            }
        }

        public class RegisterUserCommandHandler : IRequestHandler<AddWeatherCommand, Result<WeatherDTO>>
        {

            private readonly IUnitOfWork _unitOfWork;


            public RegisterUserCommandHandler(IUnitOfWork unitOfWork )
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<WeatherDTO>> Handle(AddWeatherCommand request, CancellationToken cancellationToken)
            {
                var weatherForecast = new WeatherForecast {Date = request.Date, Summary = request.Summary , TemperatureC= request.TemperatureC };
                var forecast = await _unitOfWork.GetRepository<WeatherForecast>().AddAsync( weatherForecast );
                return await Result<WeatherDTO>.SuccessAsync(new WeatherDTO { Date = forecast.Date, Summary = forecast.Summary, TemperatureC = forecast.TemperatureC });
            }
        }
    }
