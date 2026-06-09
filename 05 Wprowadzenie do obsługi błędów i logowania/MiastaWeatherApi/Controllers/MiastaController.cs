using Microsoft.AspNetCore.Mvc;
using MiastaWeatherApi.Nowy_folder;

namespace MiastaWeatherApi.Controllers;

[ApiController]
[Route("cities")]
public class CitiesController : ControllerBase
{

    private readonly ILogger<CitiesController> _logger;

    private static List<City> cities = new()
    {
        new City { Id = 1, Name = "Osaka" },
        new City { Id = 2, Name = "New York" },
        new City { Id = 3, Name = "Tokyo" }
    };

    public CitiesController(ILogger<CitiesController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetAllCities()
    {
        _logger.LogInformation("Pobrano wszystkie miasta");
        return Ok(cities);
    }

    [HttpGet("{id}")]
    public IActionResult GetCity(int id)
    {
        var city = cities.FirstOrDefault(c => c.Id == id);

        if (city == null)
        {
            _logger.LogWarning("Nie znaleziono miasta o ID {Id}", id);
            return NotFound();
        }

        return Ok(city);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCity(int id, City updatedCity)
    {
        var city = cities.FirstOrDefault(c => c.Id == id);

        if (city == null) { 
            _logger.LogWarning("Próba aktualizacji nieistniejącego miasta {Id}", id);
            return NotFound();
        }
            
        city.Name = updatedCity.Name;

        _logger.LogInformation("Zaktualizowano miasto o ID {Id}", id);

        return Ok(city);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCity(int id)
    {
        var city = cities.FirstOrDefault(c => c.Id == id);

        if (city == null)
        {
            _logger.LogInformation("Próba usunięcia nieistniejącego miasta {Id}", id);
            return NotFound();
        }

        cities.Remove(city);

        _logger.LogInformation("Usunięto miasto o ID {Id}", id);

        return NoContent();
    }
}