namespace ShelfLifeApp.Views
{
	using System;
	using Xamarin.Forms;
	using ShelfLifeApp.ViewModels;

	public class HomePage : ContentPage
	{
		private string[] userMsg = {"Welcome"};
		private string[] appMsg = {"Loading..","Home"};
		public StackLayout layout;
		public UserDetailsViewModel userDetails;
		public ActivityIndicator loading;

		public HomePage (UserDetailsViewModel userDetails)
		{	
			this.userDetails = userDetails;
			this.Title = this.appMsg[1];
			this.loading = new ActivityIndicator ();
			this.loading.IsRunning = true;
			this.loading.IsEnabled = true;
			this.loading.IsVisible = true;
			this.layout = new StackLayout 
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(10, 0),
				BackgroundColor = Color.Transparent
			};
			this.layout.Children.Add (loading);
			if(this.userDetails.UserAuth == false){
				this.Navigation.PopModalAsync();
				this.Navigation.PushModalAsync (new LoginPage(this.userDetails));
			}else{
				this.layout.Children.Clear ();
				init ();	
			}

			this.Content = this.layout;
		}

		private void init()
		{
			this.BindingContext = this.userDetails;

			var _label1 = new Label {
				XAlign = TextAlignment.Center,
				HeightRequest = 60,
				Text = this.userMsg[0] + ' '+ this.userDetails.UserName,
				TextColor = Color.White,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 40,
			};

			this.layout.Children.Add (_label1);
			this.Content = this.layout;
		}
	}
}


