using System;

namespace ShelfLifeApp.Models
{
	public class CountryOfOrigin
	{
		public CountryOfOrigin (int id, string description)
		{
			ID = id;
			Description = description;
		}

		public int ID {get; set;}

		public String Description {get; set;}
	}
}

