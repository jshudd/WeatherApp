using System;
using WeatherApp;
using Xunit;

namespace WeatherAppTests
{
    public class WeatherTests
    {
        [Theory]
        [InlineData("35242")]
        [InlineData("35226")]
        [InlineData("32541")]
        [InlineData("37211")]
        [InlineData("35184")]
        [InlineData("95014")]
        public void ShouldGetResponse(string zipCode)
        {
            var weather = new Weather();

            weather.GetAPIResponse(zipCode);

            Assert.NotNull(weather.APIResponse);
        }

        [Theory]
        [InlineData("35242")]
        [InlineData("35226")]
        [InlineData("32541")]
        [InlineData("37211")]
        [InlineData("35184")]
        [InlineData("95014")]
        public void ShouldParseZip(string zipCode)
        {
            Weather weather = new Weather();

            weather.GetAPIResponse(zipCode);

            weather.GetTemp();

            Assert.NotNull(weather.Temperature);
        }

        [Theory]
        [InlineData("35242", "Birmingham")]
        [InlineData("37211", "Nashville")]
        [InlineData("32541", "Destin")]
        [InlineData("95014", "Cupertino")]
        [InlineData("35184", "West Blocton")]
        public void ShouldParseCity(string zipCode, string expected)
        {
            Weather weather = new Weather();

            weather.GetAPIResponse(zipCode);

            weather.GetCityName();

            Assert.Equal(expected, weather.CityName);
        }
    }
}
