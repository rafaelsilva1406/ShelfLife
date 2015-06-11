using System.Collections.Generic;
using ShelfLifeApp;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace ShelfLifeApp.Views
{
	using System;

	using Xamarin.Forms;
	using ShelfLifeApp.ViewModels;

	public class QAction1Page : ContentPage
	{
		private string[] userMsg = {};
		private string[] appMsg = {"Loading..","Inspectable Items","QA Action Page 1."};
		public StackLayout layout;
		public UserDetailsViewModel userDetails;
		public ActivityIndicator loading;
		private ListView _ListView = new ListView();
		public QAction1Page (UserDetailsViewModel userDetails)
		{
			this.userDetails = userDetails;
			this.Title = this.appMsg[1];
			this.loading = new ActivityIndicator();
			this.loading.IsRunning = true;
			this.loading.IsEnabled = true;
			this.loading.IsVisible = true;
			this.layout = new StackLayout
			{
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(10,0),
				BackgroundColor = Color.Transparent
			};

			this.layout.Children.Add(this.loading);
			if(this.userDetails.UserAuth == false){
				this.Navigation.PopModalAsync ();
				this.Navigation.PushModalAsync (new LoginPage(this.userDetails));
			} else {
				this.layout.Children.Clear ();
				init ();
			}
		}

		private void init()
		{
			
			var cooList = new List<String> ();
			cooList.Add ("Cali");
			cooList.Add ("Mexico");
			cooList.Add ("Peru");
			Picker picker = new Picker
			{
				Title = "Country Of Origin",
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			foreach (string colorName in cooList)
			{
				picker.Items.Add(colorName);
			}

			List<FruitSample> samples = new List<FruitSample>
			{
				new FruitSample(0, new CountryOfOrigin(){Description = "Cali", ID = 0}, "Camino del Sol", new DateTime(1975, 1, 15), 
					"Large"),
				new FruitSample(1, new CountryOfOrigin(){Description = "Mexico", ID = 1}, "Mission de mexico", new DateTime(1975, 1, 15), 
					"Small"),
				new FruitSample(2, new CountryOfOrigin(){Description = "Peru", ID = 2}, "Camposol", new DateTime(1975, 1, 15), 
					"Medium"),
				new FruitSample(3, new CountryOfOrigin(){Description = "Cali", ID = 0}, "Camino del Sol", new DateTime(2015, 1, 15), 
					"Medium"),
				
			};
			picker.SelectedIndexChanged += (object sender, EventArgs e) => {
				this.layout.Children.Remove(_ListView);
				var originSamples = samples.Where( s => s.Origin.ID == picker.SelectedIndex ).ToList();
				_ListView =	CreateListView (originSamples.OrderBy(c => c.SamepleID).ToList());
				this.layout.Children.Add(_ListView);
			};
			this.BindingContext = this.userDetails;

			var label = new Label (){
				Text = "Samples to Inspect",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Scale = 2.0
					
			};

			// Define some data.


			this.layout.Children.Add (picker);
			this.layout.Children.Add (label);
			this.layout.Children.Add (_ListView);
			this.Content = this.layout;
		}

		private ListView CreateListView(IEnumerable itemSource){
			// Create the ListView.
			ListView listView = new ListView
			{
				// Source of data items.
				ItemsSource = itemSource,

				// Define template for displaying each item.
				// (Argument of DataTemplate constructor is called for 
				//      each item; it must return a Cell derivative.)
				ItemTemplate = new DataTemplate(() =>
					{
						// Create views with bindings for displaying each property.
						Label nameLabel = new Label();
						nameLabel.SetBinding(Label.TextProperty, "SamepleID");

						Label birthdayLabel = new Label();
						birthdayLabel.SetBinding(Label.TextProperty,
							new Binding("PackDate", BindingMode.OneWay, 
								null, null, "Pack Date {0:d}"));
						
						// Return an assembled ViewCell.
						return new ViewCell
						{
							View = new StackLayout
							{
								Padding = new Thickness(0, 5),
								Orientation = StackOrientation.Vertical,
								Children = 
								{
									new StackLayout
									{
										VerticalOptions = LayoutOptions.Center,
										Spacing = 0,
										Children = 
										{
											nameLabel,
											birthdayLabel
										}
										}
								}
								}
						};
					})
			};

			return listView;
		}
	}
}


