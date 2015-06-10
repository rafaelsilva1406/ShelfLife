namespace ShelfLifeApp
{
	using System;

	using Xamarin.Forms;
	using ShelfLifeApp.ViewModels;
	using ShelfLifeApp.Views;
	public class App : Application
	{
		public UserDetailsViewModel userDetails;
		public App ()
		{
			this.userDetails = UserDetailsViewModel.Instance;

			if(this.userDetails.UserAuth == false){
				MainPage = new LoginPage(this.userDetails);
			}else{
				// The root page of your application
				MainPage = getMainPage();	
			}
		}

		public Page getMainPage()
		{
			// Replace the ExamplePage with whatever page is appropriate to start off your app
			//  - Like your login page, or home screen, or whatever
			return new NavigationPage(new HomeTabbedPage (this.userDetails));
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

