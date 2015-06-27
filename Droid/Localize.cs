using System;
using Xamarin.Forms;
using System.Threading;
using ShelfLifeApp;

[assembly:Dependency(typeof(ShelfLifeApp.Droid.Localize))]
namespace ShelfLifeApp.Droid
{
	public class Localize : ILocalize
	{
		public System.Globalization.CultureInfo GetCurrentCultureInfo ()
		{
			var androidLocale = Java.Util.Locale.Default;
			var netLanguage = androidLocale.Language.Replace ("_", "-");

			return new System.Globalization.CultureInfo(netLanguage);
		}

		public void SetLocale ()
		{
			var androidLocale = Java.Util.Locale.Default; // user's preferred locale
			var netLocale = androidLocale.ToString().Replace ("_", "-"); 
			var ci = new System.Globalization.CultureInfo (netLocale);

			Thread.CurrentThread.CurrentCulture = ci;
			Thread.CurrentThread.CurrentUICulture = ci;
		}
	}
}

