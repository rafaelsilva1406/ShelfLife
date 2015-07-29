using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using ShelfLifeApp.Custom;
using ShelfLifeApp.Droid;

[assembly:ExportRenderer(typeof(MySearchBar), typeof(MySearchBarRenderer))]

namespace ShelfLifeApp.Droid
{
	public class MySearchBarRenderer : SearchBarRenderer
	{
		// Override the OnElementChanged method so we can tweak this renderer post-initial setup
		protected override void OnElementChanged (ElementChangedEventArgs<SearchBar> e)
		{
			base.OnElementChanged (e);

			if (Control != null) {
				// do whatever you want to the textField here!
				Control.SetBackgroundColor(global::Android.Graphics.Color.White);
				Control.SetPadding (20,5,5,5);
			}
		}
	}
}

