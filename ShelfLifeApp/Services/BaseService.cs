using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShelfLifeApp.Services
{
	public class BaseService
	{
		public BaseService ()
		{
		}

		public async Task<string> GetAsync(string uri)
		{
			var httpClient = new HttpClient ();
			var response = await httpClient.GetAsync (uri);
			response.EnsureSuccessStatusCode ();
			string content = await response.Content.ReadAsStringAsync ();
			return content;
		}
	}
}

