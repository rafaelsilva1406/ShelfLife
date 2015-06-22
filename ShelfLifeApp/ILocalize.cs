using System;
using System.Globalization;
namespace ShelfLifeApp
{
	public interface ILocalize
	{
		CultureInfo GetCurrentCultureInfo ();
	}
}

