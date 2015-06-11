namespace ShelfLifeApp.Views
{
	using System;

	using Xamarin.Forms;

	public class SettingsPage : ContentPage
	{
		private string[] appMsg = {"Loading..","Back Home","Settings Page"};
		public StackLayout layout;
		public SettingsPage ()
		{
			var _button1 = new Button {
				Text = this.appMsg[1],
				HeightRequest = 60,
				TextColor = Color.White,
				BackgroundColor = Color.Transparent,
				BorderColor = Color.Gray,
				BorderWidth = 4,
				FontFamily = Device.OnPlatform(
					iOS: "MarkerFelt-Thin",
					Android: "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 40
			};
			_button1.Clicked += (sender, e) => {
				this.Navigation.PopModalAsync();
			};
			this.Title = this.appMsg [2];
			this.layout = new StackLayout {
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(10, Device.OnPlatform(20,0,0),10,5),
				BackgroundColor = Color.Transparent
			};
			this.layout.Children.Add (_button1);
			this.Content = this.layout;
		}
	}
}


