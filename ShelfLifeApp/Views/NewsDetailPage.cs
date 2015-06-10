namespace ShelfLifeApp.Views
{
	using System;
	using Xamarin.Forms;
	using ShelfLifeApp.Models;

	public class NewsDetailPage:ContentPage
	{
		public StackLayout layout;
		public NewsDetailPage (News news)
		{
			this.Title = news.Headline;
			this.layout = new StackLayout 
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(10, 0),
				BackgroundColor = Color.Transparent,
			};

			var detailText = new Label{ 
				Text = news.Story
			};
			this.layout.Children.Add (detailText);
			this.Content = this.layout;
		}
	}
}

