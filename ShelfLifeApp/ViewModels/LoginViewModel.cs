using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ShelfLifeApp.Services;

namespace ShelfLifeApp.ViewModels
{
	public class LoginViewModel : BaseViewModel
	{
		public LoginViewModel ()
		{
		}
		private static readonly object _PadLock = new object ();
		private static LoginViewModel _Instance = null;

		public static LoginViewModel Instance
		{
			get
			{ 
				if (_Instance == null)
				{
					lock (_PadLock)
					{
						if(_Instance ==  null){
							_Instance = new LoginViewModel ();
						}
					}		
				}

				return _Instance;
			}
		}

		public async Task PostService()
		{
			var s = new BaseService();
			string loginObject = new JObject (
				new JProperty("data",
					new JObject(
						new JProperty("credentials",
							new JObject(
								new JProperty("userEmail","rasilv@missionpro.com"),
								new JProperty("userPassword","chang3m3")
							)
						)
					)
				)
			).ToString(Newtonsoft.Json.Formatting.None);
			string sResponse = await s.PostAsync("http://192.168.1.48:10080/appstack/public/v1/rest-login",loginObject);
			System.Diagnostics.Debug.WriteLine ("{0}",sResponse);
			//var json = JObject.Parse(sResponse);
		}
	}
}

