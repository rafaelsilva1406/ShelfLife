﻿namespace ShelfLifeApp.Views
{
	using System;

	using Xamarin.Forms;
	using ShelfLifeApp.ViewModels;
	using ShelfLifeApp.Views;
	public class InspectPage : ContentPage
	{
		private string[] userMsg = { };
		private string[] appMsg = {"Loading..","Inspecting Sample"};
		public StackLayout layout;
		public UserDetailsViewModel userDetails;
		public InspectPage (UserDetailsViewModel userDetails)
		{
			this.userDetails = userDetails;
			this.Title = appMsg [1];
			this.layout = new StackLayout 
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(10, 0),
				BackgroundColor = Color.Transparent
			};
			if(this.userDetails.isUserAuth == false){
				this.Navigation.PopModalAsync();
				this.Navigation.PushModalAsync (new LoginPage(this.userDetails));
			}else{
				this.layout.Children.Clear ();
				init ();	
			}
		}

		private void init()
		{
			this.BindingContext = this.userDetails;
			this.Content = this.layout;
		}
	}
}


