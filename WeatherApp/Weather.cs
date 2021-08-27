using System;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace WeatherApp
{
    public class Weather
    {
        public Weather()
        {
        }

        public string APIResponse { get; set; }
        public double Temperature { get; set; }
        public double HeatIndex { get; set; }
        public string Condition { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }
        public string CityName { get; set; }

        public void GetAPIResponse(string zipCode)
        {
            var key = File.ReadAllText("appsettings.json");
            var APIkey = JObject.Parse(key).GetValue("DefaultKey").ToString();

            var apiCall = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode}&units=imperial&appid={APIkey}";

            var client = new HttpClient();

            var response = client.GetStringAsync(apiCall).Result;

            this.APIResponse = response;
        }

        public void GetTemp()
        {
            this.Temperature = double.Parse(JObject.Parse(this.APIResponse)["main"]["temp"].ToString());
        }

        public void GetHeatIndex()
        {
            this.HeatIndex = double.Parse(JObject.Parse(this.APIResponse)["main"]["feels_like"].ToString());
        }

        public void GetCondition()
        {
            this.Condition = JObject.Parse(this.APIResponse)["weather"]["main"].ToString();
        }

        public void GetHumidity()
        {
            this.Humidity = double.Parse(JObject.Parse(this.APIResponse)["main"]["humidity"].ToString());
        }

        public void GetWindSpeed()
        {
            this.WindSpeed = double.Parse(JObject.Parse(this.APIResponse)["wind"]["speed"].ToString());
        }

        public void GetCityName()
        {
            CityName = JObject.Parse(APIResponse)["name"].ToString();
        }

        public void GetWeather()
        {
            GetCityName();
            GetTemp();
            GetHeatIndex();
            //GetCondition();
            GetHumidity();
            GetWindSpeed();
        }
    }
}
