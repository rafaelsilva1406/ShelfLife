namespace ShelfLifeApp.Views
{
	using System;
	using Xamarin.Forms;
	using ShelfLifeApp.ViewModels;

	public class AccountTabbedPage : TabbedPage
	{
		private string[] appMsg = {"Accounts"};
		public UserDetailsViewModel userDetails;
		public AccountTabbedPage (UserDetailsViewModel userDetails)
		{
			this.userDetails = userDetails;
			this.Title = this.appMsg[0];
			this.Children.Add (new AccountPage());
		}
	}
}

