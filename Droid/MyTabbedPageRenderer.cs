using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.App;
using ShelfLifeApp.Custom;
using ShelfLifeApp.Droid;
using System.ComponentModel;
using Android.Views;
using Android.Graphics.Drawables;
using Android.Widget;

[assembly: ExportRenderer(typeof(MyTabbedPage), typeof(MyTabbedPageRenderer))]

namespace ShelfLifeApp.Droid
{
	public class MyTabbedPageRenderer : TabbedRenderer
	{
		private Activity activity;
		private const string COLOR = "#000000";
		private bool isFirstDesign = true;

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			activity = this.Context as Activity;
		}

		protected override void OnWindowVisibilityChanged(ViewStates visibility)
		{
			base.OnWindowVisibilityChanged(visibility);
			if (isFirstDesign)
			{
				ActionBar actionBar = activity.ActionBar;

				ColorDrawable colorDrawable = new ColorDrawable(Android.Graphics.Color.ParseColor(COLOR));
				//actionBar.SetStackedBackgroundDrawable(colorDrawable);
				//actionBar.SetBackgroundDrawable (colorDrawable);
				//ActionBarTabsSetup(actionBar);

				isFirstDesign = false; 
			}
		}

//		private void ActionBarTabsSetup(ActionBar actionBar)
//		{
//			Android.App.ActionBar.Tab keypad = actionBar.GetTabAt(0);
//			if (TabIsEmpty(keypad))
//				TabSetup(keypad, Resource.Drawable.keypad);
//
//			Android.App.ActionBar.Tab contacts = actionBar.GetTabAt(1);
//			if (TabIsEmpty(contacts))
//				TabSetup(contacts, Resource.Drawable.contacts);
//
//			Android.App.ActionBar.Tab favorites = actionBar.GetTabAt(2);
//			if (TabIsEmpty(favorites))
//				TabSetup(favorites, Resource.Drawable.favorites);
//
//			Android.App.ActionBar.Tab callsLog = actionBar.GetTabAt(3);
//			if (TabIsEmpty(callsLog))
//				TabSetup(callsLog, Resource.Drawable.calls_log);
//
//			Android.App.ActionBar.Tab chat = actionBar.GetTabAt(4);
//			if (TabIsEmpty(chat))
//				TabSetup(chat, Resource.Drawable.messages);
//		}
//
//		private bool TabIsEmpty(ActionBar.Tab tab)
//		{
//			if (tab != null)
//			if (tab.CustomView == null)
//				return true;
//			return false;
//		}
//
//		private void TabSetup(ActionBar.Tab tab, int resourceID)
//		{
//			ImageView iv = new ImageView(activity);
//			iv.SetImageResource(resourceID);
//			iv.SetPadding(-35, 8, -35, 16);
//
//			tab.SetCustomView(iv);
//		}
	}
}

