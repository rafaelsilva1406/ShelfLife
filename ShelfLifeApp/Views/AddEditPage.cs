namespace ShelfLifeApp.Views
{
	using System;
	using System.Reflection;
	using System.Collections.Generic;
	using System.Collections;
	using System.Linq;
	using Xamarin.Forms;
	using ShelfLifeApp.ViewModels;
	using ShelfLifeApp.Views;
	public class AddEditPage : ContentPage
	{
		private string[] userMsg = { };
		private string[] appMsg = {"Loading..","Adding/Editing Sample","Sample #","COO","Packers","Growers","Regions","Size","Pallet #","Save"};
		public StackLayout layout;
		public UserDetailsViewModel userDetails;
		public ActivityIndicator loading;
		public AddEditPage (UserDetailsViewModel userDetails)
		{
			this.userDetails = userDetails;
			this.Title = this.appMsg [1];
			this.loading = new ActivityIndicator ();
			this.loading.IsRunning = true;
			this.loading.IsEnabled = true;
			this.loading.IsVisible = true;
			this.layout = new StackLayout 
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Vertical,
				//Padding = new Thickness(10, 0),
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
<<<<<<< Upstream, based on origin/master
			SearchBar _searchBar1 = new SearchBar 
			{
				Placeholder = this.appMsg[2]	
			};
			var _cooList = new List<String> ();
			_cooList.Add ("CALI");
			_cooList.Add ("MEX");
			_cooList.Add ("PERU");
			_cooList.Add ("CHILE");
			_cooList.Add ("NZ");
			Picker _picker1 = new Picker
			{
				Title = this.appMsg[3],
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			foreach(string cooName in _cooList)
			{
				_picker1.Items.Add (cooName);
			}

			var _packerList1 = new List<String> ();
			Picker _picker2 = new Picker {
				Title = this.appMsg[4],
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				IsVisible = false
			};
			var _entry1 = new Entry{ 
				Placeholder = this.appMsg[5],
				HeightRequest = 60,
				TextColor = Color.White,
				IsVisible = false
			};
			var _regionList = new List<String> ();
			_regionList.Add ("North");
			_regionList.Add ("Far North");
			_regionList.Add ("South");
			Picker _picker3 = new Picker{ 
				Title = this.appMsg[6],
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				IsVisible = false
			};

			foreach(string regionName in _regionList)
			{
				_picker3.Items.Add(regionName);
			}

			var _entry2 = new Entry{ 
				Placeholder = this.appMsg[8],
				HeightRequest = 60,
				TextColor = Color.White,
				IsVisible = false
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
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			var _sizeList = new List<String> ();
			_sizeList.Add ("Small");
			_sizeList.Add ("Medium");
			_sizeList.Add ("Large");
			Picker _picker5 = new Picker{ 
				Title = this.appMsg[7],
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};

			foreach(string sizeName in _sizeList)
			{
				_picker5.Items.Add(sizeName);
			}

			var _button1 = new Button {
				Text = this.appMsg[9],
				HeightRequest = 60,
				TextColor = Color.White,
				BackgroundColor = Color.Transparent,
				BorderColor = Color.Gray,
				BorderWidth = 4,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
			};
			this.layout.Children.Add (_searchBar1);
			this.layout.Children.Add (_picker1);
			this.layout.Children.Add (_picker2);
			this.layout.Children.Add (_entry1);
			this.layout.Children.Add (_picker3);
			this.layout.Children.Add (_datePicker1);
			this.layout.Children.Add (_picker5);
			this.layout.Children.Add (_entry2);
			this.layout.Children.Add (_button1);
=======


>>>>>>> 7e50c2b Remodeling the UI
			this.Content = this.layout;
		}
	}
}


