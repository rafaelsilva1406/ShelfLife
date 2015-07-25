using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ShelfLifeApp.Services;
using ShelfLifeApp.Custom;

namespace ShelfLifeApp.ViewModels
{
	public class LoginViewModel : BaseViewModel
	{
		public LoginViewModel ()
		{
		}
		private static readonly object _PadLock = new object ();
		private static LoginViewModel _Instance = null;
		private string [] _Services = {"http://192.168.1.48:10080/appstack/public/v1/rest-login"};

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
			
		public async Task<JToken> PostService(string Username, string Password, int Domain)
		{
			var s = new BaseService();
			var typeCheck = new TypeCheck ();
			string domain = "";
			JObject jObj = null;
			JToken data = null;
			 
			switch(Domain)
			{
				case 0:
					domain = "@missionpro.com";
				break;
				default:
					//throw exception
				break;
			}

			string loginObject = new JObject (
				new JProperty("data",
					new JObject(
						new JProperty("credentials",
							new JObject(
								new JProperty("userEmail",Username+domain),
								new JProperty("userPassword",Password)
							)
						)
					)
				)
			).ToString(Newtonsoft.Json.Formatting.None);

			string sResponse = await s.PostAsync (_Services [0], loginObject);

			if(typeCheck.isValidJson(sResponse)){
				jObj = JObject.Parse(sResponse);
				data = jObj["data"];
			}else{
				jObj = new JObject(
					new JProperty("error",sResponse)
				);
				data = jObj;
			}

			return data;
		}
	}
}

