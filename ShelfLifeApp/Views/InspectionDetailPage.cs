using System;
using System.Resources;
using Xamarin.Forms;
using XLabs.Platform.Services.Media;
using ShelfLifeApp.Models;
using ShelfLifeApp.ViewModels;
using ShelfLifeApp.Custom;
using System.Threading.Tasks;
using XLabs.Ioc;
using XLabs.Platform.Device;

namespace ShelfLifeApp.Views
{
	public class InspectionDetailPage:ContentPage
	{
		private readonly TaskScheduler _scheduler = TaskScheduler.FromCurrentSynchronizationContext();
		private Button save;
		private Button _button2;
		private ImageSource _imageSource;
		private IMediaPicker _iMediaPicker;
		private Image _img;
		public ScrollView scrollView;
		public StackLayout layout;
		public FruitSample fruitSample;
		public InspectionDetailViewModel inspectionDetail;
		public UserDetailsViewModel userdetails;
		public InspectionDetailPage (FruitSample fruitsample, UserDetailsViewModel userDetails)
		{
			fruitSample = fruitsample;
			userdetails = userDetails;
			inspectionDetail = InspectionDetailViewModel.Instance;
			Title = AppResources.InspectableItemTitle+" "+fruitSample.ID.ToString();
			layout = new StackLayout
			{
				Spacing = 0,
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.Fill,
				Padding = new Thickness (0,0,0,0),
				BackgroundColor = Color.White 
			};

			scrollView = new ScrollView () {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Orientation = ScrollOrientation.Vertical,
				Content = layout
			};
					
			if(userdetails.isUserAuth == false){
				Navigation.PopModalAsync();
				Navigation.PushModalAsync (new LoginPage(userdetails));
			}else{
				layout.Children.Clear ();
				init ();	
			}
		}

		private void init()
		{
			BindingContext = inspectionDetail;
	
			Label summary = new MyLabel  ()
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
				Text = AppResources.InspectableItemOrigin+" "+fruitSample.Origin.Description,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 20,
				XAlign = TextAlignment.End,
			};

			Label packer = new MyLabel()
			{
				Text = AppResources.InspectableItemPacker+" "+fruitSample.Packer,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 20,
				XAlign = TextAlignment.Center,
			};

			Label packDate = new MyLabel()
			{
				Text = AppResources.InspectableItemPackDate+" "+fruitSample.PackDate,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 20,
			};

			Label endDate = new MyLabel()
			{
				Text = AppResources.InspectableItemEndDate+" "+fruitSample.InspectionOnOrAfter,
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
				Text = AppResources.InspectableItemSize+" "+fruitSample.Size,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 20
			};

			Label age = new MyLabel()
			{
				Text = AppResources.InspectableItemAge+" "+fruitSample.Age,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 20
			};

			Label inspect = new MyLabel()
			{
				Text = AppResources.InspectableItemInspect,
				XAlign = TextAlignment.Center,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 28
			};

			Label lbColor = new MyLabel()
			{
				Text = AppResources.InspectableItemColor,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 28,
				XAlign = TextAlignment.End,
			};

			Picker color = new MyPicker {
				Title = AppResources.InspectableItemColor,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,

			};
			color.SetBinding (Picker.SelectedIndexProperty, "Colors");

			foreach(Colors colors in inspectionDetail.GetColor()){
				color.Items.Add (colors.Description);
			}

			Label lbStage = new MyLabel()
			{
				Text = AppResources.InspectableItemStage,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 28,
				XAlign = TextAlignment.End,
			};

