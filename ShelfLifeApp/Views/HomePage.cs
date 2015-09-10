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

		public HomePage (UserDetailsViewModel userdetails)
		{	
			userDetails = userdetails;
			Title = AppResources.HomePageTitle;
			layout = new StackLayout 
			{
				Spacing = 0,
				VerticalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.White
			};

			if(userDetails.isUserAuth == false){
				Navigation.PopModalAsync();
				Navigation.PushModalAsync (new LoginPage(userDetails));
			}else{
				layout.Children.Clear ();
				init ();	
			}

			Content = layout;
		}

		private void init()
		{
			BindingContext = userDetails;

			Label caliCountLabel = new MyLabel () {
				FontSize = 30,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				Text = string.Format( "{0}", AppResources.HomePageInspected1),
				HorizontalOptions = LayoutOptions.Center
			};
			Label mexicoCountLabel = new MyLabel () {
				FontSize = 30,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				Text = string.Format( "{0}", AppResources.HomePageInspected2),
				HorizontalOptions = LayoutOptions.Center
			};
			Label peruCountLabel = new MyLabel () {
				FontSize = 30,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				Text = string.Format( "{0}", AppResources.HomePageInspected3),
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
				FontSize = 30
			};
			_button1.Clicked += (sender, e) => {
				Navigation.PushAsync(new AddEditPage(userDetails));
			};

			layout.Children.Add (header);
			layout.Children.Add (_button1);
			Content = layout;
		}
	}
}


