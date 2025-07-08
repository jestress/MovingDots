using System;
using UltimateTemperatureLibrary;

namespace MovingDots.WeatherAPI.Business
{
    public static class TemperatureConverter
    {
        public static double KelvinToCelsius(double temperatureInKelvin)
        {
            if(temperatureInKelvin < 0)
            {
                throw new ArgumentException(
                    "Temperature value in Kelvin may not be lower than zero!", 
                    nameof(temperatureInKelvin));
            }

            var celsiusRepresentation = new Celsius(
                new Kelvin(temperatureInKelvin));

            return celsiusRepresentation.Value;
        }

        public static double KelvinToFahrenheit(double temperatureInKelvin)
        {
            if (temperatureInKelvin < 0)
            {
                throw new ArgumentException(
                    "Temperature value in Kelvin may not be lower than zero!",
                    nameof(temperatureInKelvin));
            }

            var fahrenheitRepresentation = new Fahrenheit(
                new Kelvin(temperatureInKelvin));

            return fahrenheitRepresentation.Value;
        }
    }
}
