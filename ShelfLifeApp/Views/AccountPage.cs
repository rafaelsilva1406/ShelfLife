namespace ShelfLifeApp.Views
{
	using System;
	using Xamarin.Forms;

	public class AccountPage : ContentPage
	{
		private string[] appMsg = {"Loading..","Back Home","This will show status of switch.","Switch is now","This is the Account tab.","Account Page"};
		public StackLayout layout;
		public AccountPage ()
		{
			
			var _label1 = new Label { 
				Text = this.appMsg[2],
				HeightRequest = 50
			};
			var _switcher = new Switch {
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			_switcher.Toggled += (sender, e) => {
				_label1.Text = String.Format(this.appMsg[3] + " {0}",e.Value);
			};
			var _label2 = new Label { 
				Text = this.appMsg[4], 
				HeightRequest = 50
			};
			var _button1 = new Button {
				Text = this.appMsg[1],
				HeightRequest = 60,
				TextColor = Color.Gray,
				BackgroundColor = Color.Transparent,
				BorderColor = Color.Lime,
				BorderWidth = 4,
				FontFamily = Device.OnPlatform(
					iOS: "MarkerFelt-Thin",
					Android: "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
			};
			_button1.Clicked += (sender, e) => {
				this.Navigation.PopModalAsync();
			};
			this.Title = this.appMsg[5];
			this.layout = new StackLayout {
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(10, Device.OnPlatform(20,0,0),10,5),
				BackgroundColor = Color.Transparent
			};
			this.layout.Children.Add (_label1);
			this.layout.Children.Add (_switcher);
			this.layout.Children.Add (_label2);
			this.layout.Children.Add (_button1);
			this.Content = this.layout;
		}
	}
}

