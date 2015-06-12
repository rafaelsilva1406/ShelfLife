﻿using System.Collections.ObjectModel;
using System.Linq;

namespace ShelfLifeApp.ViewModels
{
	using System;
	using System.ComponentModel;

	public sealed class UserDetailsViewModel : BaseViewModel
	{
		
		UserDetailsViewModel()
		{
			
		}

		private static readonly object padLock = new object ();
		public ObservableCollection<FruitSample> _FruitList = new ObservableCollection<FruitSample>();
		private static UserDetailsViewModel _Instance = null;
		public static UserDetailsViewModel Instance
		{
			get
			{ 
				if(_Instance == null)
				{
					lock(padLock)
					{
						if(_Instance == null)
						{
							_Instance = new UserDetailsViewModel();
							_Instance._FruitList = InitSamples ();
						}
					}
				}
				return _Instance;
			}
		}

		private string _userName;
		private string _userPassword;
		private int _currentFacility = -1;
		private bool _isUserAuth = false;
			
		public string UserName
		{
			get{ return _userName; }
			set{ 
				if (value.Equals(_userName, StringComparison.Ordinal))
				{
					// Nothing to do - the value hasn't changed;
					return;
				}
				_userName = value;
				OnPropertyChanged();
			}
		}

		public string UserPassword
		{
			get{ return _userPassword; }
			set{ 
				if(value.Equals(_userPassword, StringComparison.Ordinal))
				{
					return;
				}
				_userPassword = value;
				OnPropertyChanged ();
			}
		}

		public int CurrentFacility
		{
			get{ return _currentFacility; }
			set{ 
				if(_currentFacility == value){
					return;
				}
				_currentFacility = value;
				OnPropertyChanged ();
			}
		}

		public bool isUserAuth
		{
			get{ return _isUserAuth; }
			set{ _isUserAuth = value; }
		}

		//the view will register to this event when the DataContext is set
		public event PropertyChangedEventHandler PropertyChanged;
			
		protected void OnPropertyChanged(string propertyName = null)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public void destroyUser()
		{
			this._userName = "";
			this._userPassword = "";
			this._currentFacility = -1;
			this._isUserAuth = false;
		}

		public int CaliCount{
			get{
				return _FruitList.Where (f => f.Origin.ID == 0).Count();
			}
		}
		public int MexCount{
			get{
				return _FruitList.Where (f => f.Origin.ID == 1).Count ();
			}
		}
		public int PeruCount{
			get{
				return _FruitList.Where (f => f.Origin.ID == 2).Count ();
			}
		}

		private static ObservableCollection<FruitSample> InitSamples(){
			var _VarFruitList = new  ObservableCollection<FruitSample>
			{
				new FruitSample(0, new CountryOfOrigin(){Description = "Cali", ID = 0}, "Camino del Sol", new DateTime(1975, 1, 15), 
					"Large", 13, DateTime.Now),
				new FruitSample(1, new CountryOfOrigin(){Description = "Mexico", ID = 1}, "Mission de Mexico", new DateTime(1975, 1, 15), 
					"Small", 10, DateTime.Now),
				new FruitSample(2, new CountryOfOrigin(){Description = "Peru", ID = 2}, "Camposol", new DateTime(1975, 1, 15), 
					"Medium", 16, DateTime.Now),
				new FruitSample(3, new CountryOfOrigin(){Description = "Cali", ID = 0}, "Camino del Sol", new DateTime(2015, 1, 15), 
					"Medium", 16, DateTime.Now.AddDays(-1)),

			};
			return _VarFruitList;
		}
	}
}

