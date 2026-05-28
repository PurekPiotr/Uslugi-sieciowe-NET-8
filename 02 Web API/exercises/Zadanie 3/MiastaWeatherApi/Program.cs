using MiastaWeatherApi.Nowy_folder;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
var app = builder.Build();

app.MapGet("/weather/{city}", async ( string city, IHttpClientFactory httpClientFactory, IConfiguration configuration) =>
{
    var apiKey = configuration["WeatherApi:ApiKey"];
    var client = httpClientFactory.CreateClient();
    var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric&lang=pl";
    var response = await client.GetAsync(url);
    if (!response.IsSuccessStatusCode)
    {
        return Results.NotFound("Nie znaleziono miasta.");
    }
    var json = await response.Content.ReadAsStringAsync();
    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    var weather = JsonSerializer.Deserialize<WeatherResponse>(json, options);
    return Results.Ok(weather);
});
app.Run();