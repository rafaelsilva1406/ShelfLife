using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Resources;
using System.Globalization;
using Xamarin.Forms;
using ShelfLifeApp.Models;
using ShelfLifeApp.ViewModels;
using ShelfLifeApp.Custom;

namespace ShelfLifeApp.Views
{
	public class InspectableItemsPage : ContentPage
	{
		public StackLayout layout;
		public UserDetailsViewModel userDetails;
		public InspectableItemsViewModel inspectableItems;
		public ActivityIndicator loading;

		public InspectableItemsPage (UserDetailsViewModel userdetails)
		{
			userDetails = userdetails;
			inspectableItems = InspectableItemsViewModel.Instance;
			Title = AppResources.InspectableItemsTitle;
			loading = new ActivityIndicator();
			loading.IsRunning = true;
			loading.IsEnabled = true;
			loading.IsVisible = true;
			layout = new StackLayout
			{
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(10,0),
				BackgroundColor = Color.Black
			};

			layout.Children.Add(loading);
			if(userDetails.isUserAuth == false){
				Navigation.PopModalAsync ();
				Navigation.PushModalAsync (new LoginPage(userDetails));
			} else {
				layout.Children.Clear ();
				init ();
			}
		}

		private void init()
		{
			BindingContext = userDetails;

			Label dateLabel = new  MyLabel()
			{ 
				Text = DateTime.Now.ToString("d"),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.EndAndExpand,
				XAlign = TextAlignment.End,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
			};
				
			Picker picker = new MyPicker
			{
				Title = AppResources.InspectableItemsPicker1,
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
					
			foreach(CountryOfOrigin country in inspectableItems.GetDefaultCoo())
			{
				picker.Items.Add(country.Description);
			}

			ListView listView = new ListView();

			picker.SelectedIndexChanged += (object sender, EventArgs e) => {
				List<FruitSample> _fruitsample = new List<FruitSample>(); 

				switch(picker.SelectedIndex){
					case 0:
					_fruitsample = inspectableItems.GetFruitSample(picker.SelectedIndex);
					break;
					case 1:
					_fruitsample = inspectableItems.GetFruitSample(picker.SelectedIndex);
					break;
					case 2:
					_fruitsample = inspectableItems.GetFruitSample(picker.SelectedIndex);
					break; 
					default:
						//throw exception
					break;
				}
					
				listView.ItemsSource = _fruitsample;
				listView.SeparatorVisibility = Xamarin.Forms.SeparatorVisibility.Default;
				listView.SeparatorColor = Color.Gray;
				listView.ItemTapped += (object sender2, ItemTappedEventArgs e2) => {
					var fruitSample = e2.Item as FruitSample;
					if(fruitSample == null)
						return;
					Navigation.PushAsync(new InspectionDetailPage(fruitSample));
					listView.SelectedItem = null;
				};

				listView.ItemTemplate = new DataTemplate(()=>
				{
					Label idLabel = new MyLabel{
						HeightRequest = 20,
						FontFamily = Device.OnPlatform(
							iOS:      "MarkerFelt-Thin",
							Android:  "Droid Sans Mono",
							WinPhone: "Comic Sans MS"
						),
						FontSize = 16,
					};
						idLabel.SetBinding(Label.TextProperty, new Binding("ID", stringFormat: AppResources.InspectableItemsIdLabel+" {0}"));
					
						Label startDateLabel = new MyLabel{
						HeightRequest = 20,
						FontFamily = Device.OnPlatform(
							iOS:      "MarkerFelt-Thin",
							Android:  "Droid Sans Mono",
							WinPhone: "Comic Sans MS"
						),
						FontSize = 16,
						HorizontalOptions = LayoutOptions.CenterAndExpand
					};
						startDateLabel.SetBinding(Label.TextProperty, new Binding("PackDate", stringFormat: AppResources.InspectableItemsStartDateLabel+" {0}"));
					
						Label endDateLabel = new MyLabel{
						HeightRequest = 20,
						FontFamily = Device.OnPlatform(
							iOS:      "MarkerFelt-Thin",
							Android:  "Droid Sans Mono",
							WinPhone: "Comic Sans MS"
						),
						FontSize = 16,
					};
						endDateLabel.SetBinding(Label.TextProperty, new Binding("InspectionOnOrAfter", stringFormat: AppResources.InspectableItemsEndDateLabel+" {0}"));
					
					return new ViewCell
					{
						View = new StackLayout
						{
							Spacing = 0,
							Padding = new Thickness(0, 5, 0, 20),
							Orientation = StackOrientation.Horizontal,
							HeightRequest = 50,
							Children = 
							{
								idLabel,
								startDateLabel,
								endDateLabel
							}
						}
					};
				});
			};
				
			var label = new MyLabel(){
				Text = AppResources.InspectableItemsLabel1,
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 28
			};

			var hStack = new StackLayout(){
				Orientation = StackOrientation.Horizontal,
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			hStack.Children.Add(picker);
			hStack.Children.Add(dateLabel);

			layout.Children.Add(hStack);
			layout.Children.Add (new BoxView(){Color = Color.Gray, WidthRequest = 100, HeightRequest = 2});
			layout.Children.Add (label);
			layout.Children.Add (listView);
			Content = layout;
		}
	}
}


