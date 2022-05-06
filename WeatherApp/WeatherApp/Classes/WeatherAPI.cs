using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;

namespace WeatherApp.Classes
{
    public class WeatherAPI
    {
		// using System.Xml.Serialization;
		// XmlSerializer serializer = new XmlSerializer(typeof(Current));
		// using (StringReader reader = new StringReader(xml))
		// {
		//    var test = (Current)serializer.Deserialize(reader);
		// }

		[XmlRoot(ElementName = "coord")]
		public class Coord
		{

			[XmlAttribute(AttributeName = "lon")]
			public double Lon { get; set; }

			[XmlAttribute(AttributeName = "lat")]
			public double Lat { get; set; }
		}

		[XmlRoot(ElementName = "sun")]
		public class Sun
		{

			[XmlAttribute(AttributeName = "rise")]
			public DateTime Rise { get; set; }

			[XmlAttribute(AttributeName = "set")]
			public DateTime Set { get; set; }
		}

		[XmlRoot(ElementName = "city")]
		public class City
		{

			[XmlElement(ElementName = "coord")]
			public Coord Coord { get; set; }

			[XmlElement(ElementName = "country")]
			public string Country { get; set; }

			[XmlElement(ElementName = "timezone")]
			public int Timezone { get; set; }

			[XmlElement(ElementName = "sun")]
			public Sun Sun { get; set; }

			[XmlAttribute(AttributeName = "id")]
			public int Id { get; set; }

			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }

			[XmlText]
			public string Text { get; set; }
		}

		[XmlRoot(ElementName = "temperature")]
		public class Temperature
		{

			[XmlAttribute(AttributeName = "value")]
			public double Value { get; set; }

			[XmlAttribute(AttributeName = "min")]
			public double Min { get; set; }

			[XmlAttribute(AttributeName = "max")]
			public double Max { get; set; }

			[XmlAttribute(AttributeName = "unit")]
			public string Unit { get; set; }
		}

		[XmlRoot(ElementName = "feels_like")]
		public class FeelsLike
		{

			[XmlAttribute(AttributeName = "value")]
			public double Value { get; set; }

			[XmlAttribute(AttributeName = "unit")]
			public string Unit { get; set; }
		}

		[XmlRoot(ElementName = "humidity")]
		public class Humidity
		{

			[XmlAttribute(AttributeName = "value")]
			public int Value { get; set; }

			[XmlAttribute(AttributeName = "unit")]
			public string Unit { get; set; }
		}

		[XmlRoot(ElementName = "pressure")]
		public class Pressure
		{

			[XmlAttribute(AttributeName = "value")]
			public int Value { get; set; }

			[XmlAttribute(AttributeName = "unit")]
			public string Unit { get; set; }
		}

		[XmlRoot(ElementName = "speed")]
		public class Speed
		{

			[XmlAttribute(AttributeName = "value")]
			public double Value { get; set; }

			[XmlAttribute(AttributeName = "unit")]
			public string Unit { get; set; }

			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
		}

		[XmlRoot(ElementName = "gusts")]
		public class Gusts
		{

			[XmlAttribute(AttributeName = "value")]
			public double Value { get; set; }
		}

		[XmlRoot(ElementName = "direction")]
		public class Direction
		{

			[XmlAttribute(AttributeName = "value")]
			public int Value { get; set; }

			[XmlAttribute(AttributeName = "code")]
			public string Code { get; set; }

			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
		}

		[XmlRoot(ElementName = "wind")]
		public class Wind
		{

			[XmlElement(ElementName = "speed")]
			public Speed Speed { get; set; }

			[XmlElement(ElementName = "gusts")]
			public Gusts Gusts { get; set; }

			[XmlElement(ElementName = "direction")]
			public Direction Direction { get; set; }
		}

		[XmlRoot(ElementName = "clouds")]
		public class Clouds
		{

			[XmlAttribute(AttributeName = "value")]
			public int Value { get; set; }

			[XmlAttribute(AttributeName = "name")]
			public string Name { get; set; }
		}

		[XmlRoot(ElementName = "visibility")]
		public class Visibility
		{

			[XmlAttribute(AttributeName = "value")]
			public int Value { get; set; }
		}

		[XmlRoot(ElementName = "precipitation")]
		public class Precipitation
		{

			[XmlAttribute(AttributeName = "mode")]
			public string Mode { get; set; }
		}

		[XmlRoot(ElementName = "weather")]
		public class Weather
		{

			[XmlAttribute(AttributeName = "number")]
			public int Number { get; set; }

			[XmlAttribute(AttributeName = "value")]
			public string Value { get; set; }

			[XmlAttribute(AttributeName = "icon")]
			public string Icon { get; set; }
		}

		[XmlRoot(ElementName = "lastupdate")]
		public class Lastupdate
		{

			[XmlAttribute(AttributeName = "value")]
			public DateTime Value { get; set; }
		}

		[XmlRoot(ElementName = "current")]
		public class Current
		{

			[XmlElement(ElementName = "city")]
			public City City { get; set; }

			[XmlElement(ElementName = "temperature")]
			public Temperature Temperature { get; set; }

			[XmlElement(ElementName = "feels_like")]
			public FeelsLike FeelsLike { get; set; }

			[XmlElement(ElementName = "humidity")]
			public Humidity Humidity { get; set; }

			[XmlElement(ElementName = "pressure")]
			public Pressure Pressure { get; set; }

			[XmlElement(ElementName = "wind")]
			public Wind Wind { get; set; }

			[XmlElement(ElementName = "clouds")]
			public Clouds Clouds { get; set; }

			[XmlElement(ElementName = "visibility")]
			public Visibility Visibility { get; set; }

			[XmlElement(ElementName = "precipitation")]
			public Precipitation Precipitation { get; set; }

			[XmlElement(ElementName = "weather")]
			public Weather Weather { get; set; }

			[XmlElement(ElementName = "lastupdate")]
			public Lastupdate Lastupdate { get; set; }
		}




		public static Current GetCurrentWeather()
        {
            try
            {
                var client = new HttpClient();
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri("https://community-open-weather-map.p.rapidapi.com/weather?q=Visalia%2CUS&lat=0&lon=0&id=2172797&lang=null&units=imperial&mode=xml"),
					Headers =
					{
						{ "X-RapidAPI-Host", "community-open-weather-map.p.rapidapi.com" },
						{ "X-RapidAPI-Key", "77bcf8a05cmshb42deaf86c1f1a4p10ad49jsnd1b36d62ea8b" },
					},
				};
				client.Timeout = TimeSpan.FromSeconds(5);
                var response = client.SendAsync(request).Result;
                if (response.IsSuccessStatusCode)
                {
                    var body = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine("\n<--\n" + body + "\n-->\n");
                    XmlSerializer serializer = new XmlSerializer(typeof(Current));
                    using (StringReader reader = new StringReader(body))
                    {
                        return (Current)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception ex)
            {
				Debug.Flush();
				Debug.WriteLine(ex.ToString());
            }
            return null;
        }
    }
}
