using System;
using System.Reflection;
using Xamarin.Forms;
using ShelfLifeApp;
using ShelfLifeApp.ViewModels;
using ShelfLifeApp.Views;

namespace ShelfLifeApp
{
	public class App : Application
	{
		public UserDetailsViewModel userDetails;
		public App ()
		{
			if(Device.OS != TargetPlatform.WinPhone)
			{
				DependencyService.Get<ILocalize> ().SetLocale();
				//AppResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
			}

			userDetails = UserDetailsViewModel.Instance;

			if(userDetails.isUserAuth == false){
				MainPage  = new LoginPage(userDetails);
			}else{
				MainPage = getMainPage();	
			}
		}

		public Page getMainPage()
		{
			// Replace the ExamplePage with whatever page is appropriate to start off your app
			//  - Like your login page, or home screen, or whatever
			var navPage = new NavigationPage(new HomeTabbedPage (userDetails));
			return navPage;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
			System.Diagnostics.Debug.WriteLine("OnStart");
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
			System.Diagnostics.Debug.WriteLine("OnSleep");
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
			System.Diagnostics.Debug.WriteLine("OnResume");
		}
	}
}

