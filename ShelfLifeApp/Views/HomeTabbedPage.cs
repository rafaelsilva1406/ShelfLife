namespace ShelfLifeApp.Views
{
	using System;
	using Xamarin.Forms;
	using ShelfLifeApp.ViewModels;
	using ShelfLifeApp.Custom;

	public class HomeTabbedPage : TabbedPage
	{
		public UserDetailsViewModel userDetails;

		public HomeTabbedPage (UserDetailsViewModel userdetails)
		{
			userDetails = userdetails;
			var _settings = new ToolbarItem
			{
				Text = AppResources.HomeTabbedPageToolbarItem1,
				Order = ToolbarItemOrder.Secondary,
				Command = new Command(() => Navigation.PushModalAsync(new SettingsTabbedPage(userDetails))),

				Priority = 1
			};
			var _logOut = new ToolbarItem
			{ 
				Text = AppResources.HomeTabbedPageToolbarItem2,
				Order = ToolbarItemOrder.Secondary,
				Priority = 2
			};
			_logOut.Clicked += (sender, e) => {
				userDetails.destroyUser();
				Navigation.PopModalAsync();
				App.Current.MainPage = new NavigationPage(new LoginPage(userDetails));
			};

			Title = AppResources.HomeTabbedPageTitle;
			Children.Add(new HomePage (userDetails));
			Children.Add (new InspectableItemsPage(userDetails));
			ToolbarItems.Add (_settings);
			ToolbarItems.Add (_logOut);
		}
	}
}


