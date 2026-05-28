namespace MiastaWeatherApi.Nowy_folder;

public class WeatherResponse
{
    public MainInfo Main { get; set; }
    public List<WeatherInfo> Weather { get; set; }
    public string Name { get; set; }
}

public class MainInfo
{
    public double Temp { get; set; }
    public double Feels_Like { get; set; }
    public int Humidity { get; set; }
}

public class WeatherInfo
{
    public string Main { get; set; }
    public string Description { get; set; }
}