using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using ShelfLifeApp.Custom;
using ShelfLifeApp.Droid;

[assembly:ExportRenderer(typeof(MyLabel), typeof(MyLabelRenderer))]

namespace ShelfLifeApp.Droid
{
	public class MyLabelRenderer : LabelRenderer
	{
		// Override the OnElementChanged method so we can tweak this renderer post-initial setup
		protected override void OnElementChanged (ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged (e);

			if (Control != null) {
				// do whatever you want to the textField here!
				Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
				Control.SetTextColor(global::Android.Graphics.Color.LightGray);
				Control.SetAllCaps (true);
			}
		}
	}
}

