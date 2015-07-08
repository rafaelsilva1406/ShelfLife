using System;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Resources;
using System.Globalization;
using Xamarin.Forms;
using ShelfLifeApp.Models;
using ShelfLifeApp.ViewModels;

namespace ShelfLifeApp.Views
{
	public class AddEditPage : ContentPage
	{
		public StackLayout layout;
		public UserDetailsViewModel userDetails;
		public AddEditViewModel addEdit;
		public ActivityIndicator loading;

		public AddEditPage (UserDetailsViewModel userdetails)
		{
			userDetails = userdetails;
			addEdit = AddEditViewModel.Instance;
			Title = AppResources.AddEditPageTitle;
			loading = new ActivityIndicator ();
			loading.IsRunning = true;
			loading.IsEnabled = true;
			loading.IsVisible = true;
			layout = new StackLayout 
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Vertical,
				BackgroundColor = Color.Transparent
			};
			layout.Children.Add(loading);

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
			BindingContext = addEdit;
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
			Picker _picker1 = new Picker
			{
				Title = AppResources.AddEditPagePicker1,
				HeightRequest = 60,
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.Transparent
			};

			foreach(Coo coo in addEdit.GetDefaultCoo())
			{
				_picker1.Items.Add (coo.Name);
			}

			_picker1.SetBinding (Picker.SelectedIndexProperty, "Coo");
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
			_entry1.SetBinding (Entry.TextProperty, "Grower");
			Picker _picker3 = new Picker{ 
				Title = AppResources.AddEditPagePicker3,
				HeightRequest = 60,
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				IsVisible = false,
				BackgroundColor = Color.Transparent
			};
					
			foreach(Region region in addEdit.GetDefaultRegion())
			{
				_picker3.Items.Add (region.Name);
			}

			_picker3.SetBinding (Picker.SelectedIndexProperty, "Region");
			var _entry2 = new Entry{ 
				Placeholder = AppResources.AddEditPageEntry2,
				HeightRequest = 60,
				TextColor = Color.White,
				IsVisible = false,
				BackgroundColor = Color.Transparent
			};
			_entry2.SetBinding (Entry.TextProperty, "Pallet");
			_picker1.SelectedIndexChanged += (sender, e) => {
				addEdit._PackerList.Clear();
				_picker2.Items.Clear();
				_entry1.IsVisible = false; 
				_picker3.IsVisible = false;
				_entry2.IsVisible = false;

				switch(_picker1.SelectedIndex)
				{
					case 0:
						foreach(Packer packer in addEdit.GetDefaultPacker1())
						{
							_picker2.Items.Add (packer.Name);
						}
						
						_entry1.IsVisible = true; 
						_picker3.IsVisible = true;
					break;
					case 1:
						foreach(Packer packer in addEdit.GetDefaultPacker2())
						{
							_picker2.Items.Add (packer.Name);
						}
				
						_entry2.IsVisible = true;
					break;
					case 2:
						foreach(Packer packer in addEdit.GetDefaultPacker3())
						{
							_picker2.Items.Add (packer.Name);
						}

						_entry2.IsVisible = true;
					break;
					case 3:
						foreach(Packer packer in addEdit.GetDefaultPacker4())
						{
							_picker2.Items.Add (packer.Name);
						}

						_entry2.IsVisible = true;
					break;
					case 4:
						foreach(Packer packer in addEdit.GetDefaultPacker5())
						{
							_picker2.Items.Add (packer.Name);
						}
						_entry2.IsVisible = true;
					break;
					default:
						//throw exception
					break;
				}
					
				_picker2.IsVisible = true;
			};
			_picker2.SetBinding (Picker.SelectedIndexProperty, "Packer");
			DatePicker _datePicker1 = new DatePicker
			{
				Format = "D",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 60,
				BackgroundColor = Color.Transparent
			};
			_datePicker1.SetBinding(DatePicker.DateProperty, new Binding("Date"));
			Picker _picker4 = new Picker{ 
				Title = AppResources.AddEditPagePicker4,
				HeightRequest = 60,
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.Transparent
			};

			foreach(Sizes size in addEdit.GetDefaultSize())
			{
				_picker4.Items.Add(size.Name);
			}

			_picker4.SetBinding (Picker.SelectedIndexProperty, "Size");
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
			_button1.Clicked += Button1Submit;
			_grid1.Children.Add (_searchBar1,0, 3, 0, 1);
			_grid1.Children.Add (_picker1,0,1);
			_grid1.Children.Add (_datePicker1,1,1);
			_grid1.Children.Add (_picker4,0,2);
			_grid1.Children.Add (_entry1,0,3);
			_grid1.Children.Add (_picker2,1,2);
			_grid1.Children.Add (_picker3,1,3);
			_grid1.Children.Add (_entry2,1,4);
			_grid1.Children.Add (_button1,0,6,5,6);
			Content = _grid1;
		}

		public async void Button1Submit(object sender, EventArgs ea)
		{
			//				System.Diagnostics.Debug.WriteLine("Coo: {0}",addEdit.Coo);
			//				System.Diagnostics.Debug.WriteLine("Grower: {0}",addEdit.Grower);
			//				System.Diagnostics.Debug.WriteLine("Region: {0}",addEdit.Region);
			//				System.Diagnostics.Debug.WriteLine("Packer: {0}",addEdit.Packer);
			//				System.Diagnostics.Debug.WriteLine("Pallet: {0}",addEdit.Pallet);
			//				System.Diagnostics.Debug.WriteLine("Date: {0}",addEdit.Date);
			//				System.Diagnostics.Debug.WriteLine("Size: {0}",addEdit.Size);
			List<Earthquake> items = await addEdit.GetService();
			Navigation.PopModalAsync();
			App.Current.MainPage = new NavigationPage(new NewsPage(userDetails,items));
			addEdit.destroyAddEdit ();
		}
	}
}


