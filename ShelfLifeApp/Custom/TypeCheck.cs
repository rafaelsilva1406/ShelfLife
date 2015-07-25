using System;
using Newtonsoft.Json.Linq;

namespace ShelfLifeApp.Custom
{
	public class TypeCheck
	{
		public TypeCheck ()
		{
		}

		public bool isValidJson(string json)
		{
			try{
				JToken token = JObject.Parse(json);
				return true; 
			}
			catch(Exception ex){ 
				return false;
			}
		}
	}
}

