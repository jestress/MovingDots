using WeatherAPI.Messages.OpenWeatherMap;
using RestSharp;
using System;
using System.Text.Json;

namespace WeatherAPI.Integration
{
    public class OpenWeatherApiIntegration
    {
        private static readonly string RestAPIEndpoint = "http://api.openweathermap.org/";
        private static readonly string WeatherForecastResourceUrl = "data/2.5/weather";
        private static readonly string APIKey = "6b34b4b2b9b20b3af3530f12a8a7723e";

        public GetWeatherForecastForLocationResponse GetWeatherForLocation(string locationName)
        {
            if (string.IsNullOrEmpty(locationName))
            {
                throw new ArgumentNullException(nameof(locationName));
            }

            var client = new RestClient(RestAPIEndpoint);

            var signInRequest = new RestRequest(WeatherForecastResourceUrl);

            signInRequest.AddQueryParameter("q", locationName);
            signInRequest.AddQueryParameter("appId", APIKey);

            var response = client.Post(signInRequest);

            if (response == null ||
                response.Cookies == null)
            {
                throw new InvalidOperationException("Weather API has not returned any data.");
            }

            var deserializedWeatherApiResponse
                = JsonSerializer.Deserialize<GetWeatherForecastForLocationResponse>(response.Content);

            return deserializedWeatherApiResponse;
        }
    }
}
