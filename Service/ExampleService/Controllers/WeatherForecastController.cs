namespace ExampleService.Controllers
{
	using System.Collections.Generic;
	using System.Linq;
	using ExampleService.Context;
	using ExampleService.Models;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Logging;

	/// <summary>
	/// The weather forecast controller.
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly ILogger<WeatherForecastController> logger;
		private readonly MonitoringContext monitoringContext;

		/// <summary>
		/// Initializes a new instance of the <see cref="WeatherForecastController"/> class.
		/// </summary>
		/// <param name="logger">The logger.</param>
		/// <param name="monitoringContext">The monitoring context.</param>
		public WeatherForecastController(ILogger<WeatherForecastController> logger, MonitoringContext monitoringContext)
		{
			this.logger = logger;
			this.monitoringContext = monitoringContext;
		}

		/// <summary>
		/// Gets a list of weather examples.
		/// </summary>
		/// <returns>A list of weather examples.</returns>
		[HttpGet]
		public IEnumerable<WeatherExample> Get()
		{
			logger.LogInformation("A request for example weathers was made.");
			var domainWeather = monitoringContext.WeatherExamples;

			return domainWeather.Select(weather => new WeatherExample
			{
					Id = weather.Id, City = weather.City, High = weather.High, Low = weather.Low,
			}).ToList();
		}
	}
}
