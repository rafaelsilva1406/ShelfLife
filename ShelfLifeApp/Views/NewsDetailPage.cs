namespace ShelfLifeApp.Views
{
	using System;
	using Xamarin.Forms;
	using ShelfLifeApp.Models;

	public class NewsDetailPage:ContentPage
	{
		public StackLayout layout;
		public NewsDetailPage (Earthquake earthquake)
		{
			Title = earthquake.datetime;
			this.layout = new StackLayout 
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(10, 0),
				BackgroundColor = Color.Transparent,
			};

			var detailText = new Label{ 
				Text = earthquake.src
			};
			this.layout.Children.Add (detailText);
			this.Content = this.layout;
		}
	}
}

