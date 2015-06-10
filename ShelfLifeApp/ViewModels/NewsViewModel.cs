namespace ShelfLifeApp.ViewModels
{
	using System;
	using System.Collections.ObjectModel;
	using ShelfLifeApp.Models;

	public class NewsViewModel
	{
		public ObservableCollection<News> NewsList;
		public NewsViewModel ()
		{
			NewsList = new ObservableCollection<News> ();
			NewsList.Add (new News{
				Headline = "Test 1",
				Story = "This is test 1."
			});
			NewsList.Add (new News{
				Headline = "Test 2",
				Story = "This is test 2."
			});
		}
	}
}

