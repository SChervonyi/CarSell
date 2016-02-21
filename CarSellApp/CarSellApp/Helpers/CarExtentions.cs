using System.Collections.Generic;
using System.Linq;
using CarSellApp.Models;
using Domain.Entities;

namespace CarSellApp.Helpers
{
	public static class CarExtentions
	{
		public static IEnumerable<CarViewModel> ToViewModels(this IEnumerable<Car> value)
		{
			return value.Select(x => new CarViewModel(x));
		}
	}
}