using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using ShelfLifeApp.Custom;
using ShelfLifeApp.Droid;

[assembly:ExportRenderer(typeof(MyPicker),typeof(MyPickerRenderer))]

namespace ShelfLifeApp.Droid
{
	public class MyPickerRenderer : PickerRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement == null){
				Control.SetBackgroundColor (global::Android.Graphics.Color.LightGray);
				Control.SetTextColor (global::Android.Graphics.Color.DarkGray);
				Control.InputType = Android.Text.InputTypes.TextFlagNoSuggestions;
				Control.SetPadding (20,5,5,5);
				Control.SetHeight (150);
			}
		}
	}
}

