using System;

namespace ShelfLifeApp.Models
{
	public class CurrentFacility
	{
		public CurrentFacility (int id,String name)
		{
			ID = id;
			Name = name;
		}

		public int ID { get; set;}

		public String Name { get; set; }
	}
}

