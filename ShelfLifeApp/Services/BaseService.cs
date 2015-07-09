using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

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
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "en,en-US,es-PE;");
			var response = await httpClient.GetAsync (uri);
			response.EnsureSuccessStatusCode ();
			string content = await response.Content.ReadAsStringAsync ();
			return content;
		}

		public async Task<string> PostAsync(string uri, string data)
		{
			var httpClient = new HttpClient ();
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "en,en-US,es-PE;");
			var response = await httpClient.PostAsync (uri, new StringContent (data));
			//response.EnsureSuccessStatusCode ();
			var responseStream  = await response.Content.ReadAsStreamAsync ();
			var decompressedStream = new GZipStream (responseStream , CompressionMode.Decompress);
			var streamReader = new StreamReader (decompressedStream);
			return streamReader.ReadToEnd();
		}
	}
}

