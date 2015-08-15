using System;

namespace ShelfLifeApp.Models
{
	public class Lenticel
	{
		public Lenticel (int id, string description)
		{
			ID = id;
			Description = description;
		}

		public int ID{ get; set;}
		public String Description{ get; set;}
	}
}

