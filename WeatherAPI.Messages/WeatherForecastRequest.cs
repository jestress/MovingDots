namespace WeatherAPI.Messages
{
    public class WeatherForecastRequest
    {
        public string Location { get; set; }
        public string TargetUnit { get; set; }
    }
}
