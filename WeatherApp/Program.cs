using System;
using Newtonsoft.Json.Linq;
using System.IO;

namespace WeatherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = File.ReadAllText("appsettings.json");
            string APIkey = JObject.Parse(key).GetValue("DefaultKey").ToString();

            Console.WriteLine("Please enter your zipcode: ");
            string zipCode = Console.ReadLine();
            Console.WriteLine("Please enter your country code: ");
            string countryCode = Console.ReadLine().ToLower();

            string apiCall = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode},{countryCode}&appid={APIkey}";

            Console.WriteLine(WeatherMap.GetTemp(apiCall));
        }
    }
}
