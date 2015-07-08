using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace ShelfLifeApp.Models
{
	public class Earthquake
	{
		public string eqid { get; set; }
		public string magnitude { get; set; }
		public string lng { get; set; }
		public string src { get; set; }
		public string datetime { get; set; }
		public string depth { get; set; }
		public string lat { get; set; }
	}
}

