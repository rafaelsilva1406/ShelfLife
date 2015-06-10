namespace ShelfLifeApp.ViewModels
{
	using System;
	using System.ComponentModel;

	public sealed class UserDetailsViewModel : INotifyPropertyChanged
	{
		UserDetailsViewModel()
		{
			
		}

		private static readonly object padLock = new object ();

		private static UserDetailsViewModel _instance = null;
		public static UserDetailsViewModel Instance
		{
			get
			{ 
				if(_instance == null)
				{
					lock(padLock)
					{
						if(_instance == null)
						{
							_instance = new UserDetailsViewModel();
						}
					}
				}
				return _instance;
			}
		}

		private string _userName;
		private string _userPassword;
		private bool _userAuth = false;
			
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

		public bool UserAuth
		{
			get{ return _userAuth; }
			set{ _userAuth = value; }
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
			this._userAuth = false;
		}
	}
}