			Picker stage = new MyPicker {
				Title = AppResources.InspectableItemStage,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			stage.SetBinding (Picker.SelectedIndexProperty,"Stage");

			foreach(Stage stages in inspectionDetail.GetStage()){
				stage.Items.Add (stages.Description);
			}

			Label lbLenticel = new MyLabel()
			{
				Text = AppResources.InspectableItemLenticel,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 28,
				XAlign = TextAlignment.End,
			};

			Picker lenticel = new MyPicker {
				Title = AppResources.InspectableItemLenticel,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			lenticel.SetBinding (Picker.SelectedIndexProperty, "Lenticel");

			foreach(Lenticel lenticels in inspectionDetail.GetLenticel()){
				lenticel.Items.Add (lenticels.Description);
			}

			Label lbDefects = new MyLabel()
			{
				Text = AppResources.InspectableItemDefects,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 28,
				XAlign = TextAlignment.End,
				IsVisible = false
			};

			Picker defects = new MyPicker {
				Title = AppResources.InspectableItemDefects,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				IsVisible = false
			};

			defects.SetBinding (Picker.SelectedIndexProperty, "Defect");

			foreach(Defect defect in inspectionDetail.GetDefect()){
				defects.Items.Add (defect.Description);
			}

			Label cutLabel = new MyLabel()
			{
				Text = AppResources.InspectableItemCut,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 28
			};

			Switch cut = new Switch {
				HorizontalOptions = LayoutOptions.EndAndExpand,
				HeightRequest = 60,
				WidthRequest = 100
			};

			cut.SetBinding (Switch.IsToggledProperty,"Cut");

			cut.Toggled += (object sender, ToggledEventArgs e) => {
				System.Diagnostics.Debug.WriteLine("{0}",e.Value);
				if(e.Value == true){
					lbDefects.IsVisible = true;
					defects.IsVisible = true;
				}else{
					lbDefects.IsVisible = false;
					defects.IsVisible = false;
				}
			};

			Label imageLabel = new MyLabel()
			{
				Text = AppResources.InspectableItemImage,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 28,
				XAlign = TextAlignment.End,
			};

			Button imageUploadBtn = new MyDefaultButton {
				Text = AppResources.InspectableItemImageBTN,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 50
			};

			Label imageDeleteLabel = new MyLabel()
			{
                //temp fix AppResources.InspectableItemImageDelete not working
				Text = "Want to",
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 28,
				XAlign = TextAlignment.End,
				IsVisible = false
			};

			Button imageDeleteBtn = new MyDangerButton {
                //temp fix AppResources.InspectableItemImageDeleteBTN not working
                Text = "Delete",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 50,
				IsVisible = false
			};

			imageUploadBtn.Clicked += async (sender, e) => {
				var buttonsArray = new string[] {"Take Photo","Upload Photo"};
				var action = await DisplayActionSheet ("ActionSheet: Save Photo?", "Cancel",null,buttonsArray);
				doPhotoAction(action);
				imageLabel.IsVisible = false;
				imageUploadBtn.IsVisible = false;
				imageDeleteLabel.IsVisible = true;
				imageDeleteBtn.IsVisible = true;
			};
				
			imageDeleteBtn.Clicked += (sender, e) => {
				_imageSource = null;
				_img.Source = "";
				imageDeleteLabel.IsVisible  = false;
				imageDeleteBtn.IsVisible = false;
				imageUploadBtn.IsVisible = true;
				imageLabel.IsVisible = true;
			};

			_img = new Image(){
				HeightRequest = 300, 
				WidthRequest = 300, 
				BackgroundColor = Color.FromHex("#D6D6D2"),
				Aspect = Aspect.AspectFit,
				IsVisible = false
			};
			_img.SetBinding (Image.SourceProperty,"ImageSource");

			Label commentLabel = new MyLabel()
			{
				Text = AppResources.InspectableItemComments,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 28,
				XAlign = TextAlignment.End,
			};

			Entry comment = new MyEntry {
				Placeholder = AppResources.InspectableItemComments,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 100
			};

			comment.SetBinding (Entry.TextProperty,"Comment");

			save = new MyDefaultButton { 
				Text = AppResources.InspectableItemSave,
				FontSize = 30,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				)
			};

			save.Clicked += saveBtn;

			_button2 = new MyDefaultButton
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

			Label past = new MyLabel()
			{
				Text = AppResources.InspectableItemPastInspection,
				XAlign = TextAlignment.Center,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 28
			};

			Label datePickerLabel = new MyLabel()
			{
				Text = AppResources.InspectableItemPastDate,
				FontFamily = Device.OnPlatform (
					iOS:      "MarkerFelt-Thin",
					Android:  "Droid Sans Mono",
					WinPhone: "Comic Sans MS"
				),
				FontSize = 28,
				XAlign = TextAlignment.End
			};

			DatePicker datePicker = new MyDatePicker
			{
				Format = inspectionDetail.DateYesterday.ToString("D"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand ,
				MinimumDate = inspectionDetail.DateMax,
				MaximumDate = inspectionDetail.DateYesterday
			};
			datePicker.SetBinding (DatePicker.DateProperty,new Binding("DateYesterday",BindingMode.TwoWay));
			datePicker.DateSelected += (object sender, DateChangedEventArgs e) => {
				DisplayAlert ("Fetching data","A list will populate below with a Sample matching selected date.","OK");
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
				Padding = new Thickness(5,10,10,0),
				Children = 
				{
					lbColor,
					color
				}
			};

			StackLayout row5 = new StackLayout
			{ 
				Spacing = 5,
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(5,10,10,0),
				Children = 
				{
					lbStage,
					stage
				}
			};

			StackLayout row6 = new StackLayout
			{ 
				Spacing = 5,
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(5,10,10,0),
				Children = 
				{
					lbLenticel,
					lenticel
				}
			};

			StackLayout row7 = new StackLayout
			{
				Spacing = 5,
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(5,10,10,0),
				Children = 
				{
					lbDefects,
					defects
				}
			};

			StackLayout row8 = new StackLayout
			{
				Spacing = 5,
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(5,10,10,0),
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
				Padding = new Thickness(5,10,10,0),
				Children = 
				{
					imageLabel,
					imageUploadBtn,
					imageDeleteLabel,
					imageDeleteBtn
				}
			};

			StackLayout row10 = new StackLayout
			{
				Spacing = 5,
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(5,10,10,0),
				Children = 
				{
					_img
				}
				};

			StackLayout row11 = new StackLayout
			{
				Spacing = 5,
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(5,10,10,5),
				Children = 
				{
					commentLabel
				}
			};

			StackLayout row12 = new StackLayout
			{
				Spacing = 5,
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(5,5,10,20),
				Children = 
				{
					comment
				}
			};

			StackLayout row13 = new StackLayout
			{
				Spacing = 20,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(10,10),
				BackgroundColor = Color.FromHex("001A4C"),
				Children = 
				{
					_button2,
					save
				}
			};

			StackLayout row14 = new StackLayout
			{
				Spacing = 5,
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness(5,10,10,0),
				Children = 
				{
					datePicker
				}
			};

			layout.Children.Add (summary);
			layout.Children.Add (new BoxView(){Color = Color.Gray, WidthRequest = 100, HeightRequest = 2});
			layout.Children.Add (row1);
			layout.Children.Add (row2);
			layout.Children.Add (row3);
			layout.Children.Add (new BoxView(){Color = Color.Transparent, WidthRequest = 100, HeightRequest = 50});
			layout.Children.Add (past);
			layout.Children.Add (new BoxView (){ Color = Color.Gray, WidthRequest = 100, HeightRequest = 2 });
			layout.Children.Add (row14);
			layout.Children.Add (new BoxView(){Color = Color.Transparent, WidthRequest = 100, HeightRequest = 50});
			layout.Children.Add (inspect);
			layout.Children.Add (new BoxView(){Color = Color.Gray, WidthRequest = 100, HeightRequest = 2});
			layout.Children.Add (row4);
			layout.Children.Add (row5);
			layout.Children.Add (row6);
			layout.Children.Add (row7);
			layout.Children.Add (row8);
			layout.Children.Add (row9);
			layout.Children.Add (row10);
			layout.Children.Add (row11);
			layout.Children.Add (row12);
			layout.Children.Add (new BoxView(){Color = Color.Red, WidthRequest = 100, HeightRequest = 4});
			layout.Children.Add (row13);
			Content = scrollView;
		}

		private async void doPhotoAction(string str)
		{
			if (str == "Take Photo")
			{
				await doCameraPhoto();
			}
			else if (str == "Upload Photo")
			{
				await doPhotoLibrary();
			}
		}

		private void Setup()
		{
			if (_iMediaPicker != null)
			{
				return;
			}

			var device = Resolver.Resolve<IDevice>();

			////RM: hack for working on windows phone? 
			_iMediaPicker = DependencyService.Get<IMediaPicker>() ?? device.MediaPicker;
		}
			
		private async Task doCameraPhoto()
		{
			Setup ();

			_imageSource = null;

			try{

				if (_iMediaPicker.IsCameraAvailable)
				{
					var options = new CameraMediaStorageOptions() {
						DefaultCamera = CameraDevice.Front,
						SaveMediaOnCapture = true,
						Directory = "ShelfLifeApp",
						Name = string.Format("ShelfLifeApp_{0}", DateTime.Now.ToString("yyMMddhhmmss")),
						MaxPixelDimension = 400,
						PercentQuality = 85
					};

					var mediaFile = await _iMediaPicker.TakePhotoAsync(options);

					if (mediaFile != null && mediaFile.Source != null)
					{
						System.Diagnostics.Debug.WriteLine("{0}",mediaFile.Source);
						_imageSource = ImageSource.FromStream(() => mediaFile.Source);
						_img.Source = _imageSource;
						_img.IsVisible = true;
					}
				}
				else
				{
					System.Diagnostics.Debug.WriteLine ("Camera not available");
				}
			}
			catch(TaskCanceledException){
				System.Diagnostics.Debug.WriteLine ("Take Photo cancelled");
			}
			catch(System.Exception ex){
				System.Diagnostics.Debug.WriteLine (ex.Message);
			}
		}

		private async Task doPhotoLibrary()
		{
			Setup ();

			_imageSource = null;
			try {
				
				if (_iMediaPicker.IsCameraAvailable)
				{
					var options = new CameraMediaStorageOptions() {
						DefaultCamera = CameraDevice.Front,
						SaveMediaOnCapture = true,
						Directory = "ShelfLifeApp",
						Name = string.Format("ShelfLifeApp_{0}", DateTime.Now.ToString("yyMMddhhmmss")),
						MaxPixelDimension = 400,
						PercentQuality = 85
					};

					var mediaFile = await _iMediaPicker.SelectPhotoAsync(options);

					if (mediaFile != null && mediaFile.Source != null)
					{
						_imageSource = ImageSource.FromStream(() => mediaFile.Source);
						_img.Source = _imageSource;
						_img.IsVisible = true;
					}
				}
				else
				{
					System.Diagnostics.Debug.WriteLine ("Camera not available");
				}
			} 
			catch(TaskCanceledException){
				System.Diagnostics.Debug.WriteLine ("Select image cancelled");
			}
			catch (System.Exception ex) {

			}
		}

		public async void saveBtn(object sender, EventArgs ea)
		{
			await save.ScaleTo(2);
			await save.ScaleTo(1);
			save.IsEnabled = false;
			if (inspectionDetail.Colors < 0 || inspectionDetail.Stage < 0 || inspectionDetail.Lenticel < 0 || string.IsNullOrEmpty (inspectionDetail.Comment) || inspectionDetail.Cut && inspectionDetail.Defect < 0) {
				DisplayAlert (AppResources.InspectableItemAlertMsg1, AppResources.InspectableItemAlertMsg2, AppResources.InspectableItemAlertMsg3);
				save.IsEnabled = true;
			} else {
				DisplayAlert ("Saving","This data will be sent to table and you will be redirected to Sample to Inspect.","OK");
				inspectionDetail.destroyInspectionDetail ();
				Navigation.PopAsync();
//				System.Diagnostics.Debug.WriteLine ("clicked save button");
//				System.Diagnostics.Debug.WriteLine ("{0}", inspectionDetail.Colors);
//				System.Diagnostics.Debug.WriteLine ("{0}", inspectionDetail.Stage);
//				System.Diagnostics.Debug.WriteLine ("{0}", inspectionDetail.Lenticel);
//				System.Diagnostics.Debug.WriteLine ("{0}", inspectionDetail.Defect);
//				System.Diagnostics.Debug.WriteLine ("{0}", inspectionDetail.Cut);
//				System.Diagnostics.Debug.WriteLine ("{0}", inspectionDetail.Comment);
				save.IsEnabled = true;
			}
		}

		public async void Button2Submit(object sender, EventArgs e2)
		{
			await _button2.ScaleTo(2);
			await _button2.ScaleTo(1);
			_button2.IsEnabled = false;
			inspectionDetail.destroyInspectionDetail ();
			await Navigation.PopAsync();
			_button2.IsEnabled = true;
		}
	}
}

