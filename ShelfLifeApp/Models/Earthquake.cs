using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace ShelfLifeApp.Models
{
	public class Earthquake
	{
		public string eqid { get; set; }
		public float magnitude { get; set; }
		public float lng { get; set; }
		public string src { get; set; }
		public string datetime { get; set; }
		public float depth { get; set; }
		public float lat { get; set; }
	}
}

