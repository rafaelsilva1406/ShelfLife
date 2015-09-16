namespace ShelfLifeApp.Views
{
	using System;
	using Xamarin.Forms;
	using ShelfLifeApp.Custom;

	public class SettingsPage : ContentPage
	{
		public StackLayout layout;
		public SettingsPage ()
		{
			var _button1 = new MyDefaultButton {
				Text = AppResources.SettingsPageButton1,
				FontFamily = Device.OnPlatform(
					iOS: "MarkerFelt-Thin",
					Android: "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 30
			};
			_button1.Clicked += (sender, e) => {
				this.Navigation.PopModalAsync();
			};
			this.Title = AppResources.SettingsPageTitle;
			this.layout = new StackLayout {
				Spacing = 0,
				VerticalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.White
			};
			this.layout.Children.Add (_button1);
			this.Content = this.layout;
		}
	}
}


