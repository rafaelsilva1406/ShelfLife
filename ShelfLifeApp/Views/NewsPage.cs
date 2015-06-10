namespace ShelfLifeApp.Views
{
	using System;
	using Xamarin.Forms;
	using ShelfLifeApp.ViewModels;
	using ShelfLifeApp.Models;

	public class NewsPage : ContentPage
	{
		private string[] userMsg = {"Welcome"};
		private string[] appMsg = {"Loading..","News"};
		public StackLayout layout;
		public UserDetailsViewModel userDetails;
		public ActivityIndicator loading;

		public NewsPage (UserDetailsViewModel userDetails)
		{
			this.userDetails = userDetails;
			this.Title = this.appMsg[1];
			this.loading = new ActivityIndicator ();
			this.loading.IsRunning = true;
			this.loading.IsEnabled = true;
			this.loading.IsVisible = true;
			this.layout = new StackLayout 
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(10, 0),
				BackgroundColor = Color.Transparent
			};
			this.layout.Children.Add (loading);
			if(this.userDetails.UserAuth == false){
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
			var viewModel = new NewsViewModel ();
			var list = new ListView ();
			list.ItemsSource = viewModel.NewsList;
			var cell = new DataTemplate(typeof(ImageCell));
			cell.SetBinding (ImageCell.TextProperty, "Headline");
			cell.SetBinding (ImageCell.DetailProperty, "Story");
			list.ItemTemplate = cell;
			list.ItemTapped += (sender, e) => {
				var news = e.Item as News;
				if(news == null)
					return;
				Navigation.PushAsync(new NewsDetailPage(news));
				list.SelectedItem = null;
			};
			this.layout.Children.Add (list);
			this.Content = this.layout;
		}
	}
}


