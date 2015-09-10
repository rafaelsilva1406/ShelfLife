using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using ShelfLifeApp.Models;

namespace ShelfLifeApp
{
	public sealed class UserSelectionService
	{
		private static UserSelectionService instance = null;
		private List<UserSelection> UserSelectList = new List<UserSelection> ();
		private int GroupId = 0; 

		public List<UserSelection> GetUserSelectedList()
		{			
			//here I can grab local GroupId pass to the sql and return data 
			this.UserSelectList.Add (new UserSelection(0, 1, 0, "CALI", new DateTime(1990,12,14)));
			this.UserSelectList.Add (new UserSelection (0, 1, 1, "MEX", new DateTime (1990, 12, 14)));
			this.UserSelectList.Add (new UserSelection (0, 1, 2, "PERU", new DateTime (1990, 12, 14)));
			this.UserSelectList.Add (new UserSelection (0, 1, 3, "CHILE", new DateTime (1990, 12, 14)));
			this.UserSelectList.Add (new UserSelection (0, 1, 4, "NZ", new DateTime (1990, 12, 14)));
			return this.UserSelectList;
		}
			
		private UserSelectionService(int groupId)
		{
			this.GroupId = groupId;
		}

		public static UserSelectionService getIstance(int groupId)
		{
			if (instance == null)
			{
				instance = new UserSelectionService(groupId);
			}
			return instance;
		}
	}
}

