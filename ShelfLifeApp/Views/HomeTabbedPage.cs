namespace ShelfLifeApp.Views
{
	using System;
	using Xamarin.Forms;
	using ShelfLifeApp.ViewModels;

	public class HomeTabbedPage : TabbedPage
	{
		public UserDetailsViewModel userDetails;

		public HomeTabbedPage (UserDetailsViewModel userDetails)
		{
			var _settings = new ToolbarItem
			{
				Name = AppResources.HomeTabbedPageToolbarItem1,
				Order = ToolbarItemOrder.Secondary,
				Command = new Command(() => this.Navigation.PushModalAsync(new SettingsTabbedPage(this.userDetails))),
				Priority = 1
			};
			var _logOut = new ToolbarItem
			{ 
				Name = AppResources.HomeTabbedPageToolbarItem2,
				Order = ToolbarItemOrder.Secondary,
				Priority = 2
			};
			_logOut.Clicked += (sender, e) => {
				this.userDetails.destroyUser();
				this.Navigation.PopModalAsync();
				App.Current.MainPage = new NavigationPage(new LoginPage(this.userDetails));
			};

			this.Title = AppResources.HomeTabbedPageTitle;
			this.userDetails = userDetails;
			this.Children.Add(new HomePage (this.userDetails));
			this.Children.Add (new InspectableItemsPage(this.userDetails));
			this.ToolbarItems.Add (_settings);
			this.ToolbarItems.Add (_logOut);
		}
	}
}


