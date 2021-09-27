namespace ExampleService.Models
{
	/// <summary>
	/// The weather forecast model.
	/// </summary>
	public class WeatherExample
    {
	    /// <summary>
	    /// Gets or sets the id.
	    /// </summary>
	    public int Id { get; set; }

	    /// <summary>
	    /// Gets or sets the city.
	    /// </summary>
	    public string City { get; set; }

	    /// <summary>
	    /// Gets or sets the temperature high.
	    /// </summary>
	    public int High { get; set; }

	    /// <summary>
	    /// Gets or sets the temperature low.
	    /// </summary>
	    public int Low { get; set; }
	}
}
