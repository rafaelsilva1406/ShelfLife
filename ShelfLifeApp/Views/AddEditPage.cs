using System;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Resources;
using System.Globalization;

using Xamarin.Forms;
using ShelfLifeApp.ViewModels;
using ShelfLifeApp.Views;
using ShelfLifeApp;

namespace ShelfLifeApp.Views
{
	public class AddEditPage : ContentPage
	{
		public StackLayout layout;
		public UserDetailsViewModel userDetails;
		public ActivityIndicator loading;
		public AddEditPage (UserDetailsViewModel userDetails)
		{
			this.userDetails = userDetails;
			this.Title = AppResources.AddEditPageTitle;
			this.loading = new ActivityIndicator ();
			this.loading.IsRunning = true;
			this.loading.IsEnabled = true;
			this.loading.IsVisible = true;
			this.layout = new StackLayout 
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Vertical,
				BackgroundColor = Color.Transparent
			};
			this.layout.Children.Add (loading);
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

			var _grid1 = new Grid {
				Padding = 4,
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions = 
				{
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto }
				},
				ColumnDefinitions = 
				{
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto }
				},
				BackgroundColor = Color.Transparent
			};
			SearchBar _searchBar1 = new SearchBar 
			{
				Placeholder = AppResources.SearchBar1,
				BackgroundColor = Color.Transparent,
				HeightRequest = 40
			};
			var _cooList = new List<String> ();
			_cooList.Add ("CALI");
			_cooList.Add ("MEX");
			_cooList.Add ("PERU");
			_cooList.Add ("CHILE");
			_cooList.Add ("NZ");
			Picker _picker1 = new Picker
			{
				Title = AppResources.AddEditPagePicker1,
				HeightRequest = 60,
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.Transparent
			};

			foreach(string cooName in _cooList)
			{
				_picker1.Items.Add (cooName);
			}
				
			var _packerList1 = new List<String> ();
			Picker _picker2 = new Picker {
				Title = AppResources.AddEditPagePicker2,
				HeightRequest = 60,
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				IsVisible = false,
				BackgroundColor = Color.Transparent
			};
			var _entry1 = new Entry{ 
				Placeholder = AppResources.AddEditPageEntry1,
				HeightRequest = 60,
				TextColor = Color.White,
				IsVisible = false,
				BackgroundColor = Color.Transparent
			};
			var _regionList = new List<String> ();
			_regionList.Add ("North");
			_regionList.Add ("Far North");
			_regionList.Add ("South");
			Picker _picker3 = new Picker{ 
				Title = AppResources.AddEditPagePicker3,
				HeightRequest = 60,
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				IsVisible = false,
				BackgroundColor = Color.Transparent
			};

			foreach(string regionName in _regionList)
			{
				_picker3.Items.Add(regionName);
			}

			var _entry2 = new Entry{ 
				Placeholder = AppResources.AddEditPageEntry2,
				HeightRequest = 60,
				TextColor = Color.White,
				IsVisible = false,
				BackgroundColor = Color.Transparent
			};

			_picker1.SelectedIndexChanged += (sender, e) => {
				_packerList1.Clear();
				_picker2.Items.Clear();
				_entry1.IsVisible = false; 
				_picker3.IsVisible = false;
				_entry2.IsVisible = false;
				switch(_picker1.SelectedIndex)
				{
					case 0:
						_packerList1.Add("CD");
						_entry1.IsVisible = true; 
						_picker3.IsVisible = true;
					break;
					case 1:
						_packerList1.Add("MX");
						_packerList1.Add("MZ");
						_packerList1.Add("MR");
						_packerList1.Add("ML");
						_entry2.IsVisible = true;
					break;
					case 2:
						_packerList1.Add("Camposol");
						_packerList1.Add("AvoPack");
						_entry2.IsVisible = true;
					break;
					case 3:
						_packerList1.Add("TBA");
						_entry2.IsVisible = true;
					break;
					case 4:
						_packerList1.Add("TBA");
						_entry2.IsVisible = true;
					break;
					default:
						//throw exception
					break;
				}

				foreach(string packerName in _packerList1)
				{
					_picker2.Items.Add(packerName);
				}
				_picker2.IsVisible = true;
			};
			DatePicker _datePicker1 = new DatePicker
			{
				Format = "D",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 60,
				BackgroundColor = Color.Transparent
			};
			var _sizeList = new List<String> ();
			_sizeList.Add ("Small");
			_sizeList.Add ("Medium");
			_sizeList.Add ("Large");
			Picker _picker4 = new Picker{ 
				Title = AppResources.AddEditPagePicker4,
				HeightRequest = 60,
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.Transparent
			};

			foreach(string sizeName in _sizeList)
			{
				_picker4.Items.Add(sizeName);
			}

			var _button1 = new Button {
				Text = AppResources.AddEditPageButton1,
				HeightRequest = 80,
				TextColor = Color.White,
				BackgroundColor = Color.Black,
				BorderColor = Color.Gray,
				BorderWidth = 4,
				FontSize = 40,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				)
			};

			_grid1.Children.Add (_searchBar1,0, 3, 0, 1);
			_grid1.Children.Add (_picker1,0,1);
			_grid1.Children.Add (_datePicker1,1,1);
			_grid1.Children.Add (_picker4,0,2);
			_grid1.Children.Add (_entry1,0,3);
			_grid1.Children.Add (_picker2,1,2);
			_grid1.Children.Add (_picker3,1,3);
			_grid1.Children.Add (_entry2,1,4);
			_grid1.Children.Add (_button1,0,6,5,6);
			this.Content = _grid1;
		}
	}
}


