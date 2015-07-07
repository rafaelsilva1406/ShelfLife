using System;

namespace ShelfLifeApp.Models
{
	public class Region
	{
		public Region (int id,String name)
		{
			ID = id;
			Name = name;
		}

		public int ID { get; set;}
		public String Name { get; set;}
	}
}

