using System;
using ShelfLifeApp;

[assembly:Xamarin.Forms.Dependency(typeof(ShelfLifeApp.Droid.Localize))]
namespace ShelfLifeApp.Droid
{
	public class Localize : ShelfLifeApp.ILocalize
	{
		public System.Globalization.CultureInfo GetCurrentCultureInfo ()
		{
			var androidLocale = Java.Util.Locale.Default;
			var netLanguage = androidLocale.ToString().Replace ("_", "-"); // turns pt_BR into pt-BR
			return new System.Globalization.CultureInfo(netLanguage);
		}
	}
}

