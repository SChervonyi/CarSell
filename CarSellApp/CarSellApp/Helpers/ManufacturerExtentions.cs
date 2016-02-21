using System.Collections.Generic;
using System.Linq;
using CarSellApp.Models;
using Domain.Entities;

namespace CarSellApp.Helpers
{
	public static class ManufacturerExtentions
	{
		public static IEnumerable<ManufacturerViewModel> ToViewModels(this IEnumerable<Manufacturer> value)
		{
			return value.Select(x => new ManufacturerViewModel(x));
		}
	}
}