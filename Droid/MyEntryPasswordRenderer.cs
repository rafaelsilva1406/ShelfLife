using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using ShelfLifeApp.Custom;
using ShelfLifeApp.Droid;

[assembly:ExportRenderer(typeof(MyEntryPassword), typeof(MyEntryPasswordRenderer))]

namespace ShelfLifeApp.Droid
{
	public class MyEntryPasswordRenderer : EntryRenderer
	{
		// Override the OnElementChanged method so we can tweak this renderer post-initial setup
		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);

			if (Control != null) {
				// do whatever you want to the textField here!
				Control.SetBackgroundColor(global::Android.Graphics.Color.White);
				Control.SetTextColor(global::Android.Graphics.Color.DarkGray);
				Control.SetPadding (20,5,5,5);
				Control.SetHeight(120);
			}
		}
	}
}

