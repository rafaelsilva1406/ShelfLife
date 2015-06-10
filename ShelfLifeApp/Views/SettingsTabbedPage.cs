namespace ShelfLifeApp.Views
{
	using System;

	using Xamarin.Forms;
	using ShelfLifeApp.ViewModels;

	public class SettingsTabbedPage : TabbedPage
	{
		private string[] appMsg = {"Settings"};
		public UserDetailsViewModel userDetails;
		public SettingsTabbedPage (UserDetailsViewModel userDetails)
		{
			this.userDetails = userDetails;
			this.Title = this.appMsg [0];
			this.Children.Add (new SettingsPage());
		}
	}
}


