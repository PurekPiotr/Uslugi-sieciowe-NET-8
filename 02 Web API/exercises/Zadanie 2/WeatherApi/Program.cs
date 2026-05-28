var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

// Pierwszy endpoint

var random = new Random();

app.MapGet("/losowa_temperatura", () =>
{
    int temperatura = random.Next(-273, 101); // Losowa od 0 bezwzględnego do 100 stopni C
    return Results.Ok(new
    {
        Temperatura = temperatura,
        Jednostka = "Celsjusz"
    });
});

// Drugi endpoint 

var kierunki_wiatru = new List<string>
{
    "Wschód", "Zachód", "Północ", "Południe", "Północny-Wschód", "Północny-Zachód", "Południowy-Wschód", "Południowy-Zachód"
};

app.MapGet("/kierunek_wiatru", () =>
{
    int index = random.Next(kierunki_wiatru.Count);
    string wiatr = kierunki_wiatru[index];
    return Results.Ok(new
    {
        KierunekWiatru = wiatr
    });
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}