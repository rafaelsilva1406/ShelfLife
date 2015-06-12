using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace ShelfLifeApp
{
	public class HomeViewModel : BaseViewModel
	{
		

		public HomeViewModel ()
		{
		}
		private static readonly object _PadLock = new object ();
		private static HomeViewModel _Instance = null;

		public static HomeViewModel Instance
		{
			get
			{ 
				if(_Instance == null)
				{
					lock(_PadLock)
					{
						if (_Instance == null) {
							_Instance = new HomeViewModel ();

						}
					}
				}

				return _Instance;
			}
		}


	}
}

