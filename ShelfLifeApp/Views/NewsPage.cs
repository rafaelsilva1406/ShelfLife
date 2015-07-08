namespace ShelfLifeApp.Views
{
	using System;
	using System.Collections.Generic;
	using Xamarin.Forms;
	using ShelfLifeApp.ViewModels;
	using ShelfLifeApp.Models;

	public class NewsPage : ContentPage
	{
		private string[] userMsg = {"Welcome"};
		private string[] appMsg = {"Loading..","News"};
		public StackLayout layout;
		public UserDetailsViewModel userDetails;
		public List<Earthquake> earthQuakes;
		public ActivityIndicator loading;

		public NewsPage (UserDetailsViewModel userdetails, List<Earthquake> earthquake)
		{
			userDetails = userdetails;
			earthQuakes = earthquake;
			Title = appMsg[1];
			loading = new ActivityIndicator ();
			loading.IsRunning = true;
			loading.IsEnabled = true;
			loading.IsVisible = true;
			layout = new StackLayout 
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(10, 0),
				BackgroundColor = Color.Transparent
			};
			layout.Children.Add (loading);
			if(userDetails.isUserAuth == false){
				Navigation.PopModalAsync();
				Navigation.PushModalAsync (new LoginPage(userDetails));
			}else{
				layout.Children.Clear ();
				init ();	
			}
		}

		private void init()
		{
//			list.ItemTapped += (sender, e) => {
//				var news = e.Item as News;
//				if(news == null)
//					return;
//				Navigation.PushAsync(new NewsDetailPage(news));
//				list.SelectedItem = null;
//			};

			Label header = new Label
			{
				Text = "ListView",
				Font = Font.BoldSystemFontOfSize(40),
				HorizontalOptions = LayoutOptions.Center
			};
	
			var cell = new DataTemplate(typeof(TextCell));
			cell.SetBinding (TextCell.TextProperty, "datetime");
			cell.SetBinding (TextCell.DetailProperty, new Binding ("eqid", stringFormat: "{0}"));
			ListView listView = new ListView {
				RowHeight = 60,
				ItemsSource = earthQuakes,
				ItemTemplate = cell
			};

			listView.ItemTapped += (sender, e) => {
				var earthQuake = e.Item as Earthquake;
				if(earthQuake == null)
					return;
				Navigation.PushAsync(new NewsDetailPage(earthQuake));
				listView.SelectedItem = null;
			};
					
			layout.Children.Add (header);
			layout.Children.Add (listView);
			Content = layout;
		}
	}
}


