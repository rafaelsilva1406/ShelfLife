using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services;

namespace ShelfLifeApp.Droid
{
	[Activity (Label = "ShelfLifeApp.Droid", Icon = "@drawable/icon", MainLauncher = false, Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]

	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			var container = new SimpleContainer ();
			container.Register<IDevice> (t => AndroidDevice.CurrentDevice);
			container.Register<IDisplay> (t => t.Resolve<IDevice> ().Display);
			container.Register<INetwork>(t=> t.Resolve<IDevice>().Network);

			Resolver.SetResolver (container.GetResolver ());

			global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new App ());
			ActionBar.SetHomeButtonEnabled (true);
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			switch (item.ItemId) {
			case Android.Resource.Id.Home:
				OpenOptionsMenu ();
				break;
			}
			return base.OnOptionsItemSelected (item);
		}
	}

}

