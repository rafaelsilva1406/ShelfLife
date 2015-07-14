using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using ShelfLifeApp.Custom;
using ShelfLifeApp.Droid;

[assembly:ExportRenderer(typeof(MyDangerButton),typeof(MyDangerButtonRenderer))]

namespace ShelfLifeApp.Droid
{
	public class MyDangerButtonRenderer : ButtonRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement == null){
				Control.SetHeight (100);
				Control.SetTextColor (global::Android.Graphics.Color.White);
				var newBtn = (MyDangerButton)e.NewElement;
				newBtn.SizeChanged += (s, args) => {
					var radius = (float)System.Math.Min(10,10);	
					var normal = new global::Android.Graphics.Drawables.GradientDrawable ();
					normal.SetColor(global::Android.Graphics.Color.Red);
					normal.SetCornerRadius(radius);
					normal.SetStroke(4,global::Android.Graphics.Color.Red);
					var pressed = new global::Android.Graphics.Drawables.GradientDrawable ();
					var highlight = Context.ObtainStyledAttributes(new int[] {global::Android.Resource.Attribute.ColorActivatedHighlight}).GetColor(0,global::Android.Graphics.Color.Transparent);
					pressed.SetColor(highlight);
					pressed.SetCornerRadius(radius);
					pressed.SetStroke(4,global::Android.Graphics.Color.Red);
					var sld = new global::Android.Graphics.Drawables.StateListDrawable();
					sld.AddState(new int[]{global::Android.Resource.Attribute.StatePressed},pressed);
					sld.AddState(new int[]{},normal);
					Control.SetBackgroundDrawable(sld);
				};
			}
		}
	}
}

