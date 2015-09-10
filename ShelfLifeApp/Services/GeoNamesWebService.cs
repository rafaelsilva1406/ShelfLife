using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ShelfLifeApp.Services
{
//	public class Earthquake
//	{
//		public string eqid { get; set; }
//		public float magnitude { get; set; }
//		public float lng { get; set; }
//		public string src { get; set; }
//		public string datetime { get; set; }
//		public float depth { get; set; }
//		public float lat { get; set; }
//
//		public string Summary {
//			get{ return String.Format ("Date: {0}, Magnitude: {1}", datetime.Substring(0, 10), magnitude); }
//		}
//
//		public override string ToString ()
//		{
//			return String.Format ("{0}, {1}, {2}, {3}", lat, lng, magnitude, depth);
//		}
//	}
//
//	public class Rootobject
//	{
//		public Earthquake[] earthquakes { get; set; }
//	}

//	public class GeoNamesWebService
//	{
//		public GeoNamesWebService ()
//		{
//		}
//
//		public async Task<Earthquake[]> GetEarthquakesAsync () {
//
//			var client = new HttpClient ();
//
//			client.BaseAddress = new Uri("http://api.geonames.org/");
//
//			var response = await client.GetAsync("earthquakesJSON?north=44.1&south=-9.9&east=-22.4&west=55.2&username=bertt");
//
//			var earthquakesJson = response.Content.ReadAsStringAsync().Result;
//
//			var rootobject = JsonConvert.DeserializeObject<Rootobject>(earthquakesJson);
//
//			return rootobject.earthquakes;
//
//		}
//	}
}

