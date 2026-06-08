using Microsoft.AspNetCore.Mvc;
using MiastaWeatherApi.Nowy_folder;

namespace MiastaWeatherApi.Controllers;

[ApiController]
[Route("cities")]
public class CitiesController : ControllerBase
{
    private static List<City> cities = new()
    {
        new City { Id = 1, Name = "Osaka" },
        new City { Id = 2, Name = "New York" },
        new City { Id = 3, Name = "Tokyo" }
    };

    [HttpGet]
    public IActionResult GetAllCities()
    {
        return Ok(cities);
    }

    [HttpGet("{id}")]
    public IActionResult GetCity(int id)
    {
        var city = cities.FirstOrDefault(c => c.Id == id);
        if (city == null)
            return NotFound();
        return Ok(city);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCity(int id, City updatedCity)
    {
        var city = cities.FirstOrDefault(c => c.Id == id);
        if (city == null)
            return NotFound();

        city.Name = updatedCity.Name;
        return Ok(city);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCity(int id)
    {
        var city = cities.FirstOrDefault(c => c.Id == id);
        if (city == null)
            return NotFound();

        cities.Remove(city);
        return NoContent();
    }
}