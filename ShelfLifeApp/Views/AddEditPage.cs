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
using ShelfLifeApp.Custom;

namespace ShelfLifeApp.Views
{
	public class AddEditPage : ContentPage
	{
		private ScrollView scrollview;
		public StackLayout layout;
		public UserDetailsViewModel userDetails;
		public AddEditViewModel addEdit;

		public AddEditPage (UserDetailsViewModel userdetails)
		{
			userDetails = userdetails;
			addEdit = AddEditViewModel.Instance;
			Title = AppResources.AddEditPageTitle;
			layout = new StackLayout 
			{
				Spacing = 0,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.White
			};

			scrollview = new ScrollView () {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Orientation = ScrollOrientation.Vertical,
				Content = layout
			};

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

			Label _label1 = new MyLabel
			{ 
				XAlign = TextAlignment.Center,
				Text = AppResources.AddEditPageSampleNumber,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 40,
			};

			var header = new StackLayout {
				Spacing = 0,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					_label1
				}
			};
					
			Picker _picker1 = new MyPicker
			{
				Title = AppResources.AddEditPagePicker1,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			foreach(Coo coo in addEdit.GetDefaultCoo())
			{
				_picker1.Items.Add (coo.Name);
			}

			_picker1.SetBinding (Picker.SelectedIndexProperty, "Coo");

			Picker _picker2 = new MyPicker 
			{
				Title = AppResources.AddEditPagePicker2,
				IsVisible = false,
			};

			var _entry1 = new MyEntry
			{ 
				Placeholder = AppResources.AddEditPageEntry1,
				IsVisible = false,
			};

			_entry1.SetBinding (Entry.TextProperty, "Grower");

			Picker _picker3 = new MyPicker
			{ 
				Title = AppResources.AddEditPagePicker3,
				IsVisible = false,
			};
					
			foreach(Region region in addEdit.GetDefaultRegion())
			{
				_picker3.Items.Add (region.Name);
			}

			_picker3.SetBinding (Picker.SelectedIndexProperty, "Region");

			var _entry2 = new MyEntry
			{ 
				Placeholder = AppResources.AddEditPageEntry2,
				IsVisible = false,
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

			DatePicker _datePicker1 = new MyDatePicker
			{
				Format = "D",
			};

			_datePicker1.SetBinding(DatePicker.DateProperty, new Binding("Date"));

			Picker _picker4 = new MyPicker
			{ 
				Title = AppResources.AddEditPagePicker4
			};

			foreach(Sizes size in addEdit.GetDefaultSize())
			{
				_picker4.Items.Add(size.Name);
			}

			_picker4.SetBinding (Picker.SelectedIndexProperty, "Size");

			var _button1 = new MyDefaultButton
			{
				Text = AppResources.AddEditPageButton1,
				FontSize = 30,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				)
			};
			_button1.Clicked += Button1Submit;

			var _button2 = new MyDefaultButton
			{
				Text = "Cancel",
				FontSize = 30,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				)
			};
			_button2.Clicked += Button2Submit;

			var body = new StackLayout{ 
				Spacing = 10,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(20,20),
				BackgroundColor = Color.Transparent,
				Children = {
					_picker1,
					_datePicker1,
					_picker4,
					_entry1,
					_picker2,
					_picker3,
					_entry2
				}
			};

			var footer = new StackLayout{ 
				Spacing = 20,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(10,10),
				BackgroundColor = Color.FromHex("001A4C"),
				Children = {
					_button2,
					_button1
				}
			};
				
			layout.Children.Add (header);
			layout.Children.Add (body);
			layout.Children.Add (new BoxView(){Color = Color.Red, WidthRequest = 100, HeightRequest = 4});
			layout.Children.Add (footer);
			Content = scrollview;
		}

		public async void Button1Submit(object sender, EventArgs ea)
		{
//							System.Diagnostics.Debug.WriteLine("Coo: {0}",addEdit.Coo);
//							System.Diagnostics.Debug.WriteLine("Grower: {0}",addEdit.Grower);
//							System.Diagnostics.Debug.WriteLine("Region: {0}",addEdit.Region);
//							System.Diagnostics.Debug.WriteLine("Packer: {0}",addEdit.Packer);
//							System.Diagnostics.Debug.WriteLine("Pallet: {0}",addEdit.Pallet);
//							System.Diagnostics.Debug.WriteLine("Date: {0}",addEdit.Date);
//							System.Diagnostics.Debug.WriteLine("Size: {0}",addEdit.Size);

//			List<Earthquake> items = await addEdit.GetService();
//			Navigation.PopModalAsync();
//			App.Current.MainPage = new NavigationPage(new NewsPage(userDetails,items));
			await DisplayAlert("Saving","This data will be sent to table and you will be redirected to home screen.","OK");
			addEdit.destroyAddEdit ();
		}

		public async void Button2Submit(object sender, EventArgs e2)
		{
			await Navigation.PopAsync();
			addEdit.destroyAddEdit ();
		}
	}
}


