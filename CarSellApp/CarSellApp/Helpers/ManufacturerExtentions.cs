using System.Collections.Generic;
using System.Linq;
using CarSellApp.Models;
using Domain.Entities;

namespace CarSellApp.Helpers
{
	/// <summary>
	/// Ectentions for <see cref="Manufacturer"/>
	/// </summary>
	public static class ManufacturerExtentions
	{
		/// <summary>
		/// Convert domain models to view models
		/// </summary>
		/// <param name="value">Domain manufacturers</param>
		/// <returns>Manufacturer view model collection</returns>
		public static IEnumerable<ManufacturerViewModel> ToViewModels(this IEnumerable<Manufacturer> value)
		{
			return value.Select(x => new ManufacturerViewModel(x));
		}
	}
}