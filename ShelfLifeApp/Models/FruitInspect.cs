using System;

namespace ShelfLifeApp.Models
{
	public class FruitInspect
	{
		public FruitInspect (string color,string stage,string lenticel,string defects,bool cut,string comment)
		{
			Color = color;
			Stage = stage;
			Lenticel = lenticel;
			Defects = defects;
			Cut = cut;
			Comment = comment;
		}

		public string Color {get; set;}

		public string Stage { get; set;}

		public string Lenticel { get; set;}

		public string Defects { get; set;}

		public bool Cut { get; set;}

		public string Comment{ get; set;}
	}
}

