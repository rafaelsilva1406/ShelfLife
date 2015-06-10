namespace ShelfLifeApp.Views
{
	using System;
	using System.Threading.Tasks;
	using System.Reflection;
	using Xamarin.Forms;
	using ShelfLifeApp.Models;
	using ShelfLifeApp.ViewModels;

	public partial class LoginPage : ContentPage
	{
		private string[] userMsg = {"UserName","Welcome","Empty Username or Password.","Password"};
		private string[] appMsg = {"Loading..","MissionPro Sign In","Start","Login","Error","Failed","OK"};
		private StackLayout layout;
		public UserDetailsViewModel userDetails;
		public ActivityIndicator loading;

		public LoginPage (UserDetailsViewModel userDetails)
		{
			this.userDetails = userDetails;
			this.Title = this.appMsg[3];
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
		
			if (this.userDetails.UserAuth == false) {
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
				Text = this.appMsg[1],
				TextColor = Color.White,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 40,
			};
			var entry1 = new Entry {
				Placeholder = this.userMsg[0],
				HeightRequest = 60,
				TextColor = Color.White
			};
			entry1.SetBinding (Entry.TextProperty,"UserName");
			var entry2 = new Entry{ 
				Placeholder = this.userMsg[3],
				IsPassword = true,
				HeightRequest = 60,
				TextColor = Color.White
			};
			entry2.SetBinding (Entry.TextProperty,"UserPassword");
			var button1 = new Button {
				Text = this.appMsg [2],
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
				if(string.IsNullOrEmpty(this.userDetails.UserName) || string.IsNullOrEmpty(this.userDetails.UserPassword)){
					DisplayAlert (this.appMsg[4], this.userMsg[2], this.appMsg[6]);
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
			this.layout.Children.Add (button1);
			this.Content = this.layout;

		}

		private void OnSuccessFullLogin(){
			this.loading.IsRunning = false;
			this.loading.IsEnabled = false;
			this.loading.IsVisible = false;
			this.layout.Children.Clear ();
			this.userDetails.UserAuth = true;
			this.Navigation.PopModalAsync();
			App.Current.MainPage = new NavigationPage(new HomeTabbedPage(this.userDetails));
		}

		private void OnFailedLogin(Exception e){
			this.loading.IsRunning = false;
			this.loading.IsEnabled = false;
			this.loading.IsVisible = false;
			string error = this.appMsg[4]+":"+e.Message;
			DisplayAlert(this.appMsg[4], error, this.appMsg[6]);

		}

		private void OnFail(Exception e){
			var error = this.appMsg[4]+":"+e.Message;
			DisplayAlert (this.appMsg[4],error,this.appMsg[6]);
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


