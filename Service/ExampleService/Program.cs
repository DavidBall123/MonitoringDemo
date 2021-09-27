namespace ExampleService
{
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.Hosting;

	/// <summary>
	/// The program entry class.
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Program entry.
		/// </summary>
		/// <param name="args">Progam entry parameters.</param>
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		/// <summary>
		/// Creates the host builder.
		/// </summary>
		/// <param name="args">Arguments.</param>
		/// <returns>The host builder.</returns>
		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
