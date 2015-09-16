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
		private Button _button1;

		public HomePage (UserDetailsViewModel userdetails)
		{	
			userDetails = userdetails;
			Title = AppResources.HomePageTitle;
			layout = new StackLayout 
			{
				Spacing = 0,
				VerticalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.FromHex("001A4C")
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

			Label msg = new MyLabel (){ 
				FontSize = 22,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				Text ="A list of sample data by origin count will be listed below. You will be able to select a row and be redirect to the list to which it pertains."
			};

			var header = new StackLayout{ 
				Spacing = 10,
				Padding = new Thickness(20,20),
				BackgroundColor = Color.White,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = {
//					caliCountLabel,
//					mexicoCountLabel,
//					peruCountLabel
					msg
				}
			};

			_button1 = new MyDefaultButton{
				Text = AppResources.HomePageButton1,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 30
			};
			_button1.Clicked += btn1HandleClick;

			var footer = new StackLayout{ 
				Spacing = 10,
				Padding = new Thickness(10,10),
				BackgroundColor = Color.FromHex("001A4C"),
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = {
					_button1
				}
			};
					
			layout.Children.Add (header);
			layout.Children.Add (new BoxView(){Color = Color.Red, WidthRequest = 100, HeightRequest = 4});
			layout.Children.Add (footer);
			Content = layout;
		}

		private async void btn1HandleClick(object sender, EventArgs e)
		{
			_button1.IsEnabled = false;
			await Navigation.PushAsync(new AddEditPage(userDetails));
			_button1.IsEnabled = true;
		}
	}
}


