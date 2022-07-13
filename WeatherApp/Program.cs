using System;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading;

namespace WeatherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //EXERCISE CODE BELOW

            //string key = File.ReadAllText("appsettings.json");
            //string APIkey = JObject.Parse(key).GetValue("DefaultKey").ToString();

            //Console.WriteLine("Please enter your zipcode: ");
            //string zipCode = Console.ReadLine();
            
            //string apiCall = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode}&units=imperial&appid={APIkey}";

            //Console.WriteLine();
            //Console.WriteLine($"It is currently {WeatherMap.GetTemp(apiCall)}°F in your location.");

            //Using Weather Class Object
            var wx = new Weather();

            var cont = true;

            do
            {                
                Console.WriteLine("Please enter your zipcode: ");
                string zipCode = Console.ReadLine();

                wx.GetAPIResponse(zipCode);
                wx.GetWeather();

                Console.WriteLine($"Current weather for {wx.CityName}");
                Console.WriteLine($"Temperature: {wx.Temperature}°");
                Console.WriteLine($"Heat Index: {wx.HeatIndex}°");
                Console.WriteLine($"Condition: {wx.Condition}");
                Console.WriteLine($"Humidity: {wx.Humidity}");
                Console.WriteLine($"Wind Speed: {wx.WindSpeed} mph");
                Console.WriteLine($"Sunrise: {wx.Sunrise.ToLocalTime().ToShortTimeString()}");
                Console.WriteLine($"Sunset: {wx.Sunset.ToLocalTime().ToShortTimeString()}");
                Console.WriteLine();
                //Thread.Sleep(5000);

                Console.WriteLine("Would you like to get weather for another location?");
                Console.WriteLine("Y or N?");
                var userResponse = Console.ReadLine().ToLower();
                cont = (userResponse == "n") ? false : true;

            } while (cont);
        }
    }
}
