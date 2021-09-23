using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ExampleService.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleService.Context
{
    public class MonitoringContext : DbContext
    {
	    public MonitoringContext(DbContextOptions<MonitoringContext> options)
	    : base(options)
	    {
		    
	    }

		public DbSet<WeatherExample> WeatherExamples { get; set; }
    }
}
