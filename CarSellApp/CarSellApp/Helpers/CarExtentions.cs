using System.Collections.Generic;
using System.Linq;
using CarSellApp.Models;
using Domain.Entities;

namespace CarSellApp.Helpers
{
	/// <summary>
	/// Ectentions for <see cref="Car"/>
	/// </summary>
	public static class CarExtentions
	{
		/// <summary>
		/// Convert domain models to view models
		/// </summary>
		/// <param name="value">Domain cars</param>
		/// <returns>Car view model collection</returns>
		public static IEnumerable<CarViewModel> ToViewModels(this IEnumerable<Car> value)
		{
			return value.Select(x => new CarViewModel(x));
		}
	}
}