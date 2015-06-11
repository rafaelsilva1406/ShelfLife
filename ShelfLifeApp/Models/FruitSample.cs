using System;

namespace ShelfLifeApp
{
	public class FruitSample
	{
		public FruitSample (int id, CountryOfOrigin origin, string packer, DateTime packdate, string size, int age)
		{
			ID = id;
			Origin = origin;
			Packer = packer;
			PackDate = packdate;
			Size = size;
			Age = age;
		}

		public int ID {get; set;}

		public CountryOfOrigin Origin {get; set;}

		public string Packer {get; set;}

		public DateTime PackDate {get; set;}

		public String Size { get; set;}

		public int Age { get; set;}

		public string SampleID {
			get{
				return ID.ToString ();
			}
		}
	}
}

