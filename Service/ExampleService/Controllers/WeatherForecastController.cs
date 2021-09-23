using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using ExampleService.Context;

namespace ExampleService.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly ILogger<WeatherForecastController> _logger;
		private readonly MonitoringContext _db;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, MonitoringContext db)
		{
			_logger = logger;
			_db = db;

		}

		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			var domainWeather = _db.WeatherExamples;

			return domainWeather.Select(weather => new WeatherForecast
				{
					Id = weather.Id, City = weather.City, High = weather.High, Low = weather.Low,
				})
				.ToList();
		}
	}
}
