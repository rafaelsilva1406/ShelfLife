using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using ShelfLifeApp.Custom;
using ShelfLifeApp.Droid;

[assembly:ExportRenderer(typeof(MyBackgroundStackLayout),typeof(MyBackgroundStackLayoutRenderer))]

namespace ShelfLifeApp.Droid
{
	public class MyBackgroundStackLayoutRenderer
	{
		public MyBackgroundStackLayoutRenderer ()
		{
		}
	}
}

