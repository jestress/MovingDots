using MovingDots.WeatherAPI.Integration;
using MovingDots.WeatherAPI.Messages;
using System;

namespace MovingDots.WeatherAPI.Business
{
    public class WeatherForecastRetrievalTransaction
    {
        private static readonly string CelsiusLetterRepresentation = "C";
        private static readonly string FahrenheitLetterRepresentation = "F";

        private readonly OpenWeatherApiIntegration openWeatherApiIntegration = new OpenWeatherApiIntegration();

        public WeatherForecastResponse GetWeatherForecastForLocation(
            string cityName,
            string desiredUnitOfMeasurement = "C")
        {
            if (string.IsNullOrEmpty(cityName))
            {
                throw new ArgumentNullException(nameof(cityName));
            }

            var getWeatherForecastForLocationResponse
                = openWeatherApiIntegration.GetWeatherForLocation(cityName);

            if (getWeatherForecastForLocationResponse == null ||
                getWeatherForecastForLocationResponse.main == null ||
                string.IsNullOrEmpty(getWeatherForecastForLocationResponse.name))
            {
                throw new ApplicationException("Received data from OpenWeather API could not be read!");
            }

            double rawTemperatureValueInKelvin = getWeatherForecastForLocationResponse.main.temp;
            double convertedTemperatureValueToTargetUnit;

            if(desiredUnitOfMeasurement == CelsiusLetterRepresentation)
            {
                convertedTemperatureValueToTargetUnit 
                    = TemperatureConverter.KelvinToCelsius(rawTemperatureValueInKelvin);
            } 
            else if (desiredUnitOfMeasurement == FahrenheitLetterRepresentation)
            {
                convertedTemperatureValueToTargetUnit 
                    = TemperatureConverter.KelvinToFahrenheit(rawTemperatureValueInKelvin);
            }
            else
            {
                throw new InvalidOperationException("Given target unit of temperature is not recognized!");
            }

            var weatherForecastResponse = new WeatherForecastResponse
            {
                CityName = getWeatherForecastForLocationResponse.name,
                Degrees = convertedTemperatureValueToTargetUnit,
                Unit = desiredUnitOfMeasurement

            };

            return weatherForecastResponse;
        }
    }
}
