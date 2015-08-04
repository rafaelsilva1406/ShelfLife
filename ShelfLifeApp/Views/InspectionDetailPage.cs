using System;
using System.Resources;
using Xamarin.Forms;
using ShelfLifeApp.Models;
using ShelfLifeApp.Custom;

namespace ShelfLifeApp.Views
{
	public class InspectionDetailPage:ContentPage
	{
		public StackLayout layout;
		public InspectionDetailPage (FruitSample fruitsample)
		{
			Title = AppResources.InspectableItemTitle+" "+fruitsample.ID.ToString();
			layout = new StackLayout
			{
				Spacing = 0,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness (0,0,0,0),
				BackgroundColor = Color.Transparent 
			};

			Label summary = new MyLabel()
			{
				Text = AppResources.InspectableItemSummary,
				XAlign = TextAlignment.Center,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 28
			};

			Label origin = new MyLabel()
			{
				Text = AppResources.InspectableItemOrigin+" "+fruitsample.Origin.Description,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 20
			};

			Label packer = new MyLabel()
			{
				Text = AppResources.InspectableItemPacker+" "+fruitsample.Packer,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 20
			};

			Label packDate = new MyLabel()
			{
				Text = AppResources.InspectableItemPackDate+" "+fruitsample.PackDate,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 20
			};

			Label endDate = new MyLabel()
			{
				Text = AppResources.InspectableItemEndDate+" "+fruitsample.InspectionOnOrAfter,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 20
			};

			Label size = new MyLabel()
			{
				Text = AppResources.InspectableItemSize+" "+fruitsample.Size,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 20
			};

			Label age = new MyLabel()
			{
				Text = AppResources.InspectableItemAge+" "+fruitsample.Age,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 20
			};

			Picker color = new MyPicker {
				Title = "Color",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			Picker stage = new MyPicker {
				Title = "Stage",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			Picker lenticel = new MyPicker {
				Title = "Lenticel",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			Picker defects = new MyPicker {
				Title = "Defects",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			Label cutLabel = new MyLabel()
			{
				Text = "Cut",
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 20
			};

			Switch cut = new Switch {
			};

			Entry comment = new MyEntry {
				Placeholder = "Comments",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 100
			};

			Button save = new MySuccessButton { 
				Text = "Save",
				FontSize = 40,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				VerticalOptions = LayoutOptions.EndAndExpand,
			};

			StackLayout row1 = new StackLayout
			{ 
				Spacing = 10,
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(15,0,5,0),
				HeightRequest = 40,
				Children = 
				{
					origin,
					packer
				}
			};

			StackLayout row2 = new StackLayout
			{ 
				Spacing = 10,
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(15,0,5,0),
				HeightRequest = 50,
				Children = 
				{
					packDate,
					endDate
				}
			};

			StackLayout row3 = new StackLayout
			{ 
				Spacing = 10,
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(15,10,5,0),
				HeightRequest = 40,
				Children = 
				{
					size,
					age
				}
			};

			StackLayout row4 = new StackLayout
			{ 
				Spacing = 5,
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(5,20,5,0),
				Children = 
				{
					color,
				}
			};

			StackLayout row5 = new StackLayout
			{ 
				Spacing = 5,
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(5,5,5,0),
				Children = 
				{
					stage,
				}
			};

			StackLayout row6 = new StackLayout
			{ 
				Spacing = 5,
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(5,5,5,0),
				Children = 
				{
					lenticel
				}
			};

			StackLayout row7 = new StackLayout
			{
				Spacing = 5,
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(5,5,5,0),
				Children = 
				{
					defects
				}
			};

			StackLayout row8 = new StackLayout
			{
				Spacing = 5,
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(5,5,5,0),
				HeightRequest = 50,
				Children = 
				{
					cutLabel,
					cut
				}
			};

			StackLayout row9 = new StackLayout
			{
				Spacing = 5,
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(5,5,5,0),
				Children = 
				{
					comment
				}
			};

			layout.Children.Add (summary);
			layout.Children.Add (row1);
			layout.Children.Add (row2);
			layout.Children.Add (row3);
			layout.Children.Add (new BoxView(){Color = Color.Gray, WidthRequest = 100, HeightRequest = 2});
			layout.Children.Add (row4);
			layout.Children.Add (row5);
			layout.Children.Add (row6);
			layout.Children.Add (row7);
			layout.Children.Add (row8);
			layout.Children.Add (row9);
			layout.Children.Add (save);
			Content = layout;
		}
	}
}

