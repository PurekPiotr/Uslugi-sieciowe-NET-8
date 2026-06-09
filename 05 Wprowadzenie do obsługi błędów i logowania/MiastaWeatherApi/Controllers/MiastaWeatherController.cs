using Microsoft.AspNetCore.Mvc;
using MiastaWeatherApi.Nowy_folder;
using System.Text.Json;

namespace MiastaWeatherApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public WeatherController(
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }

    [HttpGet("{city}")]
    public async Task<IActionResult> GetWeather(string city)
    {
        var apiKey = _configuration["WeatherApi:ApiKey"];
        var client = _httpClientFactory.CreateClient();
        var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric&lang=pl";
        var response = await client.GetAsync(url);
        if (!response.IsSuccessStatusCode)
        {
            return NotFound("Nie znaleziono miasta.");
        }
        var json = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var weather = JsonSerializer.Deserialize<WeatherResponse>(json, options);
        return Ok(weather);
    }
}