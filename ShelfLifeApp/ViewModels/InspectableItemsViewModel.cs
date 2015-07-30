using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using ShelfLifeApp.Models;

namespace ShelfLifeApp.ViewModels
{
	public class InspectableItemsViewModel : BaseViewModel
	{
		public InspectableItemsViewModel ()
		{
		}

		private static readonly object padLock = new object ();
		private static InspectableItemsViewModel _Instance = null;
		private List<CountryOfOrigin> _cooList = new List<CountryOfOrigin>();
		private List<FruitSample> _fruitList = new List<FruitSample>();
		public static InspectableItemsViewModel Instance
		{
			get{
				if(_Instance == null){
					lock (padLock){
						if(_Instance == null){
							_Instance = new InspectableItemsViewModel ();

						}
					}
				}
				return _Instance;
			}

		}

		public List<CountryOfOrigin> GetDefaultCoo()
		{
			_cooList.Add (new CountryOfOrigin(0,"Cali"));
			_cooList.Add (new CountryOfOrigin(1,"Mexico"));
			_cooList.Add (new CountryOfOrigin(2,"Peru"));
			return _cooList;
		}

		public List<FruitSample> GetFruitSample(int id)
		{
			_fruitList.Clear ();
			// create date time 2008-03-09 16:05:07.123
			var dt = new DateTime(2015, 7, 30, 12, 43, 7, 123);
			switch(id){
				case 0:
				_fruitList.Add (new FruitSample(0, new CountryOfOrigin (0,"Cali"),"Test",dt,"small",2,dt));
				break;
				case 1:
				_fruitList.Add (new FruitSample(1, new CountryOfOrigin (1,"Mexico"),"Test",dt,"medium",2,dt));
				break;
				case 2:
				_fruitList.Add (new FruitSample(2, new CountryOfOrigin (0,"Peru"),"Test",dt,"large",2,dt));
				break;
				default:
					//throw exception
				break;
			}

			return _fruitList;
		}
	}
}

