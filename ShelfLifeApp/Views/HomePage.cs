﻿namespace ShelfLifeApp.Views
{
	using System;
	using Xamarin.Forms;
	using ShelfLifeApp.ViewModels;

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
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(10, 0),
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
			Label caliCountLabel = new Label () {
				Text = string.Format( "{0} California Inspections", userDetails.CaliCount),
				//Scale = 1.5
			};
			Label mexicoCountLabel = new Label () {
				Text = string.Format( "{0} Mexico Inspections ", userDetails.MexCount),
				//Scale = 1.5
			};
			Label peruCountLabel = new Label () {
				Text = string.Format( "{0} Peru Inspections", userDetails.PeruCount),
				//Scale = 1.5
			};

			var _button1 = new Button {
				Text = AppResources.HomePageButton1,
				HeightRequest = 60,
				TextColor = Color.White,
				BackgroundColor = Color.Transparent,
				BorderColor = Color.Gray,
				BorderWidth = 4,
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

			this.layout.Children.Add (caliCountLabel);
			this.layout.Children.Add (mexicoCountLabel);
			this.layout.Children.Add (peruCountLabel);
			this.layout.Children.Add (_button1);
			this.Content = this.layout;
		}
	}
}


