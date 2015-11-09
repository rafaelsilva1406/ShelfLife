using ShelfLifeApp.Droid;
using Android.App;
using Android.OS;
using System.Threading;
using Android.Widget;
using Android.Graphics.Drawables;
using System.Threading.Tasks;

namespace ShelfLifeApp.SplashScreen
{
	[Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
	public class SplashActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView (Resource.Layout.splash_screen);
			ThreadPool.QueueUserWorkItem(o => LoadActivity()); 
		}

		public override void OnWindowFocusChanged(bool hasFocus)    
		{    
			ImageView imageView = FindViewById<ImageView>(Resource.Id.imageView1);    
			AnimationDrawable animation = (AnimationDrawable)imageView.Drawable;    
			animation.Start(); 
		}

		private async void LoadActivity()    
		{    
			await Task.Delay(2000);   
			RunOnUiThread(() => StartActivity(typeof(MainActivity)));    
		} 
	}
}