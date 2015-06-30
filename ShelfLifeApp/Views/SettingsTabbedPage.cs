namespace ShelfLifeApp.Views
{
	using System;

	using Xamarin.Forms;
	using ShelfLifeApp.ViewModels;

	public class SettingsTabbedPage : TabbedPage
	{
		public UserDetailsViewModel userDetails;
		public SettingsTabbedPage (UserDetailsViewModel userDetails)
		{
			this.userDetails = userDetails;
			this.Title = AppResources.SettingsTabbedPageTitle;
			this.Children.Add (new SettingsPage());
		}
	}
}


