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

	public class InspectableItemsPage : ContentPage
	{
		private string[] userMsg = {};
		private string[] appMsg = {"Loading..","Inspectable Items","QA Action Page 1."};
		public StackLayout layout;
		public UserDetailsViewModel userDetails;
		public ActivityIndicator loading;
		private ListView _ListView = new ListView();
		public InspectableItemsPage (UserDetailsViewModel userDetails)
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
			Label dateLabel = new Label (){ 
				Text = DateTime.Now.ToString("d"),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.EndAndExpand,
				XAlign = TextAlignment.End
			};
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


			picker.SelectedIndexChanged += (object sender, EventArgs e) => {
				this.layout.Children.Remove(_ListView);
				var originSamples = UserDetailsViewModel.Instance._FruitList.Where( s => s.Origin.ID == picker.SelectedIndex ).ToList();
				_ListView =	CreateListView (originSamples.OrderBy(c => c.SampleID).ToList());
				this.layout.Children.Add(_ListView);
			};



			this.BindingContext = this.userDetails;

			var label = new Label (){
				Text = "Samples to Inspect",
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Scale = 1.5
					
			};

			var hStack = new StackLayout(){
				Orientation = StackOrientation.Horizontal,
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
			hStack.Children.Add(picker);
			hStack.Children.Add(dateLabel);

			this.layout.Children.Add(hStack);
			this.layout.Children.Add (label);
			this.layout.Children.Add (_ListView);
			this.Content = this.layout;
			picker.SelectedIndex = 0;
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
						Label sampleIDLabel = new Label(){ HorizontalOptions = LayoutOptions.Start};
						sampleIDLabel.SetBinding(Label.TextProperty,
							new Binding("SampleID", BindingMode.OneWay, 
								null, null, @" Sample ID: {0}"));

						Label ageLabel = new Label(){HorizontalOptions = LayoutOptions.FillAndExpand, XAlign = TextAlignment.End };
						ageLabel.SetBinding(Label.TextProperty,
							new Binding("Age", BindingMode.OneWay, 
								null, null, @"Age: {0} days"));

						Label packDateLabel = new Label(){ HorizontalOptions = LayoutOptions.Center};
						packDateLabel.SetBinding(Label.TextProperty,
							new Binding("PackDate", BindingMode.OneWay, 
								null, null, @" Packed {0:d}"));

						Label inspectOnOrByDateLabel = new Label(){ HorizontalOptions = LayoutOptions.Center};
						inspectOnOrByDateLabel.SetBinding(Label.TextProperty,
							new Binding("InspectionOnOrAfter", BindingMode.OneWay, 
								null, null, @" Inspect On {0:d}"));
						
						// Return an assembled ViewCell.
						return new ViewCell
						{
							View = new StackLayout
							{
								Padding = new Thickness(5,0,5,10),
								Orientation = StackOrientation.Vertical,
								Spacing = 10,

								Children = 
								{
									new StackLayout
									{
										VerticalOptions = LayoutOptions.Center,
										Orientation = StackOrientation.Horizontal,
										Spacing = 10,
										Children = 
										{
											sampleIDLabel,

											ageLabel
										}
										},
									new StackLayout
									{
										VerticalOptions = LayoutOptions.Center,
										Orientation = StackOrientation.Horizontal,
										Spacing = 10,
										Children = 
										{
											
											packDateLabel,
											inspectOnOrByDateLabel
										}
										}
								}
								}
						};
					})
			};
			listView.HasUnevenRows = true;
		
			return listView;
		}
	}
}


