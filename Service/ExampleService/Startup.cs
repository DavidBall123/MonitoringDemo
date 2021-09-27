namespace ExampleService
{
	using ExampleService.Context;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;
	using Microsoft.OpenApi.Models;

	/// <summary>
	/// Start up class.
	/// </summary>
	public class Startup
	{
		private const string MyAllowSpecificOrigins = "AllowSpecificOrigin";

		/// <summary>
		/// Initializes a new instance of the <see cref="Startup"/> class.
		/// </summary>
		/// <param name="configuration">The configuration key/value collection.</param>
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		/// <summary>
		/// Gets the configuration collection.
		/// </summary>
		public IConfiguration Configuration { get; }

		/// <summary>
		/// This method gets called by the runtime. Use this method to add services to the container.
		/// </summary>
		/// <param name="services">The service collection.</param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy(MyAllowSpecificOrigins, builder => builder.WithOrigins("http://localhost:3001"));
			});

			services.AddControllers();

			services.AddDbContext<MonitoringContext>(
				options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExampleService", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExampleService v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseCors(MyAllowSpecificOrigins);

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
