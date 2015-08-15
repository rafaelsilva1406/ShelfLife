using System;

namespace ShelfLifeApp.Models
{
	public class Defect
	{
		public Defect (int id, string desciption)
		{
			ID = id;
			Description = desciption;
		}

		public int ID{ get; set;}
		public String Description{ get; set;}
	}
}

