using System;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Xamarin.Forms;
using ShelfLifeApp.Models;
using ShelfLifeApp.ViewModels;

namespace ShelfLifeApp.Views
{
	public partial class LoginPage : ContentPage
	{
		private StackLayout layout;
		public UserDetailsViewModel userDetails;
		public ActivityIndicator loading;

		public LoginPage (UserDetailsViewModel userDetails)
		{
			this.userDetails = userDetails;
			this.Title = AppResources.LoginPageTitle;
			this.layout = new StackLayout {
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.Transparent
			};

			this.loading = new ActivityIndicator ();
			this.loading.IsRunning = true;
			this.loading.IsEnabled = true;
			this.loading.IsVisible = true;
			this.layout.Children.Add (this.loading);
			this.Content = this.layout;
		
			if (this.userDetails.isUserAuth == false) {
				this.loading.IsRunning = false;
				this.loading.IsEnabled = false;
				this.loading.IsVisible = false;
				this.layout.Children.Clear ();
				init ();
			} 
		}

		private void init()
		{
			this.BindingContext = this.userDetails;
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
			var button1 = new Button {
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
			button1.Clicked += (sender, ea) => {
				if(string.IsNullOrEmpty(this.userDetails.UserName) || string.IsNullOrEmpty(this.userDetails.UserPassword) || this.userDetails.CurrentFacility < 0){
					DisplayAlert (AppResources.LoginPageDisplayAlertMsg1, AppResources.LoginPageDisplayAlertMsg2, AppResources.LoginPageDisplayAlertMsg3);
				}else{
					this.loading.IsRunning = true;
					this.loading.IsEnabled = true;
					this.loading.IsVisible = true;
					this.layout.Children.Add (this.loading);

					Task.Factory.StartNew( () => {
						Login(OnSuccessFullLogin, OnFailedLogin);
					});

				}
			};
			this.layout.Children.Add (label1);
			this.layout.Children.Add (entry1);
			this.layout.Children.Add (entry2);
			this.layout.Children.Add (picker1);
			this.layout.Children.Add (button1);
			this.Content = this.layout;

		}
			
		private void OnSuccessFullLogin(){
			this.loading.IsRunning = false;
			this.loading.IsEnabled = false;
			this.loading.IsVisible = false;
			this.layout.Children.Clear ();
			this.userDetails.isUserAuth = true;
			this.Navigation.PopModalAsync();
			App.Current.MainPage = new NavigationPage(new HomeTabbedPage(this.userDetails));
		}

		private void OnFailedLogin(Exception e){
			this.loading.IsRunning = false;
			this.loading.IsEnabled = false;
			this.loading.IsVisible = false;
			string error = AppResources.LoginPageDisplayAlertMsg1+":"+e.Message;
			DisplayAlert(AppResources.LoginPageDisplayAlertMsg1, error, AppResources.LoginPageDisplayAlertMsg3);

		}

		private void OnFail(Exception e){
			var error = AppResources.LoginPageDisplayAlertMsg1+":"+e.Message;
			DisplayAlert (AppResources.LoginPageDisplayAlertMsg1,error,AppResources.LoginPageDisplayAlertMsg3);
		}

		public void Login(Action OnSuccess, Action<Exception> OnFail){
			try{
				Xamarin.Forms.Device.BeginInvokeOnMainThread( () => { 
					this.OnSuccessFullLogin ();
				});
		
			} catch(Exception e){
				Xamarin.Forms.Device.BeginInvokeOnMainThread (() => { 
					this.OnFail (e);
				});
			}
		}
	}
}
