namespace ShelfLifeApp.Views
{
	using System;
	using Xamarin.Forms;
	using ShelfLifeApp.ViewModels;

	public class HomeTabbedPage : TabbedPage
	{
		private string[] appMsg = { "Settings", "Accounts", "LogOut", "MissionPro" };
		public UserDetailsViewModel userDetails;

		public HomeTabbedPage (UserDetailsViewModel userDetails)
		{
			var _settings = new ToolbarItem
			{
				Name = this.appMsg[0],
				Order = ToolbarItemOrder.Secondary,
				Command = new Command(() => this.Navigation.PushModalAsync(new SettingsTabbedPage(this.userDetails))),
				Priority = 1
			};
			var _logOut = new ToolbarItem
			{ 
				Name = this.appMsg[2],
				Order = ToolbarItemOrder.Secondary,
				Priority = 2
			};
			_logOut.Clicked += (sender, e) => {
				this.userDetails.destroyUser();
				this.Navigation.PopModalAsync();
				App.Current.MainPage = new NavigationPage(new LoginPage(this.userDetails));
			};

			this.Title = this.appMsg[3];
			this.userDetails = userDetails;
			this.Children.Add(new HomePage (this.userDetails));
			this.Children.Add (new QAction1Page(this.userDetails));
			this.ToolbarItems.Add (_settings);
			this.ToolbarItems.Add (_logOut);
		}
	}
}


