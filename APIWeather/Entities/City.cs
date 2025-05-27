namespace APIWeather.Entities
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }
        public decimal Temperature { get; set; }
        public string WeatherDescription { get; set; }
    }
}
