using NUnit.Framework;
using System;

namespace WeatherAPI.Business.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TemperatureConverter_ConvertsKelvinToCelsiusWithKelvinLowerThanAbsoluteZero_ThrowsInvalidArgumentException()
        {
            // Arrange
            string invalidParameterName = "temperatureInKelvin";
            double kelvinTemperatureLowerThanZero = -273;

            // Act
            try
            {
                TemperatureConverter.KelvinToCelsius(kelvinTemperatureLowerThanZero);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(invalidParameterName, ex.ParamName);
            }

            // Assert
            Assert.Pass();
        }

        [Test]
        public void TemperatureConverter_ConvertsKelvinToFahrenheitWithKelvinLowerThanAbsoluteZero_ThrowsInvalidArgumentException()
        {
            // Arrange
            string invalidParameterName = "temperatureInKelvin";
            double kelvinTemperatureLowerThanZero = -275;

            // Act
            try
            {
                TemperatureConverter.KelvinToFahrenheit(kelvinTemperatureLowerThanZero);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(invalidParameterName, ex.ParamName);
            }

            // Assert
            Assert.Pass();
        }
    }
}