﻿using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using ShelfLifeApp.Custom;
using ShelfLifeApp.Droid;

[assembly:ExportRenderer(typeof(MyDatePicker), typeof(MyDatePickerRenderer))]

namespace ShelfLifeApp.Droid
{
	public class MyDatePickerRenderer : DatePickerRenderer
	{
		// Override the OnElementChanged method so we can tweak this renderer post-initial setup
		protected override void OnElementChanged (ElementChangedEventArgs<DatePicker> e)
		{
			base.OnElementChanged (e);

			if (Control != null) {
				// do whatever you want to the textField here!
				Control.SetBackgroundColor(global::Android.Graphics.Color.LightGray);
				Control.SetTextColor(global::Android.Graphics.Color.DarkGray);
				Control.SetPadding (20,5,5,5);
				Control.SetHeight(120);
			}
		}
	}
}
