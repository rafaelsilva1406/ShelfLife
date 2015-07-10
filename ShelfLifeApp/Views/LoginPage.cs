using System;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using ShelfLifeApp.Models;
using ShelfLifeApp.ViewModels;

namespace ShelfLifeApp.Views
{
	public partial class LoginPage : ContentPage
	{
		private StackLayout layout;
		public UserDetailsViewModel userDetails;
		public LoginViewModel login;
		public ActivityIndicator loading;
		private Button button1;

		public LoginPage (UserDetailsViewModel userdetails)
		{
			userDetails = userdetails;
			login = LoginViewModel.Instance;
			Title = AppResources.LoginPageTitle;
			layout = new StackLayout {
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.Transparent
			};

			loading = new ActivityIndicator ();
			loading.IsRunning = true;
			loading.IsEnabled = true;
			loading.IsVisible = true;
			layout.Children.Add (loading);
			Content = layout;
		
			if (userDetails.isUserAuth == false) {
				loading.IsRunning = false;
				loading.IsEnabled = false;
				loading.IsVisible = false;
				layout.Children.Clear ();
				init ();
			} 
		}

		private void init()
		{
			BindingContext = userDetails;
			var label1 = new Label {
				XAlign = TextAlignment.Center,
				HeightRequest = 60,
				Text = AppResources.LoginPageLabel1,
				TextColor = Color.White,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 40,
			};
			var entry1 = new Entry {
				Placeholder = AppResources.LoginPageEntry1,
				HeightRequest = 60,
				TextColor = Color.White
			};
			entry1.SetBinding (Entry.TextProperty,"UserName");
			var entry2 = new Entry{ 
				Placeholder = AppResources.LoginPageEntry2,
				IsPassword = true,
				HeightRequest = 60,
				TextColor = Color.White
			};
			entry2.SetBinding (Entry.TextProperty,"UserPassword");

			Picker picker1 = new Picker
			{
				Title = AppResources.LoginPagePicker1,
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
					
			foreach(CurrentFacility facility in userDetails.GetDefaultCurrentFacilities ())
			{
				picker1.Items.Add (facility.Name);
			}

			picker1.SetBinding (Picker.SelectedIndexProperty, "CurrentFacility");
			button1 = new Button {
				Text = AppResources.LoginPageButton1,
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
			};
			button1.Clicked += Button1Submit;
			layout.Children.Add (label1);
			layout.Children.Add (entry1);
			layout.Children.Add (entry2);
			layout.Children.Add (picker1);
			layout.Children.Add (button1);
			Content = layout;

		}

		public async void Button1Submit(object sender, EventArgs ea)
		{
			if(string.IsNullOrEmpty(userDetails.UserName) || string.IsNullOrEmpty(userDetails.UserPassword) || userDetails.CurrentFacility < 0){
				DisplayAlert (AppResources.LoginPageDisplayAlertMsg1, AppResources.LoginPageDisplayAlertMsg2, AppResources.LoginPageDisplayAlertMsg3);
			}else{
				loading.IsRunning = true;
				loading.IsEnabled = true;
				loading.IsVisible = true;
				layout.Children.Add (loading);
				button1.IsEnabled = false;
				JToken response = await login.PostService(userDetails.UserName,userDetails.UserPassword);
				bool auth = response.Value<bool>("authenticated");
				string authMsg = response.Value<string>("authMessage");
				if (auth == false) {
					loading.IsRunning = false;
					loading.IsEnabled = false;
					loading.IsVisible = false;
					button1.IsEnabled = true;
					DisplayAlert (AppResources.LoginPageDisplayAlertMsg1, authMsg, AppResources.LoginPageDisplayAlertMsg3);
				} else {
					loading.IsRunning = false;
					loading.IsEnabled = false;
					loading.IsVisible = false;
					userDetails.isUserAuth = auth;
					layout.Children.Clear ();
					Navigation.PopModalAsync();
					App.Current.MainPage = new NavigationPage(new HomeTabbedPage(userDetails));
				}
					
			}
		}
	}
}
