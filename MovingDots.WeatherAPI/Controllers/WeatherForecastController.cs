using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovingDots.WeatherAPI.Business;
using MovingDots.WeatherAPI.Messages;

namespace MovingDots.WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly WeatherForecastRetrievalTransaction weatherForecastRetrievalTransaction
            = new WeatherForecastRetrievalTransaction();

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public WeatherForecastResponse Get(string cityName, string desiredUnitOfMeasurement)
        {
            if (string.IsNullOrEmpty(cityName))
            {
                return null;
            }

            return weatherForecastRetrievalTransaction.GetWeatherForecastForLocation(cityName, desiredUnitOfMeasurement);
        }
    }
}
