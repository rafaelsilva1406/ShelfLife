using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using ShelfLifeApp.Models;

namespace ShelfLifeApp.ViewModels
{
	public sealed class UserDetailsViewModel : BaseViewModel
	{
		
		UserDetailsViewModel()
		{
			
		}

		private static readonly object padLock = new object ();
		private static UserDetailsViewModel _Instance = null;
		public List<CurrentFacility> _CurrentFacilityList = new List<CurrentFacility>();
		private string _userName;
		private string _userPassword;
		private int _currentFacility = -1;
		private bool _isUserAuth = false;
		private int _domain = 0;
		public List<string> _Domains = new List<string>();

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
						}
					}
				}
				return _Instance;
			}
		}
						
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

		public int Domain
		{
			get{ return _domain; }
			set{ 
				if(_domain == value){
					return;
				}
				_domain = value;
				OnPropertyChanged ();
			}
		}

		public List<string> GetDomains()
		{
			_Domains.Add ("MISSIONPRO");
			return _Domains;
		}
			
		public void destroyUser()
		{
			_userName = "";
			_userPassword = "";
			_currentFacility = -1;
			_isUserAuth = false;
			_domain = 0;
			//_Domains.Clear ();
		}
			
		public List<CurrentFacility> GetDefaultCurrentFacilities()
		{
			_CurrentFacilityList.Add(new CurrentFacility(0,"CD"));
			_CurrentFacilityList.Add (new CurrentFacility(1, "NJ"));
			_CurrentFacilityList.Add (new CurrentFacility(2, "TX"));
			_CurrentFacilityList.Add (new CurrentFacility (3, "MX"));
			_CurrentFacilityList.Add (new CurrentFacility (4, "AP"));
			return _CurrentFacilityList;
		}
	}
}

