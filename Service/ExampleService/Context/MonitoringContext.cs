namespace ExampleService.Context
{
	using ExampleService.Models;
	using Microsoft.EntityFrameworkCore;

	/// <summary>
	/// The monitoring context class.
	/// </summary>
	public class MonitoringContext : DbContext
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="MonitoringContext"/> class.
		/// </summary>
		/// <param name="options">The db context options. </param>
		public MonitoringContext(DbContextOptions<MonitoringContext> options)
	    : base(options)
	    {
	    }

		/// <summary>
		/// Gets or sets the db weather examples.
		/// </summary>
		public DbSet<WeatherExample> WeatherExamples { get; set; }
    }
}
