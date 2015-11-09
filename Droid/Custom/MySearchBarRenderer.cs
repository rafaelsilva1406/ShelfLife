using Android.Widget;
using Android.Text;
using G = Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
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
				// Get native control (background set in shared code, but can use SetBackgroundColor here)
				SearchView searchView = (base.Control as SearchView);
				searchView.SetInputType( InputTypes.ClassText | InputTypes.TextVariationNormal );

				// Access search textview within control
				int textViewId = searchView.Context.Resources.GetIdentifier( "android:id/search_src_text", null, null );
				EditText textView = (searchView.FindViewById( textViewId ) as EditText);

				// Set custom colors
				textView.SetBackgroundColor(global::Android.Graphics.Color.LightGray);
				textView.SetTextColor(global::Android.Graphics.Color.DarkGray);
				textView.SetHintTextColor(global::Android.Graphics.Color.Gray);
				textView.SetPadding(20,5,5,5);

				// Customize frame color
				int frameId = searchView.Context.Resources.GetIdentifier( "android:id/search_plate", null, null );
				Android.Views.View frameView = (searchView.FindViewById( frameId ) as Android.Views.View);
				frameView.SetBackgroundColor( G.Color.Rgb( 96, 96, 96 ) );
			}
		}
	}
}

