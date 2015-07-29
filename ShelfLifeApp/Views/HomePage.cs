namespace ShelfLifeApp.Views
{
	using System;
	using Xamarin.Forms;
	using ShelfLifeApp.ViewModels;
	using ShelfLifeApp.Custom;

	public class HomePage : ContentPage
	{
		public StackLayout layout;
		public UserDetailsViewModel userDetails;
		public ActivityIndicator loading;

		public HomePage (UserDetailsViewModel userDetails)
		{	
			this.userDetails = userDetails;
			this.Title = AppResources.HomePageTitle;
			this.loading = new ActivityIndicator ();
			this.loading.IsRunning = true;
			this.loading.IsEnabled = true;
			this.loading.IsVisible = true;
			this.layout = new StackLayout 
			{
				Spacing = 0,
				VerticalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.Transparent
			};
			this.layout.Children.Add (loading);

			if(this.userDetails.isUserAuth == false){
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

			Label caliCountLabel = new MyLabel () {
				FontSize = 30,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				Text = string.Format( "{0} California Inspections", userDetails.CaliCount),
				HorizontalOptions = LayoutOptions.Center
			};
			Label mexicoCountLabel = new MyLabel () {
				FontSize = 30,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				Text = string.Format( "{0} Mexico Inspections ", userDetails.MexCount),
				HorizontalOptions = LayoutOptions.Center
			};
			Label peruCountLabel = new MyLabel () {
				FontSize = 30,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				Text = string.Format( "{0} Peru Inspections", userDetails.PeruCount),
				HorizontalOptions = LayoutOptions.Center
			};

			var header = new StackLayout{ 
				Spacing = 0,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					caliCountLabel,
					mexicoCountLabel,
					peruCountLabel
				}
			};

			var _button1 = new MyDefaultButton{
				Text = AppResources.HomePageButton1,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 40
			};
			_button1.Clicked += (sender, e) => {
				Navigation.PushAsync(new AddEditPage(this.userDetails));
			};

			this.layout.Children.Add (header);
			this.layout.Children.Add (_button1);
			this.Content = this.layout;
		}
	}
}


