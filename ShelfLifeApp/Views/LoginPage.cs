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
using ShelfLifeApp.Custom;

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
				Spacing = 0,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
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
			var header = new StackLayout {
				Spacing = 0,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Children = {
					new Label {
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
					}
				}
			};

			var entry1 = new MyEntry {
				Placeholder = AppResources.LoginPageEntry1,
			};
			entry1.SetBinding (Entry.TextProperty,"UserName");

			var entry2 = new MyEntryPassword{ 
				Placeholder = AppResources.LoginPageEntry2,
				IsPassword = true
			};
			entry2.SetBinding (Entry.TextProperty,"UserPassword");

			Picker picker1 = new MyPicker
			{
				Title = AppResources.LoginPagePicker1,
			};

			foreach(CurrentFacility facility in userDetails.GetDefaultCurrentFacilities ())
			{
				picker1.Items.Add (facility.Name);
			}

			picker1.SetBinding (Picker.SelectedIndexProperty, "CurrentFacility");

			Picker picker2 = new MyPicker 
			{
				Title = AppResources.LoginPagePicker2,
			};

			foreach(var item in userDetails.GetDomains())
			{
				picker2.Items.Add (item);
			}

			picker2.SetBinding (Picker.SelectedIndexProperty,"Domain");

			var body = new StackLayout{ 
				Spacing = 10,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(20,20),
				BackgroundColor = Color.Transparent,
				Children = {
					entry1,
					entry2,
					picker1,
					picker2
				}
			};
					
			button1 = new MySuccessButton {
				Text = AppResources.LoginPageButton1,
				FontSize = 40,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				)
			};
			button1.Clicked += Button1Submit;
			layout.Children.Add (header);
			layout.Children.Add (body);
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
				JToken response = await login.PostService(userDetails.UserName,userDetails.UserPassword,userDetails.Domain);
			
				if (response ["error"] != null) {
					loading.IsRunning = false;
					loading.IsEnabled = false;
					loading.IsVisible = false;
					button1.IsEnabled = true;
					string errorMsg = response.Value<string> ("error"); 
					DisplayAlert (AppResources.LoginPageDisplayAlertMsg1, errorMsg, AppResources.LoginPageDisplayAlertMsg3);
				} else {
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
}
