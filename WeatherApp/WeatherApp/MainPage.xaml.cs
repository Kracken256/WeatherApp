using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Classes;
using Xamarin.Forms;
using static WeatherApp.Classes.WeatherAPI;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Current weatherAPIClass = WeatherAPI.GetCurrentWeather();
            if (weatherAPIClass != null)
            {
                currentTemp.Text = Math.Round(weatherAPIClass.Temperature.Value).ToString();
                TempUnit.Text = weatherAPIClass.Temperature.Unit.StartsWith("f") ? "F°" : "C°";
                Humidity.Text = weatherAPIClass.Humidity.Value.ToString() + " " + weatherAPIClass.Humidity.Unit;
                Wind.Text = weatherAPIClass.Wind.Speed.Value.ToString() + " " + weatherAPIClass.Wind.Speed.Unit;
                Pressure.Text = weatherAPIClass.Pressure.Value.ToString() + " " + weatherAPIClass.Pressure.Unit;
                Clouds.Text = weatherAPIClass.Clouds.Value.ToString() + " %";
                details.Text = weatherAPIClass.Weather.Value;
                
            }
            dateTime.Text = DateTime.Now.ToLocalTime().ToString();
            //WeatherForecastList.ItemsSource = WeatherForecast;
        }
        List<Weather> WeatherForecast = new List<Weather>()
        {
            new Weather() {Date = "5/4/2022", Temp = "50"}
        };
        public class Weather
        {
            public string Date { get; set; }
            public string Temp { get; set; }
            public string Icon = "weather.png";
        }
    }
}
