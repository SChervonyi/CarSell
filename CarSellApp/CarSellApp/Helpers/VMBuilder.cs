using System.Collections.Generic;
using System.Linq;
using CarSellApp.Models;
using Domain.Entities;

namespace CarSellApp.Helpers
{
    static class VMBuilder
	{
	    public static IEnumerable<CarViewModel> BuildCarsVM(IEnumerable<Car> cars)
	    {
		    return cars.Select(x => new CarViewModel(x));
	    }

		public static IEnumerable<ManufacturerViewModel> BuildManufacturersVM(IEnumerable<Manufacturer> manufacturers)
		{
			return manufacturers.Select(x => new ManufacturerViewModel(x));
		}
	}
}