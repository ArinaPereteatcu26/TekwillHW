namespace WebApplication.Repositories
{
    public interface IWeatherForecastRepository
    {
        IEnumerable<WeatherForecast> GetAll();
        WeatherForecast GetByName(string summary);
        void Create(WeatherForecast weatherForecast);
        void Update(WeatherForecast weatherForecast);
        void DeleteByName(string summary);
    }

}
