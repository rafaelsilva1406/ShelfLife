using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ShelfLifeApp.Models;
using ShelfLifeApp.Services;

namespace ShelfLifeApp.ViewModels
{
	public sealed class AddEditViewModel : BaseViewModel
	{
		AddEditViewModel()
		{
		}

		private static readonly object padLock = new object ();
		private static AddEditViewModel _Instance = null;
		public List<Coo> _CooList = new List<Coo>();
		private int _coo = -1;
		public List<Region> _RegionList = new List<Region>();
		private int _region = -1;
		private string _grower;
		public List<Packer> _PackerList = new List<Packer>();
		private string _pallet;
		private int _packer = -1;
		private DateTime _date;
		public List<Sizes> _SizeList = new List<Sizes>();
		private int _size = -1;

		public static AddEditViewModel Instance
		{
			get
			{ 
				if(_Instance == null)
				{
					lock(padLock)
					{
						if (_Instance == null)
						{
							_Instance = new AddEditViewModel ();
						}
					}
				}
				return _Instance;
			}
		}
			
		public int Coo
		{
			get{ return _coo; }
			set{ 
				if(_coo == value){
					return;	
				}
				_coo = value;
				OnPropertyChanged ();
			}
		}

		public string Grower
		{
			get{ return _grower; }
			set{ 
				if (value.Equals(_grower, StringComparison.Ordinal))
				{
					return;
				}
				_grower = value;
				OnPropertyChanged();
			}
		}

		public int Region
		{
			get{ return _region; }
			set{
				if(_region == value){
					return;
				}
				_region = value;
				OnPropertyChanged ();
			}
		}

		public int Packer
		{
			get{ return _packer; }
			set{ 
				if(_packer == value){
					return;
				}
				_packer = value;
				OnPropertyChanged ();
			}
		}

		public string Pallet
		{
			get{ return _pallet; }
			set{ 
				if (value.Equals(_pallet, StringComparison.Ordinal))
				{
					return;
				}
				_pallet = value;
				OnPropertyChanged();
			}
		}

		public DateTime Date
		{
			get{ return _date; }
			set
			{
				if (DateTime.Compare(value,_date) == 0)
				{
					return;
				}
				_date = value;
				OnPropertyChanged ();
			}
		}

		public int Size
		{
			get{ return _size; }
			set{ 
				if(_size == value){
					return;
				}
				_size = value;
				OnPropertyChanged ();
			}
		}

		public List<Coo> GetDefaultCoo()
		{
			_CooList.Add (new Coo(0,"CALI"));
			_CooList.Add (new Coo(1,"MEX"));
			_CooList.Add (new Coo(2,"PERU"));
			_CooList.Add (new Coo(3,"CHILE"));
			_CooList.Add (new Coo(4,"NZ"));
			return _CooList;
		}
			
		public List<Region> GetDefaultRegion()
		{
			_RegionList.Add (new Region(0,"North"));
			_RegionList.Add (new Region(1,"Far North"));
			_RegionList.Add (new Region(2,"South"));
			return _RegionList;
		}

		public List<Packer> GetDefaultPacker1()
		{
			_PackerList.Add (new Packer(0,"CD"));
			return _PackerList;
		}

		public List<Packer> GetDefaultPacker2()
		{
			_PackerList.Add (new Packer(0,"MX"));
			_PackerList.Add (new Packer(1,"MZ"));
			_PackerList.Add (new Packer(2,"MR"));
			_PackerList.Add (new Packer(3,"ML"));
			return _PackerList;
		}

		public List<Packer> GetDefaultPacker3()
		{
			_PackerList.Add (new Packer(0,"Camposol"));
			_PackerList.Add (new Packer(1,"AvoPack"));
			return _PackerList;
		}

		public List<Packer> GetDefaultPacker4()
		{
			_PackerList.Add (new Packer(0,"TBA"));
			return _PackerList;
		}

		public List<Packer> GetDefaultPacker5()
		{
			_PackerList.Add (new Packer(0,"TBA"));
			return _PackerList;
		}

		public List<Sizes> GetDefaultSize()
		{
			_SizeList.Add (new Sizes(0,"Small"));
			_SizeList.Add (new Sizes(1,"Medium"));
			_SizeList.Add (new Sizes(2,"Large"));
			return _SizeList;
		}

		public async Task<List<Earthquake>> GetService()
		{
			var s = new BaseService ();
			var sResponse = await s.GetAsync ("http://api.geonames.org/earthquakesJSON?north=44.1&south=-9.9&east=-22.4&west=55.2&username=bertt");
			List<Earthquake> earthquakes = JObject.Parse (sResponse).SelectToken ("earthquakes").ToObject<List<Earthquake>>();
			return earthquakes;
		}

		public void destroyAddEdit()
		{
			_CooList.Clear ();
			_coo = -1;
			_RegionList.Clear ();
			_region = -1;
			_PackerList.Clear ();
			_packer = -1;
			_SizeList.Clear ();
			_size = -1;
		}
	}
}

