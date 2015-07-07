using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using ShelfLifeApp.Models;

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

		public List<Coo> GetDefaultCoo()
		{
			_CooList.Add (new Coo(0,"CALI"));
			_CooList.Add (new Coo(1,"MEX"));
			_CooList.Add (new Coo(2,"PERU"));
			_CooList.Add (new Coo(3,"CHILE"));
			_CooList.Add (new Coo(4,"NZ"));
			return _CooList;
		}

		public void destroyAddEdit()
		{
			_coo = -1;
		}
	}
}

