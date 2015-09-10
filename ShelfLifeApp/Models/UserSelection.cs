using System;

namespace ShelfLifeApp.Models
{
	public class UserSelection
	{
		public UserSelection (int rowId, int groupId, int sequence, string normalizedDesc, DateTime expirationDate)
		{
			RowId = rowId;
			GroupId = groupId;
			Sequence = sequence;
			NormalizeDesc = normalizedDesc;
			ExpirationDate = expirationDate;
		}

		public int RowId { get; set;}
		public int GroupId { get; set;}
		public int Sequence { get; set;}
		public string NormalizeDesc { get; set;}
		public DateTime ExpirationDate { get; set;}
	}
}

